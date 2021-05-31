package View;

import java.awt.EventQueue;

import javax.swing.Icon;
import javax.swing.ImageIcon;
import javax.swing.JFrame;
import java.awt.GridLayout;
import java.awt.Image;
import java.net.URL;

import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JPasswordField;

import java.awt.CardLayout;
import javax.swing.GroupLayout;
import javax.swing.GroupLayout.Alignment;
import javax.swing.LayoutStyle.ComponentPlacement;

import Controller.ActionProcessing;
import Controller.LoginService;
import Model.DataTransferObject;
import Model.DateAccessObject;

import java.awt.Font;
import javax.swing.JTextField;
import javax.swing.JWindow;
import javax.swing.JButton;
import javax.swing.SwingConstants;
import java.awt.Color;
import java.awt.SystemColor;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class LoginPage {

	private JFrame frame;
	private URL url = getClass().getResource("LoginJhin.gif");
	private JTextField identityTextField;
	private JPasswordField passwordTextField;
	private DataTransferObject data;
	
	/**
	 * @wbp.parser.entryPoint
	 */
	public LoginPage() {
		//frame = new JFrame();
		//frame.setBounds(100, 100, 1599, 900);
		//frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		//Login();
	}
	/**
	 * Initialize the contents of the frame.
	 * @wbp.parser.entryPoint
	 */
	//new ImageIcon(getClass().getResource("lol.gif");)
	public void Login() {
		Icon icon = new ImageIcon(url);
		frame = new JFrame();
		frame.setIconImage(new ImageIcon(LoginPage.class.getResource("lol.png")).getImage());
		frame.setBounds(100, 100, 1599, 900);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		//frame.setUndecorated(true);
		JPanel panel = new JPanel();
		panel.setBackground(Color.WHITE);
		//JWindow w = new JWindow();
		//w.setBounds(100, 100, 1599, 900);
		//w.setVisible(true);

		JLabel label = new JLabel(icon);
		GroupLayout groupLayout = new GroupLayout(frame.getContentPane());
		groupLayout.setHorizontalGroup(
			groupLayout.createParallelGroup(Alignment.TRAILING)
				.addGroup(Alignment.LEADING, groupLayout.createSequentialGroup()
					.addComponent(panel, GroupLayout.PREFERRED_SIZE, 389, GroupLayout.PREFERRED_SIZE)
					.addComponent(label, GroupLayout.PREFERRED_SIZE, 1200, GroupLayout.PREFERRED_SIZE))
		);
		groupLayout.setVerticalGroup(
			groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(Alignment.TRAILING, groupLayout.createSequentialGroup()
					.addComponent(panel, GroupLayout.DEFAULT_SIZE, 870, Short.MAX_VALUE)
					.addGap(40))
				.addGroup(Alignment.TRAILING, groupLayout.createSequentialGroup()
					.addComponent(label, GroupLayout.PREFERRED_SIZE, 900, Short.MAX_VALUE)
					.addContainerGap())
		);
		
		JLabel lblNewLabel = new JLabel("\uB85C\uADF8\uC778");
		lblNewLabel.setFont(new Font("나눔고딕 ExtraBold", Font.BOLD, 24));
		
		identityTextField = new JTextField();
		identityTextField.setColumns(10);
		
		passwordTextField = new JPasswordField();
		passwordTextField.setColumns(10);
		
		JButton nextButton = new JButton("->");
		//nextButton.addActionListener(new ActionProcessing());
		nextButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				if(new DateAccessObject().isaccessDataBase(identityTextField, passwordTextField, data)) {

					frame.setVisible(false);
					new UserPage();
				}
				else {
					
				}
				
				//new SignupPage();
			}
            // 찾기 버튼이 눌러지면 발생하는 행동 정의
		});
		nextButton.setContentAreaFilled(false);
		nextButton.setFocusPainted(false);
		
		JButton signUpButton = new JButton("회원가입");
		signUpButton.setHorizontalAlignment(SwingConstants.LEFT);
		//signUpButton.addActionListener(new ActionProcessing(frame, identityTextField, passwordTextField));
		signUpButton.setContentAreaFilled(false);
		signUpButton.setFocusPainted(false);
		signUpButton.setFont(new Font("나눔고딕", Font.PLAIN, 14));
		signUpButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				frame.setVisible(false);
				new SignupPage();
			}
            // 찾기 버튼이 눌러지면 발생하는 행동 정의
		});
		
		JButton findIdentityButton = new JButton("아이디 찾기");
		findIdentityButton.setHorizontalAlignment(SwingConstants.LEFT);
		findIdentityButton.addActionListener(new ActionProcessing());
		findIdentityButton.setContentAreaFilled(false);
		findIdentityButton.setFocusPainted(false);
		findIdentityButton.setFont(new Font("나눔고딕", Font.PLAIN, 14));
		
		JButton findPasswordButton = new JButton("비밀번호 찾기");
		findPasswordButton.setHorizontalAlignment(SwingConstants.LEFT);
		findPasswordButton.addActionListener(new ActionProcessing());
		findPasswordButton.setContentAreaFilled(false);
		findPasswordButton.setFocusPainted(false);
		findPasswordButton.setFont(new Font("나눔고딕", Font.PLAIN, 14));
		
		JLabel lblNewLabel_1 = new JLabel("", new ImageIcon(new ImageIcon(getClass().getResource("lol.png")).getImage().getScaledInstance(70, 70, Image.SCALE_AREA_AVERAGING)), 10);
		
		GroupLayout gl_panel = new GroupLayout(panel);
		gl_panel.setHorizontalGroup(
			gl_panel.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_panel.createSequentialGroup()
					.addGroup(gl_panel.createParallelGroup(Alignment.LEADING)
						.addGroup(gl_panel.createSequentialGroup()
							.addGap(61)
							.addGroup(gl_panel.createParallelGroup(Alignment.LEADING)
								.addComponent(passwordTextField, GroupLayout.PREFERRED_SIZE, 244, GroupLayout.PREFERRED_SIZE)
								.addComponent(identityTextField, GroupLayout.PREFERRED_SIZE, 244, GroupLayout.PREFERRED_SIZE)
								.addComponent(lblNewLabel, GroupLayout.PREFERRED_SIZE, 151, GroupLayout.PREFERRED_SIZE)
								.addComponent(signUpButton)
								.addComponent(findIdentityButton)
								.addComponent(findPasswordButton)
								.addComponent(lblNewLabel_1, GroupLayout.PREFERRED_SIZE, 73, GroupLayout.PREFERRED_SIZE)))
						.addGroup(gl_panel.createSequentialGroup()
							.addGap(143)
							.addComponent(nextButton, GroupLayout.PREFERRED_SIZE, 75, GroupLayout.PREFERRED_SIZE)))
					.addContainerGap(84, Short.MAX_VALUE))
		);
		gl_panel.setVerticalGroup(
			gl_panel.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_panel.createSequentialGroup()
					.addGap(80)
					.addComponent(lblNewLabel_1, GroupLayout.PREFERRED_SIZE, 62, GroupLayout.PREFERRED_SIZE)
					.addGap(18)
					.addComponent(lblNewLabel, GroupLayout.PREFERRED_SIZE, 38, GroupLayout.PREFERRED_SIZE)
					.addGap(27)
					.addComponent(identityTextField, GroupLayout.PREFERRED_SIZE, 48, GroupLayout.PREFERRED_SIZE)
					.addGap(18)
					.addComponent(passwordTextField, GroupLayout.PREFERRED_SIZE, 48, GroupLayout.PREFERRED_SIZE)
					.addGap(126)
					.addComponent(nextButton, GroupLayout.PREFERRED_SIZE, 64, GroupLayout.PREFERRED_SIZE)
					.addPreferredGap(ComponentPlacement.RELATED, 181, Short.MAX_VALUE)
					.addComponent(signUpButton)
					.addGap(18)
					.addComponent(findIdentityButton, GroupLayout.PREFERRED_SIZE, 25, GroupLayout.PREFERRED_SIZE)
					.addGap(18)
					.addComponent(findPasswordButton, GroupLayout.PREFERRED_SIZE, 25, GroupLayout.PREFERRED_SIZE)
					.addGap(49))
		);
		panel.setLayout(gl_panel);
		frame.getContentPane().setLayout(groupLayout);
		//JLabel label = new JLabel(icon);
		frame.getContentPane().add(label);
		//frame.pack();
		frame.setVisible(true);
	}
}
