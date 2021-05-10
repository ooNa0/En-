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
        private DataAccessObject dataAccessObject;
        private OutputError outputError;
        private BookManagement bookManagement;
        private UserDataTransferObject userDataTransferObject;
        private LogManagement log;
        public string stringLog;
        public UserManagement(Exception exception, InputManagement inputManagement, OutputMenu outputMenu, DataAccessObject dataAccessObject, OutputError outputError, OutputData outputData, BookManagement bookManagement, LogManagement log)
        {
            this.exception = exception;
            this.inputManagement = inputManagement;
            this.outputMenu = outputMenu;
            this.dataAccessObject = dataAccessObject;
            this.outputError = outputError;
            this.outputData = outputData;
            this.bookManagement = bookManagement;
            this.log = log;
        }

        public void ManageUserMenu() // 유저 메뉴
        {
            string input; string bookNO;
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
                        if (input == Constant.EXIT) { continue; }
                        else if (input == Constant.SEARCH_BOOK_MENU) { if (bookManagement.SearchBook() == 0) { Console.WriteLine("찾고자하는 책이 없습니다."); Console.ReadLine(); continue; } }
                        else { outputData.ShowAllBookList(dataAccessObject.GetAllBookData(Constant.BOOK_TABLE)); }
                        bookNO = inputManagement.GetBookNO();
                        if (bookNO != Constant.BACK)
                        {
                            if (dataAccessObject.EditBorrowBookDataNumber(bookNO, -Constant.ADD_NUMBER))
                            {
                                dataAccessObject.UpdateCurrentBorrowedStatus(bookNO, userDataTransferObject.GetId(), !Constant.IS_EDIT_BOOK_NUMBER);
                                stringLog = string.Format("{0}님이 BOOKNO가 {1}인 책을 빌리셨습니다.", userDataTransferObject.GetName(), bookNO); log.AddLog(stringLog);
                            }
                        }
                        break;
                    case Constant.RETURN_BOOK:
                        if (outputData.ShowUserborrowedBook(dataAccessObject.ShowUserBorrowedStatus(userDataTransferObject.GetId())) == 0)
                        {
                            Console.WriteLine("반납할 책이 없습니다! ENTER를 눌러주세요.");
                            Console.ReadLine();
                            continue;
                        }
                        bookNO = inputManagement.GetBookNO();
                        if (bookNO != Constant.BACK)
                        {
                            if (dataAccessObject.EditBorrowBookDataNumber(bookNO, Constant.ADD_NUMBER))
                            {
                                dataAccessObject.UpdateCurrentBorrowedStatus(bookNO, userDataTransferObject.GetId(), Constant.IS_EDIT_BOOK_NUMBER);
                                stringLog = string.Format("{0}님이 BOOKNO가 {1}인 책을 반납하셨습니다.", userDataTransferObject.GetName(), bookNO); log.AddLog(stringLog);
                            }
                        }
                        break;
                    case Constant.PRINT_BOOKS:
                        outputData.ShowAllBookList(dataAccessObject.GetAllBookData(Constant.BOOK_TABLE));
                        Console.Write("엔터하면 뒤로갑니다.");
                        Console.ReadLine(); break;
                    case Constant.SEARCH_BOOK:
                        bookManagement.SearchBook();
                        Console.ReadLine(); break;
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
                if (inputManagement.GetMenuNumber(Constant.EDIT_NUMBER) == Constant.WANT_EDITING) { Console.WriteLine("수정하실 번호를 입력해주세요. 0:뒤로가기,1~5 해당 정보 수정"); }
                else { return; }
                switch (inputManagement.GetMenuNumber(Constant.MAXIMUN_EDIT_USER_DATA_NUMBER))
                {
                    case Constant.EXIT:
                        isFinished = true;
                        return;
                    case Constant.EDIT_USER_DATA_NAME:
                        stringLog = string.Format("{0}님이 이름을 수정하였습니다.", userDataTransferObject.GetName()); log.AddLog(stringLog);
                        userDataTransferObject.SetName(inputManagement.GetName());
                        break;
                    case Constant.EDIT_USER_DATA_BIRTHYEAR:
                        stringLog = string.Format("{0}님이 생년을 수정하였습니다.", userDataTransferObject.GetName()); log.AddLog(stringLog);
                        userDataTransferObject.SetBirthYear(inputManagement.GetBirthYear());
                        break;
                    case Constant.EDIT_USER_DATA_ID:
                        stringLog = string.Format("{0}님이 ID를 수정하였습니다.", userDataTransferObject.GetName()); log.AddLog(stringLog);
                        userDataTransferObject.SetId(inputManagement.GetIdentity(false));
                        break;
                    case Constant.EDIT_USER_DATA_PHONENUMBER:
                        stringLog = string.Format("{0}님이 전화번호를 수정하였습니다.", userDataTransferObject.GetName()); log.AddLog(stringLog);
                        userDataTransferObject.SetPhoneNumber(inputManagement.GetPhoneNumber());
                        break;
                    case Constant.EDIT_USER_DATA_ADDRESS:
                        stringLog = string.Format("{0}님이 주소를 수정하였습니다.", userDataTransferObject.GetName()); log.AddLog(stringLog);
                        userDataTransferObject.SetAddress(inputManagement.GetAddress());
                        break;
                    case Constant.UNSUBSCRIBE:
                        stringLog = string.Format("{0}님이 회원탈퇴를 하였습니다.", userDataTransferObject.GetName()); log.AddLog(stringLog);
                        dataAccessObject.RemoveDateInDataBase(Constant.USER_TABLE, userDataTransferObject.GetId());
                        break;
                }
            }
        }

        public void SignUpUser() // 유저 회원가입
        {
            outputMenu.LibraryDefault();
            string identity = inputManagement.GetIdentity(true);
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

            dataAccessObject.InputUserDateInDataBase(identity, password, name, brithYear, phoneNumber, address);
            Console.WriteLine("{0}님, 회원가입이 완료되었습니다!", name);
            stringLog = string.Format("{0}님이 회원가입하였습니다.", name); log.AddLog(stringLog);
            Console.WriteLine();
            return;
        }

        public bool SignInUser()
        {
            string identity;
            string password;
            bool isCorrect = false;

            while (!isCorrect) // 아이디
            {
                Console.Clear(); outputMenu.LibraryDefault();
                identity = inputManagement.GetIdentity(false);
                if (identity == "b") { return false; }
                userDataTransferObject = dataAccessObject.CheckUserData(identity, userDataTransferObject);
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
            Console.WriteLine("로그인을 완료하였습니다! 반가워요! {0}님", userDataTransferObject.GetName());
            Console.ReadLine();
            stringLog = string.Format("{0}님이 로그인했습니다.", userDataTransferObject.GetName());
            log.AddLog(stringLog);
            return true;
        }

       
        public void SearchUser() // 이름 나이 주소
        {
            string findInformation;
            outputMenu.ShowHowToSearchUser();
            switch (inputManagement.GetMenuNumber(Constant.SEARCH_MENU_NUMBER))
            {
                case Constant.EXIT:
                    return;
                case Constant.BOOK_TITLE: // 이름
                    findInformation = inputManagement.SearchName();
                    stringLog = string.Format("관리자가 사용자의 이름 {0}을/를 검색했습니다.", findInformation); log.AddLog(stringLog);
                    outputData.ShowAllUserList(dataAccessObject.SearchDataList(Constant.USER_TABLE, Constant.USER_COLUMN_NAME, findInformation));
                   break;
                case Constant.BOOK_PUBLISHER: // 생년
                    findInformation = inputManagement.SearchAge();
                    stringLog = string.Format("관리자가 사용자의 생년 {0}을/를 검색했습니다.", findInformation); log.AddLog(stringLog);
                    outputData.ShowAllUserList(dataAccessObject.CorrectDataInUser(findInformation, Constant.USER_COLUMN_BIRTHYEAR));
                    break;
                case Constant.BOOK_AUTHOR: // 주소
                    findInformation = inputManagement.SearchName();
                    stringLog = string.Format("관리자가 사용자의 주소 {0}을/를 검색했습니다.", findInformation); log.AddLog(stringLog);
                    outputData.ShowAllUserList(dataAccessObject.SearchDataList(Constant.USER_TABLE, Constant.USER_COLUMN_ADDRESS, findInformation));
                    break;
            }
        }
    }
    
}
