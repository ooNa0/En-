using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace en_6_Library_DB
{
    class DataAccessObject // 데베의 데이터 조회, 조작 기능
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private DataSet userDataSet;
        public DataAccessObject()
        {
            if(connection == null)
                connection = new MySqlConnection(Constant.DATABASE_CONNECTION_INFOMATION);
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
            command.Parameters.Clear();
            Console.WriteLine("추가를 완료했습니다.");
            connection.Close(); // mysql DB 연결 종료
        }

        public void InputBookDateInDataBase(string Title, string Author, string Publisher, string Number, string Price, string PublicationDate, string ISBN, string Explanation)
        {
            if (command == null){ command = new MySqlCommand(); }
            connection.Open();
            command.Connection = connection;
            command.CommandText = "insert into book (Title, Author, Publisher, Number, Price, PublicationDate, ISBN, Explanation) value (@TitleParameter, @AuthorParameter, @PublisherParameter, @NumberParameter, @PriceParameter, @PublicationDateParameter, @ISBNParameter, @ExplanationParameter)";
            command.Parameters.AddWithValue("@TitleParameter", Title);
            command.Parameters.AddWithValue("@AuthorParameter", Author);
            command.Parameters.AddWithValue("@PublisherParameter", Publisher);
            command.Parameters.AddWithValue("@NumberParameter", Convert.ToInt32(Number));
            command.Parameters.AddWithValue("@PriceParameter", Convert.ToInt32(Price));
            if (PublicationDate == null) { command.Parameters.AddWithValue("@PublicationDateParameter", "등록되지 않음"); }
            else { command.Parameters.AddWithValue("@PublicationDateParameter", PublicationDate); }
            if (ISBN == null) { command.Parameters.AddWithValue("@ISBNParameter", "등록되지 않음"); }
            else { command.Parameters.AddWithValue("@ISBNParameter", ISBN); }
            if (Explanation == null) { command.Parameters.AddWithValue("@ExplanationParameter", "등록되지 않음"); }
            else { command.Parameters.AddWithValue("@ExplanationParameter", Explanation); }
            
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            connection.Close(); // mysql DB 연결 종료
        }

        public void RemoveDateInDataBase(string tableName, string identity)
        {
            string quary;
            connection.Open();
            if (tableName == Constant.BOOK_TABLE) { quary = "delete from " + tableName + " where ID='" + Convert.ToInt32(identity) + "';"; }
            else { quary = "delete from " + tableName + " where ID='" + identity + "';"; }
            MySqlCommand command = new MySqlCommand(quary, connection);
            if (command.ExecuteNonQuery() <= 0) { Console.WriteLine("삭제를 실패하였습니다."); }
            else { Console.WriteLine("삭제를 완료하였습니다."); }
            Console.ReadLine();
            connection.Close();
            // mysql DB 연결 종료
        }

        public UserDataTransferObject CheckUserData(string identity, UserDataTransferObject userDataTransferObject)
        { // ID의 값 가져오기! 다 가져오기
            string password = "b";
            connection.Open();
            string quary = "select * from user where ID='"+identity +"'";
            MySqlCommand command = new MySqlCommand(quary, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                if (userDataTransferObject == null)
                    userDataTransferObject = new UserDataTransferObject(Convert.ToString(dataReader["ID"]), Convert.ToString(dataReader["PASSWORD"]), Convert.ToString(dataReader["Name"]),
                        Convert.ToString(dataReader["BirthYear"]), Convert.ToString(dataReader["PhoneNumber"]), Convert.ToString(dataReader["Address"]));
                else
                {
                    userDataTransferObject.SetId(Convert.ToString(dataReader["ID"]));
                    userDataTransferObject.SetPassword(Convert.ToString(dataReader["PASSWORD"]));
                    userDataTransferObject.SetName(Convert.ToString(dataReader["Name"]));
                    userDataTransferObject.SetBirthYear(Convert.ToString(dataReader["BirthYear"]));
                    userDataTransferObject.SetPhoneNumber(Convert.ToString(dataReader["PhoneNumber"]));
                    userDataTransferObject.SetAddress(Convert.ToString(dataReader["Address"]));
                }
                password = dataReader["PASSWORD"].ToString();
                break;
            }
            dataReader.Close();
            connection.Close();
            return userDataTransferObject;
        }

        public bool EditBookDataNumber(string bookID, int editNumber)
        {
            connection.Open();
            string quary = "update book set Number='" + editNumber + "'where ID='" + bookID + "'";
            MySqlCommand command = new MySqlCommand(quary, connection);
            if (command.ExecuteNonQuery() <= 0) { Console.WriteLine("수정을 실패하였습니다."); }
            else { Console.WriteLine("수정을 완료하였습니다."); }
            Console.ReadLine();
            connection.Close();
            return Constant.IS_EDIT_BOOK_NUMBER;
        }

        public bool EditBorrowBookDataNumber(string bookID, int editNumber)
        {
            string query; int number = 0;
            connection.Open();
            if (editNumber == -1)
            {
                query = "select * from book where ID='" + bookID + "'";
                command = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    number = Convert.ToInt32(dataReader["Number"]);
                    if (number == Constant.ZERO)
                    {
                        Console.WriteLine("책을 빌릴 수 없습니다!");
                        Console.ReadLine();
                        dataReader.Close();
                        connection.Close();
                        return !Constant.IS_EDIT_BOOK_NUMBER;
                    }
                }
                dataReader.Close();
            }
            number += editNumber;
            query = "update book set Number='" + number + "'where ID='" + bookID + "'";
            //Console.WriteLine(query);
            command = new MySqlCommand(query, connection);
            if (command.ExecuteNonQuery() == 0)
                Console.WriteLine("작업을 완료하였습니다.");
            connection.Close();
            return Constant.IS_EDIT_BOOK_NUMBER;
        }

        public string KnowBookTitle(int bookID)
        {
            string bookTitle = Constant.BACK;
            string query = "select * from book where ID='" + bookID + "'";
            command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
                bookTitle = Convert.ToString(dataReader["Title"]);
            dataReader.Close();
            return bookTitle;
        }

        public void UpdateCurrentBorrowedStatus(string bookID, string userID, bool isRemove)
        {
            string query;
            connection.Open();
            Console.ReadLine();
            if (isRemove)
                query = "delete from currentborrowbookstatus where book_id='" + bookID + "' and user_id='" + userID +"';";
            else
                query = "insert into currentborrowbookstatus value('" + userID + "'," + bookID + ",'"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',\"" + KnowBookTitle(Convert.ToInt32(bookID)) + "\");";
            //Console.WriteLine(query);
            Console.ReadLine();
            command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery(); 
            connection.Close();
        }

        public DataSet ShowUserBorrowedStatus(string userID)
        {
            DataSet currentBorrowedBookStatus = new DataSet();
            string query;
            connection.Open();
            query = "select * from currentborrowbookstatus where user_id='" + userID + "';";
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, connection);
            mySqlDataAdapter.Fill(currentBorrowedBookStatus, "currentborrowbookstatus");
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
