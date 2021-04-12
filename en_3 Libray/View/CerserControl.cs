using en_3_Libray.View;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace en_3_Libray
{
    class CerserControl
    {
        public bool cerserControl(int Y, int min, int max)
        {
            Printing print = new Printing();
            bool isOpen = false;
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
                        if (y > 0) { y--; }
                        break;
                    case ConsoleKey.DownArrow:
                        if (y < 3) { y++; }
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

    }
}
