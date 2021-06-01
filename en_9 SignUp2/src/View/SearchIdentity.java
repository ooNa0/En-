package View;

import java.awt.Color;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.GroupLayout;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.SwingConstants;
import javax.swing.border.Border;
import javax.swing.GroupLayout.Alignment;
import javax.swing.LayoutStyle.ComponentPlacement;
import javax.swing.DropMode;

public class SearchIdentity extends JFrame{

	private JPanel panel = new JPanel();
	private JFrame frame;
	JLabel mainNotice = new JLabel("¾ÆÀÌµð Ã£±â");
	JLabel notice = new JLabel("°¡ÀÔÇÏ½Å °èÁ¤ÀÇ ¾ÆÀÌµð´Â ¾Æ·¡¿Í °°½À´Ï´Ù.");
	JLabel nameNotice = new JLabel(){
        @Override
        public void setBorder(Border border) {
            
        }
    };
	JButton nextButton = new JButton("È®ÀÎ");//
	private informationPanel informationPanel;// = new informationPanel(panel);
	private JTextField identityTextField;

	/**
	 * Launch the application.
	
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					test window = new test();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	} */

	/**
	 * Create the application.
	 */
	public SearchIdentity(String identityTextField) {
		nameNotice.setForeground(Color.ORANGE);
		nameNotice.setBackground(Color.BLACK);
		//nameNotice.setEnabled(false);
		//this.identityTextField = identityTextField;
		nameNotice.setText(identityTextField);
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
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
		nameNotice.setFont(new Font("³ª´®°íµñ", Font.BOLD, 38));
		nextButton.setForeground(Color.WHITE);
		
		nextButton.setHorizontalAlignment(SwingConstants.LEFT);
		nextButton.setContentAreaFilled(false);
		//nextButton.setFocusPainted(false);
		nextButton.setFont(new Font("³ª´®°íµñ", Font.PLAIN, 14));
		nextButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				frame.setVisible(false);
			}
		});
		
		
		GroupLayout groupLayout = new GroupLayout(panel);
		groupLayout.setHorizontalGroup(
			groupLayout.createParallelGroup(Alignment.TRAILING)
				.addGroup(groupLayout.createSequentialGroup()
					.addGroup(groupLayout.createParallelGroup(Alignment.LEADING)
						.addGroup(groupLayout.createSequentialGroup()
							.addGap(126)
							.addComponent(mainNotice, GroupLayout.DEFAULT_SIZE, 172, Short.MAX_VALUE))
						.addGroup(groupLayout.createSequentialGroup()
							.addGap(186)
							.addComponent(nextButton, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
							.addGap(54)))
					.addGap(136))
				.addGroup(groupLayout.createSequentialGroup()
					.addGap(106)
					.addComponent(nameNotice, GroupLayout.DEFAULT_SIZE, 234, Short.MAX_VALUE)
					.addGap(94))
				.addGroup(groupLayout.createSequentialGroup()
					.addGap(71)
					.addComponent(notice, GroupLayout.DEFAULT_SIZE, 295, Short.MAX_VALUE)
					.addGap(68))
		);
		groupLayout.setVerticalGroup(
			groupLayout.createParallelGroup(Alignment.LEADING)
				.addGroup(groupLayout.createSequentialGroup()
					.addGap(86)
					.addComponent(mainNotice, GroupLayout.DEFAULT_SIZE, 68, Short.MAX_VALUE)
					.addPreferredGap(ComponentPlacement.UNRELATED)
					.addComponent(notice, GroupLayout.DEFAULT_SIZE, 18, Short.MAX_VALUE)
					.addGap(41)
					.addComponent(nameNotice, GroupLayout.DEFAULT_SIZE, 59, Short.MAX_VALUE)
					.addGap(55)
					.addComponent(nextButton, GroupLayout.DEFAULT_SIZE, 50, Short.MAX_VALUE)
					.addGap(174))
		);
			panel.setBackground(Color.BLACK);
			panel.setLayout(groupLayout);
			frame.getContentPane().add(panel);
			
			frame.setVisible(true);
	}

}
