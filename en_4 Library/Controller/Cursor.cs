using en_4_Library.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace en_4_Library
{
    class Cursor
    {
        Print print = new Print(); // 매개 변수로
        Constant constant = new Constant(); // 매개변수로 빼기

        ConsoleKeyInfo keyInfo;
        public int controlCursor(int min, int max)//Print print, Constant constant, 
        {
            int y = 0;
            while (Constant.USING_CURSOR)
            {
                Console.Clear();
                print.ShowMenu();
                Console.SetCursorPosition(Constant.X_POSITION, y);
                Console.Write('▶');
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if(y > min) 
                        { 
                            y--; 
                        }
                        else if(y == min)
                        {
                            y = max;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (y < max) 
                        { 
                            y++; 
                        }
                        else if(y == max)
                        {
                            y = min;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return y;
                    case ConsoleKey.Escape:
                        Console.WriteLine("메뉴로 돌아갑니다.");
                        break;
                }
            }
        }
    }
}
