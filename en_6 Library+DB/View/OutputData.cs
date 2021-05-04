using System;
using System.Collections.Generic;
using System.Text;

namespace en_6_Library_DB
{
    class OutputData
    {
        //private 
        public OutputData()
        {

        }/*
        public void ShowBookList(List<BookVO> bookList, Print print)
        {
            Console.Clear(); print.Library();
            int count = bookList.Count - 1;
            Console.WriteLine("도서명(저자_출판사명) - 대여 가능 수량 ");
            while (count >= 0)
            {
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");
                foreach (BookVO book in bookList)
                {
                    Console.WriteLine("{0}", book.ToString());
                }
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");
                break;
            }
        }

        public void ShowBookList(List<BookVO> bookList, Print print)
        {
            Console.Clear(); print.Library();
            int count = bookList.Count - 1;
            Console.WriteLine("도서명(저자_출판사명) - 대여 가능 수량 ");
            while (count >= 0)
            {
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");
                foreach (BookVO book in bookList)
                {
                    Console.WriteLine("{0}", book.ToString());
                }
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");

                break;
            }
        }

        public void ShowUserList(List<UserVO> userList, Print print)
        {
            Console.Clear(); print.Library();
            int count = userList.Count - 1;
            Console.WriteLine("    이름        아이디              나이               전화번호");
            while (count >= 0)
            {
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");
                foreach (UserVO user in userList)
                {
                    Console.WriteLine("{0}", user.ToString());
                }
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");

                break;
            }
        }

        public void ShowUserInformation(List<UserVO> userList, int userNumber)
        {
            Console.WriteLine("\n이름 : {0}", userList[userNumber].Name);
            Console.WriteLine("\n나이 : {0}", userList[userNumber].Age);
            Console.WriteLine("\n아이디 : {0}", userList[userNumber].Id);
            Console.WriteLine("\n비밀번호 : {0}", userList[userNumber].PhoneNumber);
            if (userList[userNumber].BorrowBook != "")
            {
                Console.WriteLine("\n빌린 책 제목 : {0}", userList[userNumber].BorrowBook);
                Console.WriteLine("\n대출일 : {0}", userList[userNumber].BorrowDate);
                Console.WriteLine("\n반납일 : {0}", userList[userNumber].RorrowDate);
            }
        }*/
    }
}
