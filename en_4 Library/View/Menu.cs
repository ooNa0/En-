using en_4_Library.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace en_4_Library
{
    class Menu
    {
        private List<BookVO> bookList;
        private List<UserVO> userList;
        private Cursor cursor;
        private Print print;
        private User user;
        private Administrator administrator;

        public Menu()
        {
            bookList = new List<BookVO>(); // BookVO 리스트
            userList = new List<UserVO>(); // UserVO 리스트
            cursor = new Cursor();
            print = new Print();
            user = new User();
            administrator = new Administrator();
        }
        

        string adminPassWord;
        int userNumber;
        public void StartMenu()
        {
            userList.Add(new UserVO("a", "a", "테스트쉽다~!", "66", "010-1111-1111"));
            userList.Add(new UserVO("AAA123", "AAAAA12345", "구나영", "32", "010-1234-1234"));
            userList.Add(new UserVO("BBB123", "BBBBB12345", "구나영", "22", "070-1114-3283"));
            userList.Add(new UserVO("ABC123", "CCABS12345", "곽현숙", "45", "010-2383-2184"));
            bookList.Add(new BookVO("엔샵의 발견", "엔지니어스", "EN#", 2));
            bookList.Add(new BookVO("당신은 엔-샵인가", "엔지니어스", "EN#", 1));
            bookList.Add(new BookVO("안녕 나의 청춘, 엔샵", "엔지니어스", "EN#", 5));
            bookList.Add(new BookVO("a", "테스터편하게", "구나영코딩머신", 1));

            //Console.SetWindowSize(30,300);
            //Console.SetBufferSize(80, 80);
            Console.SetWindowSize(73, 37);
            Console.Title = "Library";
            
            bool isEnd = false;

            while (!isEnd)
            {
                switch ((cursor.controlCursor(0, 3, Constant.MAIN_MENU)-Constant.Y_POSITION)/2)
                {
                    case Constant.SIGN_IN:
                        userNumber = user.SignIn(print, userList);
                        Console.WriteLine(userNumber);
                        
                        if (userNumber > -1) // 로그인이 되면
                        {
                            StartUserMenu(userNumber);
                        }
                        break;
                    case Constant.SIGN_UP:
                        user.SignUp(print, userList);
                        break;
                    case Constant.ADMINISTRATOR_MODE:
                        Console.Clear(); print.Library();
                        Console.Write("관리자 비밀번호를 입력해주세요 :");
                        adminPassWord = Console.ReadLine();
                        if (adminPassWord == Constant.ADMIN_PASSWORD)
                        {
                            StartAdministratorMenu();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("관리자 비밀번호가 올바르지 않습니다.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case Constant.EXIT:
                        Console.Clear();
                        Console.WriteLine("\n\n프로그램을 이용해주셔서 감사합니다.");
                        isEnd = true;
                        break;
                }
            }
        }

        public void StartUserMenu(int userNumber)
        {
            bool isFinished = false;
            Book book = new Book();
            while (!isFinished)
            {
                print.ShowUserMenu();
                switch ((cursor.controlCursor(0, 5, Constant.USER_MENU) - Constant.Y_POSITION)/2)
                {
                    case Constant.ESC:
                        return;
                    case Constant.BORROW_BOOK:
                        user.BorrowBook(userList, bookList, userNumber, print);
                        break;
                    case Constant.RETURN_BOOK:
                        user.ReturnBook(userList, bookList, userNumber, print);
                        break;
                    case Constant.PRINT_BOOKS:
                        print.ShowBookList(bookList, print);
                        Console.ReadLine();
                        break;
                    case Constant.SEARCH_BOOK:
                        book.Search(cursor, bookList, print);
                        break;
                    case Constant.PRINT_USER_INFOMATION:
                        Console.Clear(); print.Library();
                        Console.WriteLine("\n      {0}님의 정보입니다.\n", userList[userNumber].Name);
                        //foreach (string user in userList[userNumber])
                        //{
                        print.ShowUserInformation(userList, userNumber);
                        //}
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

        public void StartAdministratorMenu()
        {
            User user = new User();
            Book book = new Book();
            Administrator administrator = new Administrator();
            bool isSet = true;
            while (isSet)
            {
                Console.Clear();
                print.ShowAdministratorMenu();

                switch ((cursor.controlCursor(0, 7, Constant.ADMINISTRATOR_MENU) - Constant.Y_POSITION)/2)
                {
                   
                    case Constant.ADD_BOOK: // 도서 등록
                        book.Add(bookList, print);
                        break;
                    case Constant.REMOVE_BOOK: // 도서 삭제
                        book.Remove(bookList, print);
                        break;
                    case Constant.SEARCH_BOOKS: // 도서 검색
                        Console.Clear();
                        book.Search(cursor, bookList, print);
                        break;
                    case Constant.PRINT_BOOKLIST: // 전체 도서 출력
                        print.ShowBookList(bookList, print);
                        Console.ReadLine();
                        //Console.Clear();
                        break;
                    case Constant.PRINT_USERS: // 회원 리스트
                        print.ShowUserList(userList, print);
                        break;
                    case Constant.SEARCH_USER: // 회원 검색
                        Console.Clear();
                        administrator.Search(userList, print);
                        break;
                    case Constant.REMOVE_USER: // 회원 삭제
                        administrator.Remove(userList, print);
                        break;
                    case Constant.GO_BACK: // 돌아가기
                        return;
                    case Constant.ESC:
                        Thread.Sleep(1000);
                        return;
                }
            }
        }
    }
}
