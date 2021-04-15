using en_4_Library.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace en_4_Library
{
    class Menu
    {
        public List<BookVO> book = new List<BookVO>(); // BookVO 리스트
        public List<UserVO> user = new List<UserVO>(); // UserVO 리스트
        Cursor cursor = new Cursor();
        Print print = new Print();
        string adminPassWord;
        int PositionY;
        public void StartMenu()
        {
            Console.Title = "Library - Menu";
            cursor.controlCursor(0, 3);
            bool isEnd = false;

            while (isEnd)
            {
                switch (PositionY)
                {
                    case Constant.SIGN_IN:
                        StartSignin();
                        break;
                    case Constant.SIGN_UP:
                        StartSignup();
                        break;
                    case Constant.ADMINISTRATOR_MODE:
                        Console.Clear();
                        Console.Write("관리자 비밀번호를 입력해주세요 :");
                        adminPassWord = Console.ReadLine();
                        if (adminPassWord == Constant.ADMIN_PASSWORD)
                        {
                            administratorMenu.UserSelectMenu(user, book);
                            return;
                        }
                        Console.Write("관리자 비밀번호가 올바르지 않습니다.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case Constant.EXIT:
                        Console.Clear();
                        Console.WriteLine("\n\n프로그램을 이용해주셔서 감사합니다.");
                        Console.ReadLine();
                        isEnd = true;
                        break;
                }
            }
        }
    }
}
