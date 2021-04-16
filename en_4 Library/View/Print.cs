using System;
using System.Collections.Generic;
using System.Text;

namespace en_4_Library.View
{
    class Print
    {
        public void Library()
        {
            Console.WriteLine("┌──────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                                      │");
            Console.WriteLine("│   ■       ■  ■■■■   ■■■■     ■■   ■■■■   ■    ■    │");
            Console.WriteLine("│   ■       ■  ■     ■  ■     ■  ■    ■ ■     ■  ■    ■    │");
            Console.WriteLine("│   ■       ■  ■■■■   ■■■■   ■■■■ ■■■■    ■  ■     │"); 
            Console.WriteLine("│   ■       ■  ■     ■  ■■■     ■    ■ ■■■        ■       │");
            Console.WriteLine("│   ■       ■  ■     ■  ■   ■■  ■    ■ ■   ■■     ■       │");
            Console.WriteLine("│   ■■■■ ■  ■■■■   ■     ■  ■    ■ ■     ■     ■       │");
            Console.WriteLine("│                                                                      │");
            Console.WriteLine("└──────────────────────────────────────────────────────────────────────┘");
            Console.WriteLine(); Console.WriteLine();
        }

        public void ShowMenu()
        {
            Console.WriteLine("                              ▷ 로그인"); Console.WriteLine();
            Console.WriteLine("                              ▷ 회원가입"); Console.WriteLine();
            Console.WriteLine("                              ▷ 관리자 모드"); Console.WriteLine();
            Console.WriteLine("                              ▷ 종료");
        }

        public void ShowUserMenu()
        {
            Console.WriteLine("                              ▷ 도서 대출"); Console.WriteLine();
            Console.WriteLine("                              ▷ 도서 반납"); Console.WriteLine();
            Console.WriteLine("                              ▷ 전체 도서 출력"); Console.WriteLine();
            Console.WriteLine("                              ▷ 도서 검색"); Console.WriteLine();
            Console.WriteLine("                              ▷ 나의 정보"); Console.WriteLine();
            Console.WriteLine("                              ▷ 로그아웃");
        }

        public void ShowAdministratorMenu()
        {
            Console.WriteLine("                              ▷ 도서 등록"); Console.WriteLine();
            Console.WriteLine("                              ▷ 도서 삭제"); Console.WriteLine();
            Console.WriteLine("                              ▷ 도서 검색"); Console.WriteLine();
            Console.WriteLine("                              ▷ 전체 도서 출력"); Console.WriteLine();
            Console.WriteLine("                              ▷ 회원 리스트"); Console.WriteLine();
            Console.WriteLine("                              ▷ 회원 검색"); Console.WriteLine();
            Console.WriteLine("                              ▷ 회원 삭제"); Console.WriteLine();
            Console.WriteLine("                              ▷ 돌아가기");
        }

        public void ShowHowToSearchBook()
        {
            Console.WriteLine("                              ▷ 도서명"); Console.WriteLine();
            Console.WriteLine("                              ▷ 출판사"); Console.WriteLine();
            Console.WriteLine("                              ▷ 저자"); Console.WriteLine();
            Console.WriteLine("                              ▷ 돌아가기");
        }

        public void IsNotExistIdentity()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n이미 존재하는 아이디가 아닙니다.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n아무키나 입력해주세요..");
            Console.ReadLine();
        }

        public void IsExistIdentity()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n이미 존재하는 아이디입니다.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n아무키나 입력해주세요..");
            Console.ReadLine();
        }

        public void IncorrectPassword()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n틀렸습니다. 다시 입력해주세요.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n(5번 이상 틀릴 경우 초기화면으로 돌아갑니다.)");
            Console.ReadLine();
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
        }
    }
}
