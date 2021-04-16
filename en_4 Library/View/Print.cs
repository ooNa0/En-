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
            //Console.WriteLine("└─────────────────────────────[뒤로가기 :: ESC]────────────────────────┘");
            Console.WriteLine(); Console.WriteLine();
        }
        public void LibraryEscapeKey()
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
            //Console.WriteLine("└──────────────────────────────────────────────────────────────────────┘");
            Console.WriteLine("└────────────────────────────[뒤로가기 :: ESC]─────────────────────────┘");
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

        public void ShowAdministratorMode()
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
            //Console.WriteLine("                              이미 존재하는 아이디입니다.");
            Console.WriteLine("\n\n이미 존재하는 아이디입니다.");
            Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine("                              아무키나 입력해주세요..");
            Console.WriteLine("\n아무키나 입력해주세요..");
            Console.ReadLine();
        }

        public void IncorrectPassword()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("\n\n                       틀렸습니다. 다시 입력해주세요.");
            Console.WriteLine("\n\n틀렸습니다. 다시 입력해주세요.");
            Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine("\n\n                (5번 이상 틀릴 경우 초기화면으로 돌아갑니다.)");
            Console.WriteLine("\n(5번 이상 틀릴 경우 초기화면으로 돌아갑니다.)");
            Console.ReadLine();
        }
        public void ShowBookList(List<BookVO> bookList)
        {
            Console.Clear();
            int count = bookList.Count - 1;
            Console.WriteLine("도서명               저자                 출판사명          수량 ");
            while (count >= 0)
            {
                Console.WriteLine("-------------------------------------------------------------------");
                foreach (BookVO book in bookList)
                {
                    Console.WriteLine("{0}", book.ToString());
                }
                break;
            }
            Console.ReadLine();
            Console.Clear();
        }
        public void ShowUserList(List<UserVO> userList)
        {
            Console.Clear();
            int count = userList.Count - 1;
            Console.WriteLine("이름               아이디                 나이 ");
            while (count >= 0)
            {
                Console.WriteLine("-------------------------------------------------------------------");
                foreach (UserVO user in userList)
                {
                    Console.WriteLine("{0}", user.ToString());
                }
                break;
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}
