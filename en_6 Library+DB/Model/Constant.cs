using System;
using System.Collections.Generic;
using System.Text;

namespace en_6_Library_DB
{
    class Constant
    {
        public const int CONSOLE_SIZE_X = 55;

        public const int CONSOLE_SIZE_Y = 45;

        public const string BACK = "b";

        public const int MENU_NUMBER_MINIMUN = 0;
        public const int NUMBER_LENGTH = 1; //숫자 하나만

        public const string ADMINISTRATOR_PASSWORD = "****"; // 관리자 비밀번호

        public const int MAXIMUN_FIRST_MENU_NUMBER = 4; // 첫 메뉴 0~3

        public const int MAXIMUN_SEARCH_MENU_NUMBER = 4; // 찾기 메뉴 0~3

        public const int MAXIMUN_USER_MENU_NUMBER = 6; // 유저 메뉴 0~5

        public const int MAXIMUN_ADMINISTRATOR_MENU_NUMBER = 8; // 관리자 메뉴 0~7

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
        public const string REGISTRATION_BOOK = "1";

        public const string REMOVE_BOOK = "2";

        public const string PRINT_USERLIST = "5";

        public const string SEARCH_USER = "6";

        public const string REMOVE_USER = "7";
    }
}
