package Controller;

import javax.swing.*;
@SuppressWarnings("serial")


public class MainMenu extends JFrame {
	public MainMenu() {
		
	}
	
	public void startMenu() {
		setLayout(null); //Layout을 NULL로 설정 (컴포넌트의 위치를 사용자가 설정해주어야 함)
		setTitle("Image Search Program"); //Frame의 타이틀 이름 주기
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); //Frame의 X를 누를경우 "제대로" 종료
		setSize(700, 500); //Frame의 크기 설정
		setResizable(false); // 창 크기 수정 불가능하게
		createPanel();
		setVisible(true); //생성한 Frame을 윈도우에 뿌리기
	}
	
	private void createPanel() {
		JPanel panel = new JPanel(); //패널을 생성
		panel.setLayout(null); //패널의 Layout을 NULL
		panel.setBounds(0, 0, 700, 500); //패널의 크기 및 위치 지정 (x,y로 부터 넓이(width, 높이(height))
	  
		//JTextArea testArea = new JTextArea();  //JTextArea 생성
	    //testArea.setBounds(50, 50, 300, 300); //JTeatArea 크기 및 위치 지정
	    //testArea.setEditable(false); //실행시 JtextArea edit 금지 (글을 쓸 수 없음) true면 가능

		JButton a = new JButton("이미지 서치");  //버튼 생성
		JButton b = new JButton("검색 내역 보기");
		a.setBounds(70, 250, 200, 70); //크기 지정
		b.setBounds(400, 250, 200, 70);
	  
  	    //panel.add(testArea); //패널에 TextArea add
	    panel.add(a); //패널에 버튼 add
	    panel.add(b); 
	    this.add(panel);  //Frame에 Panel add (JFrame을 상속받았기에 this(생략가능)가 JFrame)
	}
}
