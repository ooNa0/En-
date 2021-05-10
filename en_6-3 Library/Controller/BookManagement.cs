using System;
using System.Collections.Generic;
using System.Text;

namespace en_6_Library_DB
{
    class BookManagement
    {
        private OutputData outputData;
        private OutputMenu outputMenu;
        private InputManagement inputManagement;
        private DataAccessObject dataAccessObject;
        private LogManagement log;

        public BookManagement(OutputMenu outputMenu, OutputData outputData, InputManagement inputManagement, DataAccessObject dataAccessObject, LogManagement log)
        {
            this.outputData = outputData;
            this.outputMenu = outputMenu;
            this.inputManagement = inputManagement;
            this.dataAccessObject = dataAccessObject;
            this.log = log;
        }

        public int SearchBook()
        {
            string stringLog;
            string findInformation;
            outputMenu.ShowHowToSearchBook();
            switch (inputManagement.GetMenuNumber(Constant.SEARCH_MENU_NUMBER))
            {
                case Constant.EXIT:
                    return 0;
                case Constant.BOOK_TITLE: // 도서명
                    findInformation = inputManagement.SearchName();
                    stringLog = string.Format("도서이름 {0}을 검색하였습니다.", findInformation); log.AddLog(stringLog);
                    return outputData.ShowAllBookList(dataAccessObject.SearchDataList(Constant.BOOK_TABLE, Constant.BOOK_COLUMN_TITLE, findInformation));
                    
                case Constant.BOOK_PUBLISHER: // 출판사
                    findInformation = inputManagement.SearchName();
                    stringLog = string.Format("도서출판사 {0}을 검색하였습니다.", findInformation); log.AddLog(stringLog);
                    return outputData.ShowAllBookList(dataAccessObject.SearchDataList(Constant.BOOK_TABLE, Constant.BOOK_COLUMN_PUBLISHER, findInformation));
                 
                case Constant.BOOK_AUTHOR: // 저자
                    findInformation = inputManagement.SearchName();
                    stringLog = string.Format("도서저자 {0}을 검색하였습니다.", findInformation); log.AddLog(stringLog);
                    return outputData.ShowAllBookList(dataAccessObject.SearchDataList(Constant.BOOK_TABLE, Constant.BOOK_COLUMN_AUTHOR, findInformation));
            }
            return 0;
        }
    }
}
