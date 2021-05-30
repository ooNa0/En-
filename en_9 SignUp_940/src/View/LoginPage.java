package View;
import java.awt.Color;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;

import com.sun.tools.javac.Main;

import Controller.ActionProcessing;
import Controller.LoginService;

import javax.swing.GroupLayout;
import javax.swing.GroupLayout.Alignment;
import javax.swing.JButton;
import javax.swing.LayoutStyle.ComponentPlacement;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

public class LoginPage extends JFrame{

	private JFrame frame;
	private Image background = new ImageIcon(LoginPage.class.getResource("3SEJONGLOGIN.png")).getImage(); //배경이미지
	private JPasswordField passwordField;
	private JTextField textField;

	/**
	 * Launch the application.
	
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					new LoginPage(); //LoginPage window = 
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	} */

	/**
	 * Create the application.
	 * @wbp.parser.entryPoint
	 */
	public LoginPage() {
		//initialize();
	}

	public LoginPage(JTextField textField, JPasswordField passwordField) {
		// TODO Auto-generated constructor stub
		this.textField = textField;
		this.passwordField = passwordField;
	}

	/**
	 * Initialize the contents of the frame.
	 */
	@SuppressWarnings("serial")
	public void initialize() {
		frame = new JFrame();
		frame.setTitle("세종대학교 로그인"); //타이틀
		frame.setIconImage(new ImageIcon(LoginPage.class.getResource("sejongmark.jpeg")).getImage());
		frame.setBounds(100, 100, 834, 608);
		frame.setResizable(false);//창의 크기를 변경하지 못하게
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		passwordField = new JPasswordField(null);		
		textField = new JTextField(null);
		textField.setColumns(10);
		
		//int result= JOptionPane.showConfirmDialog(null, "아이디를 입력해주세요!");
		//JOptionPane.showConfirmDialog(null, "제거하시겠습니까?", "종료", JOptionPane.YES_NO_CANCEL_OPTION, JOptionPane.INFORMATION_MESSAGE);
		
		JButton signUpButton = new JButton("학생가입");
		signUpButton.addActionListener(new ActionProcessing());
		signUpButton.setContentAreaFilled(false);
		signUpButton.setFocusPainted(false);
		signUpButton.setFont(new Font("맑은 고딕", Font.PLAIN, 21));
		
		JButton findIdentityButton = new JButton("아이디 찾기");
		findIdentityButton.addActionListener(new ActionProcessing());
		findIdentityButton.setContentAreaFilled(false);
		findIdentityButton.setFocusPainted(false);
		findIdentityButton.setFont(new Font("맑은 고딕", Font.BOLD, 13));
		
		JButton findPasswordButton = new JButton("비밀번호 찾기");
		findPasswordButton.addActionListener(new ActionProcessing());
		//findPasswordButton.setBorderPainted(false);
		findPasswordButton.setContentAreaFilled(false);
		findPasswordButton.setFocusPainted(false);
		findPasswordButton.setFont(new Font("맑은 고딕", Font.BOLD, 13));
		
		JButton loginButton = new JButton("");
		//loginButton.addActionListener(new ActionProcessing(String.valueOf(passwordField.getPassword()), textField.getText()));
		loginButton.addActionListener(new ActionProcessing(textField, passwordField));
		//loginButton.setBackground(new Color(210, 0, 0));
		loginButton.setContentAreaFilled(false);
		loginButton.setBorderPainted(false);
		loginButton.setFocusPainted(false);
		

		
		JPanel panel = new JPanel() {
            public void paintComponent(Graphics g) {
                // Approach 1: Dispaly image at at full size
                g.drawImage(background, 0, 0, null);
                // Approach 2: Scale image to size of component
                // Dimension d = getSize();
                // g.drawImage(icon.getImage(), 0, 0, d.width, d.height, null);
                // Approach 3: Fix the image position in the scroll pane
                // Point p = scrollPane.getViewport().getViewPosition();
                // g.drawImage(icon.getImage(), p.x, p.y, null);
                setOpaque(false); //그림을 표시하게 설정,투명하게 조절
                //super.paintComponent(g);
            }
        };
        frame.getContentPane().add(panel);
		
		GroupLayout groupLayout = new GroupLayout(panel);
		groupLayout.setHorizontalGroup( // 가로
			groupLayout.createParallelGroup(Alignment.TRAILING)
				.addGroup(groupLayout.createSequentialGroup()
					.addGap(96)
					.addComponent(signUpButton, GroupLayout.PREFERRED_SIZE, 118, GroupLayout.PREFERRED_SIZE)
					.addPreferredGap(ComponentPlacement.RELATED, 140, Short.MAX_VALUE)
					.addComponent(findIdentityButton, GroupLayout.PREFERRED_SIZE, 118, GroupLayout.PREFERRED_SIZE)
					.addGap(132)
					.addComponent(findPasswordButton, GroupLayout.PREFERRED_SIZE, 118, GroupLayout.PREFERRED_SIZE)
					.addGap(106))
				.addGroup(groupLayout.createSequentialGroup()
					.addContainerGap(491, Short.MAX_VALUE)
					.addGroup(groupLayout.createParallelGroup(Alignment.TRAILING, false)
						.addComponent(passwordField)
						.addComponent(textField, GroupLayout.DEFAULT_SIZE, 173, Short.MAX_VALUE))
					.addPreferredGap(ComponentPlacement.RELATED, 1, 1) // 로그인 버튼과 TEXT 필드와의 간격
					.addComponent(loginButton, GroupLayout.PREFERRED_SIZE, 89, GroupLayout.PREFERRED_SIZE) // 로그인 버튼
					.addGap(55))
		);
		groupLayout.setVerticalGroup( // 세로
			groupLayout.createParallelGroup(Alignment.TRAILING)
				.addGroup(groupLayout.createSequentialGroup()
					.addGroup(groupLayout.createParallelGroup(Alignment.TRAILING)
						.addGroup(groupLayout.createSequentialGroup()
							.addContainerGap()
							.addComponent(signUpButton, GroupLayout.PREFERRED_SIZE, 62, GroupLayout.PREFERRED_SIZE))
						.addGroup(groupLayout.createSequentialGroup()
							.addGap(149) // 위 버튼 위치하는 높이
							.addGroup(groupLayout.createParallelGroup(Alignment.LEADING, false)
								.addGroup(groupLayout.createSequentialGroup()
									.addComponent(textField, GroupLayout.PREFERRED_SIZE, 29, GroupLayout.PREFERRED_SIZE)
									.addComponent(passwordField, GroupLayout.PREFERRED_SIZE, 29, GroupLayout.PREFERRED_SIZE))
								.addComponent(loginButton, GroupLayout.PREFERRED_SIZE, 60, GroupLayout.PREFERRED_SIZE))
							.addPreferredGap(ComponentPlacement.RELATED, 271, Short.MAX_VALUE) // 밑에 버튼
							.addGroup(groupLayout.createParallelGroup(Alignment.BASELINE)
								.addComponent(findPasswordButton, GroupLayout.PREFERRED_SIZE, 30, GroupLayout.PREFERRED_SIZE)
								.addComponent(findIdentityButton, GroupLayout.PREFERRED_SIZE, 30, GroupLayout.PREFERRED_SIZE))))
					.addGap(60)) // 밑의 버튼 위아래 차이
		);
		panel.setLayout(groupLayout);
		//JPanel panel = new JPanel()
		
		frame.setVisible(true);//창이 보이게	
	}
	public void paint(Graphics g) {//그리는 함수
		g.drawImage(background, 0, 0, null);//background를 그려줌
	}
}
