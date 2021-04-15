using en_4_Library.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace en_4_Library
{
    class Menu
    {
        public List<BookVO> bookList = new List<BookVO>(); // BookVO 리스트
        public List<UserVO> userList = new List<UserVO>(); // UserVO 리스트
        
        Cursor cursor = new Cursor();
        Print print = new Print();
        User user = new User();
        Administrator administrator = new Administrator();
        string adminPassWord;
        int userNumber;
        public void StartMenu()
        {
            userList.Add(new UserVO("AAA123", "AAAAA12345", "구나영", "32", 0));
            userList.Add(new UserVO("BBB123", "BBBBB12345", "구나영", "22", 0));
            userList.Add(new UserVO("ABC123", "CCABS12345", "곽현숙", "45", 0));
            bookList.Add(new BookVO("엔샵의 발견", "엔지니어스", "EN#", 2));
            bookList.Add(new BookVO("당신은 엔-샵인가", "엔지니어스", "EN#", 1));
            bookList.Add(new BookVO("안녕 나의 청춘 엔샵", "엔지니어스", "EN#", 5));

            //Console.SetWindowSize(1, 1);
            //Console.SetBufferSize(80, 80);
            //Console.SetWindowSize(40, 20);
            Console.Title = "Library - Menu";

            bool isEnd = false;

            while (!isEnd)
            {
                switch (cursor.controlCursor(0, 3, Constant.MAIN_MENU))
                {
                    case Constant.SIGN_IN:
                        userNumber = user.SignIn(print, userList);
                        Console.WriteLine(userNumber);
                        
                        if (userNumber > -1) // 로그인이 되면
                        {
                            StartUserMenu(bookList, userList, cursor, print, userNumber);
                        }
                        break;
                    case Constant.SIGN_UP:
                        user.SignUp(print, userList);
                        break;
                    case Constant.ADMINISTRATOR_MODE:
                        Console.Clear();
                        Console.Write("관리자 비밀번호를 입력해주세요 :");
                        adminPassWord = Console.ReadLine();
                        if (adminPassWord == Constant.ADMIN_PASSWORD)
                        {
                            //administratorMenu.UserSelectMenu(user, book);
                            return;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("관리자 비밀번호가 올바르지 않습니다.");
                        Console.ForegroundColor = ConsoleColor.White;
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

        public void StartUserMenu(List<BookVO> bookList, List<UserVO> userList, Cursor cursor, Print print, int userNumber)
        {
            bool isFinished = false;

            while (!isFinished)
            {
                print.ShowUserMenu();
                switch (cursor.controlCursor(0, 5, Constant.USER_MENU))
                {
                    case Constant.BORROW_BOOK:
                        break;
                    case Constant.RETURN_BOOK:
                        break;
                    case Constant.PRINT_BOOKS:
                        print.ShowBookList(bookList);
                        break;
                    case Constant.SEARCH_BOOK:
                        Console.Clear();
                        print.ShowHowToSearchBook();
                        break;
                    case Constant.PRINT_USER_INFOMATION:
                        Console.Clear();
                        Console.WriteLine("\n      {0}님의 정보입니다.\n", userList[userNumber].Name);
                        foreach (UserVO user in userList)
                        {
                            Console.WriteLine("\n{0}\n", user.ToString());
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case Constant.LOG_OUT:
                        Console.Clear();
                        isFinished = false;
                        return;
                }
            }
        }
    }
}
