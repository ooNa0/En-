package Controller;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JPasswordField;
import javax.swing.JTextField;

import View.LoginPage;

public class LoginService{
	
	private JPasswordField passwordField;
	private JTextField textField;
	private ActionProcessing action;
	private LoginPage loginPage;
	private Exception exception;
	
	public LoginService() {
		//ActionProcessing action = new ActionProcessing(passwordField, textField);
		exception = new Exception();
		action = new ActionProcessing(exception);
		loginPage = new LoginPage();
		//LoginPage loginPage = new LoginPage();
		loginPage.initialize(); // 처음에 로그인 화면
	}
	
	
	
}
