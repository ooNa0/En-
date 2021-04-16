using en_4_Library.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace en_4_Library
{
    class Cursor
    {
        Print print = new Print();
        ConsoleKeyInfo keyInfo;
        public int controlCursor(int minimum, int max, int mode)
        {
            int y = Constant.Y_POSITION;
            max += Constant.Y_POSITION + max;
            minimum += Constant.Y_POSITION + minimum;
            while (Constant.USING_CURSOR)
            {
                Console.Clear();
                print.Library();
                switch (mode)
                {
                    case Constant.MAIN_MENU:
                        print.ShowMenu();
                        break;
                    case Constant.USER_MENU:
                        print.ShowUserMenu();
                        break;
                    case Constant.ADMINISTRATOR_MODE:
                        print.ShowAdministratorMenu();
                        break;
                    case Constant.SEARCH_BOOK:
                        print.ShowHowToSearchBook();
                        break;
                }
                Console.SetCursorPosition(Constant.X_POSITION, y);
                Console.Write('▶');
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if(y > minimum) 
                        { 
                            y -= 2; 
                        }
                        else if(y == minimum)
                        {
                            y = max;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (y < max) 
                        { 
                            y += 2; 
                        }
                        else if(y == max)
                        {
                            y = minimum;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return y;
                    case ConsoleKey.Escape:
                        return -1;
                }
            }
        }
    }
}
