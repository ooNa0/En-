using System;
using System.Collections.Generic;
using System.Text;

namespace en_6_Library_DB
{
    class bookManagement
    {
        private OutputData outputData;
        private OutputMenu outputMenu;
        private InputManagement inputManagement;
        private DataAccessObject dataAccessObject;
        public bookManagement(OutputMenu outputMenu, OutputData outputData, InputManagement inputManagement, DataAccessObject dataAccessObject)
        {
            this.outputData = outputData;
            this.outputMenu = outputMenu;
            this.inputManagement = inputManagement;
            this.dataAccessObject = dataAccessObject;
        }

        public void SearchBook()
        {

            outputMenu.ShowHowToSearchBook();
            switch (inputManagement.GetMenuNumber(Constant.WHAT_SEARCH_MENU_NUMBER))
            {
                case Constant.EXIT:
                    return;
                case Constant.BOOK_TITLE: // 도서명
                    outputData.ShowAllBookList(dataAccessObject.SearchDataList(Constant.BOOK_TABLE, Constant.BOOK_COLUMN_TITLE, inputManagement.SearchName()));
                    Console.Write("엔터하면 뒤로갑니다.");
                    Console.ReadLine();
                    break;
                case Constant.BOOK_PUBLISHER: // 출판사
                    outputData.ShowAllBookList(dataAccessObject.SearchDataList(Constant.BOOK_TABLE, Constant.BOOK_COLUMN_PUBLISHER, inputManagement.SearchName()));
                    Console.Write("엔터하면 뒤로갑니다.");
                    Console.ReadLine(); break;
                case Constant.BOOK_AUTHOR: // 저자
                    outputData.ShowAllBookList(dataAccessObject.SearchDataList(Constant.BOOK_TABLE, Constant.BOOK_COLUMN_AUTHOR, inputManagement.SearchName()));
                    Console.Write("엔터하면 뒤로갑니다.");
                    Console.ReadLine(); break;
            }
        }
    }
}
