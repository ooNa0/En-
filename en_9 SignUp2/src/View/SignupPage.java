package View;

import java.awt.Graphics;
import java.awt.Image;
import java.awt.Toolkit;
import java.net.MalformedURLException;
import java.net.URL;

import javax.swing.Icon;
import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;


public class SignupPage extends JPanel{
	
	private JFrame frame;
	private Image image;
	private JPanel penel;
	private Graphics graphics;
	private URL url = getClass().getResource("Jhin.gif");
	
	public SignupPage() {
		Icon icon = new ImageIcon(url);
		JLabel label = new JLabel(icon);
		frame = new JFrame();
		frame.setTitle("로그인"); //타이틀
		//frame.setIconImage(new ImageIcon(LoginPage.class.getResource("sejongmark.jpeg")).getImage());
		frame.setBounds(100, 100, 834, 608);
		//setResizable(false);//창의 크기를 변경하지 못하게
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().add(label);
		frame.pack();
		frame.setVisible(true);
	}
	/*
	 Graphics2D g2d = (Graphics2D) g.create();
	  // 50% transparent Alpha 
	   * g2d.setComposite(AlphaComposite.getInstance(AlphaComposite.SRC_OVER, 0.0f));
	  g2d.setColor(getBackground());
	   g2d.fill(getBounds());
	   g2d.dispose(); }
	 */

}
