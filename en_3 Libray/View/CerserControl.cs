using en_3_Libray.View;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace en_3_Libray
{
    class CerserControl
    {
        public int cerserControl(int min, int max)
        {
            int y = 0;
            Printing print = new Printing();
            bool isOpen = false;
            ConsoleKeyInfo cki;
            //int x = 0, y = 0;
            while (!isOpen)
            {
                Console.Clear();
                print.ShowMenu();
                Console.SetCursorPosition(0, 0);
                Console.Write('▶');
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (y > min) { y--; }
                        break;
                    case ConsoleKey.DownArrow:
                        if (y < max) { y++; }
                        break;
                    case ConsoleKey.Enter:
                        return y;
                    case ConsoleKey.Escape:
                        Console.WriteLine("메뉴로 돌아갑니다.");
                        break;
                }
            }
            return y;
        }

    }
}
