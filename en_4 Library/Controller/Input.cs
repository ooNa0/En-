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
            //List<char> input = new List<char>();
            //List<char> esc = new List<char>("ESC");
            while (Constant.RECEIVE_KEY_INPUT)
            {
                // switch로 수정하기
                if(keyInput.Key != ConsoleKey.Enter && keyInput.Key != ConsoleKey.Backspace && keyInput.Key != ConsoleKey.Escape)
                {
                    input += keyInput.KeyChar;
                    //input.Add(keyInput.KeyChar);
                    if (isPassword)
                    {
                        Console.Write("*");
                    }
                }
                else
                {
                    if (keyInput.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        if (isPassword)
                        {
                            input = input.Substring(0, (input.Length - 1));
                            //input.RemoveAt(input.Count - 1);
                            Console.Write("\b \b");//keyInput.KeyChar);
                        }
                        else
                        {
                            input = input.Substring(0, (input.Length - 1));
                            //input.Remove(1);
                            //Console.Write("\b");
                        }
                    }
                    if (keyInput.Key == ConsoleKey.Escape)
                    {
                        //esc.Add("E");
                        return "ESC";
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
