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
            Console.Write("엔터하면 뒤로갑니다.");
            Console.ReadLine();
        }
        
        public void ShowUserInformation(DataSet dataSet)
        {
            Console.Clear(); outputMenu.LibraryDefault();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Console.WriteLine("\n[1] 이름 : {0}", row["Name"]);
                Console.WriteLine("\n[2] 나이 : {0}", row["BirthYear"]);
                Console.WriteLine("\n[3] 아이디 : {0}", row["ID"]);
                Console.WriteLine("\n[4] 전화번호 : {0}", row["PhoneNumber"]);
                Console.WriteLine("\n[5] 주소 : {0}", row["Address"]);
                
                // 수정할거 컨트롤러에서 받기 -> 수정
                /*if (userList[userNumber].BorrowBook != "")
                {
                    Console.WriteLine("\n빌린 책 제목 : {0}", userList[userNumber].BorrowBook);
                    Console.WriteLine("\n대출일 : {0}", userList[userNumber].BorrowDate);
                    Console.WriteLine("\n반납일 : {0}", userList[userNumber].RorrowDate);
                }*/
            }
        }

        public void ShowAllNaverBookList(string text, bool isRegistration)
        {
            Console.Clear(); outputMenu.LibraryDefault();
            JObject parseJson = JObject.Parse(text);

            if (parseJson["items"].ToString() == "[]")
            {
                Console.WriteLine("검색한 도서가 존재하지 않습니다!");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("네이버 도서 검색 결과 ");
            Console.WriteLine("───────────────────────────────────────────────────────────────────────");


            for (int i = 0; i < Constant.NAVER_API_DISPLAY_NUMBER; i++)
            {
                Console.Write("NO :{0}\n", i);
                Console.WriteLine("도서 제목:{0}", parseJson["items"][i]["title"]);

                Console.WriteLine("저자:{0}", parseJson["items"][i]["author"]);

                Console.WriteLine("출판사:{0}", parseJson["items"][i]["publisher"]);

                Console.WriteLine("가격:{0} ISBN:{1}", parseJson["items"][i]["price"], parseJson["items"][i]["isbn"]);
                //description = 
                Console.WriteLine("설명:{0}", parseJson["items"][i]["description"]);
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");
            }
            int index = 0;
            if (isRegistration)
            {
                Console.WriteLine(Convert.ToString(parseJson["items"][index]["title"]));
                //index = inputManagement.GetNaverBookNO();
                Console.WriteLine("______________");
                dataAccessObject.InputBookDateInDataBase(Convert.ToString(parseJson["items"][index]["title"]), Convert.ToString(parseJson["items"][index]["Author"]), Convert.ToString(parseJson["items"][index]["Publisher"]), Convert.ToString(parseJson["items"][index]["Number"]), Convert.ToString(parseJson["items"][index]["Price"]), Convert.ToString(parseJson["items"][index]["PublicationDate"]), Convert.ToString(parseJson["items"][index]["ISBN"]), Convert.ToString(parseJson["items"][index]["Explanation"]));
                // 책 등록
            }
            Console.ReadLine();
        }
    }
}
