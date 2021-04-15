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
            keyInput = Console.ReadKey(isPassword);
            string input = "";
            while (Constant.RECEIVE_KEY_INPUT)
            {
                if(keyInput.Key != ConsoleKey.Enter && keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Escape)
                {
                    input += keyInput.KeyChar;
                    if (isPassword)
                    {
                        Console.Write("*");
                    }
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input = input.Substring(0, (input.Length - 1));
                        Console.Write("b b");
                    }
                    if (keyInput.Key == ConsoleKey.Escape)
                    {
                        return "NULL";
                    }
                    if (keyInput.Key == ConsoleKey.Enter)
                    {
                        return input;
                    }
                }
                keyInput = Console.ReadKey(isPassword);
            }
        }
    }
}
