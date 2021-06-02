package Controller;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.net.URL;

import javax.print.attribute.standard.Media;
import javax.sound.sampled.AudioInputStream;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.Clip;
import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;

import View.LoginPage;

public class LoginService extends JFrame{

	private JPanel panel;
	private JFrame frame;
	private URL url = getClass().getResource("/JhinSound.wav");
	//private Image background = new ImageIcon(LoginPage.class.getResource("../View/loginJhin.jpg")).getImage(); //배경이미지
	
	public LoginService(){
		//initiaize();
		//panel = 
		//frame = new JFrame("로오그으인");
		//frame.setBounds(100, 100, 1599, 900);
		//frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		//setIconImage(new ImageIcon(LoginPage.class.getResource("../View/loginJhin.jpg")).getImage());
		//new LoginPage(frame);
		Play("JhinSound.wav");
		new LoginPage().Login();
		//setContentPane(panel);
		//getContentPand().setBackground(Color.black);

		//setVisible(true);
		//frame.setBounds(100, 100, 1599, 900);
		//frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	}
	private void initiaize() {
		//frame = new JFrame();
		//setTitle("처음로그인"); //타이틀
		//frame.setIconImage(new ImageIcon(LoginPage.class.getResource("sejongmark.jpeg")).getImage());
		//setBounds(100, 100, 834, 608);
		//setResizable(false);//창의 크기를 변경하지 못하게
		//setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	}
	//public void paint(Graphics g) {//그리는 함수
	//	g.drawImage(background, 0, 0, null);//background를 그려줌
	//}
	public void Play(String fileName)
    {
        try
        {
            AudioInputStream ais = AudioSystem.getAudioInputStream(new File(fileName));
            Clip clip = AudioSystem.getClip();
            //clip.stop();
            clip.open(ais);
            clip.start();
            clip.loop(10);
        }
        catch (Exception ex)
        {
        }
    }
}
