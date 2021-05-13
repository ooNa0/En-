package Controller;

//import javax.swing.*;
import javax.swing.JFrame;
import javax.swing.JPanel;

import View.SetFrame;

import javax.swing.JButton;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
@SuppressWarnings("serial")


public class MainMenu extends JFrame {
	private JPanel panel;
	private JButton imageSearchButton;
	private JButton searchHistoryButton;
	private SetFrame setFrame;
	public MainMenu() {
		panel = new JPanel(); //패널을 생성
		imageSearchButton = new JButton("이미지 찾기");
		searchHistoryButton = new JButton("검색 내역 보기");
		setFrame = new SetFrame();
	}
	public void startMenu() {
		setLayout(null); //Layout을 NULL로 설정 (컴포넌트의 위치를 사용자가 설정해주어야 함)
		//setFrame.createFrame();
		setTitle("Image Search"); //Frame의 타이틀 이름 주기
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(700, 500); //Frame의 크기 설정
		setResizable(false); // 창 크기 수정 불가능하게
		setLocationRelativeTo(null); // 창 화면 가운데에 나오도록
        //setVisible(true);
		createPanel();
		setVisible(true); //생성한 Frame을 윈도우에 뿌리기
		imageSearchButton.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				new ImageSearch("아진짜");
				//setVisible(false);
			}
            // 만들어진 버튼에 버튼이 눌러지면 발생하는 행동 정의
		});
		searchHistoryButton.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				new SearchHistory(setFrame);
				//setVisible(false);
			}
            // 만들어진 버튼에 버튼이 눌러지면 발생하는 행동 정의
		});
		
	}
	
	private void createPanel() {
		panel.setLayout(null); //패널의 Layout을 NULL
		panel.setBounds(0, 0, 700, 500); //패널의 크기 및 위치 지정 (x,y로 부터 넓이(width, 높이(height))
	  
		//JTextArea testArea = new JTextArea();  //JTextArea 생성
	    //testArea.setBounds(50, 50, 300, 300); //JTeatArea 크기 및 위치 지정
	    //testArea.setEditable(false); //실행시 JtextArea edit 금지 (글을 쓸 수 없음) true면 가능

		//JButton imageSearchButton = new JButton("이미지 서치");  //버튼 생성
		//JButton searchHistoryButton = new JButton("검색 내역 보기");
		imageSearchButton.setBounds(70, 250, 200, 70); //크기 지정
		searchHistoryButton.setBounds(400, 250, 200, 70);
	  
  	    //panel.add(testArea); //패널에 TextArea add
	    panel.add(imageSearchButton); //패널에 버튼 add
	    panel.add(searchHistoryButton); 
	    this.add(panel);  //Frame에 Panel add (JFrame을 상속받았기에 this(생략가능)가 JFrame)
	}
}
