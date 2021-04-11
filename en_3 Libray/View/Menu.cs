using en_3_Libray.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace en_3_Libray.View
{
    class Menu
    {
        public void MainMenu()
        {
            Printing print = new Printing();
            ConsoleKeyInfo cki;
            int x = 0, y = 0;
            while (true)
            {
                Console.Clear();
                print.ShowMenu();
                Console.SetCursorPosition(x, y);
                Console.Write('>');
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if(y >= 0)
                        {
                            y--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if(y <= 4)
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
            if (y == 0) // 로그인
            {
                login.StartLogin();
            }
            else if (y == 1) // 회원가입
            {

            }
            else if (y == 2) // 관리자 모드
            {

            }
            else if(y == 3) // 종료
            {

            }
            else
            {

            }
        }
    }
}
