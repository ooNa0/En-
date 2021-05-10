using System;
using System.Collections.Generic;
using System.Text;

namespace en_6_Library_DB
{
    class Constant
    {
        public const string NAVER_API_CLIENT_ID = "iBLtZnxwGneJsLbGgDCa";
        public const string NAVER_API_CLIENT_SECRET = "3Qm2iN4bbG";
        public const string NAVER_API_DISPLAY = "&&display=";
        public const bool IS_REGISTRATION = true;
        public const bool IS_PASSWORD = true;

        public const string DATABASE_CONNECTION_INFOMATION = "Server=localhost;Port=3307;Database=enlibrary;Uid=root;Pwd=0000;allow user variables=true";

        public const int CONSOLE_SIZE_X = 77;

        public const int CONSOLE_SIZE_Y = 45;

        public const string BACK = "b";

        public const int MENU_NUMBER_MINIMUN = 0;

        public const int NUMBER_LENGTH = 1; //숫자 하나만

        public const string ADMINISTRATOR_PASSWORD = "*"; // 관리자 비밀번호

        public const int MAXIMUN_FIRST_MENU_NUMBER = 3; // 첫 메뉴 0~3

        public const int MAXIMUN_SEARCH_MENU_NUMBER = 4; // 찾기 메뉴 0~3

        public const int MAXIMUN_USER_MENU_NUMBER = 6; // 유저 메뉴 0~5

        public const int MAXIMUN_ADMINISTRATOR_MENU_NUMBER = 3; // 관리자 메뉴 0~3

        public const int MAXIMUN_ADMINISTRATOR_BOOKMANAGEMENT_MENU_NUMBER = 7; // 관리자 도서 관리 메뉴 0~3

        public const int INFORMATION_EXIT_AND_SEARCH = 3; // 나갈건지 찾을건지

        public const int SEARCH_MENU_NUMBER = 4; // 책 검색 메뉴

        public const int EDIT_NUMBER = 1;

        public const string WANT_EDITING = "1";

        public const int MAXIMUN_EDIT_USER_DATA_NUMBER = 6;


        // 첫 메뉴
        public const string EXIT = "0";

        public const string SIGN_IN = "1";

        public const string SIGN_UP = "2";

        public const string ADMINISTRATOR_MODE = "3";

        // 유저 메뉴
        public const string LOG_OUT = "0";

        public const string BORROW_BOOK = "1";

        public const string RETURN_BOOK = "2";

        public const string PRINT_BOOKS = "3";

        public const string SEARCH_BOOK = "4";

        public const string SHOW_USER_INFOMATION = "5";

        // 관리자 메뉴
        public const string ADMINISTRATOR_BOOK_MANAGEMENT = "1";

        public const string ADMINISTRATOR_USER_MANAGEMENT = "2";

        public const string LOG_INITALIZATION = "3";

        // 관리자 책 메뉴


        // 관리자 책 관리 메뉴
        public const string REGISTRATION_BOOK = "1";
        public const string NAVER_API_REGISTRATION_BOOK = "2";

        public const string SEARCH_NAVER_API_BOOK = "5";
        public const string EDIT_BOOK = "6";
        public const string REMOVE_BOOK = "7";
        public const bool IS_EDIT_BOOK_NUMBER = true;
        public const int ZERO = 0;
        public const int ADD_NUMBER = 1;

        // 관리자 유저 관리 메뉴
        public const string PRINT_USERLIST = "1";

        public const string SEARCH_USER = "2";

        public const string REMOVE_USER = "3";

        // 입력 문자 길이
        public const int MINIMUN_LENGTH = 0;

        public const int MAXIMUM_LENGTH_BOOKTITLE = 15;

        public const int MAXIMUM_LENGTH_BOOKAUTHOR = 10;

        public const int MAXIMUM_LENGTH_BOOKPUBLISHER = 15;

        public const int MAXIMUM_BOOKNUMBER = 5;

        public const int MAXIMUM_BOOKPRICE = 7;

        public const int BOOK_ID_LENGTH = 4;

        // 책 검색
        public const string SEARCH_BOOK_MENU = "1";
        public const string BOOK_TITLE = "1";

        public const string BOOK_PUBLISHER = "2";

        public const string BOOK_AUTHOR = "3";

        // 유저 정보 수정
        public const string EDIT_USER_DATA_NAME = "1";
        public const string EDIT_USER_DATA_BIRTHYEAR = "2";
        public const string EDIT_USER_DATA_ID = "3";
        public const string EDIT_USER_DATA_PHONENUMBER = "4";
        public const string EDIT_USER_DATA_ADDRESS = "5"; 
        public const string UNSUBSCRIBE = "6";

        // DB 이름
        public const string BOOK_TABLE = "book";
        public const string USER_TABLE = "user";

        public const string BOOK_COLUMN_TITLE = "Title";
        public const string BOOK_COLUMN_PUBLISHER = "Publisher";
        public const string BOOK_COLUMN_AUTHOR = "Author";

        public const string USER_COLUMN_NAME = "Name";
        public const string USER_COLUMN_BIRTHYEAR = "BirthYear";
        public const string USER_COLUMN_ADDRESS = "Address";
        public const string USER_COLUMN_ID = "ID";

    }
}
