using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace en_6_Library_DB
{
    class DataAccessObject // 데베의 데이터 조회, 조작 기능
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private DataSet dataSet;
        public DataAccessObject()
        {
            connection = new MySqlConnection(Constant.DATABASE_CONNECTION_INFOMATION);
            command = new MySqlCommand();
            dataSet = new DataSet();
        }

        public void InputUserDateInDataBase(string identity, string password, string name, string brithYear, string phoneNumber, string address)
        {
            // MySqlDataReader  -> input, update문에 사용

            //MySqlCommand command = new MySqlCommand("select * from user");

            connection.Open();
            command.Connection = connection;
            command.CommandText = "insert into user (ID, PASSWORD, Name, BirthYear, PhoneNumber, Address) value (@idParameter, @passwordParameter, @nameParameter, @birthYearParameter, @phoneNumberParameter, @addressParameter)";

            command.Parameters.AddWithValue("@idParameter", identity);
            command.Parameters.AddWithValue("@passwordParameter", password);
            command.Parameters.AddWithValue("@nameParameter", name);
            command.Parameters.AddWithValue("@birthYearParameter", brithYear);
            command.Parameters.AddWithValue("@phoneNumberParameter", phoneNumber);
            command.Parameters.AddWithValue("@addressParameter", address);
            /*
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }*/
            command.ExecuteNonQuery();
            connection.Close(); // mysql DB 연결 종료
        }

        public DataSet CheckUserData(string identity)
        { // ID가 존재하면 b 리턴, 맞으면 password 리턴
            string quary = "select * from user where ID=" + identity;
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(quary, connection);
            mySqlDataAdapter.Fill(dataSet, "user");
            return dataSet;
        }

        public DataSet GetAllBookData()
        {
            //DataSet dataSet = new DataSet();
            string quary = "select * from book";
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(quary, connection);
            mySqlDataAdapter.Fill(dataSet, "book");
            return dataSet;
        }

        public DataSet GetAllUserData()
        {
            //DataSet dataSet = new DataSet();
            string quary = "select * from user";
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(quary, connection);
            mySqlDataAdapter.Fill(dataSet, "user");
            return dataSet;
        }
    }
}
