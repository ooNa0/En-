package Controller;

import java.awt.Container;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.URL;
import java.net.URLEncoder;
import java.net.http.HttpHeaders;
import java.net.http.HttpResponse;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
/*
import com.ch.yoon.kakao.pay.imagesearch.repository.model.imagesearch.request.ImageSearchRequest;
import com.ch.yoon.kakao.pay.imagesearch.repository.model.imagesearch.response.DetailImageInfo;
import com.ch.yoon.kakao.pay.imagesearch.repository.model.imagesearch.response.ImageSearchResult;
import org.json.JSONArray;
import org.json.JSONObject;
*/
import javax.net.ssl.HttpsURLConnection;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JList;

import View.SetFrame;

public class ImageSearch extends JFrame {
	/*private SetFrame setFrame;
	public ImageSearch(SetFrame setFrame) {
		this.setFrame = setFrame;
	}*/
	JLabel la = new JLabel("You");
	ImageSearch(String labelName){
		super("YourFrame");
		
		
		setLayout(null); //Layout을 NULL로 설정 (컴포넌트의 위치를 사용자가 설정해주어야 함)
		//setFrame.createFrame();
		setTitle("Image Search"); //Frame의 타이틀 이름 주기
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(700, 500); //Frame의 크기 설정
		setResizable(false); // 창 크기 수정 불가능하게
		setLocationRelativeTo(null); // 창 화면 가운데에 나오도록
		setVisible(true); //생성한 Frame을 윈도우에 뿌리기
		
		
		Container containerPanel = getContentPane(); // 화면 패널 얻어오기
		containerPanel.setLayout(null);
		
		//c.setLayout(new FlowLayout());
		JButton backBtn = new JButton("back");
		backBtn.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
					//setVisible(false);
					new MainMenu().startMenu();
			}
		});
		
		String auth = "KakaoAK " + "4d74071d3fbd89dfcb53c6ab3e6dd5e0";
		HttpsURLConnection hc;
		try {
			URL link = new URL("https://dapi.kakao.com/v2/search/image.json?query=cat&&size=3");
			// 접속
			hc = (HttpsURLConnection)link.openConnection();
			// 요청 헤더 추가
			hc.setRequestMethod("GET");
			hc.setRequestProperty("User-Agent", "Java-Client");	// https 호출시 user-agent 필요
			hc.setRequestProperty("X-Requested-With", "curl");
			hc.setRequestProperty("Authorization", auth);

            int responseCode = hc.getResponseCode(); //
            BufferedReader br;
            if(responseCode==200) 
            { // 정상 호출
                br = new BufferedReader(new InputStreamReader(hc.getInputStream(), "UTF-8")); 
                //서버와 연결되어 있는 스트림을 추출한다.
                //InputStream is = conn.getInputStream();
                //InputStreamReader isr = new InputStreamReader(is, "UTF-8");
                //BufferedReader br = new BufferedReader(isr);
            } 
            else 
            {  // 에러 발생
                br = new BufferedReader(new InputStreamReader(hc.getErrorStream()));
            }

            String inputLine;
            StringBuffer res = new StringBuffer();
            while ((inputLine = br.readLine()) != null) 
            {
            	res.append(inputLine);
            }
            br.close();
            
            System.out.println(res.toString());
            //Component a = res;
            //c.add(res)
		} catch (IOException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}
		
		
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
		/*
		 * String searchItem;
		 
		try {
			String query = "https://dapi.kakao.com/v2/search/image.json?query=고양이"
					+ URLEncoder.encode(searchItem, "UTF-8");
			HttpHeaders headers = new HttpHeaders();
            headers.add("Authorization", "KakaoAK {4d74071d3fbd89dfcb53c6ab3e6dd5e0}");
	//ObjectMapper objectMapper = new ObjectMapper();
	//objectMapper.configure(DeserializationFeature.ACCEPT_SINGLE_VALUE_AS_ARRAY, true);
	//la.setText(labelName);
		}*/
		
		containerPanel.add(la);
		containerPanel.add(backBtn);
		setVisible(true);
	}
}
