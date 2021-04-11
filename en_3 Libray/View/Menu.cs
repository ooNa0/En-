using System;
using System.Collections.Generic;
using System.Text;

namespace en_3_Libray.View
{
    class Menu
    {
        public void MainMenu()
        {
            ConsoleKeyInfo cki;
            int x = 0, y = 0;
            while (true)
            {
                Console.Clear();
                ShowMenu();
                Console.SetCursorPosition(x, y);
                Console.Write('>');
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        y--;
                        break;
                    case ConsoleKey.DownArrow:
                        y++;
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
        private void ShowMenu()
        {
            Console.WriteLine("1. 로그인");
            Console.WriteLine("2. 회원가입");
            Console.WriteLine("3. 관리자 모드");
            Console.WriteLine("4. 종료하기");
        }
        private void SelectMeun(int y)
        {
            if (y == 0)
            {

            }
            else if (y == 1)
            {

            }
            else if (y == 2)
            {

            }
            else if(y == 3)
            {

            }
            else
            {

            }
        }
    }
}
