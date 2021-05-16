package Controller;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.net.MalformedURLException;
import java.net.URL;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.JTextField;
import javax.swing.event.MenuDragMouseEvent;
import javax.swing.event.MouseInputAdapter;
import javax.swing.table.DefaultTableModel;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;

import Model.Constant;
import Model.DataBase;
import Model.KakaoAPI;

@SuppressWarnings("serial")
public class ImageSearch extends JFrame{
	JLabel label;
	DataBase database = new DataBase();
	JTable table = new JTable();
	JScrollPane scrollpane;
	JSONArray jsonArray1;
	JLabel imageLabel;
	public ImageSearch(){
		JPanel panel = new JPanel();
		panel.setBackground(new Color(Constant.PANEL_COLOR_GREY_SET,
				Constant.PANEL_COLOR_GREY_SET,
				Constant.PANEL_COLOR_GREY_SET));
		
		JLabel la = new JLabel(Constant.LABEL_SEARCHITEM_INFORMATION);
		JTextField inputSearchText = new JTextField(15);
    	
		setTitle("Image Search"); //Frame의 타이틀 이름 주기
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(Constant.FRAME_HORIZONTAL_SIZE, Constant.FRAME_VERTICAL_SIZE); //Frame의 크기 설정
		setResizable(false); // 창 크기 수정 불가능하게
		setLocationRelativeTo(null); // 창 화면 가운데에 나오도록
		
		JButton backButton = new JButton("뒤로가기");
		JButton searchButton = new JButton("검색하기");
		Integer[] numbers = {5, 10, 15, 20, 25, 30};
		JComboBox<Integer> comboBox = new JComboBox<Integer>(numbers);
		panel.add(comboBox);
		panel.add(la);
		panel.add(inputSearchText);
		panel.add(searchButton);
		panel.add(backButton);
		add(panel, BorderLayout.NORTH);
		setVisible(true);
		
		backButton.addActionListener(new ActionListener() { // 뒤로가기 버튼
			@Override
			public void actionPerformed(ActionEvent e) {
					setVisible(false);
					new MainMenu().startMenu();
					
			}
		});
		searchButton.addActionListener(new ActionListener() { // 찾기 버튼
			@Override
			public void actionPerformed(ActionEvent e) {
				JPanel imagePanel = new JPanel();
				String searchItem = inputSearchText.getText();
				GridLayout layout = new GridLayout(3,3, 1, 1);
				imagePanel.setLayout(layout);

				add(imagePanel);
				setVisible(true);
				
				jsonArray1 = new KakaoAPI().getImageData(searchItem, comboBox.getSelectedItem().toString());
				
				database.inputDataBase(searchItem);
					// 검색하기 버튼을 누르면, 그 값을 입력받아서 query에 보냄
					// 그걸 출력
				
				for(int i=0; i<jsonArray1.size(); i++){          
	                   JSONObject objectInArray = (JSONObject) jsonArray1.get(i);
	                   try {
						URL url = new URL(objectInArray.get("thumbnail_url").toString());//image_url
	                	ImageIcon img = new ImageIcon(url);
	                	imageLabel = new JLabel(img);
	                	System.out.println("이미지 레이블>");
	                	System.out.println(imageLabel);
	                	imageLabel.addMouseListener(new MyMouseListener());
	                	imagePanel.add(imageLabel);
					} catch (MalformedURLException e1) {
						// TODO Auto-generated catch block
						e1.printStackTrace();
					}
		            	setVisible(true);
				}
				setVisible(true);
			}
		});			
	}
	class MyMouseListener extends MouseInputAdapter{
		@Override
		public void mouseClicked(MouseEvent e) {
			if(e.getClickCount() == 2) { // 더블클릭의 경우				
				JLabel clickLabel = (JLabel)e.getSource(); // 마우스가 클릭된 컴포넌트
				System.out.println("체크 레이블>");
				System.out.println(clickLabel);		
				new newWindow(clickLabel);
			}
		}
	}
	class newWindow extends JFrame {
	    // 버튼이 눌러지면 만들어지는 새 창을 정의한 클래스
	    newWindow(JLabel clickLabel) {
	        setTitle("Image");
	        for(int i=0; i<jsonArray1.size(); i++){   
                JSONObject objectInArray = (JSONObject) jsonArray1.get(i);
    	        System.out.println(clickLabel.getIcon().toString());
    	        System.out.println(objectInArray.get("thumbnail_url").toString());
    	        System.out.println(clickLabel.getIcon().toString().equals( objectInArray.get("thumbnail_url").toString()));
	        	if(clickLabel.getIcon().toString().equals( objectInArray.get("thumbnail_url").toString())) {
	    	        System.out.println("클릭");
					try {
						URL url = new URL(objectInArray.get("image_url").toString());
	                	ImageIcon img = new ImageIcon(url);
		    	        JLabel showLabel = new JLabel(img);
		    	        JPanel NewWindowContainer = new JPanel();
		    	        setContentPane(NewWindowContainer);
		    	        NewWindowContainer.add(showLabel);
		    	        setSize(Integer.parseInt(String.valueOf(objectInArray.get("width")))+50, Integer.parseInt(String.valueOf(objectInArray.get("height")))+50);
					} catch (MalformedURLException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}//image_url 
	    	        setResizable(false);
	    	        setVisible(true);
	        	}
	        	}
                
	    }
	}
}
