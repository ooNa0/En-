using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using MySql.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Tls;

namespace en_6_Library_DB
{
    class DataAccessObject // 데베의 데이터 조회, 조작 기능
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private DataSet userDataSet;
        private DataSet bookDataSet;
        private DataSet currentBorrowedBookStatus;
        // private MySqlDataReader dataReader;
        private UserDataTransferObject userDataTransferObject;
        public DataAccessObject()
        {
            if(connection == null)
                connection = new MySqlConnection(Constant.DATABASE_CONNECTION_INFOMATION);
            //command = new MySqlCommand();
            // dataSet = new DataSet();
        }

        public void InputUserDateInDataBase(string identity, string password, string name, string brithYear, string phoneNumber, string address)
        {
            if (command == null) { command = new MySqlCommand(); }
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

        public void InputBookDateInDataBase(string Title, string Author, string Publisher, string Number, string Price, string PublicationDate, string ISBN, string Explanation)
        {//string identity, 
            if (command == null){ command = new MySqlCommand(); }
            connection.Open();
            command.Connection = connection;
            //command.CommandText = "insert into book (ID, Title, Author, Publisher, Number, Price, PublicationDate, ISBN, Explanation) value (@idParameter, @TitleParameter, @AuthorParameter, @PublisherParameter, @NumberParameter, @PriceParameter, @PublicationDateParameter, @ISBNParameter, @ExplanationParameter)";
            command.CommandText = "insert into book (Title, Author, Publisher, Number, Price, PublicationDate, ISBN, Explanation) value (@TitleParameter, @AuthorParameter, @PublisherParameter, @NumberParameter, @PriceParameter, @PublicationDateParameter, @ISBNParameter, @ExplanationParameter)";
            //command.Parameters.AddWithValue("@idParameter", 1);
            //command.Parameters.AddWithValue("@idParameter", identity);
            command.Parameters.AddWithValue("@TitleParameter", Title);
            command.Parameters.AddWithValue("@AuthorParameter", Author);
            command.Parameters.AddWithValue("@PublisherParameter", Publisher);
            command.Parameters.AddWithValue("@NumberParameter", Convert.ToInt32(Number));
            command.Parameters.AddWithValue("@PriceParameter", Convert.ToInt32(Price));
            Console.WriteLine("ssssssssssssssssssssssssssssssssss");
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
            Console.WriteLine(command);
            MySqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("삭제를 완료하였습니다.");
            Console.ReadLine();
            connection.Close(); // mysql DB 연결 종료
        }

        public UserDataTransferObject CheckUserData(string identity, UserDataTransferObject userDataTransferObject)
        { // ID의 값 가져오기! 다 가져오기
            string password = "b";
            connection.Open();
            string quary = "select * from user where ID='"+identity +"'";
            MySqlCommand command = new MySqlCommand(quary, connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            // userDataTransferObject();
            while (dataReader.Read())
            {
                if (userDataTransferObject == null)
                    userDataTransferObject = new UserDataTransferObject(Convert.ToString(dataReader["ID"]), Convert.ToString(dataReader["PASSWORD"]), Convert.ToString(dataReader["Name"]),
                        Convert.ToString(dataReader["BirthYear"]), Convert.ToString(dataReader["PhoneNumber"]), Convert.ToString(dataReader["PhoneNumber"])
                        );
                else
                {
                    userDataTransferObject.SetId(Convert.ToString(dataReader["ID"]));
                    userDataTransferObject.SetPassword(Convert.ToString(dataReader["PASSWORD"]));
                    userDataTransferObject.SetName(Convert.ToString(dataReader["Name"]));
                    userDataTransferObject.SetBirthYear(Convert.ToString(dataReader["BirthYear"]));
                    userDataTransferObject.SetPhoneNumber(Convert.ToString(dataReader["PhoneNumber"]));
                    userDataTransferObject.SetAddress(Convert.ToString(dataReader["PhoneNumber"]));
                }
                password = dataReader["PASSWORD"].ToString();
                break;
            }
            dataReader.Close();
            connection.Close();
            return userDataTransferObject;
        }
        public int EditBookDataDiscount(int bookID, int editdiscount, bool isEditDiscount)
        {
            connection.Open();
            if (isEditDiscount)
            {
                
                string quary = "update * from book set discount ='" + editdiscount + "'where ID='" + bookID + "'";
                MySqlCommand command = new MySqlCommand(quary, connection);
                connection.Close();
                return 1;
            }
            string query = "select * from book where ID='" + bookID + "'";
            command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            int discount = Convert.ToInt16(dataReader["Discount"]);
            if (discount == 0)
            {
                Console.WriteLine("책을 빌릴 수 없습니다!"); return 0;
            }
            connection.Open();
            query = "update * from book set discount ='" + discount + editdiscount + "'where ID='" + bookID + "'";
            command = new MySqlCommand(query, connection);
            connection.Close();
            return 1;
            // book id, 이게 수정인지 하나 삭제인지 int형
            // 수정이면 수정
            // 하나 삭제면 discount-1 이런식으로 넣어주기, 근데 discount가 0이면 return 0
        }

        public string KnowBookTitle(int bookID)
        {
            string query = "select * from book where ID='" + bookID + "'";
            command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            return Convert.ToString(dataReader["Title"]);
        }

        public void UpdateCurrentBorrowedStatus(int bookID, string userID, bool isRemove)
        {
            string query;
            connection.Open();
            if (isRemove)
                query = "delete from currentborrowedstatus where book_id='" + bookID + "' and user_id='" + userID +"';";
            else
                query = "insert into currentborrowedstatus value(" + userID + "," + bookID + ","+ DateTime.Now + "," + KnowBookTitle(bookID) + ");";
            
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Close();
        }

        public DataSet ShowUserBorrowedStatus(string userID)
        {
            DataSet currentBorrowedBookStatus = new DataSet();
            string query;
            connection.Open();
            query = "select * from currentborrowedstatus where user_id='" + userID + "';";
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, connection);
            mySqlDataAdapter.Fill(currentBorrowedBookStatus, "currentborrowedstatus where");
            connection.Close();

            return currentBorrowedBookStatus;
        }

        public DataSet GetAllBookData()
        {
            DataSet bookDataSet = new DataSet();
                string quary = "select * from book";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(quary, connection);
                mySqlDataAdapter.Fill(bookDataSet, "book");
            
            return bookDataSet;
        }

        public DataSet GetAllUserData()
        {
            userDataSet = new DataSet();
                string quary = "select * from user";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(quary, connection);
                mySqlDataAdapter.Fill(userDataSet, "user");
            
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
            mySqlDataAdapter.Fill(dataSet, Constant.USER_TABLE);
            return dataSet;
        }

    }
}
