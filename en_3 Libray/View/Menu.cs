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
            int x = 0, y = 20;
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
    }
}
