using en_3_Libray.Exception;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace en_3_Libray.User
{
    class SignUp
    {
        public string _identity;
        public string _passWord = "";
        public void StartSignUp()
        {
            bool isSet = true;

            while (isSet) // 아이디
            {
                Console.Clear();

                Console.Write("생성하실 아이디를 입력해주세요. 영어와 숫자만으로 10자리 이내로 입력해주세요.\n아이디 : ");
                _identity = Console.ReadLine();
                if (!(Regex.IsMatch(_identity, "^[a-zA-Z0-9]{1,10}$"))) // 영어와 숫자만 받음
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("영어(대소문자 상관 없음)와 숫자만 10자리 이내로 입력해주세요.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
                else
                {
                    isSet = false;
                }
            }

            while (!isSet) // 비밀번호
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
                // 비밀번호는 하나의 영문자 이상, 하나의 특수문자 이상, 영어+숫자+특수문자로 이루어져있으며 7~15 크기
                if(!Regex.IsMatch(_identity, "/^(?=.*[A-Za-z])(?=.*[@.!%*#?&])[A-Za-z0-9@.!%*#?&]{7,15}$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("비밀번호는 최소 하나의 영문자, 하나의 특수문자(@.!%*#?& 중) 가 포함되어야 하고,");
                    Console.WriteLine("길이는 8보다 크고 15보다 작아야 합니다.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
                else
                {
                    isSet = true;
                }
            }

            while (isSet) // 이름
            {
                Console.Clear();

                Console.Write("4글자 이내로 한글로 성함을 입력해주세요.(띄어쓰기 불가능)\n 성함 : ");
                _identity = Console.ReadLine();
                if (!(Regex.IsMatch(_identity, "^[가-힣]{1,4}$")))
                {
                    Console.WriteLine("4글자 이내 한글만 입력이가능합니다.");
                    Console.ReadLine();
                }
                else
                {
                    isSet = false;
                    // 리스트에 넣기
                }
            } 
            
            while (!isSet) // 생년월일
            {
                Console.Write("(yyyy/mm/dd 형식) 생년월일 : ");
                
                if (!(Regex.IsMatch(_identity, "^/{4}/{1,2}/{1,2}$")))
                {
                    Console.WriteLine("숫자만 입력이 가능합니다.");
                    Console.ReadLine();
                }
                else
                {
                    isSet = false;
                    // 리스트에 넣기
                }
            }

            while (isSet) // 전화번호
            {
                Console.Write("(000-0000-0000 형식으로 입력해주세요.)\n전화번호: ");

                if (!Regex.IsMatch(_identity, "^{3}-{4}-{4}$"))
                {
                    Console.WriteLine("000-0000-0000 형식으로 입력해주세요.");
                    Console.ReadLine();
                }
                else
                {
                    isSet = true;
                    // 리스트에 넣기
                }
            }
        }
    }
}

/*
                if (_passWord.Length < 4 || _passWord.Length > 15)
                {
                    Console.WriteLine("\n길이에 문제가 있습니다. 다시 입력해주세요.");
                    Console.ReadLine();
                    Console.Clear();
                    Console.Write("아이디 : " + _identity + "\n");
                }
                else if (!(Regex.IsMatch(_identity, "^[a-zA-Z0-9]*$"))) // 영어와 숫자만 받음
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("영어(대소문자 상관 없음)와 숫자만 입력해주세요.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
                else
                {
                    isSet = false;
                }
    */