package Controller;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.net.MalformedURLException;
import java.net.URL;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Vector;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.JTextField;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;

import Model.DataBase;
import Model.KakaoAPI;
import View.SetFrame;

public class SearchHistory extends JFrame{
	JLabel label;
	DataBase database = new DataBase();
	public SearchHistory() {//SetFrame setFrame
		//JButton backButton = new JButton("뒤로가기");
		//JButton searchButton = new JButton("검색하기")
			//new ImageSearchMenu().main(null);
			JPanel panel = new JPanel();
			panel.setBackground(new Color(140,140,140));
			//panel.setPreferredSize(new Dimension(400, 60));
			JLabel la = new JLabel("검색 기록 보기");
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
			JButton resetButton = new JButton("데이터 베이스 초기화");
			//searchButton.addActionListener(this);
			panel.add(la);
			panel.add(resetButton);
			panel.add(backButton);
			add(panel, BorderLayout.NORTH);
			//setVisible(true);

			JPanel imagePanel = new JPanel();
			//GridLayout layout = new GridLayout(3,3, 1, 1);
			//imagePanel.setBackground(new Color(120,0,0));
			imagePanel.setLayout(new FlowLayout());
			//JTextArea tx = new JTextArea("아아", 10, 30);
			//imagePanel.add(tx);
			Vector queryArray = database.showDataBase();
			JList<?> list = new JList();
			list.setListData(queryArray);
			add(new JScrollPane(list), "Center");
			//System.out.println(queryArray);

			/*try {
				while(queryArray.next()==true){
				       System.out.println("아 오 안될까용");
				       queryArray.close();
				}
			} catch (SQLException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			} finally {
			try {queryArray.close();} catch (SQLException e1) {e1.printStackTrace();}
			}*/
			//add(imagePanel);
			setVisible(true);
			//inputSearchText.addActionListener(this); // 엔터 누르면 버튼 실행
			
			backButton.addActionListener(new ActionListener() { // 뒤로가기 버튼
				@Override
				public void actionPerformed(ActionEvent e) {
						//setVisible(false);
						new MainMenu().startMenu();
				}
			});
			resetButton.addActionListener(new ActionListener() { // 데베 초기화 버튼
				@Override
				public void actionPerformed(ActionEvent e) {
						//setVisible(false);
					database.resetDataBase();
					Vector queryArray = database.showDataBase();
					JList<?> list = new JList();
					list.setListData(queryArray);
					add(new JScrollPane(list), "Center");
					setVisible(true);
						// 그걸 출력
					
				}
			});
			
	}
}
