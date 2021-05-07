using System;
using System.Collections.Generic;
using System.Text;

namespace en_6_Library_DB
{
    class AdministratorManagement
    {
        private Exception exception;
        private InputManagement inputManagement;
        private OutputMenu outputMenu;
        private OutputData outputData;
        private DataAccessObject dataAccessObject;
        private BookManagement bookManagement;
        private UserManagement userManagement;
        private NaverAPIAccessObject naverAPIAccessObject;
        public AdministratorManagement(Exception exception, InputManagement inputManagement, OutputMenu outputMenu, OutputData outputData, DataAccessObject dataAccessObject, OutputError outputError, BookManagement bookManagement, UserManagement userManagement)
        {
            this.exception = exception;
            this.inputManagement = inputManagement;
            this.outputMenu = outputMenu;
            this.outputData = outputData;
            this.dataAccessObject = dataAccessObject;
            this.bookManagement = bookManagement;
            this.userManagement = userManagement;
            naverAPIAccessObject = new NaverAPIAccessObject(outputData, dataAccessObject, inputManagement);
        }

        public void AdministratorMenu() // 관리자 메뉴
        {
            bool isFinished = false;
            while (!isFinished)
            {
                outputMenu.ShowAdministratorMenu();
                switch (inputManagement.GetMenuNumber(Constant.MAXIMUN_ADMINISTRATOR_MENU_NUMBER))
                {
                    case Constant.EXIT:
                        Console.Clear();
                        isFinished = true;
                        return;
                    case Constant.ADMINISTRATOR_BOOK_MANAGEMENT:
                        AdministratorBookMenu();
                        break;
                    case Constant.ADMINISTRATOR_USER_MANAGEMENT:
                        AdministratorUserMenu();
                        break;
                    case Constant.LOG_INITALIZATION:
                        // 로그 삭제 필요
                        break;
                }
            }
        }

        public void AdministratorUserMenu()
        {
            string input;
            bool isFinished = false;
            while (!isFinished)
            {
                outputMenu.ShowAdministratorUserManagementMenu();
                switch (inputManagement.GetMenuNumber(Constant.MAXIMUN_ADMINISTRATOR_MENU_NUMBER))
                {
                    case Constant.EXIT:
                        Console.Clear();
                        isFinished = true;
                        return;
                    case Constant.PRINT_USERLIST:
                        outputData.ShowAllUserList(dataAccessObject.GetAllUserData());
                        Console.Write("엔터하면 뒤로갑니다.");
                        Console.ReadLine(); break;
                    case Constant.SEARCH_USER:
                        userManagement.SearchUser();
                        Console.Write("엔터하면 뒤로갑니다.");
                        Console.ReadLine(); break;
                        break;
                    case Constant.REMOVE_USER: // 유저 삭제
                        outputData.ShowAllUserList(dataAccessObject.GetAllUserData());
                        dataAccessObject.RemoveDateInDataBase(Constant.USER_TABLE, inputManagement.GetIdentity());
                        break;
                }
            }
        }
        public void AdministratorBookMenu()
        {
            string bookNOString; string bookNumberString;
            bool isFinished = false;
            while (!isFinished)
            {
                outputMenu.ShowAdministratorBookManagementMenu();
                switch (inputManagement.GetMenuNumber(Constant.MAXIMUN_ADMINISTRATOR_BOOKMANAGEMENT_MENU_NUMBER))
                {
                    case Constant.EXIT:
                        Console.Clear();
                        isFinished = true;
                        return;
                    case Constant.REGISTRATION_BOOK: // 책 등록
                        RegistrateBook();
                        break;
                    case Constant.NAVER_API_REGISTRATION_BOOK: // 네이버 책 등록
                        naverAPIAccessObject.ShowNaverBookList(inputManagement.GetBookTitle(), Constant.IS_REGISTRATION);
                        //RegistrateBook();
                        break;
                    case Constant.PRINT_BOOKS:
                        outputData.ShowAllBookList(dataAccessObject.GetAllBookData());
                        Console.Write("엔터하면 뒤로갑니다.");
                        Console.ReadLine(); break;
                    case Constant.SEARCH_BOOK:
                        bookManagement.SearchBook();
                        break;
                    case Constant.SEARCH_NAVER_API_BOOK:
                        outputMenu.SearchBookApi();
                        naverAPIAccessObject.ShowNaverBookList(inputManagement.GetBookTitle(), !Constant.IS_REGISTRATION);
                        break;
                    case Constant.EDIT_BOOK:
                        outputData.ShowAllBookList(dataAccessObject.GetAllBookData());
                        Console.WriteLine("수량을 수정할");
                        bookNOString = inputManagement.GetBookNO();
                        bookNumberString = inputManagement.GetBookNumber();
                        if (bookNOString != Constant.BACK && bookNumberString != Constant.BACK) { dataAccessObject.EditBookDataDiscount(bookNOString, Convert.ToInt32(bookNumberString), Constant.IS_EDIT_BOOK_DISCOUNT); }
                        break;
                    case Constant.REMOVE_BOOK:
                        outputData.ShowAllBookList(dataAccessObject.GetAllBookData());
                        bookNOString = inputManagement.GetBookNO();
                        if (bookNOString != Constant.BACK) { dataAccessObject.RemoveDateInDataBase(Constant.BOOK_TABLE, bookNOString); }
                        break;
                }
            }
        }

        public void RegistrateBook() // 책 등록, 아이디 겹치는지 확인 예외처리 필요
        {
            outputMenu.LibraryDefault();
            //string identity = inputManagement.GetBookID();
            //if (identity == Constant.BACK) return;
            string title = inputManagement.GetBookTitle();
            if (title == Constant.BACK) return;
            string author = inputManagement.GetBookAuthor();
            if (author == Constant.BACK) return;
            string publisher = inputManagement.GetBookPublisher();
            if (publisher == Constant.BACK) return;
            string bookNumber = inputManagement.GetBookNumber();
            if (bookNumber == Constant.BACK) return;
            string price = inputManagement.GetBookPrice();
            if (price == Constant.BACK) return;
            //identity, 
            dataAccessObject.InputBookDateInDataBase(title, author, publisher, bookNumber, price, Constant.NULL, Constant.NULL, Constant.NULL);
            Console.WriteLine("{0} 도서 등록이 완료되었습니다!\n", title);
            Console.ReadLine();
            return;
        }
    }
}