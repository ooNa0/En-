using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace en_3_Libray.Exception
{
    class Login
    {
        public string _identity;
        public string _passWord ="";

        public void StartLogin()
        {
            while (true)
            {
                Console.Write("아이디를 입력해주십시오. :");
                _identity = Console.ReadLine();
                if (_identity.Length < 1 || _identity.Length > 10)
                {
                    Console.WriteLine("길이에 문제가 있습니다. 다시 입력해주세요.");
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                Console.Write("Enter password: ");
                ConsoleKeyInfo keyInfo;

                do
                {
                    keyInfo = Console.ReadKey(true);
                    // Skip if Backspace or Enter is Pressed
                    if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                    {
                        _passWord += keyInfo.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (keyInfo.Key == ConsoleKey.Backspace && _passWord.Length > 0)
                        {
                            // Remove last charcter if Backspace is Pressed
                            _passWord = _passWord.Substring(0, (_passWord.Length - 1));
                            Console.Write("b b");
                        }
                    }
                }
                // Stops Getting Password Once Enter is Pressed
                while (keyInfo.Key != ConsoleKey.Enter);
                Console.WriteLine();
                Console.WriteLine("---------------------------");
                Console.WriteLine("Your Password is : " + _passWord);
            }
            /*
            while (true)
            {
                Console.Write("비밀번호를 입력해주십시오. :");
                _identity = Console.ReadLine();
                if (_identity.Length < 1 || _identity.Length > 15)
                {
                    Console.WriteLine("길이에 문제가 있습니다. 다시 입력해주세요.");
                    Console.Clear();
                }
                else
                {
                    break;
                }
            }*/
        }
    }
}
