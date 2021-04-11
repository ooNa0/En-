using en_3_Libray.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace en_3_Libray.User
{
    class SignUp
    {
        public string _identity;
        public string _passWord = "";
        public void StartSignUp()
        {
            bool isSet = true;
            while (isSet)
            {
                Console.Clear();
                Console.Write("아이디 : ");
                _identity = Console.ReadLine();
                if (_identity.Length < 1 || _identity.Length > 10)
                {
                    Console.WriteLine("길이에 문제가 있습니다. 다시 입력해주세요.");
                    Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            while (isSet)
            {
                Console.Write("비밀번호 : ");
                ConsoleKeyInfo keyInfo;
                keyInfo = Console.ReadKey(true);
                //keyInfo.Key != ConsoleKey.Backspace && 
                while (keyInfo.Key != ConsoleKey.Enter)
                {
                    _passWord += keyInfo.KeyChar;
                    Console.Write("*");
                    keyInfo = Console.ReadKey(true);
                }
                if (_passWord.Length < 4 || _passWord.Length > 15)
                {
                    Console.WriteLine("\n길이에 문제가 있습니다. 다시 입력해주세요.");
                    Console.ReadLine();
                    Console.Clear();
                    Console.Write("아이디 : " + _identity + "\n");
                }
                else
                {
                    isSet = false;
                }
            }
        }
    }
}
