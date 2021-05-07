using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace en_6_Library_DB
{
    class OutputData
    {
        private OutputMenu outputMenu;
        private DataAccessObject dataAccessObject;
        private InputManagement inputManagement;
        public OutputData(OutputMenu outputMenu, DataAccessObject dataAccessObject, InputManagement inputManagement)
        {
            this.outputMenu = outputMenu;
            this.dataAccessObject = dataAccessObject;
            this.inputManagement = inputManagement;
        }
        

        public int ShowAllBookList(DataSet dataSet)
        {
            Console.Clear(); outputMenu.LibraryDefault();
            //Console.WriteLine(dataSet);
            Console.WriteLine("도서명(저자_출판사명) - 수량, 가격 ");
            Console.WriteLine("───────────────────────────────────────────────────────────────────────");
            //Console.WriteLine(dataSet.Tables.Count));
            if (dataSet == null) { Console.WriteLine("등록된 책이 없습니다."); return 0; }
                //
                // {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Console.WriteLine("{0} {1}({2}_{3}) - {4}, {5}", row["ID"], row["Title"], row["Author"], row["Publisher"], row["Number"], row["Price"]);
                }
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");
            // }
            return 1;
        }

        public void ShowAllUserList(DataSet dataSet)
        {
            Console.Clear(); outputMenu.LibraryDefault();
            Console.WriteLine("유저이름(아이디_생년) - 휴대폰번호 | 주소 ");
            //Console.WriteLine(dataSet.Tables.Count);
            Console.WriteLine("───────────────────────────────────────────────────────────────────────");

            //if (dataSet.Tables.Count > 0)
            //{
            foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Console.WriteLine("{0}({1}_{2}) - {3} {4}", row["Name"], row["ID"],row["BirthYear"], row["PhoneNumber"], row["Address"]);
                }
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");
            //}
        }

        public void ShowUserborrowedBook(DataSet dataSet)
        {
            Console.WriteLine("빌린 책 이름  반납일");
            Console.WriteLine("───────────────────────────────────────────────────────────────────────");

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Console.WriteLine("{0}{1}", row["user"], row["ID"]);
            }
            Console.WriteLine("───────────────────────────────────────────────────────────────────────");
           
            Console.Write("엔터하면 뒤로갑니다.");
            Console.ReadLine();
        }

        public void ShowUserInformation(UserDataTransferObject userData)
        {
            Console.Clear(); outputMenu.LibraryDefault();

            Console.WriteLine("\n\t[1] 이름 : {0}", userData.GetName());
            Console.WriteLine("\n\t[2] 생년월일 : {0}", userData.GetBirthYear());
            Console.WriteLine("\n\t[3] 아이디 : {0}", userData.GetId());
            Console.WriteLine("\n\t[4] 전화번호 : {0}", userData.GetPhoneNumber());
            Console.WriteLine("\n\t[5] 주소 : {0}", userData.GetAddress());

            Console.WriteLine("\n\n0을 누르면 뒤로가기, 1을 누르면 유저 정보 수정");

                // 수정할거 컨트롤러에서 받기 -> 수정
                /*if (userList[userNumber].BorrowBook != "")
                {
                    Console.WriteLine("\n빌린 책 제목 : {0}", userList[userNumber].BorrowBook);
                    Console.WriteLine("\n대출일 : {0}", userList[userNumber].BorrowDate);
                    Console.WriteLine("\n반납일 : {0}", userList[userNumber].RorrowDate);
                }*/
            
        }

        public void ShowAllNaverBookList(string text, bool isRegistration)
        {
            //Console.Clear(); outputMenu.LibraryDefault();
            JObject parseJson = JObject.Parse(text);
            Console.WriteLine(text);
            if (parseJson["items"].ToString() == "[]")
            {
                Console.WriteLine("검색한 도서가 존재하지 않습니다!");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("네이버 도서 검색 결과 ");
            Console.WriteLine("───────────────────────────────────────────────────────────────────────");

            //Console.WriteLine(parseJson["display"]);
            int i = 0;
            foreach(JToken jToken in parseJson["items"])
            {
                Console.Write("NO :[{0}]  ", i);
                Console.WriteLine("도서 제목:{0}", jToken["title"]);

                Console.WriteLine("저자:{0}", jToken["author"]);

                Console.WriteLine("출판사:{0}", jToken["publisher"]);
                Console.WriteLine("출판일:{0}", jToken["pubdate"]);

                Console.WriteLine("가격:{0}원, ISBN:{1}", jToken["price"], jToken["isbn"]);
                //description = 
                Console.WriteLine("설명:{0}", jToken["description"]);
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");
                i++;
            }

           
            int index = 0;
            string discount = "1";
            if (isRegistration) // 따로 Controller의 bookmanagement에 빼고 싶다
            {
                Console.WriteLine(parseJson["items"][index]["author"]);
                //index = inputManagement.GetBookNO(); // 이거도 controller
                //string discount = inputManagement.GetBookNumber();
                //Console.WriteLine("______________");
                dataAccessObject.InputBookDateInDataBase("11111",
                    "11111",
                    "11111", discount,
                    "11111",
                    "11111", 
                    "11111", 
                    "AAAA");
                // 책 등록
            }
            Console.ReadLine();
        }
    }
}
/*
 * dataAccessObject.InputBookDateInDataBase(Convert.ToString(parseJson["items"][index]["title"]), 
                    Convert.ToString(parseJson["items"][index]["author"]), 
                    Convert.ToString(parseJson["items"][index]["publisher"]), discount, 
                    Convert.ToString(parseJson["items"][index]["price"]), 
                    Convert.ToString(parseJson["items"][index]["pubdate"]), 
                    Convert.ToString(parseJson["items"][index]["isbn"]), 
                    "AAAA");

    */