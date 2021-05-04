using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace en_6_Library_DB
{
    class OutputData
    {
        private OutputMenu outputMenu;
        public OutputData(OutputMenu outputMenu)
        {
            this.outputMenu = outputMenu;
        }
        

        public void ShowAllBookList(DataSet dataSet)
        {
            Console.Clear(); outputMenu.LibraryDefault();
            Console.WriteLine("도서명(저자_출판사명) - 대여 가능 수량 ");
            if (dataSet.Tables.Count > 0)
            {
                foreach(DataRow row in dataSet.Tables[0].Rows)
                {
                    Console.Write(row["ID"]); Console.Write(row["Title"]);
                    Console.Write(row["Author"]); Console.Write(row["Publisher"]);
                    Console.Write(row["Number"]); Console.Write(row["borrowedNumber"]);
                    Console.Write(row["Price"]);
                }
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");
             }
        }

        public void ShowAllUserList(DataSet dataSet)
        {
            Console.Clear(); outputMenu.LibraryDefault();
            Console.WriteLine("유저이름(아이디_생년) - 휴대폰번호 | 주소 ");
            if (dataSet.Tables.Count > 0)
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Console.Write(row["Name"]); Console.Write(row["ID"]);
                    Console.Write(row["BirthYear"]); Console.Write(row["PhoneNumber"]);
                    Console.Write(row["Address"]);
                }
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");
            }
        }

        public void ShowUserInformation()
        {
            Console.WriteLine("\n[1] 이름 : {0}", userList[userNumber].Name);
            Console.WriteLine("\n[2] 나이 : {0}", userList[userNumber].Age);
            Console.WriteLine("\n[3] 아이디 : {0}", userList[userNumber].Id);
            Console.WriteLine("\n[4] 비밀번호 : {0}", userList[userNumber].PhoneNumber);
            Console.WriteLine("\n[5] 전화번호 : {0}", userList[userNumber].Id);
            Console.WriteLine("\n[6] 주소 : {0}", userList[userNumber].PhoneNumber);
            if (userList[userNumber].BorrowBook != "")
            {
                Console.WriteLine("\n빌린 책 제목 : {0}", userList[userNumber].BorrowBook);
                Console.WriteLine("\n대출일 : {0}", userList[userNumber].BorrowDate);
                Console.WriteLine("\n반납일 : {0}", userList[userNumber].RorrowDate);
            }
        }*/
    }
}
