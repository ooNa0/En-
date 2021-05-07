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
        private OutputData outputData;
        private UserDataManagement userDataManagement;
        private DataAccessObject dataAccessObject;
        private OutputError outputError;
        private BookManagement bookManagement;
        private UserDataTransferObject userDataTransferObject;
        public UserManagement(Exception exception, InputManagement inputManagement, UserDataManagement userDataManagement, OutputMenu outputMenu, DataAccessObject dataAccessObject, OutputError outputError, OutputData outputData, BookManagement bookManagement)
        {
            this.exception = exception;
            this.inputManagement = inputManagement;
            this.outputMenu = outputMenu;
            this.userDataManagement = userDataManagement;
            this.dataAccessObject = dataAccessObject;
            this.outputError = outputError;
            this.outputData = outputData;
            this.bookManagement = bookManagement;
        }

        public void ManageUserMenu() // 유저 메뉴
        {
            string input; int bookNO;
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
                        outputMenu.ShowAskAction(); outputMenu.ShowAskOtherAction("전체 도서 출력 후 대출하기");
                        input = inputManagement.GetMenuNumber(Constant.INFORMATION_EXIT_AND_SEARCH);
                        if (input == "0") { continue; }
                        else if (input == "1") { if (bookManagement.SearchBook() == 0) { Console.WriteLine("찾고자하는 책이 없습니다."); Console.ReadLine(); continue; } }
                        else { outputData.ShowAllBookList(dataAccessObject.GetAllBookData()); }
                        bookNO = inputManagement.GetBookNO();
                        dataAccessObject.EditBookDataDiscount(bookNO, -1, false);
                        dataAccessObject.UpdateCurrentBorrowedStatus(bookNO, userDataTransferObject.GetId(), false);
                        break;
                    case Constant.RETURN_BOOK:
                        dataAccessObject.ShowUserBorrowedStatus(userDataTransferObject.GetId());
                        //user.ReturnBook(userList, bookList, userNumber, print);
                        bookNO = inputManagement.GetBookNO();
                        dataAccessObject.EditBookDataDiscount(bookNO, 1, false);
                        dataAccessObject.UpdateCurrentBorrowedStatus(bookNO, userDataTransferObject.GetId(), true);
                        // 유저의 책 빌린 정보 모두 출력
                        // 반납할 책 index 입력받기
                        // 책 discount + 1, currentstatus 에서 해당 줄 삭제
                        break;
                    case Constant.PRINT_BOOKS:
                        outputData.ShowAllBookList(dataAccessObject.GetAllBookData());
                        Console.Write("엔터하면 뒤로갑니다.");
                        Console.ReadLine(); break;
                    case Constant.SEARCH_BOOK:
                        bookManagement.SearchBook();
                        break;
                    case Constant.SHOW_USER_INFOMATION:
                        EditUserData();
                        break;
                }
            }
        }

        private void EditUserData()
        {
            bool isFinished = false;
            while (!isFinished)
            {
                outputData.ShowUserInformation(userDataTransferObject);
                if (inputManagement.GetMenuNumber(Constant.EDIT_NUMBER) == Constant.WANT_EDITING) { Console.WriteLine("수정하실 번호를 입력해주세요. 0:뒤로가기, 6: 회원탈퇴"); }
                else { return; }
                switch (inputManagement.GetMenuNumber(Constant.MAXIMUN_EDIT_USER_DATA_NUMBER))
                {
                    case Constant.EXIT:
                        isFinished = true;
                        return;
                    case Constant.EDIT_USER_DATA_NAME:
                        userDataTransferObject.SetName(inputManagement.GetName());
                        break;
                    case Constant.EDIT_USER_DATA_BIRTHYEAR:
                        userDataTransferObject.SetBirthYear(inputManagement.GetBirthYear());
                        break;
                    case Constant.EDIT_USER_DATA_ID:
                        userDataTransferObject.SetId(inputManagement.GetIdentity());
                        break;
                    case Constant.EDIT_USER_DATA_PHONENUMBER:
                        userDataTransferObject.SetPhoneNumber(inputManagement.GetPhoneNumber());
                        break;
                    case Constant.EDIT_USER_DATA_ADDRESS:
                        userDataTransferObject.SetAddress(inputManagement.GetAddress());
                        break;
                    case Constant.UNSUBSCRIBE:
                        dataAccessObject.RemoveDateInDataBase(Constant.USER_TABLE, userDataTransferObject.GetId());
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
            Console.WriteLine("{0}님, 회원가입이 완료되었습니다!", name);
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

                //if (userDataTransferObject == null)
                //    userDataTransferObject = new UserDataTransferObject;
                //checkPassword = dataAccessObject.CheckUserData(identity, userDataTransferObject);
                userDataTransferObject = dataAccessObject.CheckUserData(identity, userDataTransferObject);
               // if (checkPassword == "b") 
              //  {
                //    outputError.ShowUserLoginFailureID();
              //      continue;
             //   }
                isCorrect = true;
            }
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            while (isCorrect) // 비밀번호
            {
                password = inputManagement.GetPassword();
                if (password == "b") { return false; }

                if (!(userDataTransferObject.GetPassword() == password))
                {
                    outputError.ShowUserLoginFailureID();
                    inputManagement.InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                    continue;
                }
                isCorrect = false;
            }
            Console.WriteLine("로그인을 완료하였습니다! 반가워요! {0}님 ><", userDataTransferObject.GetName()); // ~~님 이름 같이 출력
            Console.WriteLine();
            return true;
        }

       
        public void SearchUser() // 이름 나이 주소
        {
            outputMenu.ShowHowToSearchUser();
            switch (inputManagement.GetMenuNumber(Constant.SEARCH_MENU_NUMBER))
            {
                case Constant.EXIT:
                    return;
                case Constant.BOOK_TITLE: // 이름
                    outputData.ShowAllUserList(dataAccessObject.SearchDataList(Constant.USER_TABLE, Constant.USER_COLUMN_NAME, inputManagement.SearchName()));
                   break;
                case Constant.BOOK_PUBLISHER: // 생년
                    outputData.ShowAllUserList(dataAccessObject.CorrectDataList(inputManagement.SearchAge()));//Constant.USER_TABLE, Constant.USER_COLUMN_BIRTHYEAR, 
                    break;
                case Constant.BOOK_AUTHOR: // 주소
                    outputData.ShowAllUserList(dataAccessObject.SearchDataList(Constant.USER_TABLE, Constant.USER_COLUMN_ADDRESS, inputManagement.SearchName()));
                    break;
            }
        }
    }
    
}
