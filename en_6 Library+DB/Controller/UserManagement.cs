using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace en_6_Library_DB
{
    class UserManagement
    {
        private Exception exception;
        private InputManagement inputManagement;
        private OutputMenu outputMenu;
        private UserDataManagement userDataManagement;
        private DataAccessObject dataAccessObject;
        private OutputError outputError;
        public UserManagement(Exception exception, InputManagement inputManagement, UserDataManagement userDataManagement, OutputMenu outputMenu, DataAccessObject dataAccessObject, OutputError outputError)
        {
            this.exception = exception;
            this.inputManagement = inputManagement;
            this.outputMenu = outputMenu;
            this.userDataManagement = userDataManagement;
            this.dataAccessObject = dataAccessObject;
            this.outputError = outputError;
        }

        public void ManageUserMenu() // 유저 메뉴
        {
            bool isFinished = false;
            while (!isFinished)
            {
                outputMenu.ShowUserMenu();
                switch (inputManagement.GetMenuNumber(Constant.MAXIMUN_USER_MENU_NUMBER))
                {
                    case Constant.LOG_OUT:
                        Console.Clear();
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
            outputMenu.LibraryDefault();
            string identity = inputManagement.GetIdentity();
            if (identity == Constant.BACK) return;
            string password = inputManagement.GetPassword();
            if (password == Constant.BACK) return;
            string name = inputManagement.GetName();
            if (name == Constant.BACK) return;
            string brithYear = inputManagement.GetBirthYear();
            if (brithYear == Constant.BACK) return;
            string phoneNumber = inputManagement.GetPhoneNumber();
            if (phoneNumber == Constant.BACK) return;
            string address = inputManagement.GetAddress();
            if (address == Constant.BACK) return;
            // 아이디 입력(영어, 숫자 5~10글자 입력하세요.) -> 틀리면 에러 출력 후, 커서 이동
            // 비밀번호 입력(영어, 숫자 8~15글자 입력하세요.)
            // 이름(공백없이 한글 2~4글자 입력하세요.)
            // 태어난 연도(연도만 입력해주세요. ex)2001)
            // 전화번호('-'없이 번호만 입력해주세요.)
            // 이메일 주소?
            // 주소(우편번호, 도로명 주소)

            // 데베에 넣기!!!!!!!!!!!
            dataAccessObject.InputUserDateInDataBase(identity, password, name, brithYear, phoneNumber, address);
            Console.WriteLine("회원가입이 완료되었습니다!");
            Console.WriteLine();
            return;
        }

        public bool SignInUser()
        {
            string identity;
            string password;
            string checkPassword = "";
            bool isCorrect = false;

            while (!isCorrect) // 아이디
            {
                Console.Clear(); outputMenu.LibraryDefault();
                identity = inputManagement.GetIdentity();
                if (identity == "b") { return false; }
                checkPassword = dataAccessObject.CheckUserData(identity);
                if (checkPassword == "b") 
                {
                    outputError.ShowUserLoginFailureID();
                    continue;
                }
                isCorrect = true;
            }
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            while (isCorrect) // 비밀번호
            {
                password = inputManagement.GetPassword();
                if (password == "b") { return false; }

                if (!(checkPassword == password))
                {
                    outputError.ShowUserLoginFailureID();
                    inputManagement.InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                    continue;
                }
                isCorrect = false;
            }
            Console.WriteLine("로그인을 완료하였습니다! 반가워요!"); // ~~님 이름 같이 출력
            return true;
        }
    }
}
