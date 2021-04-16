using System;
using System.Collections.Generic;
using System.Text;

namespace en_4_Library
{
    class Input
    {
        ConsoleKeyInfo keyInput;
        
        public string KeyChar(bool isPassword)
        {
            string input = "";
            while (Constant.RECEIVE_KEY_INPUT)
            {
                keyInput = Console.ReadKey(isPassword);
                switch (keyInput.Key)
                {
                    case ConsoleKey.Enter:
                        return input;
                    case ConsoleKey.Backspace:
                        if(input.Length > 0)
                        {
                            if (isPassword)
                            {
                                input = input.Substring(0, (input.Length - 1));
                                Console.Write("\b \b");
                            }
                            else
                            {
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                                Console.Write(" ");
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                input = input.Substring(0, (input.Length - 1));
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        return "ESC";
                    default:
                        input += keyInput.KeyChar;
                        if (isPassword)
                        {
                            Console.Write("*");
                        }
                        break;
                }
            }
        }
    }
}
