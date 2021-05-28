import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import View.LoginPage;

public class LoginService implements ActionListener{
	
	public LoginService() {
		LoginPage loginPage = new LoginPage();
		loginPage.initialize(); // 처음에 로그인 화면
	}
	
	
	public void actionPerformed(ActionEvent event)
	{
	    // your code
	}
}
