using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace en_6_Library_DB
{
    class DataAccessObject // 데베의 데이터 조회, 조작 기능
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private DataSet userDataSet;
        private DataSet bookDataSet;
       // private MySqlDataReader dataReader;
        public DataAccessObject()
        {
            connection = new MySqlConnection(Constant.DATABASE_CONNECTION_INFOMATION);
            //command = new MySqlCommand();
            // dataSet = new DataSet();
            userDataSet = new DataSet();
            bookDataSet = new DataSet();
        }

        public void InputUserDateInDataBase(string identity, string password, string name, string brithYear, string phoneNumber, string address)
        {
            if (command == null) { MySqlCommand command = new MySqlCommand(); }
            connection.Open();
            command.Connection = connection;
            command.CommandText = "insert into user (ID, PASSWORD, Name, BirthYear, PhoneNumber, Address) value (@idParameter, @passwordParameter, @nameParameter, @birthYearParameter, @phoneNumberParameter, @addressParameter)";

            command.Parameters.AddWithValue("@idParameter", identity);
            command.Parameters.AddWithValue("@passwordParameter", password);
            command.Parameters.AddWithValue("@nameParameter", name);
            command.Parameters.AddWithValue("@birthYearParameter", brithYear);
            command.Parameters.AddWithValue("@phoneNumberParameter", phoneNumber);
            command.Parameters.AddWithValue("@addressParameter", address);
            command.ExecuteNonQuery();
            Console.WriteLine("추가를 완료했습니다.");
            connection.Close(); // mysql DB 연결 종료
        }

        public void InputBookDateInDataBase(string identity, string Title, string Author, string Publisher, string Number, string Price, string PublicationDate, string ISBN, string Explanation)
        {
            if(command == null){ MySqlCommand command = new MySqlCommand(); }
            connection.Open();
            command.Connection = connection;
            command.CommandText = "insert into book (ID, Title, Author, Publisher, Number, Price, PublicationDate, ISBN, Explanation) value (@idParameter, @TitleParameter, @AuthorParameter, @PublisherParameter, @NumberParameter, @PriceParameter, @PublicationDateParameter, @ISBNParameter, @ExplanationParameter)";

            command.Parameters.AddWithValue("@idParameter", identity);
            command.Parameters.AddWithValue("@TitleParameter", Title);
            command.Parameters.AddWithValue("@AuthorParameter", Author);
            command.Parameters.AddWithValue("@PublisherParameter", Publisher);
            command.Parameters.AddWithValue("@NumberParameter", Convert.ToInt32(Number));
            command.Parameters.AddWithValue("@PriceParameter", Convert.ToInt32(Price));
            if (PublicationDate == Constant.NULL) { command.Parameters.AddWithValue("@PublicationDateParameter", "        "); }
            else { command.Parameters.AddWithValue("@PublicationDateParameter", PublicationDate); }
            if (ISBN == Constant.NULL) { command.Parameters.AddWithValue("@ISBNParameter", "                 "); }
            else { command.Parameters.AddWithValue("@ISBNParameter", ISBN); }
            if (Explanation == Constant.NULL) { command.Parameters.AddWithValue("@ExplanationParameter", "등록되지 않음"); }
            else { command.Parameters.AddWithValue("@ExplanationParameter", Explanation); }
            command.ExecuteNonQuery();
            connection.Close(); // mysql DB 연결 종료
        }

        public void RemoveDateInDataBase(string tableName, string identity)//, string password, string name, string brithYear, string phoneNumber, string address
        {
            connection.Open();
            string quary = "delete from "+ tableName+" where ID='"+identity+"';";
            
            MySqlCommand command = new MySqlCommand(quary, connection);
            
            MySqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("삭제를 완료하였습니다.");
            Console.ReadLine();
            connection.Close(); // mysql DB 연결 종료
        }

        public string CheckUserData(string identity)
        { // ID가 존재하면 b 리턴, 맞으면 password 리턴
            string password = "b";
            connection.Open();
            string quary = "select * from user where ID='"+identity +"'";
            MySqlCommand command = new MySqlCommand(quary, connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                password = dataReader["PASSWORD"].ToString();
                break;
            }
            dataReader.Close();
            connection.Close();
            return password;
        }

        public DataSet GetAllBookData()
        {
            if (bookDataSet == null)
            {
                DataSet bookDataSet = new DataSet();
                string quary = "select * from book";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(quary, connection);
                mySqlDataAdapter.Fill(bookDataSet, "book");
            }
            return bookDataSet;
        }

        public DataSet GetAllUserData()
        {
            if(userDataSet == null)
            {
                userDataSet = new DataSet();
                string quary = "select * from user";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(quary, connection);
                mySqlDataAdapter.Fill(userDataSet, "user");
            }
            return userDataSet;
        }

        public DataSet SearchDataList(string table, string column, string value)
        {
            DataSet dataSet = new DataSet();
            string quary = "select * from " + table + " where " + column + " like '%" + value + "%'"; 
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(quary, connection);
            mySqlDataAdapter.Fill(dataSet, table);
            return dataSet;
            //SELECT * FROM table_name WHERE column_name LIKE "%value%";
        }

        public DataSet CorrectDataList(string value)
        {
            DataSet dataSet = new DataSet();
            string quary = "select * from user where BirthYear='" + value + "'";
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(quary, connection);
            mySqlDataAdapter.Fill(dataSet, "user");
            return dataSet;
        }
    }
}
