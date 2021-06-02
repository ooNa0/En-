package Model;

import java.io.UnsupportedEncodingException;
import java.net.http.HttpRequest;
import java.util.Properties;

import javax.mail.*;
import javax.mail.internet.AddressException;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import javax.swing.JOptionPane;

public class MailSender {

	private String sendPassword;
	private String email;

    final String user = "koonayoung51@naver.com";
    final String password = "skdud155";
        

	public MailSender(String sendPassword, String email) {
		System.out.println(sendPassword);
		System.out.println(email);
		this.sendPassword = sendPassword;
		this.email = email;
		Properties props = new Properties();
		props.put("mail.transport.protocol", "smtp.naver.com"); // 이메일 발송을 처리해줄 STMP 서버
        props.put("mail.smtp.port", 25);  // gmail일 경우 465를 Naver의 경우 587
        props.put("mail.smtp.starttls.enable", "true");
        props.put("mail.smtp.auth", "true");
        props.put("mail.smtp.ssl.enable", "true");
        
        Session session = Session.getDefaultInstance(props, new javax.mail.Authenticator() {
            protected PasswordAuthentication getPasswordAuthentication() {
                return new PasswordAuthentication(user, password);
            }
        });
        
        try {
            MimeMessage message = new MimeMessage(session);
            message.setFrom(new InternetAddress(user));

            //수신자메일주소
            message.addRecipient(Message.RecipientType.TO, new InternetAddress("koonayoung51@naver.com")); 

            // Subject
            message.setSubject("aaaa"); //메일 제목을 입력

            // Text
            message.setText("aaaaaaaaa");    //메일 내용을 입력

            // send the message
            Transport.send(message); ////전송
            System.out.println("message sent successfully...");
        } catch (AddressException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (MessagingException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
		
		/*
		Session session = Session.getDefaultInstance(props, null);

		try {
		  Message msg = new MimeMessage(session);
		  msg.setFrom(new InternetAddress("koonayoung51@naver.com", "naver.com na0"));
		  msg.addRecipient(Message.RecipientType.TO,
		                   new InternetAddress("koonayoung51@naver.com", "Mr. User"));
		  msg.setSubject("Your Example.com account has been activated");
		  msg.setText("This is a test");
		  Transport.send(msg);
		} catch (AddressException e) {
		  // ...
		} catch (MessagingException e) {
		  // ...
		} catch (UnsupportedEncodingException e) {
		  // ...
		}*/
	}

	public void mailSender() {
		
		/*
		String BODY = String.join(
		        System.getProperty("line.separator"),
		        "<h1>비밀번호</h1>",
		        "<p>비밀번호를 알려드리겠습니다</p>." + sendPassword);
		
        Properties props = System.getProperties(); // 정보를 담기 위한 객체 생성 // SMTP 서버 정보 설정
        props.put("mail.transport.protocol", "smtp");
        props.put("mail.smtp.port", PORT); 
        props.put("mail.smtp.starttls.enable", "true");
        props.put("mail.smtp.auth", "true");
        Session session = Session.getDefaultInstance(props);
        MimeMessage msg = new MimeMessage(session);
        try {
			msg.setFrom(new InternetAddress(FROM, FROMNAME));
	        msg.setRecipient(Message.RecipientType.TO, new InternetAddress(email));
	        msg.setSubject("na0's Signup - sendPassword!");
	        msg.setContent(BODY, "text/html;charset=euc-kr");
		} catch (UnsupportedEncodingException | MessagingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

        
        Transport transport;
		try {
			transport = session.getTransport();
            System.out.println("Sending...");
            
            transport.connect(HOST, SMTP_USERNAME, SMTP_PASSWORD);
            transport.sendMessage(msg, msg.getAllRecipients());
            System.out.println("Email sent!");
            JOptionPane.showMessageDialog(null, "이메일을 확인해주세요.");
		} catch (NoSuchProviderException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
        catch (Exception ex) {
            ex.printStackTrace();
        }*/
    }
}
	/*(HttpRequest request) throws AddressException, MessagingException {
		// 네이버일 경우 smtp.naver.com 을 입력합니다.
		// Google일 경우 smtp.gmail.com 을 입력합니다.
		String host = "smtp.naver.com";
		final String username = "XXXXXXXX"; // 네이버 아이디를 입력해주세요. @nave.com은 입력하지 마시구요.
		final String password = "YYYYYYYY"; // 네이버 이메일 비밀번호를 입력해주세요.
		int port = 465; // 포트번호 // 메일 내용
		String recipient = email; // 받는 사람의 메일주소를 입력해주세요.
		Properties props = System.getProperties(); 
		props.put("mail.smtp.host", host);
		props.put("mail.smtp.port", port);
		props.put("mail.smtp.auth", "true");
		props.put("mail.smtp.ssl.enable", "true");
		props.put("mail.smtp.ssl.trust", host); // Session 생성
		Session session = Session.getDefaultInstance(props, new javax.mail.Authenticator() {
			String un = username;
			String pw = password;

			protected javax.mail.PasswordAuthentication getPasswordAuthentication() {
				return new javax.mail.PasswordAuthentication(un, pw);
			}
		});
		session.setDebug(true);
		Message mimeMessage = new MimeMessage(session); //MimeMessage 생성
		mimeMessage.setFrom(new InternetAddress("XXXXXXXX@naver.com")); //발신자 셋팅 ,
		mimeMessage.setRecipient(Message.RecipientType.TO, new InternetAddress(recipient));
		mimeMessage.setSubject("na0's Signup - sendPassword!"); //제목셋팅 
		mimeMessage.setText("your password is" + sendPassword); //내용셋팅
		Transport.send(mimeMessage);
		}
	}*/

