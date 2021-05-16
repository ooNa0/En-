package View;
import javax.swing.JPanel;

import Controller.MainMenu;

import java.awt.Graphics;
import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.JFrame;

public class ShowPanel{
	JFrame frame;
	private Image background =new ImageIcon(MainMenu.class.getResource("../View/ImageSearch.png")).getImage();//배경이미지
	
	public JPanel createPanel() {

		//JPanel panel = new JPanel();
		JPanel panel = new JPanel() {
			public void paint(Graphics g) {//그리는 함수
				g.drawImage(background, 0, 0, null);//background를 그려줌
				setOpaque(false); //그림을 표시하게 설정,투명하게 조절
		        super.paint(g);
			}
		};
		panel.setLayout(null); //패널의 Layout을 NULL
		panel.setBounds(0, 0, 700, 500); //패널의 크기 및 위치 지정 (x,y로 부터 넓이(width, 높이(height))
		return panel;
	  
		//JTextArea testArea = new JTextArea();  //JTextArea 생성
	    //testArea.setBounds(50, 50, 300, 300); //JTeatArea 크기 및 위치 지정
	    //testArea.setEditable(false); //실행시 JtextArea edit 금지 (글을 쓸 수 없음) true면 가능

		//JButton imageSearchButton = new JButton("이미지 서치");  //버튼 생성
		//JButton searchHistoryButton = new JButton("검색 내역 보기");
		}
}
