using en_4_Library.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace en_4_Library
{

    class User
    {
        Input input = new Input(); // 이거도 인자로? 
        List<char> convertString = new List<char>();
        public bool SignIn(Print print, List<UserVO> userList)
        {
            string identity = "";
            string password = "";
           
            bool isIdentityExist = false;
            bool isPasswordExist = false;
            int count = userList.Count - 1;
            if (count < 0)
            {
                print.SignUpFirst();
                return false;
            }
            while (!isIdentityExist) // 아이디
            {
                Console.Clear();
                Console.Write("아이디 :");
                convertString = input.KeyChar(Constant.IS_NOT_PASSWORD);
                identity = new string(convertString.ToArray());
                if (identity == "ESC")
                {
                    return false;
                }
                while (count >= 0)
                {
                    if (identity == userList[count].Id)
                    {
                        isIdentityExist = true;
                        break;
                    }
                }
                if (isIdentityExist == false)
                {
                    print.IsNotExistIdentity();
                    break;
                }
            }
            count = userList.Count - 1;
            int failCount = 0;
            while (!isPasswordExist)
            {
                Console.Clear();
                Console.WriteLine("아이디 :" + identity);
                Console.Write("비밀번호 : ");
                //password = input.KeyChar(Constant.IS_PASSWORD);
                convertString = input.KeyChar(Constant.IS_NOT_PASSWORD);
                password = new string(convertString.ToArray());
                if (password == "ESC")
                {
                    return false;
                }
                if (password != userList[count].Password) // 해당 아이디에 비밀번호가 맞는지
                {
                    Console.WriteLine("\n틀렸습니다. 다시 입력해주세요. (5번 이상 틀릴 경우 초기화면으로 돌아갑니다.");
                    if (failCount > 5)
                    {
                        Console.WriteLine("초기 화면으로 돌아갑니다.");
                        //Thread.Sleep(500);
                        Console.ReadLine();
                        return false;
                    }
                    Console.ReadLine();
                    failCount++;
                    Console.Clear();
                    Console.Write("아이디 : " + identity + "\n");
                }
                else
                {
                    Console.WriteLine("\n\n로그인 되었습니다. 반갑습니다. " + userList[count].Name + "님");
                    Console.WriteLine("아무키나 입력해주세요..");
                    Console.ReadLine();
                    Console.Clear();

                    isPasswordExist = true;
                }
            }
            return true;
        }

        public void SignUp(Print print, List<UserVO> userList)
        {
            Check check = new Check();
            string identity = "";
            string password = "";
            string name = "";
            string age = "";
            string phoneNumber = "";
            string record = "(1~10글자 영어숫자혼합)아이디 :";

            bool isIdentityExist = false;
            bool isSet = true;
            int count = userList.Count - 1;
            
            while (isSet) // 아이디
            {
                Console.Clear();
                Console.Write(record);
                Console.WriteLine("-------------------------");
                //identity = input.KeyChar(Constant.IS_NOT_PASSWORD);
                convertString = input.KeyChar(Constant.IS_NOT_PASSWORD);
                identity = new string(convertString.ToArray());
                if (identity == "ESC")
                {
                    return;
                }
                if (!check.Length(identity, Constant.ID_MIN_LENGTH, Constant.ID_MAX_LENGTH))
                {
                    continue;
                }
                if (!check.EnglishAndNumber(identity))// && check.Number(identity)))
                {
                    continue;
                }
                while (count >= 0)
                {
                    if (identity == userList[count].Id) // 이미 존재
                    {
                        isIdentityExist = true;
                        print.IsExistIdentity();
                        continue;
                    }
                    count--;
                }
                if (isIdentityExist == false)
                {
                    isSet = false;
                    record += identity + "\n";
                }
            }
            while (!isSet) // 비밀번호
            {
                Console.Clear();
                password = "";
                Console.Write(record);
                Console.Write("(길이 8이상 15이하 영어+숫자 혼합)비밀번호 : ");//길이 8이상, 영어 + 숫자 + 특수문자)
                //password = input.KeyChar(Constant.IS_PASSWORD);
                convertString = input.KeyChar(Constant.IS_PASSWORD);
                password = new string(convertString.ToArray());
                if (password == "ESC")
                {
                    return;
                }
                if (!check.Length(password, Constant.PASSWORD_MIN_LENGTH, Constant.PASSWORD_MAX_LENGTH))
                {
                    continue;
                }
                if (!check.EnglishAndNumber(identity))// && check.Number(identity)))
                {
                    continue;
                }
                // 비밀번호는 하나의 영문자 이상, 하나의 특수문자 이상, 영어+숫자+특수문자로 이루어져있으며 7~15 크기

                record += "(길이 8이상 15이하 영어+숫자 혼합)비밀번호 : ";
                for (int index = 0; index < password.Length; index++)
                {
                    record += "*";
                }
                record += "\n";
                isSet = true;
            }

            while (isSet) // 이름
            {
                Console.Clear();
                Console.Write(record);
                Console.Write("(4글자 내 한글)이름 : ");
                //name = input.KeyChar(Constant.IS_NOT_PASSWORD);
                convertString = input.KeyChar(Constant.IS_NOT_PASSWORD);
                name = new string(convertString.ToArray());
                if (password == "ESC")
                {
                    return;
                }

                if (!check.Korean(name))
                {
                    continue;
                }
                else
                {
                    record += "(4글자 내 한글)이름 : " + name + "\n";
                    isSet = false;
                }
            }

            while (!isSet) // 나이
            {
                Console.Clear();
                Console.Write(record);
                Console.Write("(숫자만 입력나이 : ");//(숫자만 입력)
                //age = input.KeyChar(Constant.IS_NOT_PASSWORD);
                convertString = input.KeyChar(Constant.IS_NOT_PASSWORD);
                age = new string(convertString.ToArray());
                if (password == "ESC")
                {
                    return;
                }

                if (!check.Number(age))
                {
                    continue;
                }
                else
                {
                    record += "나이 : " + age + "\n";
                    isSet = false;
                }
            }

            while (isSet) // 전화번호
            {
                Console.Clear();
                Console.Write(record);
                Console.Write("(010-0000-0000 형식)전화번호: ");
                //phoneNumber = input.KeyChar(Constant.IS_NOT_PASSWORD);
                convertString = input.KeyChar(Constant.IS_NOT_PASSWORD);
                phoneNumber = new string(convertString.ToArray());
                if (phoneNumber == "ESC")
                {
                    return;
                }

                if (!check.PhoneNumber(phoneNumber))
                {
                    continue;
                }
                else
                {
                    record += "(010-0000-0000 형식)전화번호: " + phoneNumber + "\n";
                    isSet = false;
                }
            }

            userList.Add(new UserVO(identity, password, name, age, phoneNumber, 0));

            Console.WriteLine("\n회원가입이 완료되었습니다. 반가워요 " + userList[userList.Count - 1].Name + "님");
            Console.WriteLine("아무키나 눌러주세요.");
            Console.ReadLine();
        }
    }
}
