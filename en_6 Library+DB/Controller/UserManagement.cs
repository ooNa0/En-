using System;
using System.Collections.Generic;
using System.Text;

namespace en_6_Library_DB
{
    class UserManagement
    {
        private Exception exception;
        private InputManagement inputManagement;
        private OutputMenu outputMenu;
        private UserDataManagement userDataManagement;
        public UserManagement(Exception exception, InputManagement inputManagement, UserDataManagement userDataManagement, OutputMenu outputMenu)
        {
            this.exception = exception;
            this.inputManagement = inputManagement;
            this.outputMenu = outputMenu;
            this.userDataManagement = userDataManagement;
        }

        public void ManageUserMenu() // 유저 메뉴
        {
            bool isFinished = false;
            while (!isFinished)
            {
                outputMenu.ShowUserMenu();
                switch (inputManagement.getMenuNumber(Constant.MAXIMUN_USER_MENU_NUMBER))
                {
                    case Constant.LOG_OUT:
                        Console.Clear();
                        isFinished = false;
                        return;
                    case Constant.BORROW_BOOK:
                        //user.BorrowBook(userList, bookList, userNumber, print);
                        break;
                    case Constant.RETURN_BOOK:
                        //user.ReturnBook(userList, bookList, userNumber, print);
                        break;
                    case Constant.PRINT_BOOKS:
                        //print.ShowBookList(bookList, print);
                        Console.ReadLine();
                        break;
                    case Constant.SEARCH_BOOK:
                        //book.Search(cursor, bookList, print);
                        break;
                    case Constant.SHOW_USER_INFOMATION:
                        //Console.Clear(); print.Library();
                        //Console.WriteLine("[{0}님의 정보]\n", userList[userNumber].Name);
                        //print.ShowUserInformation(userList, userNumber);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        public void SignUpUser() // 유저 회원가입
        {
            string identity = inputManagement.getIdentity();
            if (identity == Constant.BACK) return;
            string password = inputManagement.getPassword();
            if (password == Constant.BACK) return;
            string name = inputManagement.getName();
            if (name == Constant.BACK) return;
            string brithYear = inputManagement.getBirthYear();
            if (brithYear == Constant.BACK) return;
            string phoneNumber = inputManagement.getPhoneNumber();
            if (phoneNumber == Constant.BACK) return;
            string address = inputManagement.getAddress();
            if (address == Constant.BACK) return;
            // 아이디 입력(영어, 숫자 5~10글자 입력하세요.) -> 틀리면 에러 출력 후, 커서 이동
            // 비밀번호 입력(영어, 숫자 8~15글자 입력하세요.)
            // 이름(공백없이 한글 2~4글자 입력하세요.)
            // 태어난 연도(연도만 입력해주세요. ex)2001)
            // 전화번호('-'없이 번호만 입력해주세요.)
            // 이메일 주소?
            // 주소(우편번호, 도로명 주소)
            userDataManagement.InputUserDataBase(identity, password, name, brithYear, phoneNumber, address);
            Console.WriteLine("회원가입이 완료되었습니다!");
            Console.WriteLine();
            return;
        }
    }
}
