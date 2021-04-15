using en_3_Libray.Data;
using en_3_Libray.User;
using en_3_Libray.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
// 없는 아이디이다. 비밀번호가 일치하지 않는다. 
namespace en_3_Libray.Exception
{
    class Login
    {
        public string _identity;
        public string _passWord = "";
        public void StartLogin(List<UserVO> user)
        {
            int failCount = 0;
            bool isSet = true;
            Menu menu = new Menu();
            SignUp signup = new SignUp();
            int count = user.Count - 1;
            if (count < 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("회원가입을 먼저해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("아무키나 입력해주세요..");
                Console.ReadLine();
                menu.MainMenu();
            }
            while (isSet) // 아이디
            {
                Console.Clear();
                Console.WriteLine(user.Count);
                Console.Write("아이디 :");

                _identity = Console.ReadLine();

                Console.WriteLine(user.Count);

                while (count >= 0)
                {
                    if (_identity != user[count].Id)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("이미 존재하는 아이디가 아닙니다.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("아무키나 입력해주세요..");
                        Console.ReadLine();
                        menu.MainMenu();
                        //continue;
                    }
                    else
                    {
                        isSet = false;
                        break;
                    }
                }
            }

            count = user.Count - 1;
            while (!isSet)
            {
                ConsoleKeyInfo keyInput;
                //Console.Clear();
                Console.WriteLine("아이디 :" + _identity);
                Console.Write("비밀번호 : ");
                keyInput = Console.ReadKey(true);
                _passWord = "";
                while (keyInput.Key != ConsoleKey.Enter)
                {
                    _passWord += keyInput.KeyChar;
                    Console.Write("*");
                    keyInput = Console.ReadKey(true);
                }
                Console.Write(_passWord);

                if (_passWord != user[count].PassWord)//// 해당 아이디에 비밀번호가 맞는지
                {
                    Console.WriteLine("\n틀렸습니다. 다시 입력해주세요. (5번 이상 틀릴 경우 초기화면으로 돌아갑니다.");
                    if (failCount > 5)
                    {
                        Console.WriteLine(" 초기 화면으로 돌아갑니다.");
                        Thread.Sleep(500);
                        Console.ReadLine();
                        return;
                    }
                    Console.ReadLine();
                    failCount++;
                    //Console.Clear();
                    Console.Write("아이디 : " + _identity + "\n");
                }
                else
                {
                    Console.WriteLine("로그인 되었습니다. 반갑습니다. " + user[count].Name + "님");
                    Thread.Sleep(1000);
                    isSet = true;
                }

            }
        }
    }
}
/*
if (!(Regex.IsMatch(_identity, "^[a-zA-Z0-9]{1,10}$"))) // 영어와 숫자만 받음
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("영어(대소문자 상관 없음)와 숫자만 10자리 이내로 입력해주세요.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("아무키나 입력해주세요..");
                    Console.ReadLine();
                }
                else
                {
                    isSet = false;
                    //user[userNumber].Id = _identity;
                }

                while (isSet)
                {
                    Console.Clear();
                    Console.Write("아이디 : ");//(영어와 숫자로 이루어진 10자리 이하)\n
                    _identity = Console.ReadLine();
                    if (!Regex.IsMatch(_identity, "^[a-zA-Z0-9]{1,10}$"))
                    {
                        if (failCount > 5) { Console.WriteLine("아이디는 영어와 숫자로 이루어진 10자리 이하 문자열입니다."); }
                        else if (failCount > 10)
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
*/