using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
// 없는 아이디이다. 비밀번호가 일치하지 않는다. 
namespace en_3_Libray.Exception
{
    class Login
    {
        public string _identity;
        public string _passWord ="";

        public void StartLogin()
        {
            int failCount = 0;
            bool isSet = true;
            while (isSet)
            {
                Console.Clear();
                Console.Write("(영어와 숫자로 이루어진 10자리 이하)\n아이디 : ");
                _identity = Console.ReadLine();
                if (!Regex.IsMatch(_identity, "^[a-zA-Z0-9]{1,10}$"))
                {
                    if (failCount > 5) { Console.WriteLine("아이디는 영어와 숫자로 이루어진 10자리 이하 문자열입니다."); }
                    else if(failCount > 10)
                    {
                        Console.WriteLine(" 초기 화면으로 돌아갑니다.");
                        Thread.Sleep(500);
                        Console.ReadLine();
                        return;
                    }
                    Console.ReadLine();
                    failCount++;
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
                while (keyInfo.Key != ConsoleKey.Enter) {
                    _passWord += keyInfo.KeyChar;
                    Console.Write("*");
                    keyInfo = Console.ReadKey(true);
                }
                if(_passWord.Length < 4 || _passWord.Length > 15)//// 해당 아이디에 비밀번호가 맞는지
                {
                    Console.WriteLine("\n틀렸습니다. 다시 입력해주세요.");
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