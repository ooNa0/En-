using System;
using System.Collections.Generic;
using System.Text;

namespace en_6_Library_DB
{
    class OutputError
    {
        public OutputError()
        {

        }

        public void ShowAdministratorLoginFailure()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("관리자 비밀번호가 올바르지 않습니다.");
            NoticeBack();
            //Console.Clear();
        }
        public void ShowUserLoginFailureID()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("아이디가 올바르지 않습니다!");
            //NoticeBack();
        }
        public void ShowUserLoginFailurePassword()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("비밀번호가 올바르지 않습니다!");
            Console.WriteLine("\n(5번 이상 틀릴 경우 초기화면으로 돌아갑니다.)");
            NoticeBack();
        }

        public void NotExistIdentity()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n이미 존재하는 아이디가 아닙니다.");
            NoticeBack();
        }

        public void ExistIdentity()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n이미 존재하는 아이디입니다.");
            NoticeBack();
        }
        private void NoticeBack()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("아무키나 입력하고 엔터하면 뒤로갑니다.");
            Console.ReadLine();
        }
    }
}
