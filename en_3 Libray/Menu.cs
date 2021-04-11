using en_3_Libray.Exception;
using en_3_Libray.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace en_3_Libray.View
{
    class Menu
    {
        public bool isOpen = false;
        public void MainMenu()
        {
            Printing print = new Printing();
            ConsoleKeyInfo cki;
            int x = 0, y = 0;
            while (!isOpen)
            {
                Console.Clear();
                print.ShowMenu();
                Console.SetCursorPosition(x, y);
                Console.Write('▶');
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if(y > 0)
                        {
                            y--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if(y < 3)
                        {
                            y++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        SelectMenu(y);
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("메뉴로 돌아갑니다.");
                        break;
                }
            }
        }
        private void SelectMenu(int y)
        {
            Login login = new Login();
            SignUp signUp = new SignUp();
            Ask ask = new Ask();
            int yesOrNo;

            if (y == 0) // 로그인
            {
                login.StartLogin();
            }
            else if (y == 1) // 회원가입
            {
                signUp.StartSignUp();
            }
            else if (y == 2) // 관리자 모드
            {

            }
            else if(y == 3) // 종료
            {
                Console.Clear();
                Console.WriteLine("정말로 프로그램을 종료하시겠어요?");
                yesOrNo = ask.AskYesOrNo();
                if(yesOrNo == 0)
                {
                    Console.WriteLine("프로그램을 이용해주셔서 감사합니다.");
                    isOpen = true;
                }
                else
                {
                    Console.WriteLine("메뉴로 되돌아갑니다.\n아무키나 눌러주십시오.");
                    Console.ReadLine();
                }
            }
            else
            {

            }
        }
    }
}
