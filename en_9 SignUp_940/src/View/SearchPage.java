package View;

import java.awt.EventQueue;
import java.awt.Graphics;
import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.GroupLayout;
import javax.swing.GroupLayout.Alignment;
import javax.swing.JTextField;
import javax.swing.JButton;
import javax.swing.LayoutStyle.ComponentPlacement;

public class SearchPage {

	private JFrame frame;
	private Image searchBackground = new ImageIcon(LoginPage.class.getResource("searchid.png")).getImage(); // 배경이미지
	private Image searchPasswordBackground = new ImageIcon(LoginPage.class.getResource("searchpassword.png"))
			.getImage(); // 배경이미지
	private JTextField textField;

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
		
		textField = new JTextField();
		textField.setColumns(10);
		
		JPanel panel = new JPanel() {
			public void paintComponent(Graphics g) {
				g.drawImage(searchBackground, 0, 0, null);
				setOpaque(false); // 그림을 표시하게 설정,투명하게 조절
			}
		};
		
		JButton searchButton = new JButton("  ");

		searchButton.setContentAreaFilled(false);
		searchButton.setBorderPainted(false);
		searchButton.setFocusPainted(false);
		
		GroupLayout groupLayout = new GroupLayout(panel);
		groupLayout.setHorizontalGroup(
			groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(groupLayout.createSequentialGroup()
					.addGroup(groupLayout.createParallelGroup(Alignment.LEADING)
						.addGroup(groupLayout.createSequentialGroup()
							.addGap(245)
							.addComponent(searchButton, GroupLayout.PREFERRED_SIZE, 148, GroupLayout.PREFERRED_SIZE))
						.addGroup(groupLayout.createSequentialGroup()
							.addGap(201)
							.addComponent(textField, GroupLayout.PREFERRED_SIZE, 249, GroupLayout.PREFERRED_SIZE)))
					.addContainerGap(198, Short.MAX_VALUE))
		);
		groupLayout.setVerticalGroup(
			groupLayout.createParallelGroup(Alignment.TRAILING)
				.addGroup(groupLayout.createSequentialGroup()
					.addGap(153)
					.addComponent(textField, GroupLayout.PREFERRED_SIZE, 33, GroupLayout.PREFERRED_SIZE)
					.addPreferredGap(ComponentPlacement.RELATED, 161, Short.MAX_VALUE)
					.addComponent(searchButton, GroupLayout.PREFERRED_SIZE, 36, GroupLayout.PREFERRED_SIZE)
					.addGap(28))
		);
		panel.setLayout(groupLayout);
		frame.getContentPane().add(panel);
		//frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	}

	public void searchIdentity() {
		//initialize();		
		frame.setVisible(true);
	}

	public void searchPassword() {
		//initialize();
		frame.setVisible(true);
	}
}
