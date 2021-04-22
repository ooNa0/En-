using System;
using System.Collections.Generic;
using System.Text;

namespace en_5_LectureTimeTable
{
    class Constant
    {
        public const int CONSOLE_SIZE_X = 80;

        public const int CONSOLE_SIZE_Y = 45;

        // 엑셀 범위
        public const string EXCEL_LOCATION_TOP_LEFT= "A2";

        public const string EXCEL_LOCATION_BOTTOM_RIGHT = "L170";


        // 수강신청인지, 관심과목인지!
        public const bool IS_INTERESTED_COURSE = true;

        // StartMenu, 첫 메뉴
        public const int MINIMUN_STARTMENU_NUMBER = 1;

        public const int MAXIMUN_STARTMENU_NUMBER = 4;

        public const string INTERESTED_COURSE_MENU = "1";

        public const string SOURSE_REGISTRATION_MENU = "2";

        public const string MY_TIMETABLE = "3";

        public const string EXIT = "4";

        //ShowInterestedCourseMenu, 관심과목, 수강신청 메뉴
        public const int MINIMUN_INTERESTEDCOURSE_NUMBER = 0;

        public const int MAXIMUN_INTERESTEDCOURSE_NUMBER = 4;

        public const string SHOW_ALL_COURSE = "1";

        public const string ADD_COURSE = "2";

        public const string REMOVE_COURSE = "3";

        public const string PRINT_COURSE = "4";

        // SearchCourse, 강의 검색
        public const int MINIMUN_SEARCHCOURSE_MENU_NUMBER = 0;

        public const int MAXIMUN_SEARCHCOURSE_MENU_NUMBER = 6;

        public const int MAXIMUN_INTERESTEDCOURSE_MENU_NUMBER = 7;

        public const string BACK = "0";

        public const string BY_MAJOR = "1";

        public const string BY_COURSE_NUMBER = "2";

        public const string BY_COURSE_TITLE = "3";

        public const string BY_TARGETSTUDENT = "4";

        public const string BY_LECTURER = "5";

        public const string BY_INTERESTED_COURSE = "6";

        // MyTimeTable, 나의 시간표 보기
        public const int MINIMUN_SHOWMYTIMETABLE_MENU_NUMBER = 0;

        public const int MAXIMUN_SHOWMYTIMETABLE_MENU_NUMBER = 2;

        public const string SHOW_MYTIMETABLE = "1";

        public const string SAVE_TIMETABLE = "2";

        //숫자 하나만
        public const int NUMBER_LENGTH = 1;
    }
}
