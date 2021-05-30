package View;

import java.awt.EventQueue;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JPanel;

import Controller.ActionProcessing;
import Controller.LoginService;
import javax.swing.SpringLayout;
import javax.swing.JButton;
import javax.swing.GroupLayout;
import javax.swing.GroupLayout.Alignment;
import javax.swing.JTextField;
import javax.swing.LayoutStyle.ComponentPlacement;

public class SignupPage {

	private JFrame frame;
	private Image background = new ImageIcon(LoginPage.class.getResource("signup4.png")).getImage(); //배경이미지
	private JTextField textField;
	private JTextField textField_1;
	private JTextField textField_2;
	private JTextField textField_3;
	private JTextField textField_4;
	private JTextField textField_5;
	private JTextField textField_6;
	private JTextField textField_7;

	/**
	 * Launch the application.
	 */
	/**
	 * Create the application.
	 * @wbp.parser.entryPoint
	 */
	public SignupPage() {
		//initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	public void initialize() {
		frame = new JFrame();
		frame.setBounds(100, 100, 860, 610);
		frame.setTitle("세종대학교 회원가입"); //타이틀
		frame.setIconImage(new ImageIcon(LoginPage.class.getResource("sejongmark.jpeg")).getImage());
		frame.setResizable(false);//창의 크기를 변경하지 못하게
		//frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		JPanel panel = new JPanel() {
            public void paintComponent(Graphics g) {
                g.drawImage(background, 0, 0, null);
                setOpaque(false); //그림을 표시하게 설정,투명하게 조절
            }
        };
        frame.getContentPane().add(panel);
        
        JButton SubmitSignUpButton = new JButton("학생가입하기");
        SubmitSignUpButton.addActionListener(new ActionProcessing());
        SubmitSignUpButton.setContentAreaFilled(false);
        SubmitSignUpButton.setFocusPainted(false);
        SubmitSignUpButton.setFont(new Font("맑은 고딕", Font.PLAIN, 21));
		//loginButton.setBorderPainted(false);
        
        textField = new JTextField();
        textField.setColumns(10);
        
        textField_1 = new JTextField();
        textField_1.setColumns(10);
        
        textField_2 = new JTextField();
        textField_2.setColumns(10);
        
        textField_3 = new JTextField();
        textField_3.setColumns(10);
        
        textField_4 = new JTextField();
        textField_4.setColumns(10);
        
        textField_5 = new JTextField();
        textField_5.setColumns(10);
        
        textField_6 = new JTextField();
        textField_6.setColumns(10);
        
        textField_7 = new JTextField();
        textField_7.setColumns(10);
        GroupLayout gl_panel = new GroupLayout(panel);
        gl_panel.setHorizontalGroup(
        	gl_panel.createParallelGroup(Alignment.LEADING)
        		.addGroup(gl_panel.createSequentialGroup()
        			.addGap(180)
        			.addGroup(gl_panel.createParallelGroup(Alignment.LEADING)
        				.addComponent(textField_7, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
        				.addGroup(gl_panel.createSequentialGroup()
        					.addGroup(gl_panel.createParallelGroup(Alignment.LEADING)
        						.addComponent(textField_6, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
        						.addComponent(textField_5, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
        						.addComponent(textField_4, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
        						.addComponent(textField_3, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
        						.addComponent(textField_2, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
        						.addComponent(textField_1, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
        						.addComponent(textField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))
        					.addContainerGap(558, Short.MAX_VALUE))))
        		.addGroup(Alignment.TRAILING, gl_panel.createSequentialGroup()
        			.addContainerGap(609, Short.MAX_VALUE)
        			.addComponent(SubmitSignUpButton, GroupLayout.PREFERRED_SIZE, 212, GroupLayout.PREFERRED_SIZE)
        			.addGap(33))
        );
        gl_panel.setVerticalGroup(
        	gl_panel.createParallelGroup(Alignment.LEADING)
        		.addGroup(gl_panel.createSequentialGroup()
        			.addGap(131)
        			.addComponent(textField, GroupLayout.PREFERRED_SIZE, 34, GroupLayout.PREFERRED_SIZE)
        			.addPreferredGap(ComponentPlacement.UNRELATED)
        			.addComponent(textField_1, GroupLayout.PREFERRED_SIZE, 34, GroupLayout.PREFERRED_SIZE)
        			.addPreferredGap(ComponentPlacement.RELATED)
        			.addComponent(textField_2, GroupLayout.PREFERRED_SIZE, 34, GroupLayout.PREFERRED_SIZE)
        			.addPreferredGap(ComponentPlacement.RELATED)
        			.addComponent(textField_3, GroupLayout.PREFERRED_SIZE, 34, GroupLayout.PREFERRED_SIZE)
        			.addPreferredGap(ComponentPlacement.UNRELATED)
        			.addComponent(textField_4, GroupLayout.PREFERRED_SIZE, 34, GroupLayout.PREFERRED_SIZE)
        			.addPreferredGap(ComponentPlacement.UNRELATED)
        			.addComponent(textField_5, GroupLayout.PREFERRED_SIZE, 34, GroupLayout.PREFERRED_SIZE)
        			.addGap(10)
        			.addComponent(textField_6, GroupLayout.PREFERRED_SIZE, 34, GroupLayout.PREFERRED_SIZE)
        			.addPreferredGap(ComponentPlacement.UNRELATED)
        			.addComponent(textField_7, GroupLayout.PREFERRED_SIZE, 34, GroupLayout.PREFERRED_SIZE)
        			.addPreferredGap(ComponentPlacement.RELATED, 15, Short.MAX_VALUE)
        			.addComponent(SubmitSignUpButton, GroupLayout.PREFERRED_SIZE, 71, GroupLayout.PREFERRED_SIZE)
        			.addContainerGap())
        );
        panel.setLayout(gl_panel);
        frame.setVisible(true);
	}
}
