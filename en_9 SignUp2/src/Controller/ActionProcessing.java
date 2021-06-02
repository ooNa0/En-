package Controller;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

import View.SearchPage;
import View.SignupPage;
import View.LoginPage;

public class ActionProcessing extends JFrame implements ActionListener{

	private JPasswordField passwordField;
	private JTextField textField;
	private SearchPage search = new SearchPage();
	private Exception exception;
	private JFrame frame;
	//private SignupPage signup = new SignupPage();
	
	public ActionProcessing(Exception exception) {
		this.exception = exception;
	}
	
	public ActionProcessing(JFrame frame,JTextField textField, JPasswordField passwordField) {
		// TODO Auto-generated constructor stub
		this.frame = frame;
		this.textField = textField;
		this.passwordField = passwordField;
	}
	
	public ActionProcessing() {
		
	}

	public void actionPerformed(ActionEvent event)
	{
    	System.out.println(event.getActionCommand());
	    switch(event.getActionCommand()) {
	    case "->":
	    	System.out.println("텍스트 =" + textField.getText());
	    	if(textField.getText() == null) {
	    		JOptionPane.showMessageDialog(null, "아이디를 입력해주세요!");
	    	}
	    	else {
		    	if(passwordField.getPassword() == null) {
		    		JOptionPane.showMessageDialog(null, "비밀번호를 입력해주세요!");
		    	}
		    	else {
			    	System.out.println(passwordField.getPassword());    		
		    	}
	    	}
	    	break;
	    //case "회원가입":
	    	//setVisible(false);
	    	//signup.initialize();
	    	//signup.initialize();
	    	//break;
	    case "아이디 찾기":
	    	setVisible(false);
	    	search.findIdentity();
	    	//search.searchIdentity();
	    	break;
	    case "비밀번호 찾기":
	    	setVisible(false);
	    	search.findPassword();
	    	//search.searchPassword();
	    	break;
	    }
	}
}
