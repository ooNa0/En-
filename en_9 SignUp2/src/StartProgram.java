import java.io.File;

import javax.sound.sampled.AudioInputStream;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.Clip;

import Controller.LoginService;

public class StartProgram {
	public static void main(String[] args) {
		/*
		 * File file = new File("/JhinSound.wav");
		
		//file = new File("C://JhinSound.wav");
        try {
            
            AudioInputStream stream = AudioSystem.getAudioInputStream(file);
            Clip clip = AudioSystem.getClip();
            clip.open(stream);
            clip.start();
            
        } catch(Exception e) {
            
            e.printStackTrace();
        }*/
		new LoginService();
	}
}
