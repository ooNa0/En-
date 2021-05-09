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
            int count = 0;
            Console.Clear(); outputMenu.LibraryDefault();
            Console.WriteLine("도서명(저자_출판사명) - 수량, 가격 ");
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                count++;
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");
                Console.Write("NO :[{0}]  ", row["ID"]);
                Console.WriteLine("도서 제목:{0}", row["title"]);
                Console.WriteLine("저자:{0}", row["Author"]);
                Console.WriteLine("출판사:{0}", row["Publisher"]);
                Console.WriteLine("출판일:{0}", row["PublicationDate"]);
                Console.WriteLine("가격:{0}원, ISBN:{1}", row["Price"], row["ISBN"]);
                Console.WriteLine("설명:{0}", row["Explanation"]);
            }
            Console.WriteLine("───────────────────────────────────────────────────────────────────────");
            //Console.ReadLine();
            return count;
        }

        public void ShowAllUserList(DataSet dataSet)
        {
            Console.Clear(); outputMenu.LibraryDefault();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");
                Console.WriteLine("사용자 이름: {0}\n생년 :{1} 아이디: {2}\n전화번호: {3} 주소: {4}", row["Name"], row["ID"], row["BirthYear"], row["PhoneNumber"], row["Address"]);
            }
            Console.WriteLine("───────────────────────────────────────────────────────────────────────");
        }

        public int ShowUserborrowedBook(DataSet dataSet)
        {
            int count = 0;
            Console.WriteLine("빌린 책 이름  반납일");

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");
                count++;
                Console.WriteLine(" NO:{0} 책이름: {1} 반납일:", row["book_id"], row["bookName"], row["time"]);
            }
            Console.WriteLine("───────────────────────────────────────────────────────────────────────");
            return count;
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
            
        }

        public void ShowAllNaverBookList(JObject parseJson)
        {
            Console.Clear(); outputMenu.LibraryDefault();
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

                Console.WriteLine("설명:{0}", jToken["description"]);
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");
                i++;
            }
            Console.WriteLine("ENTER하시면 뒤로 갑니다.");
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