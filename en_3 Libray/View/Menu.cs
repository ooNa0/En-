using en_3_Libray.Data;
using en_3_Libray.Exception;
using en_3_Libray.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace en_3_Libray.View
{
    class Menu
    {
        public List<UserVO> user = new List<UserVO>();
        public bool isOpen = false;
        Printing print = new Printing();
        public void MainMenu()
        {
            CerserControl cerserControl = new CerserControl();
            while (true)
            {
                Console.Clear();
                print.ShowMenu();
                SelectMenu(cerserControl.cerserControl(0, 3)); // 메뉴
            }

            //ConsoleKeyInfo cki;
            /*
            int x = 0, y = 0;
            while (!isOpen)
            {
                Console.Clear();
                print.ShowMenu();
                Console.SetCursorPosition(x, y);
                Console.Write('▶');
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (y > 0) { y--; }
                        break;
                    case ConsoleKey.DownArrow:
                        if (y < 3) { y++; }
                        break;
                    case ConsoleKey.Enter:
                        SelectMenu(y);
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("메뉴로 돌아갑니다.");
                        break;
                }
            }*/
        }
        private void SelectMenu(int y)
        {

            Ask ask = new Ask();
            AdministratorMenu administratorMenu = new AdministratorMenu();

            if (y == 0) // 로그인
            {
                StartLogin();
            }
            else if (y == 1) // 회원가입
            {
                StartSignUp();
            }
            else if (y == 2) // 관리자 모드
            {
                Console.Clear();
                administratorMenu.UserSelectMenu(user);
                Thread.Sleep(1000);
            }
            else if (y == 3) // 종료
            {
                Console.Clear();
                Console.WriteLine("정말로 프로그램을 종료하시겠어요?");
                if (ask.AskYesOrNo() == 0)
                {
                    Console.WriteLine("\n\n프로그램을 이용해주셔서 감사합니다.");
                    isOpen = true;
                }
                else
                {
                    Console.WriteLine("메뉴로 되돌아갑니다.\n아무키나 눌러주십시오.");
                    Console.ReadLine();
                }
            }
        }

        public void StartLogin()
        {

            UserMenu userMenu = new UserMenu();
            string _identity = "0";
            string _passWord = "0";
            int failCount = 0;
            bool isSet = true;
            Console.WriteLine(user.Count);
            int count = user.Count - 1;
            if (count < 0)
            {
                Console.Clear();
                Console.WriteLine(user.Count);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("회원가입을 먼저해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("아무키나 입력해주세요..");
                Console.ReadLine();
                MainMenu();
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
                        MainMenu();
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
                        Console.WriteLine("초기 화면으로 돌아갑니다.");
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
                    Console.WriteLine("\n\n로그인 되었습니다. 반갑습니다. " + user[count].Name + "님");
                    Console.WriteLine("아무키나 입력해주세요..");

                    Console.ReadLine();
                    Console.Clear();
                    userMenu.UserSelectMenu(user, count);

                    isSet = true;
                }

            }
        }
        public void StartSignUp()
        {
            //ConsoleKeyInfo keyInfo;
            string _identity = "";
            string _passWord = ""; string _name = ""; string _age = ""; string _phoneNumber = ""; string recode = "아이디 :";
            //List<UserVO> user = new List<UserVO>();
            //UserVO userVO = new UserVO();
            bool isSet = true;
            Menu menu = new Menu();

            while (isSet) // 아이디
            {
                Console.Clear();
                Console.Write(recode);
                _identity = Console.ReadLine();
                int count = user.Count - 1;
                

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
                    //userVO.Id = _identity;
                }
                while (count >= 0)
                {
                    if (_identity == user[count].Id)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("이미 존재하는 아이디입니다.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("아무키나 입력해주세요..");
                        Console.ReadLine();
                        //MainMenu();
                        isSet = true;
                    }
                    count--;
                }
            }
            recode += _identity + "\n";

            while (!isSet) // 비밀번호
            {
                Console.Clear();
                _passWord = "";
                string star = "";
                Console.Write(recode);
                //recode += "비밀번호 : ";
                Console.Write("비밀번호 : ");//길이 8이상, 영어 + 숫자 + 특수문자)
                _passWord = Console.ReadLine();
                //keyInfo = Console.ReadKey(true);
                /*while (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
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
                }*/
                recode += "비밀번호 : " + _passWord + "\n";
                isSet = true;
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
            user.Add(new UserVO() { Id = _identity, PassWord = _passWord, Name = _name, Age = _age, PhoneNumber = _phoneNumber, BorrowBookNumber = 0 });

            /*foreach (List<> userVOs in user)
            {
                Console.WriteLine("{0}", userVOs.ToString);
            }*/

            Console.WriteLine(user.Count);
            Console.WriteLine("\n회원가입이 완료되었습니다. 반가워요 " + user[user.Count - 1].Name + "님");
            Console.WriteLine("아무키나 눌러주세요.");
            Console.ReadLine();
        }
    }
}