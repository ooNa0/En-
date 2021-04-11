using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace en_3_Libray.Exception
{
    class Login
    {
        public string _identity;
        public string _passWord;

        public void login()
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
            }
        }
    }
}
