package Controller;

//import javax.swing.*;
import javax.swing.JFrame;
import javax.swing.JPanel;

import View.SetFrame;
import View.ShowPanel;

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
		//panel = new JPanel(); //패널을 생성
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
		panel = new ShowPanel().createPanel();
		imageSearchButton.setBounds(70, 250, 200, 70); //크기 지정
		searchHistoryButton.setBounds(400, 250, 200, 70);
	  
  	    //panel.add(testArea); //패널에 TextArea add
	    panel.add(imageSearchButton); //패널에 버튼 add
	    panel.add(searchHistoryButton); 
	    this.add(panel);  //Frame에 Panel add (JFrame을 상속받았기에 this(생략가능)가 JFrame)
	
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
	
	
}
