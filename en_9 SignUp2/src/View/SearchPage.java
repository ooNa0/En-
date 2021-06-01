package View;

import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.GroupLayout;
import javax.swing.ImageIcon;
import javax.swing.GroupLayout.Alignment;
import javax.swing.JLabel;
import javax.swing.JPanel;

import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.SwingConstants;
import java.awt.Color;
import java.awt.Container;

import javax.swing.JTextField;
import javax.swing.LayoutStyle.ComponentPlacement;

import Model.DataTransferObject;
import Model.DataAccessObject;

import javax.swing.JButton;


class informationPanel extends JPanel{
	private JPanel panel = new JPanel();
	private JFrame frame;
	JLabel mainNotice = new JLabel("¾ÆÀÌµð Ã£±â");
	JLabel notice = new JLabel("°¡ÀÔÇÏ½Å °èÁ¤ÀÇ ¾ÆÀÌµð´Â ¾Æ·¡¿Í °°½À´Ï´Ù.");
	JLabel nameNotice = new JLabel("¾ÆÀÌµð :");
	JButton nextButton = new JButton("È®ÀÎ");
	
	public informationPanel(JPanel panel) {
		this.panel = panel;
		mainNotice.setForeground(Color.WHITE);
		mainNotice.setBackground(Color.WHITE);
		mainNotice.setHorizontalAlignment(SwingConstants.CENTER);
		mainNotice.setFont(new Font("³ª´®°íµñ", Font.BOLD, 32));
		
		notice.setHorizontalAlignment(SwingConstants.CENTER);
		notice.setFont(new Font("³ª´®°íµñ", Font.PLAIN, 15));
		notice.setForeground(Color.ORANGE);
				
		nameNotice.setHorizontalAlignment(SwingConstants.LEFT);
		nameNotice.setForeground(Color.ORANGE);
		nameNotice.setFont(new Font("³ª´®°íµñ", Font.PLAIN, 15));
		
		GroupLayout groupLayout = new GroupLayout(panel);
		groupLayout.setHorizontalGroup(
			groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(groupLayout.createSequentialGroup()
					.addGroup(groupLayout.createParallelGroup(Alignment.LEADING)
						.addGroup(groupLayout.createSequentialGroup()
							.addGap(126)
							.addComponent(mainNotice, GroupLayout.PREFERRED_SIZE, 172, GroupLayout.PREFERRED_SIZE))
						.addGroup(groupLayout.createSequentialGroup()
							.addGap(86)
							.addComponent(notice, GroupLayout.PREFERRED_SIZE, 295, GroupLayout.PREFERRED_SIZE))
						.addGroup(groupLayout.createSequentialGroup()
							.addGap(186)
							.addComponent(nextButton))
						.addGroup(groupLayout.createSequentialGroup()
							.addGap(114)
							.addComponent(nameNotice, GroupLayout.PREFERRED_SIZE, 61, GroupLayout.PREFERRED_SIZE)))
					.addContainerGap(53, Short.MAX_VALUE))
		);
		groupLayout.setVerticalGroup(
			groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(groupLayout.createSequentialGroup()
					.addGap(86)
					.addComponent(mainNotice, GroupLayout.PREFERRED_SIZE, 68, GroupLayout.PREFERRED_SIZE)
					.addPreferredGap(ComponentPlacement.UNRELATED)
					.addComponent(notice)
					.addGap(56)
					.addComponent(nameNotice, GroupLayout.PREFERRED_SIZE, 18, GroupLayout.PREFERRED_SIZE)
					.addGap(81)
					.addComponent(nextButton, GroupLayout.PREFERRED_SIZE, 50, GroupLayout.PREFERRED_SIZE)
					.addContainerGap(174, Short.MAX_VALUE))
		);
			panel.setBackground(Color.BLACK);
			panel.setLayout(groupLayout);
			setVisible(true);
	}
}

public class SearchPage extends JFrame{

	private JPanel panel;
	private JFrame frame;
	private JTextField nameTextField;
	private JTextField phonenumberTextField;
	private JTextField textField_3;
	JLabel mainNotice = new JLabel("º» ÀÎ ÀÎ Áõ");
	JLabel notice = new JLabel("°¡ÀÔÇÏ½Å °èÁ¤ÀÇ Á¤º¸¸¦ ÀÔ·ÂÇØÁÖ¼¼¿ä.");
	JLabel nameNotice = new JLabel("ÀÌ¸§ :");
	JLabel phonenumberNotice = new JLabel("ÀüÈ­¹øÈ£ : 010 -");
	JLabel lblNewLabel_1_1_2 = new JLabel("¾ÆÀÌµð :");
	JButton nextButton = new JButton("Ã£±â");
	private informationPanel informationPanel;
	private DataAccessObject data = new DataAccessObject();

	public SearchPage() {

		frame = new JFrame();
		frame.getContentPane().setBackground(Color.BLACK);
		frame.setIconImage(new ImageIcon(LoginPage.class.getResource("lol.png")).getImage());
		frame.setBounds(200, 200, 450, 600);

		
		mainNotice.setForeground(Color.WHITE);
		mainNotice.setBackground(Color.WHITE);
		mainNotice.setHorizontalAlignment(SwingConstants.CENTER);
		mainNotice.setFont(new Font("³ª´®°íµñ", Font.BOLD, 32));
		
		notice.setHorizontalAlignment(SwingConstants.CENTER);
		notice.setFont(new Font("³ª´®°íµñ", Font.PLAIN, 15));
		notice.setForeground(Color.ORANGE);
				
		nameNotice.setHorizontalAlignment(SwingConstants.CENTER);
		nameNotice.setForeground(Color.ORANGE);
		nameNotice.setFont(new Font("³ª´®°íµñ", Font.PLAIN, 15));
		
		phonenumberNotice.setHorizontalAlignment(SwingConstants.CENTER);
		phonenumberNotice.setForeground(Color.ORANGE);
		phonenumberNotice.setFont(new Font("³ª´®°íµñ", Font.PLAIN, 15));
		
		nameTextField = new JTextField();
		nameTextField.setFont(new Font("³ª´®°íµñ", Font.PLAIN, 15));
		nameTextField.setColumns(10);
		
		phonenumberTextField = new JTextField();
		phonenumberTextField.setFont(new Font("³ª´®°íµñ", Font.PLAIN, 15));
		phonenumberTextField.setColumns(10);		
		
		lblNewLabel_1_1_2.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel_1_1_2.setForeground(Color.ORANGE);
		lblNewLabel_1_1_2.setFont(new Font("³ª´®°íµñ", Font.PLAIN, 15));
		
		textField_3 = new JTextField();
		textField_3.setFont(new Font("³ª´®°íµñ", Font.PLAIN, 15));
		textField_3.setColumns(10);
		
	}
	
	private void initialize() {
		//frame = new JFrame();
		//frame.getContentPane().setBackground(Color.BLACK);
		//frame.setBounds(100, 100, 450, 600);
		//frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
	}
	
	public void findIdentity() {
		
		panel = new JPanel();
		informationPanel = new informationPanel(panel);
		 //initialize();
		
			GroupLayout groupLayout = new GroupLayout(frame.getContentPane());
		 groupLayout.setHorizontalGroup(
					groupLayout.createParallelGroup(Alignment.LEADING)
						.addGroup(groupLayout.createSequentialGroup()
							.addGroup(groupLayout.createParallelGroup(Alignment.LEADING)
								.addGroup(groupLayout.createSequentialGroup()
									.addGap(126)
									.addComponent(mainNotice, GroupLayout.PREFERRED_SIZE, 172, GroupLayout.PREFERRED_SIZE))
								.addGroup(groupLayout.createSequentialGroup()
									.addGap(86)
									.addGroup(groupLayout.createParallelGroup(Alignment.TRAILING)
										.addGroup(groupLayout.createSequentialGroup()
											.addGroup(groupLayout.createParallelGroup(Alignment.LEADING, false)
												.addGroup(groupLayout.createSequentialGroup()
													.addGap(28)
													.addComponent(nameNotice, GroupLayout.PREFERRED_SIZE, 48, GroupLayout.PREFERRED_SIZE)))
											.addPreferredGap(ComponentPlacement.RELATED)
											.addGroup(groupLayout.createParallelGroup(Alignment.LEADING)
												.addComponent(nameTextField, GroupLayout.PREFERRED_SIZE, 116, GroupLayout.PREFERRED_SIZE)
											.addGap(248))
											)
										.addGroup(Alignment.LEADING, groupLayout.createSequentialGroup()
											.addComponent(phonenumberNotice, GroupLayout.PREFERRED_SIZE, 114, GroupLayout.PREFERRED_SIZE)
											.addPreferredGap(ComponentPlacement.RELATED)
											.addComponent(phonenumberTextField, GroupLayout.PREFERRED_SIZE, 121, GroupLayout.PREFERRED_SIZE))
										.addComponent(notice, Alignment.LEADING, GroupLayout.PREFERRED_SIZE, 259, GroupLayout.PREFERRED_SIZE)))
								.addGroup(groupLayout.createSequentialGroup()
									.addGap(164)
									.addComponent(nextButton)))
							.addContainerGap())
				);
				groupLayout.setVerticalGroup(
					groupLayout.createParallelGroup(Alignment.LEADING)
						.addGroup(groupLayout.createSequentialGroup()
							.addGap(86)
							.addComponent(mainNotice, GroupLayout.PREFERRED_SIZE, 68, GroupLayout.PREFERRED_SIZE)
							.addPreferredGap(ComponentPlacement.UNRELATED)
							.addComponent(notice)
							.addGap(56)
							.addGroup(groupLayout.createParallelGroup(Alignment.BASELINE)
								//.addComponent(label)
								.addComponent(nameNotice, GroupLayout.PREFERRED_SIZE, 18, GroupLayout.PREFERRED_SIZE)
								.addComponent(nameTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))
							.addGap(18)
							.addGroup(groupLayout.createParallelGroup(Alignment.BASELINE))
							.addGap(18)
							.addGroup(groupLayout.createParallelGroup(Alignment.BASELINE)
								.addComponent(phonenumberNotice, GroupLayout.PREFERRED_SIZE, 18, GroupLayout.PREFERRED_SIZE)
								.addComponent(phonenumberTextField, GroupLayout.PREFERRED_SIZE, 24, GroupLayout.PREFERRED_SIZE))
							.addGap(70)
							.addComponent(nextButton, GroupLayout.PREFERRED_SIZE, 50, GroupLayout.PREFERRED_SIZE)
							.addContainerGap(95, Short.MAX_VALUE))
				);
		//panel.setBackground(Color.BLACK);
		//panel.setLayout(groupLayout);
		frame.getContentPane().setLayout(groupLayout);
		frame.add(panel);
		frame.setVisible(true);
		
		nextButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				if(data.returnIdentity(nameTextField,phonenumberTextField)!=null) {
					new test(data.returnIdentity(nameTextField,phonenumberTextField));
					frame.setVisible(false);
				}
				//new LoginPage().Login();
				//panel.removeAll();
				//panel.add(informationPanel);
				//revalidate();
				//repaint();
			}
		});
	}
	
	public void findPassword() {
		initialize();
		GroupLayout groupLayout = new GroupLayout(frame.getContentPane());
		groupLayout.setHorizontalGroup(
			groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(groupLayout.createSequentialGroup()
					.addGroup(groupLayout.createParallelGroup(Alignment.LEADING)
						.addGroup(groupLayout.createSequentialGroup()
							.addGap(126)
							.addComponent(mainNotice, GroupLayout.PREFERRED_SIZE, 172, GroupLayout.PREFERRED_SIZE))
						.addGroup(groupLayout.createSequentialGroup()
							.addGap(86)
							.addGroup(groupLayout.createParallelGroup(Alignment.LEADING)
								.addGroup(groupLayout.createSequentialGroup()
									.addGroup(groupLayout.createParallelGroup(Alignment.LEADING)
										.addGroup(groupLayout.createSequentialGroup()
											.addGap(28)
											.addComponent(nameNotice, GroupLayout.PREFERRED_SIZE, 48, GroupLayout.PREFERRED_SIZE))
										.addComponent(lblNewLabel_1_1_2, Alignment.TRAILING, GroupLayout.PREFERRED_SIZE, 59, GroupLayout.PREFERRED_SIZE))
									.addPreferredGap(ComponentPlacement.RELATED)
									.addGroup(groupLayout.createParallelGroup(Alignment.LEADING)
										.addGroup(groupLayout.createSequentialGroup()
											.addComponent(nameTextField, GroupLayout.PREFERRED_SIZE, 116, GroupLayout.PREFERRED_SIZE)
											.addGap(248))
										.addComponent(textField_3, GroupLayout.PREFERRED_SIZE, 126, GroupLayout.PREFERRED_SIZE)))
								.addComponent(notice, GroupLayout.PREFERRED_SIZE, 259, GroupLayout.PREFERRED_SIZE)
								.addGroup(groupLayout.createSequentialGroup()
									.addComponent(phonenumberNotice, GroupLayout.PREFERRED_SIZE, 114, GroupLayout.PREFERRED_SIZE)
									.addPreferredGap(ComponentPlacement.RELATED)
									.addComponent(phonenumberTextField, GroupLayout.PREFERRED_SIZE, 121, GroupLayout.PREFERRED_SIZE))))
						.addGroup(groupLayout.createSequentialGroup()
							.addGap(184)
							.addComponent(nextButton)))
					.addContainerGap(GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
		);
		groupLayout.setVerticalGroup(
			groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(groupLayout.createSequentialGroup()
					.addGap(86)
					.addComponent(mainNotice, GroupLayout.PREFERRED_SIZE, 68, GroupLayout.PREFERRED_SIZE)
					.addPreferredGap(ComponentPlacement.UNRELATED)
					.addComponent(notice)
					.addGap(20)
					.addGroup(groupLayout.createParallelGroup(Alignment.BASELINE)
						.addComponent(lblNewLabel_1_1_2, GroupLayout.PREFERRED_SIZE, 18, GroupLayout.PREFERRED_SIZE)
						.addComponent(textField_3, GroupLayout.PREFERRED_SIZE, 24, GroupLayout.PREFERRED_SIZE))
					.addGap(18)
					.addGroup(groupLayout.createParallelGroup(Alignment.BASELINE)
						.addComponent(nameNotice, GroupLayout.PREFERRED_SIZE, 18, GroupLayout.PREFERRED_SIZE)
						.addComponent(nameTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))
					.addGap(18)
					.addGroup(groupLayout.createParallelGroup(Alignment.BASELINE)
						.addComponent(phonenumberNotice, GroupLayout.PREFERRED_SIZE, 18, GroupLayout.PREFERRED_SIZE)
						.addComponent(phonenumberTextField, GroupLayout.PREFERRED_SIZE, 24, GroupLayout.PREFERRED_SIZE))
					.addPreferredGap(ComponentPlacement.RELATED, 101, Short.MAX_VALUE)
					.addComponent(nextButton, GroupLayout.PREFERRED_SIZE, 50, GroupLayout.PREFERRED_SIZE)
					.addGap(100))
		);

		frame.getContentPane().setLayout(groupLayout);
		frame.setVisible(true);
	}
}
