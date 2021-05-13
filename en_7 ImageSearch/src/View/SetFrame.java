package View;

import javax.swing.JFrame;

@SuppressWarnings("serial")
public class SetFrame extends JFrame {
	 public SetFrame() {
	        //CreateUI("글자 입력창 만들기");
	        //setContentPane(Comp.UIComponents());
	    }
	 public void createFrame() {
		 	setTitle("Image Search"); //Frame의 타이틀 이름 주기
	        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	        setSize(700, 500); //Frame의 크기 설정
			setResizable(false); // 창 크기 수정 불가능하게
			setLocationRelativeTo(null); // 창 화면 가운데에 나오도록
	        setVisible(true);
	    }
}
