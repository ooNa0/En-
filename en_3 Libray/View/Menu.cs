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
            int x = 40, y = 20;
            while (true)
            {
                Console.Clear();
                ShowMenu();
                Console.SetCursorPosition(x, y);
                Console.Write('@');
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
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAA");
            Console.WriteLine("BBBBBBBBBBBBBBBBBBBBBBB");
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAA");
        }
    }
}
