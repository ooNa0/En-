using System;
using System.Collections.Generic;
using System.Text;

namespace en_6_Library_DB
{
    class OutputMenu
    {
        public void LibraryDefault()
        {
            Console.Clear();
            Console.WriteLine("  ┌──────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("  │                                                                      │");
            Console.WriteLine("  │            ■           ■  ■    ■            ■                   │");
            Console.WriteLine("  │   ■■■■ ■   ■■■  ■  ■■■■  ■■■■  ■ ■■■■  □□ □□");
            Console.WriteLine("  │         ■ ■■■     ■■  ■    ■        ■■■       ■  □  □   □");
            Console.WriteLine("  │   ■■■■ ■  ■     ■■  ■■■■  ■■■■  ■ ■■■    □  □□□");
            Console.WriteLine("  │   ■       ■   ■■■  ■            ■        ■ ■        □  □   □");
            Console.WriteLine("  │   ■■■■ ■           ■ ■■■■■ ■■■■  ■  ■■■■ □□ □□");
            Console.WriteLine("  │                                                                      │");
            Console.WriteLine("  └──────────────────────────────────────────────────────────────────────┘");
            Console.WriteLine(); Console.WriteLine();
        }
        public void ShowFirstMenu()
        {
            Console.SetWindowSize(Constant.CONSOLE_SIZE_X, Constant.CONSOLE_SIZE_Y);
            LibraryDefault();
            Console.WriteLine("                              [0] 종료\n");
            Console.WriteLine("                              [1] 로그인\n");
            Console.WriteLine("                              [2] 회원가입\n");
            Console.WriteLine("                              [3] 관리자 모드");
        }

        public void ShowUserMenu()
        {
            LibraryDefault();
            Console.WriteLine("                              [0] 로그아웃\n");
            Console.WriteLine("                              [1] 도서 대출\n");
            Console.WriteLine("                              [2] 도서 반납\n");
            Console.WriteLine("                              [3] 전체 도서 출력\n");
            Console.WriteLine("                              [4] 도서 검색\n");
            Console.WriteLine("                              [5] 나의 정보");
        }

        public void ShowAdministratorMenu()
        {
            LibraryDefault();
            Console.WriteLine("                              [0] 돌아가기\n");
            Console.WriteLine("                              [1] 도서 등록\n");
            Console.WriteLine("                              [2] 도서 삭제\n");
            Console.WriteLine("                              [3] 전체 도서 출력\n");
            Console.WriteLine("                              [4] 도서 검색\n");
            Console.WriteLine("                              [5] 회원 리스트\n");
            Console.WriteLine("                              [6] 회원 검색\n");
            Console.WriteLine("                              [7] 회원 삭제");
        }

        public void ShowHowToSearchBook()
        {
            LibraryDefault();
            Console.WriteLine("                              [0] 돌아가기\n");
            Console.WriteLine("                              [1] 도서명\n");
            Console.WriteLine("                              [2] 출판사\n");
            Console.WriteLine("                              [3] 저자");
        }

        public void ShowAskAction()
        {
            LibraryDefault();
            Console.WriteLine("                              [0] 돌아가기\n");
            Console.WriteLine("                              [1] 검색하기\n");
        }

        public void ShowAskOtherAction(string input)
        {
            Console.WriteLine("                              [2] {0}", input);
        }
    }
}
