package Controller;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Container;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;
import java.net.http.HttpHeaders;
import java.net.http.HttpResponse;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import javax.imageio.ImageIO;
/*
import com.ch.yoon.kakao.pay.imagesearch.repository.model.imagesearch.request.ImageSearchRequest;
import com.ch.yoon.kakao.pay.imagesearch.repository.model.imagesearch.response.DetailImageInfo;
import com.ch.yoon.kakao.pay.imagesearch.repository.model.imagesearch.response.ImageSearchResult;
import org.json.JSONArray;
import org.json.JSONObject;
*/
import javax.net.ssl.HttpsURLConnection;
import javax.swing.ComboBoxModel;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JPanel;
import javax.swing.JTextField;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;

import Model.KakaoAPI;
import View.ImageSearchMenu;
import View.SetFrame;

public class ImageSearch extends JFrame{// implements ActionListener, KeyListener 
	/*private SetFrame setFrame;
	public ImageSearch(SetFrame setFrame) {
		this.setFrame = setFrame;
	}*/
	//JFrame frame ;
	JLabel label;
	//JButton backButton = new JButton("뒤로가기");
	//JButton searchButton = new JButton("검색하기");

	//public ImageSearch() {
	public ImageSearch(String labelName){//
		//new ImageSearchMenu().main(null);
		JPanel panel = new JPanel();
		panel.setBackground(new Color(120,255,0));
		//panel.setPreferredSize(new Dimension(400, 60));
		JLabel la = new JLabel("검색할 것 입력:");
		JTextField inputSearchText = new JTextField(15);
		//inputSearchText.addKeyListener(this);
		//setLayout(null); //Layout을 NULL로 설정 (컴포넌트의 위치를 사용자가 설정해주어야 함)
		//setFrame.createFrame();
		setTitle("Image Search"); //Frame의 타이틀 이름 주기
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(700, 500); //Frame의 크기 설정
		setResizable(false); // 창 크기 수정 불가능하게
		setLocationRelativeTo(null); // 창 화면 가운데에 나오도록
		//setVisible(true); //생성한 Frame을 윈도우에 뿌리기
		
		//Container containerPanel = getContentPane(); // 화면 패널 얻어오기
		//containerPanel.setLayout(null);		

		//c.setLayout(new FlowLayout());
		JButton backButton = new JButton("뒤로가기");
		//backButton.addActionListener(this);
		JButton searchButton = new JButton("검색하기");
		//searchButton.addActionListener(this);
		Integer[] numbers = {5, 10, 15, 20, 25, 30};
		JComboBox<Integer> comboBox = new JComboBox<Integer>(numbers);
		panel.add(comboBox);
		panel.add(la);
		panel.add(inputSearchText);
		panel.add(searchButton);
		panel.add(backButton);
		add(panel, BorderLayout.NORTH);
		setVisible(true);
		
		
		//inputSearchText.addActionListener(this); // 엔터 누르면 버튼 실행
		
		backButton.addActionListener(new ActionListener() { // 뒤로가기 버튼
			@Override
			public void actionPerformed(ActionEvent e) {
					//setVisible(false);
					new MainMenu().startMenu();
			}
		});
		searchButton.addActionListener(new ActionListener() { // 찾기 버튼
			@Override
			public void actionPerformed(ActionEvent e) {
					//setVisible(false);
				JPanel imagePanel = new JPanel();
				GridLayout layout = new GridLayout(3,3, 1, 1);
				//imagePanel.setBackground(new Color(120,0,0));
				imagePanel.setLayout(layout);

				add(imagePanel);
				setVisible(true);
				JSONArray jsonArray1 = new KakaoAPI().getImageData(inputSearchText.getText(), comboBox.getSelectedItem().toString());
					// 검색하기 버튼을 누르면, 그 값을 입력받아서 query에 보냄
					// 그걸 출력
				
				for(int i=0; i<jsonArray1.size(); i++){
	                   //System.out.println("검색결과"+ i +" : " +jsonArray1.get(i));            
	                   JSONObject objectInArray = (JSONObject) jsonArray1.get(i);
	                   try {
						URL url = new URL(objectInArray.get("thumbnail_url").toString());//image_url
	                	ImageIcon img = new ImageIcon(url);
	                	JLabel imageLabel = new JLabel(img);
	                	imagePanel.add(imageLabel);
					} catch (MalformedURLException e1) {
						// TODO Auto-generated catch block
						e1.printStackTrace();
					}

		            		setVisible(true);
		            		//pack();
		                	//imageLabel.setText("dkdkdkdk");
		                	//imageLabel.setOpaque(true);
		                	//imageLabel.setBackground(Color.GRAY);
		    		        //add(imageLabel);
		    		        //add(panel);
		    				//setVisible(true);
				}
			}
		});
		
	}/*
	@Override 
	public void actionPerformed(ActionEvent e)
	{ 
		if (e.getSource() == loginButton) 
		{ //...동작을 실행한다. 
			
		}
	}

	@Override 
	public void actionPerformed(ActionEvent e) 
	{ 
		if (e.getSource() == backButton)
		{ //...동작을 실행한다. } } //엔터를 눌렀을 때의 액션 
			public void keyPressed(KeyEvent e)
			{ 
				if (e.getKeyCode() == KeyEvent.VK_ENTER) 
				{ //...동작을 실행한다.
					
				}
			}
		}
	}*/
	
		

	/*
	private void search() {
        // 콤보박스 값 알아내기 - 검색기준
        String field = (String)combo.getSelectedItem();
        
        // 텍스트필드값 알아오기 - 검색어
        String word = search.getText();
        Vector<Vector> sresult = new Vector<>();
        // 찾아서 가져오기
        int index = 1;
        if(field.equals("주소")){
            index = 3;
        }
        for(Vector<String> in : outer){
            if(word.equals(in.get(index))){
                sresult.add(in);
            }
        }
        // 검색결과 체크후 테이블에 표시
        if(sresult.size()>0){
            model.setDataVector(sresult, title);
        }else{
            showMessage("검색 결과가 없습니다.");
        }
    }	*/
		
	/*
	ComboBoxModel<Int> items = {10, 20, 30};
	JComboBox<Int> comboBox = new JComboBox<Int>(items);
	JComboBox<Int> combo;MemberBook() {
		try {
			makeGui();
			initTable(); // 테이블 초기화		
		} catch(Exception e) {
			e.printStackTrace();
		}
	}
	private void makeGui() {
		frame = new JFrame("StarMall Member Book");
		label = new JLabel("스타몰 회원 리스트",JLabel.CENTER);
		Font font = new Font("맑은 고딕", Font.BOLD, 30); //***
		label.setFont(font); //***
		num = new JLabel(" 번 호:  ",JLabel.CENTER);
		fnum = new JTextField(15);
		pid = new JPanel();
		pid.add(num);
		pid.add(fnum);

		name = new JLabel("이 름 : ");
		fname = new JTextField(15);
		pname = new JPanel();
		pname.add(name);
		pname.add(fname);

		phone = new JLabel("전 화 : ");
		fphone = new JTextField(15);
		pphone = new JPanel();
		pphone.add(phone);
		pphone.add(fphone);
	}*/
		
		/*
		 * try 
		 
        {
            //String text = URLEncoder.encode("안녕하세요", "UTF-8");//번역될 문장
     
            String postParams = "src_lang=kr&target_lang=en&query=번역해주세요"; 
            
            String apiURL = "https://kapi.kakao.com/v1/translation/translate?"+postParams;
            URL url = new URL(apiURL);
            HttpsURLConnection con = (HttpsURLConnection)url.openConnection();

            con.setRequestMethod("GET");

            con.setRequestProperty("Authorization", "KakaoAK {4d74071d3fbd89dfcb53c6ab3e6dd5e0}");
        	Map<String, List<String>> map = con.getRequestProperties();
        	 
        	System.out.println("Printing Response Header...\n");
         
        	for (Entry<String, List<String>> entry : map.entrySet()) {
        		System.out.println("Key : " + entry.getKey() 
                                   + " ,Value : " + entry.getValue());
        	}
            
            
            con.setUseCaches(false);
            con.setDoInput(true);
            con.setDoOutput(true);
         
            int responseCode = con.getResponseCode(); //
            BufferedReader br;
            if(responseCode==200) 
            { // 정상 호출
                br = new BufferedReader(new InputStreamReader(con.getInputStream())); 
            } 
            else 
            {  // 에러 발생
                br = new BufferedReader(new InputStreamReader(con.getErrorStream()));
            }
            String inputLine;
            StringBuffer res = new StringBuffer();
            while ((inputLine = br.readLine()) != null) 
            {
            	res.append(inputLine);
            }
            br.close();
            System.out.println("sd>>  "+res.toString());
            
 
        } 
        catch (Exception e) 
        {
        	System.out.println("--확인용-- T_TranslatorNaver.java에서 오류 발생" );
            System.out.println(e);
        }*/
		
}
