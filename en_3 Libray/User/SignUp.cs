using en_3_Libray.Data;
using en_3_Libray.Exception;
using en_3_Libray.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace en_3_Libray.User
{
    class SignUp
    {

        public List<UserVO> user = new List<UserVO>();
        private string _identity;
        private string _passWord;
        private string _name;
        private string _age;
        private string _phoneNumber;
        private string recode = "아이디 :";
        public void StartSignUp()
        {
            ConsoleKeyInfo keyInfo;

            //List<UserVO> user = new List<UserVO>();
            //UserVO userVO = new UserVO();
            bool isSet = true;
            Menu menu = new Menu();

            while (isSet) // 아이디
            {
                Console.Clear();

                Console.Write(recode);
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
                    recode += _identity + "\n";
                    isSet = false;
                    //userVO.Id = _identity;
                }
            }
            while (!isSet) // 비밀번호
            {
                Console.Clear();
                _passWord = "";
                string star = "";
                Console.Write(recode);
                //recode += "비밀번호 : ";
                Console.Write("비밀번호: ");//길이 8이상, 영어 + 숫자 + 특수문자)
                keyInfo = Console.ReadKey(true);
                while (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    _passWord += keyInfo.KeyChar;
                    Console.Write("*");
                    star += "*";
                    keyInfo = Console.ReadKey(true);
                }
                // 비밀번호는 하나의 영문자 이상, 하나의 특수문자 이상, 영어+숫자+특수문자로 이루어져있으며 7~15 크기
                if (_passWord.Length < 8 || _passWord.Length > 15)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n길이는 8보다 크고 15보다 작아야 합니다.");
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.WriteLine(_passWord.Length);
                    Console.ReadLine();
                    Console.Clear();

                }
                else if (!(Regex.IsMatch(_passWord, "^(?=.*?[A-Za-z])(?=.*?[0-9])(?=.*?[$@%().!%^*#?_=+&]).{8,}$")))//(?=.*[@.!%*#?&])  [A-Za-z0-9@.!%*#?&]
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n비밀번호는 최소 하나의 영문자, 특수문자, 숫자로 이루어져 있어야 합니다.");
                    Console.WriteLine(_passWord);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine(recode);
                }
                else
                {
                    recode += "비밀번호 : ";
                    recode += star + "\n";
                    isSet = true;
                    //userVO.PassWord = _passWord;
                }
            }

            while (isSet) // 이름
            {
                Console.Clear();
                Console.Write(recode);
                Console.Write("이름 : ");//\n(4글자 이내 한글)
                _name = Console.ReadLine();

                recode += "이름 : " + _name + "\n";
                isSet = false;
                /*
                if (!(Regex.IsMatch(_name, "^[가-힣]{1,4}$")))
                {
                    Console.WriteLine("4글자 이내 한글만 입력이가능합니다.");
                    Console.ReadLine();
                }
                else
                {
                    recode += "이름 : " + _name + "\n";
                    isSet = false;
                }*/
            }

            while (!isSet) // 나이
            {
                Console.Clear();
                Console.Write(recode);
                Console.Write("나이 : ");//(숫자만 입력)
                _age = Console.ReadLine();


                recode += "나이 : " + _age + "\n";
                isSet = true;
                /*
                if (!(Regex.IsMatch(_age, "^[0-9]+$")))
                {
                    Console.WriteLine("\n숫자만 입력이 가능합니다.");
                    Console.ReadLine();
                }
                else
                {
                    recode += "나이 : " + _age + "\n";
                    isSet = true;
                    //userVO.Age = _age;
                }*/
            }

            while (isSet) // 전화번호
            {
                Console.Clear();
                Console.Write(recode);
                Console.Write("(010-0000-0000 형식)전화번호: ");
                _phoneNumber = Console.ReadLine();


                recode += "전화번호 : " + _phoneNumber + "\n";
                isSet = false;
                /*
                if (!Regex.IsMatch(_phoneNumber, "^010-?([0-9]{4})-?([0-9]{4})$"))
                {
                    Console.WriteLine("010-0000-0000 형식으로 입력해주세요.");
                    Console.ReadLine();
                }
                else
                {
                    recode += "전화번호 : " + _phoneNumber + "\n";
                    isSet = false;
                    //userVO.PhoneNumber = _phoneNumber;
                }*/
            }
            //List<UserVO> user = new List<UserVO>(userVO);
            user.Add(new UserVO() { Id=_identity, PassWord=_passWord, Name=_name, Age=_age, PhoneNumber=_phoneNumber });
            Console.WriteLine(user.Count);
            Console.WriteLine("\n회원가입이 완료되었습니다. 반가워요 " + user[user.Count-1].Name + "님");
            Console.WriteLine("아무키나 눌러주세요.");
            Console.ReadLine();
        }
    }
}
/*
 while (isSet) // 아이디
            {
                Console.Clear();

                Console.Write("생성할 아이디를 입력해주세요. (영어숫자 10자리 이내)\n아이디 : ");
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
                    user[userNumber].Id = _identity;
                }
*/
/*
             while (isSet) // 아이디
             {
                 Console.Clear();
                 _identity = "";
                 Console.Write("생성할 아이디를 입력해주세요. (영어숫자 10자리 이내)\n");

                 keyInfo = Console.ReadKey(false);
                 while (keyInfo.Key != ConsoleKey.Enter)//keyInfo.Key != ConsoleKey.Backspace || 
                 {
                     if(keyInfo.Key == ConsoleKey.Escape)
                     {
                         menu.MainMenu();
                     }
                     _identity += keyInfo.KeyChar;
                     keyInfo = Console.ReadKey(false);
                 }

                 if (!(Regex.IsMatch(_identity, "^[a-zA-Z0-9]{1,10}$"))) // 영어와 숫자만 받음
                 {
                     Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine("영어(대소문자 상관 없음)와 숫자만 10자리 이내로 입력해주세요.");
                     Console.ForegroundColor = ConsoleColor.White;
                     Console.ReadLine();
                 }
                 else
                 {
                     recode += _identity;
                     recode += "\n";
                     isSet = false;
                     //user[userNumber].Id = _identity;
                 }
             }*/
