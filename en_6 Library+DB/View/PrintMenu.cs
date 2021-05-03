using System;
using System.Collections.Generic;
using System.Text;

namespace en_6_Library_DB
{
    class PrintMenu
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
        public void ShowFirstMenu()
        {
            Console.WriteLine("                              1. 로그인\n");
            Console.WriteLine("                              2. 회원가입\n");
            Console.WriteLine("                              3. 관리자 모드\n");
            Console.WriteLine("                              4. 종료");
        }

        public void ShowUserMenu()
        {
            Console.WriteLine("                              0. 로그아웃\n");
            Console.WriteLine("                              1. 도서 대출\n");
            Console.WriteLine("                              2. 도서 반납\n");
            Console.WriteLine("                              3. 전체 도서 출력\n");
            Console.WriteLine("                              4. 도서 검색\n");
            Console.WriteLine("                              5. 나의 정보");
        }

        public void ShowAdministratorMenu()
        {
            Console.WriteLine("                              0. 돌아가기\n");
            Console.WriteLine("                              1. 도서 등록\n");
            Console.WriteLine("                              2. 도서 삭제\n");
            Console.WriteLine("                              3. 도서 검색\n");
            Console.WriteLine("                              4. 전체 도서 출력\n");
            Console.WriteLine("                              5. 회원 리스트\n");
            Console.WriteLine("                              6, 회원 검색\n");
            Console.WriteLine("                              7. 회원 삭제");
        }

        public void ShowHowToSearchBook()
        {
            Console.WriteLine("                              0. 돌아가기\n");
            Console.WriteLine("                              1. 도서명\n");
            Console.WriteLine("                              2. 출판사\n");
            Console.WriteLine("                              3. 저자");
        }
    }
}
