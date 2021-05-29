package View;

import java.awt.EventQueue;
import java.awt.Graphics;
import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class SearchPage {

	private JFrame frame;
	private Image searchBackground = new ImageIcon(LoginPage.class.getResource("searchid.png")).getImage(); // 배경이미지
	private Image searchPasswordBackground = new ImageIcon(LoginPage.class.getResource("searchpassword.png"))
			.getImage(); // 배경이미지

	/**
	 * Launch the application.
	 */

	/**
	 * Create the application.
	 */
	public SearchPage() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.setBounds(100, 100, 654, 440);
		frame.setTitle("세종대학교 아이디/비밀번호 찾기"); //타이틀
		frame.setIconImage(new ImageIcon(LoginPage.class.getResource("sejongmark.jpeg")).getImage());
		frame.setResizable(false);//창의 크기를 변경하지 못하게
		//frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	}

	public void searchIdentity() {
		//initialize();
		JPanel panel = new JPanel() {
			public void paintComponent(Graphics g) {
				g.drawImage(searchBackground, 0, 0, null);
				setOpaque(false); // 그림을 표시하게 설정,투명하게 조절
			}
		};
		frame.getContentPane().add(panel);
		frame.setVisible(true);
	}

	public void searchPassword() {
		//initialize();
		JPanel panel = new JPanel() {
			public void paintComponent(Graphics g) {
				g.drawImage(searchPasswordBackground, 0, 0, null);
				setOpaque(false); // 그림을 표시하게 설정,투명하게 조절
			}
		};
		frame.getContentPane().add(panel);
		frame.setVisible(true);
	}
}
