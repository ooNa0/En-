package View;

import java.awt.Color;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.net.URL;

import javax.swing.GroupLayout;
import javax.swing.Icon;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;
import javax.swing.SwingConstants;
import javax.swing.GroupLayout.Alignment;
import javax.swing.LayoutStyle.ComponentPlacement;

import Controller.ActionProcessing;
import Model.DataTransferObject;
import Model.DataAccessObject;

import java.awt.BorderLayout;
import com.jgoodies.forms.layout.FormLayout;
import com.jgoodies.forms.layout.ColumnSpec;
import com.jgoodies.forms.layout.RowSpec;
import javax.swing.SpringLayout;
import javax.swing.JComboBox;

public class UserPage{

	private JFrame frame = new JFrame();
	private Image background = new ImageIcon(LoginPage.class.getResource("RESIZE.png")).getImage(); //배경이미지
	private JTextField nameTextField;
	private JTextField brithTextField;
	private JTextField identityTextField;
	private JPasswordField passwordField;
	private JPasswordField passwordCheckField;
	private JTextField phoneTextField;
	private JTextField emailTextField;
	private JTextField addressTextField;
	private JLabel noticeIdentity;
	private DataTransferObject data;

	/**
	 * Launch the application.
	 */

	/**
	 * Create the application.
	 * @param data 
	 */
	public UserPage(DataTransferObject data) {
		this.data = data;
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	
	public void initialize() {
		//frame.setIconImage(new ImageIcon(LoginPage.class.getResource("enver.PNG")).getImage().getScaledInstance(1599, 900, Image.SCALE_DEFAULT));
		//frame.setIconImage(new ImageIcon(LoginPage.class.getResource("loginJhin.jpg")).getImage());
		frame.setBounds(100, 100, 1599, 900);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		JPanel panel = new JPanel() {
			public void paint(Graphics g) {//그리는 함수
				g.drawImage(background, 0, 0, null);//background를 그려줌
				setOpaque(false); //그림을 표시하게 설정,투명하게 조절
		        super.paint(g);
			}
		};
		frame.getContentPane().add(panel);

		JLabel notice = new JLabel("나의 정보");
		notice.setForeground(Color.WHITE);
		notice.setBackground(Color.WHITE);
		notice.setHorizontalAlignment(SwingConstants.CENTER);
		notice.setFont(new Font("나눔고딕", Font.BOLD, 41));
		
		JLabel noticeName = new JLabel("이름 :");
		noticeName.setHorizontalAlignment(SwingConstants.RIGHT);
		noticeName.setFont(new Font("나눔고딕", Font.PLAIN, 21));
		noticeName.setForeground(Color.WHITE);
		
		JLabel noticeBirth = new JLabel("\uC0DD\uB144\uC6D4\uC77C :");
		noticeBirth.setHorizontalAlignment(SwingConstants.RIGHT);
		noticeBirth.setForeground(Color.WHITE);
		noticeBirth.setFont(new Font("나눔고딕", Font.PLAIN, 21));
		
		noticeIdentity = new JLabel("\uC544\uC774\uB514 :");
		noticeIdentity.setHorizontalAlignment(SwingConstants.RIGHT);
		noticeIdentity.setForeground(Color.WHITE);
		noticeIdentity.setFont(new Font("나눔고딕", Font.PLAIN, 21));
		
		JLabel noticePassword = new JLabel("\uBE44\uBC00\uBC88\uD638 :");
		noticePassword.setHorizontalAlignment(SwingConstants.RIGHT);
		noticePassword.setForeground(Color.WHITE);
		noticePassword.setFont(new Font("나눔고딕", Font.PLAIN, 21));
		
		JLabel noticePasswordCheck = new JLabel("\uBE44\uBC00\uBC88\uD638 \uD655\uC778 :");
		noticePasswordCheck.setHorizontalAlignment(SwingConstants.RIGHT);
		noticePasswordCheck.setForeground(Color.WHITE);
		noticePasswordCheck.setFont(new Font("나눔고딕", Font.PLAIN, 21));
		
		JLabel noticePhoneNumber = new JLabel("\uC804\uD654\uBC88\uD638 :");
		noticePhoneNumber.setHorizontalAlignment(SwingConstants.RIGHT);
		noticePhoneNumber.setForeground(Color.WHITE);
		noticePhoneNumber.setFont(new Font("나눔고딕", Font.PLAIN, 21));
		
		JLabel noticeEmail = new JLabel("\uC774\uBA54\uC77C :");
		noticeEmail.setHorizontalAlignment(SwingConstants.RIGHT);
		noticeEmail.setForeground(Color.WHITE);
		noticeEmail.setFont(new Font("나눔고딕", Font.PLAIN, 21));
		
		nameTextField = new JTextField(data.getName());
		nameTextField.setColumns(10);
		
		brithTextField = new JTextField(data.getBirthday());
		brithTextField.setColumns(10);
		
		identityTextField = new JTextField(data.getIdentity());
		identityTextField.setColumns(10);
		
		passwordField = new JPasswordField(data.getPassword());
		
		passwordCheckField = new JPasswordField(data.getPassword());
		
		phoneTextField = new JTextField(data.getPhonenumber());
		phoneTextField.setColumns(10);
		
		emailTextField = new JTextField(data.getEmail());
		emailTextField.setColumns(10);

		addressTextField = new JTextField(data.getAddress());
		addressTextField.setColumns(10);
		
		//String emailAddress[] = {"naver.com", "gmail.com", "sju.ac.kr"};
		//JComboBox emailAddresscomboBox = new JComboBox<String>(emailAddress);//
		
		
		JPanel backgroundGray = new JPanel();
		backgroundGray.setBackground(new Color(0, 0, 0, 123));
		
		JButton backButton = new JButton("로그아웃");
		backButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				frame.setVisible(false);
				new LoginPage().Login();
			}
		});
		backButton.setBackground(new Color(0, 0, 0, 123));
		backButton.setFocusPainted(false);
		backButton.setFont(new Font("나눔고딕", Font.PLAIN, 14));
		backButton.setForeground(Color.WHITE);
		
		JButton signupButton = new JButton("회원탈퇴");
		signupButton.setForeground(Color.WHITE);
		signupButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				frame.setVisible(false); 
				new DataAccessObject().deleteUser(identityTextField);
				new LoginPage().Login();
			}
		});
		signupButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				frame.setVisible(false); 
				// 회원가입이 완료되었습니다!! 창 띄어야 하나?
				new DataAccessObject().insertUserInfromation(nameTextField, brithTextField, identityTextField, passwordField, phoneTextField, emailTextField, addressTextField);
				new LoginPage().Login();
			}
		});
		signupButton.setFont(new Font("나눔고딕", Font.PLAIN, 14));
		signupButton.setFocusPainted(false);
		signupButton.setBackground(new Color(0, 0, 0, 123));
		
		JButton editButton = new JButton("회원정보 수정");
		editButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				// 회원가입이 완료되었습니다!! 창 띄어야 하나?
				data = new DataAccessObject().updateUserInfromation(nameTextField, brithTextField, identityTextField, passwordField, phoneTextField, emailTextField, addressTextField, data);
	    		JOptionPane.showMessageDialog(null, "회원정보 수정이 완료되었습니다.");
			}
		});
		editButton.setForeground(Color.WHITE);
		editButton.setFont(new Font("나눔고딕", Font.PLAIN, 14));
		editButton.setFocusPainted(false);
		editButton.setBackground(new Color(0, 0, 0, 123));
		
		GroupLayout groupLayout = new GroupLayout(panel);
		groupLayout.setHorizontalGroup(
			groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(groupLayout.createSequentialGroup()
					.addGap(168)
					.addComponent(backgroundGray, GroupLayout.DEFAULT_SIZE, 1213, Short.MAX_VALUE)
					.addGap(202))
				.addGroup(groupLayout.createSequentialGroup()
					.addContainerGap()
					.addComponent(backButton, GroupLayout.PREFERRED_SIZE, 167, GroupLayout.PREFERRED_SIZE)
					.addGap(495)
					.addComponent(editButton, GroupLayout.PREFERRED_SIZE, 167, GroupLayout.PREFERRED_SIZE)
					.addPreferredGap(ComponentPlacement.RELATED, 563, Short.MAX_VALUE)
					.addComponent(signupButton, GroupLayout.PREFERRED_SIZE, 167, GroupLayout.PREFERRED_SIZE)
					.addContainerGap())
		);
		groupLayout.setVerticalGroup(
			groupLayout.createParallelGroup(Alignment.TRAILING)
				.addGroup(groupLayout.createSequentialGroup()
					.addGap(116)
					.addComponent(backgroundGray, GroupLayout.DEFAULT_SIZE, 620, Short.MAX_VALUE)
					.addGap(49)
					.addGroup(groupLayout.createParallelGroup(Alignment.LEADING)
						.addComponent(signupButton, GroupLayout.PREFERRED_SIZE, 66, GroupLayout.PREFERRED_SIZE)
						.addGroup(groupLayout.createParallelGroup(Alignment.BASELINE)
							.addComponent(backButton, GroupLayout.PREFERRED_SIZE, 66, GroupLayout.PREFERRED_SIZE)
							.addComponent(editButton, GroupLayout.PREFERRED_SIZE, 66, GroupLayout.PREFERRED_SIZE)))
					.addContainerGap())
		);

		
		JLabel noticeInputPasswordcheck = new JLabel("확인을 위해 입력하신 비밀번호를 다시 한번 입력해 주세요.");
		noticeInputPasswordcheck.setForeground(Color.WHITE);
		noticeInputPasswordcheck.setFont(new Font("나눔고딕", Font.PLAIN, 12));
		
		JLabel noticeInputPassword = new JLabel("8\uC790 ~ 16\uC790\uC758 \uC22B\uC790, \uC601\uBB38\uC790 \uC870\uD569");
		noticeInputPassword.setForeground(Color.WHITE);
		noticeInputPassword.setFont(new Font("나눔고딕", Font.PLAIN, 12));
		
		JLabel noticeInputId = new JLabel("4자 ~ 15자의 영문 또는 숫자의 조합");
		noticeInputId.setForeground(Color.WHITE);
		noticeInputId.setFont(new Font("나눔고딕", Font.PLAIN, 12));
		
		JLabel noticeInputBirth = new JLabel("yymmdd로 입력해주세요. ex)010630");
		noticeInputBirth.setForeground(Color.WHITE);
		noticeInputBirth.setFont(new Font("나눔고딕", Font.PLAIN, 12));
		
		JLabel noticeInputName = new JLabel("2자 ~ 5자 이내의 한글로만 입력해주세요.");
		noticeInputName.setForeground(Color.WHITE);
		noticeInputName.setFont(new Font("나눔고딕", Font.PLAIN, 12));
		
		JLabel zeroOneZero = new JLabel("010");
		zeroOneZero.setHorizontalAlignment(SwingConstants.RIGHT);
		zeroOneZero.setForeground(Color.WHITE);
		zeroOneZero.setFont(new Font("나눔고딕", Font.PLAIN, 21));
		
		JLabel noticeInputPhone = new JLabel("-을 제외하고 8자리로 입력해주세요.");
		noticeInputPhone.setForeground(Color.WHITE);
		noticeInputPhone.setFont(new Font("나눔고딕", Font.PLAIN, 12));
		
		JLabel noticeAddress = new JLabel("주소 :");
		noticeAddress.setHorizontalAlignment(SwingConstants.RIGHT);
		noticeAddress.setForeground(Color.WHITE);
		noticeAddress.setFont(new Font("나눔고딕", Font.PLAIN, 21));
		
		
		JLabel noticeInputAddress = new JLabel("00\uC2DC/\uB3C4 00\uC2DC/\uAD6C 00\uB3D9 \uD615\uD0DC\uC758 \uC8FC\uC18C\uB85C \uC785\uB825\uD574\uC8FC\uC138\uC694.\r\n\uC608:\uCDA9\uCCAD\uB0A8\uB3C4 \uCC9C\uC548\uC2DC \uC11C\uBD81\uAD6C \uD55C\uB4E42\uB85C 88");
		noticeInputAddress.setForeground(Color.WHITE);
		noticeInputAddress.setFont(new Font("나눔고딕", Font.PLAIN, 12));
		
		GroupLayout gl_panel_1 = new GroupLayout(backgroundGray);
		gl_panel_1.setHorizontalGroup(
			gl_panel_1.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_panel_1.createSequentialGroup()
					.addContainerGap(553, Short.MAX_VALUE)
					.addComponent(notice)
					.addGap(493))
				.addGroup(gl_panel_1.createSequentialGroup()
					.addGap(163)
					.addGroup(gl_panel_1.createParallelGroup(Alignment.TRAILING)
						.addComponent(noticeAddress, GroupLayout.PREFERRED_SIZE, 76, GroupLayout.PREFERRED_SIZE)
						.addComponent(noticeName)
						.addComponent(noticeBirth, GroupLayout.PREFERRED_SIZE, 100, GroupLayout.PREFERRED_SIZE)
						.addComponent(noticeIdentity, GroupLayout.PREFERRED_SIZE, 100, GroupLayout.PREFERRED_SIZE)
						.addComponent(noticePassword, GroupLayout.PREFERRED_SIZE, 100, GroupLayout.PREFERRED_SIZE)
						.addComponent(noticePasswordCheck)
						.addComponent(noticeEmail, GroupLayout.PREFERRED_SIZE, 100, GroupLayout.PREFERRED_SIZE)
						.addComponent(noticePhoneNumber, GroupLayout.PREFERRED_SIZE, 172, GroupLayout.PREFERRED_SIZE))
					.addGap(18)
					.addGroup(gl_panel_1.createParallelGroup(Alignment.LEADING)
						.addGroup(gl_panel_1.createSequentialGroup()
							.addComponent(passwordCheckField, GroupLayout.PREFERRED_SIZE, 239, GroupLayout.PREFERRED_SIZE)
							.addPreferredGap(ComponentPlacement.UNRELATED)
							.addComponent(noticeInputPasswordcheck))
						.addGroup(gl_panel_1.createSequentialGroup()
							.addComponent(passwordField, 239, 239, 239)
							.addPreferredGap(ComponentPlacement.UNRELATED)
							.addComponent(noticeInputPassword, GroupLayout.PREFERRED_SIZE, 377, GroupLayout.PREFERRED_SIZE))
						.addGroup(gl_panel_1.createSequentialGroup()
							.addGroup(gl_panel_1.createParallelGroup(Alignment.LEADING, false)
								.addComponent(identityTextField)
								.addComponent(nameTextField)
								.addComponent(brithTextField))
							.addGroup(gl_panel_1.createParallelGroup(Alignment.LEADING)
								.addGroup(gl_panel_1.createSequentialGroup()
									.addGap(20)
									.addComponent(noticeInputId, GroupLayout.PREFERRED_SIZE, 212, GroupLayout.PREFERRED_SIZE))
								.addGroup(gl_panel_1.createSequentialGroup()
									.addGap(18)
									.addGroup(gl_panel_1.createParallelGroup(Alignment.LEADING)
										.addComponent(noticeInputName, GroupLayout.PREFERRED_SIZE, 239, GroupLayout.PREFERRED_SIZE)
										.addComponent(noticeInputBirth, GroupLayout.PREFERRED_SIZE, 212, GroupLayout.PREFERRED_SIZE)))))
						.addGroup(gl_panel_1.createSequentialGroup()
							.addComponent(zeroOneZero)
							.addPreferredGap(ComponentPlacement.RELATED)
							.addComponent(phoneTextField, GroupLayout.PREFERRED_SIZE, 197, GroupLayout.PREFERRED_SIZE)
							.addPreferredGap(ComponentPlacement.UNRELATED)
							.addComponent(noticeInputPhone, GroupLayout.PREFERRED_SIZE, 320, GroupLayout.PREFERRED_SIZE))
						.addGroup(gl_panel_1.createSequentialGroup()
							.addComponent(addressTextField, GroupLayout.PREFERRED_SIZE, 280, GroupLayout.PREFERRED_SIZE)
							.addPreferredGap(ComponentPlacement.RELATED)
							.addComponent(noticeInputAddress))
						.addComponent(emailTextField, GroupLayout.PREFERRED_SIZE, 323, GroupLayout.PREFERRED_SIZE))
					.addContainerGap(126, Short.MAX_VALUE))
		);
		gl_panel_1.setVerticalGroup(
			gl_panel_1.createParallelGroup(Alignment.LEADING)
				.addGroup(gl_panel_1.createSequentialGroup()
					.addGap(37)
					.addComponent(notice)
					.addGap(44)
					.addGroup(gl_panel_1.createParallelGroup(Alignment.BASELINE)
						.addComponent(noticeName)
						.addComponent(nameTextField, GroupLayout.PREFERRED_SIZE, 27, GroupLayout.PREFERRED_SIZE)
						.addComponent(noticeInputName, GroupLayout.PREFERRED_SIZE, 22, GroupLayout.PREFERRED_SIZE))
					.addGap(26)
					.addGroup(gl_panel_1.createParallelGroup(Alignment.TRAILING)
						.addComponent(noticeBirth, GroupLayout.PREFERRED_SIZE, 25, GroupLayout.PREFERRED_SIZE)
						.addGroup(gl_panel_1.createParallelGroup(Alignment.BASELINE)
							.addComponent(brithTextField, GroupLayout.PREFERRED_SIZE, 27, GroupLayout.PREFERRED_SIZE)
							.addComponent(noticeInputBirth, GroupLayout.PREFERRED_SIZE, 22, GroupLayout.PREFERRED_SIZE)))
					.addGap(26)
					.addGroup(gl_panel_1.createParallelGroup(Alignment.TRAILING)
						.addComponent(noticeIdentity, GroupLayout.PREFERRED_SIZE, 25, GroupLayout.PREFERRED_SIZE)
						.addGroup(gl_panel_1.createParallelGroup(Alignment.BASELINE)
							.addComponent(identityTextField, GroupLayout.PREFERRED_SIZE, 27, GroupLayout.PREFERRED_SIZE)
							.addComponent(noticeInputId, GroupLayout.PREFERRED_SIZE, 22, GroupLayout.PREFERRED_SIZE)))
					.addGap(18)
					.addGroup(gl_panel_1.createParallelGroup(Alignment.TRAILING)
						.addComponent(noticePassword, GroupLayout.PREFERRED_SIZE, 25, GroupLayout.PREFERRED_SIZE)
						.addGroup(gl_panel_1.createParallelGroup(Alignment.BASELINE)
							.addComponent(passwordField, GroupLayout.PREFERRED_SIZE, 29, GroupLayout.PREFERRED_SIZE)
							.addComponent(noticeInputPassword, GroupLayout.PREFERRED_SIZE, 22, GroupLayout.PREFERRED_SIZE)))
					.addGap(23)
					.addGroup(gl_panel_1.createParallelGroup(Alignment.TRAILING)
						.addComponent(noticePasswordCheck, GroupLayout.PREFERRED_SIZE, 25, GroupLayout.PREFERRED_SIZE)
						.addGroup(gl_panel_1.createParallelGroup(Alignment.BASELINE)
							.addComponent(passwordCheckField, GroupLayout.PREFERRED_SIZE, 29, GroupLayout.PREFERRED_SIZE)
							.addComponent(noticeInputPasswordcheck, GroupLayout.PREFERRED_SIZE, 22, GroupLayout.PREFERRED_SIZE)))
					.addGap(26)
					.addGroup(gl_panel_1.createParallelGroup(Alignment.BASELINE)
						.addComponent(noticePhoneNumber, GroupLayout.PREFERRED_SIZE, 25, GroupLayout.PREFERRED_SIZE)
						.addComponent(zeroOneZero, GroupLayout.PREFERRED_SIZE, 25, GroupLayout.PREFERRED_SIZE)
						.addComponent(phoneTextField, GroupLayout.PREFERRED_SIZE, 27, GroupLayout.PREFERRED_SIZE)
						.addComponent(noticeInputPhone, GroupLayout.PREFERRED_SIZE, 22, GroupLayout.PREFERRED_SIZE))
					.addGap(26)
					.addGroup(gl_panel_1.createParallelGroup(Alignment.TRAILING)
						.addComponent(noticeEmail, GroupLayout.PREFERRED_SIZE, 25, GroupLayout.PREFERRED_SIZE)
						.addComponent(emailTextField, GroupLayout.PREFERRED_SIZE, 27, GroupLayout.PREFERRED_SIZE))
					.addGap(26)
					.addGroup(gl_panel_1.createParallelGroup(Alignment.TRAILING)
						.addComponent(noticeAddress, GroupLayout.PREFERRED_SIZE, 25, GroupLayout.PREFERRED_SIZE)
						.addGroup(gl_panel_1.createParallelGroup(Alignment.BASELINE)
							.addComponent(addressTextField, GroupLayout.PREFERRED_SIZE, 27, GroupLayout.PREFERRED_SIZE)
							.addComponent(noticeInputAddress, GroupLayout.PREFERRED_SIZE, 22, GroupLayout.PREFERRED_SIZE)))
					.addContainerGap(94, Short.MAX_VALUE))
		);
		backgroundGray.setLayout(gl_panel_1);
		panel.setLayout(groupLayout);
		frame.setVisible(true);
	}
}
