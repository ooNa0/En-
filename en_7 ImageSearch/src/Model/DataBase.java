package Model;
import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Vector;

import javax.swing.JTextArea;
 
 
public class DataBase {

    Connection connection = null;
    Statement state = null;
    ResultSet result = null;
	public void inputDataBase(String searchItem) {
        // DB 접속 객체선언
		 result = null;
        try {
            // Maria db 드라이버 로드
            Class.forName("org.mariadb.jdbc.Driver");
            // 데이터베이스 접속
            connection = DriverManager.getConnection("jdbc:mariadb://127.0.0.1:3307/ImageSearch", "root", "0000");
            state = connection.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
            result = state.executeQuery("select * from searchitem where input='" + searchItem + "';");
            SimpleDateFormat dateFormat = new SimpleDateFormat(Constant.DATABASE_DATE_FORMAT);
            Calendar date = Calendar.getInstance(); 
            if(result.next() == true) {
            	// 삭제
            	result = state.executeQuery("update searchitem set time='" + dateFormat.format(date.getTime()) 
            	+ "' where input='" + searchItem + "';");
            }
            // 갱신
            else {
                result = state.executeQuery("insert into searchitem values('" + searchItem + "','" + 
                dateFormat.format(date.getTime())+ "');");
            }
        } catch (Exception e) {
            System.out.println(e.toString());
        } finally {
            try {connection.close();} catch (Exception e) {}
            try {state.close();} catch (Exception e) {}
            try {result.close();} catch (Exception e) {}
        }
    }
	
	@SuppressWarnings("unchecked")
	public Vector showDataBase() {
		Vector vector = new Vector();
        result = null;// ResultSet 
        JTextArea area = new JTextArea();
        try {
            // Maria db 드라이버 로드
            Class.forName("org.mariadb.jdbc.Driver");
            // 데이터베이스 접속
            connection = DriverManager.getConnection("jdbc:mariadb://127.0.0.1:3307/ImageSearch", "root", "0000");
            state = connection.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
            result = state.executeQuery("select * from searchitem;");
            //System.out.println(result.next());
            while(result.next()) {
            	String inputString = "[" + result.getString(2) + "] " + result.getString(1);
                System.out.println(inputString);
            	vector.addElement(inputString);
            }
        } catch (Exception e) {
            System.out.println(e.toString());
        } finally {
            try {connection.close();} catch (Exception e) {}
            try {state.close();} catch (Exception e) {}
            try {result.close();} catch (Exception e) {}
        }
        if (connection != null) {
            System.out.println(result);
        }
        
        return vector;
	}
	
	public void resetDataBase() {
		try {
			Class.forName("org.mariadb.jdbc.Driver");
			// 데이터베이스 접속
	        connection = DriverManager.getConnection("jdbc:mariadb://127.0.0.1:3307/ImageSearch", "root", "0000");
	        state = connection.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
	        result = state.executeQuery("truncate searchitem;");
		} catch (Exception e) {
			// TODO Auto-generated catch block
			System.out.println(e.toString());
		}
        
	}
}
