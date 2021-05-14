package Model;
import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.text.SimpleDateFormat;
import java.util.Calendar;
 
 
public class DataBase {
	public void inputDataBase(String searchItem) {
        // DB 접속 객체선언
        Connection connection = null;
        Statement state = null;
        ResultSet result = null;
        
        try {
            // Maria db 드라이버 로드
            Class.forName("org.mariadb.jdbc.Driver");
            // 데이터베이스 접속
            connection = DriverManager.getConnection("jdbc:mariadb://127.0.0.1:3307/ai_db", "root", "0000");
            state = connection.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
            result = state.executeQuery("select * from log where searchItem='" + searchItem + "';");
            if(result.next() == true) {
            	// 삭제
            	result.deleteRow();
            	//result.updateString(0, searchItem);
            }
            // 갱신
            //result.close();
            result.moveToInsertRow();
            SimpleDateFormat dateFormat = new SimpleDateFormat("[yyyy/MM/dd HH:mm:ss]");
            Calendar date = Calendar.getInstance(); 
            result.updateString(searchItem, dateFormat.format(date.getTime()));
            result.insertRow();
            //result = state.executeQuery("select * from log where searchItem='" + searchItem + "';");
        } catch (Exception e) {
            System.out.println(e.toString());
        } finally {
            try {connection.close();} catch (Exception e) {}
            try {state.close();} catch (Exception e) {}
            try {result.close();} catch (Exception e) {}
        }
        if (connection != null) {
            System.out.println("접속성공");
        }
    }
	
	public ResultSet showDataBase() {
		Connection connection = null;
        Statement state = null;
        ResultSet result = null;
        
        try {
            // Maria db 드라이버 로드
            Class.forName("org.mariadb.jdbc.Driver");
            // 데이터베이스 접속
            connection = DriverManager.getConnection("jdbc:mariadb://127.0.0.1:3307/ai_db", "root", "0000");
            state = connection.createStatement(ResultSet.TYPE_SCROLL_SENSITIVE, ResultSet.CONCUR_UPDATABLE);
            result = state.executeQuery("select * from log;");
            
            //result = state.executeQuery("select * from log where searchItem='" + searchItem + "';");
        } catch (Exception e) {
            System.out.println(e.toString());
        } finally {
            try {connection.close();} catch (Exception e) {}
            try {state.close();} catch (Exception e) {}
            try {result.close();} catch (Exception e) {}
        }
        if (connection != null) {
            System.out.println("접속성공");
        }
        return result;
	}
}
