using System;
using System.Collections.Generic;
using System.Text;

namespace en_4_Library
{
    class Constant
    {
        public const int ESC = -1;

        public const int CONSOLE_SIZE_X = 73;

        public const int CONSOLE_SIZE_Y = 37;

        public const bool SAME_BOOK_EXIST = true;

        // 비밀 번호 유무, 별모양
        public const bool IS_PASSWORD = true;

        public const bool IS_NOT_PASSWORD = false;

        // 관리자 모드
        public const int ADD_BOOK = 0;

        public const int REMOVE_BOOK = 1;

        public const int SEARCH_BOOKS = 2;

        public const int PRINT_BOOKLIST= 3;

        public const int PRINT_USERS = 4;

        public const int SEARCH_USER = 5;

        public const int REMOVE_USER = 6;

        public const int GO_BACK = 7;

        // 찾기 목록
        public const int HOW_TO_SEARCH_BOOK = 3;

        public const int SEARCH_BOOK_NAME = 0;

        public const int SEARCH_BOOK_PUBLISHER = 1;

        public const int SEARCH_BOOK_AUTHOR = 2;

        // 책관리
        public const int BORROW_BOOK = 0;

        public const int RETURN_BOOK = 1;

        public const int PRINT_BOOKS = 2;

        public const int SEARCH_BOOK = 3;

        public const int PRINT_USER_INFOMATION = 4;

        public const int LOG_OUT = 5;


        // 첫 메뉴
        public const int SIGN_IN = 0;

        public const int SIGN_UP = 1;

        public const int ADMINISTRATOR_MODE = 2;

        public const int EXIT = 3;

        public const string ADMIN_PASSWORD = "****";

        // input
        public const bool RECEIVE_KEY_INPUT = true;

        // 길이
        public const int ID_MIN_LENGTH = 1;
        public const int ID_MAX_LENGTH = 10;

        public const int PASSWORD_MIN_LENGTH = 8;
        public const int PASSWORD_MAX_LENGTH = 15;

        public const int BOOKNAME_MIN_LENGTH = 1;
        public const int BOOKNAME_MAX_LENGTH = 10;

        public const int X_POSITION = 30;
        public const int Y_POSITION = 12;

        // 메뉴
        public const int MAIN_MENU = 0;

        public const int USER_MENU = 1;

        public const int ADMINISTRATOR_MENU = 2;

        public const int SEARCH_BOOK_MENU = 3;

        public const bool USING_CURSOR = true;
    }
}