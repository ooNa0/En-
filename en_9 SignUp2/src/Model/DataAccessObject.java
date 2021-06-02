package Model;

import java.sql.*;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;

import javax.swing.JComboBox;
import javax.swing.JOptionPane;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

public class DataAccessObject {

	/*
	 * public void inputDataBase(String searchItem) { // DB 접속 객체선언 result = null;
	 * try { connection =
	 * DriverManager.getConnection("jdbc:mariadb://127.0.0.1:3307/ImageSearch",
	 * "root", "0000"); state =
	 * connection.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE,
	 * ResultSet.CONCUR_UPDATABLE); result =
	 * state.executeQuery("select * from searchitem where input='" + searchItem +
	 * "';"); SimpleDateFormat dateFormat = new
	 * SimpleDateFormat(Constant.DATABASE_DATE_FORMAT); Calendar date =
	 * Calendar.getInstance(); if(result.next() == true) { // 삭제 result =
	 * state.executeQuery("update searchitem set time='" +
	 * dateFormat.format(date.getTime()) + "' where input='" + searchItem + "';"); }
	 * // 갱신 else { result = state.executeQuery("insert into searchitem values('" +
	 * searchItem + "','" + dateFormat.format(date.getTime())+ "');"); } } }
	 */
	private Connection connection = null;
	private Statement state = null;
	private ResultSet result = null;
	private int resultNumber;
	private DataTransferObject dataObject;

	// 드라이버 로딩
	public void Initialize() {
		try {
			// Maria db 드라이버 로드
			Class.forName("org.mariadb.jdbc.Driver");
			//Class.forName("com.mysql.jdbc.Driver");
			try {
				connection = DriverManager.getConnection("jdbc:mariadb://127.0.0.1:3307/signup", "root", "0000");
				//connection = DriverManager.getConnection("jdbc:mysql://localhost:3306/signup", "root", "0000");
				state = connection.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
			} catch (SQLException e) {
				e.printStackTrace();
			}
			// 데이터베이스 접속
		} catch (ClassNotFoundException e) {
			System.err.println("<JDBC 오류> Driver load 오류: " + e.getMessage());
			e.printStackTrace();
		}
	}

	// select 구문
	public void insertUserInfromation(JTextField nameTextField, JTextField birthTextField, JTextField identityTextField,
			JPasswordField passwordField, JTextField phoneTextField, JTextField emailTextField,
			JTextField addressTextField) {
		// 연결
		Initialize();
		try {
			resultNumber = state.executeUpdate("insert into signup value('" + nameTextField.getText() + "', '"
					+ birthTextField.getText() + "', '" + identityTextField.getText() + "', '"
					+ new String(passwordField.getPassword()) + "', '" + phoneTextField.getText() + "', '"
					+ emailTextField.getText() + "', '" + addressTextField.getText() + "');");
		} catch (SQLException e) {
			e.printStackTrace();
		} finally {
			try {
				connection.close();
				state.close();
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}

	public DataTransferObject isaccessDataBase(JTextField identityTextField, JPasswordField passwordTextField,
			DataTransferObject dataObject) {
		// this.dataObject = dataObject;
		Initialize();
		// boolean isCorrect = false;
		try {
			result = state.executeQuery("select * from signup where id='" + identityTextField.getText()
					+ "' && password ='" + new String(passwordTextField.getPassword()) + "';");
			if (result.next()) { // 성공했을 때!
				dataObject = new DataTransferObject(result.getString("name"), result.getString("birthday"),
						result.getString("id"), result.getString("password"), result.getString("phonenumber"),
						result.getString("email"), result.getString("address"));
				/*
				 * dataObject.setName(result.getString("name"));
				 * dataObject.setBirthday(result.getString("birthday"));
				 * dataObject.setIdentity(result.getString("id"));
				 * dataObject.setPassword(result.getString("password"));
				 * dataObject.setPhonenumber(result.getString("phonenumber"));
				 * dataObject.setEmail(result.getString("email"));
				 * dataObject.setAddress(result.getString("address"));
				 */
				// isCorrect = true;
			} else {
				JOptionPane.showMessageDialog(null, "로그인에 실패하셨습니다!");
			}
		} catch (SQLException e) {
			System.err.println("con 오류:" + e.getMessage());
			e.printStackTrace();
		} finally {
			try {
				connection.close();
				state.close();
				result.close();
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

		}
		return dataObject;
	}

	public void deleteUser(JTextField identityTextField) {
		Initialize();
		try {
			resultNumber = state.executeUpdate("delete from signup where id='" + identityTextField.getText() + "';");
			JOptionPane.showMessageDialog(null, "회원탈퇴가 완료되었습니다!");

		} catch (SQLException e) {
			System.err.println("con 오류:" + e.getMessage());
			e.printStackTrace();
		} finally {
			try {
				connection.close();
				state.close();
				result.close();
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

		}
	}

	public DataTransferObject updateUserInfromation(JTextField nameTextField, JTextField birthTextField,
			JTextField identityTextField, JPasswordField passwordField, JTextField phoneTextField,
			JTextField emailTextField, JTextField addressTextField, DataTransferObject data) {
		Initialize();
		try {

			// TODO Auto-generated method stub
			resultNumber = state.executeUpdate("update signup set id ='" + identityTextField.getText()
					+ "', birthday ='" + birthTextField.getText() + "', name ='" + nameTextField.getText()
					+ "', password ='" + new String(passwordField.getPassword()) + "', phonenumber ='"
					+ phoneTextField.getText() + "', email ='" + emailTextField.getText() + "', address ='"
					+ addressTextField.getText() + "';");
			// isaccessDataBase(nameTextField, birthTextField, identityTextField,
			// passwordField, phoneTextField, emailTextField, addressTextField);
			data.setName(nameTextField.getText());
			data.setBirthday(birthTextField.getText());
			data.setIdentity(identityTextField.getText());
			data.setPassword(new String(passwordField.getPassword()));
			data.setPhonenumber(phoneTextField.getText());
			data.setEmail(emailTextField.getText());
			data.setAddress(addressTextField.getText());

		} catch (SQLException e) {

			// TODO Auto-generated catch block

			e.printStackTrace();

		}
		return data;
	}
	
	public String returnIdentity(JTextField nameTextField, JTextField phoneNumberTextField) {
    	//this.dataObject = dataObject;
    	Initialize();
    	String identity = null;
    	//boolean isCorrect = false;
    	try {
            result = state.executeQuery("select * from signup where name='" + nameTextField.getText() + "' && phonenumber ='" + phoneNumberTextField.getText() + "';");
            if (result.next()) { // 성공했을 때!
            	identity = result.getString("id");

            }
            else {
            	JOptionPane.showMessageDialog(null, "본인인증에 실패하셨습니다!");
            }
        } catch(SQLException e) {
            System.err.println("con 오류:" + e.getMessage());
            e.printStackTrace();
        } finally {
        	try {
				connection.close();
				state.close();
				result.close();
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
            
        }
    	return identity;
    }
	
	public DataTransferObject returnPassword(JTextField identityTextField, JTextField nameTextField, JTextField phonenumberTextField) {
		// this.dataObject = dataObject;
		Initialize();
		// boolean isCorrect = false;
		try {
			result = state.executeQuery("select * from signup where id='" + identityTextField.getText()
					+ "' && name ='" + nameTextField.getText() + "' && phonenumber ='" + phonenumberTextField.getText() + "';");
			if (result.next()) { // 성공했을 때!
				dataObject = new DataTransferObject(result.getString("name"), result.getString("birthday"),
						result.getString("id"), result.getString("password"), result.getString("phonenumber"),
						result.getString("email"), result.getString("address"));
				/*
				 * dataObject.setName(result.getString("name"));
				 * dataObject.setBirthday(result.getString("birthday"));
				 * dataObject.setIdentity(result.getString("id"));
				 * dataObject.setPassword(result.getString("password"));
				 * dataObject.setPhonenumber(result.getString("phonenumber"));
				 * dataObject.setEmail(result.getString("email"));
				 * dataObject.setAddress(result.getString("address"));
				 */
				// isCorrect = true;
			} else {
				JOptionPane.showMessageDialog(null, "본인인증에 실패하셨습니다!");
			}
		} catch (SQLException e) {
			e.printStackTrace();
		} finally {
				try {
					connection.close();
					state.close();
					result.close();
				} catch (SQLException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}

		}
		return dataObject;
	}
}