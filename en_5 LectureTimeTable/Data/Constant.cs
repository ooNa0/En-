using System;
using System.Collections.Generic;
using System.Text;

namespace en_5_LectureTimeTable
{
    class Constant
    {
        public const int CONSOLE_SIZE_X = 55;

        public const int CONSOLE_SIZE_Y = 45;

        public const int CONSOLE_SHOW_ALL_COURSE_SIZE_X = 180;

        public const int CONSOLE_SHOW_ALL_COURSE_SIZE_Y = 50;

        // 엑셀 범위
        public const string EXCEL_LOCATION_TOP_LEFT= "A2";

        public const string EXCEL_LOCATION_BOTTOM_RIGHT = "L170";

        public const int EXCEL_ROW_RANGE = 170;

        public const int COLUMN_NO = 1;
        public const int COLUMN_MAJOR = 2;
        public const int COLUMN_COURSE_NUMBER = 3;
        public const int COLUMN_DIVISION_NUMBER = 4;
        public const int COLUMN_COURSE_TITLE = 5;
        public const int COLUMN_CATEGORIZATION = 6;
        public const int COLUMN_TARGET_STUDENT = 7;
        public const int COLUMN_CREDIT = 8;
        public const int COLUMN_DATETIME = 9;
        public const int COLUMN_COURSEROOM = 10;
        public const int COLUMN_LECTURER = 11;
        public const int COLUMN_LANGUAGE = 12;

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

        public const int MAXIMUN_INTERESTEDCOURSE_NUMBER = 3;

        public const string SHOW_ALL_COURSE = "1";

        public const string ADD_COURSE = "2";

        public const string REMOVE_COURSE = "3";

        public const string PRINT_COURSE = "4";

        // SearchCourse, 강의 검색
        public const int MINIMUN_SEARCHCOURSE_MENU_NUMBER = 0;

        public const int MAXIMUN_SEARCHCOURSE_MENU_NUMBER = 5;

        public const int MAXIMUN_INTERESTEDCOURSE_MENU_NUMBER = 7;

        public const string BACK = "0";

        public const string BY_MAJOR = "1";

        public const string BY_COURSE_NUMBER = "2";

        public const string BY_COURSE_TITLE = "3";

        public const string BY_TARGET_STUDENT = "4";

        public const string BY_LECTURER = "5";

        public const string BY_INTERESTED_COURSE = "6";

        // MyTimeTable, 나의 시간표 보기
        public const int MINIMUN_SHOWMYTIMETABLE_MENU_NUMBER = 0;

        public const int MAXIMUN_SHOWMYTIMETABLE_MENU_NUMBER = 2;

        public const string SHOW_MYTIMETABLE = "1";

        public const string SAVE_TIMETABLE = "2";

        //숫자 하나만
        public const int NUMBER_LENGTH = 1;

        // LectureVO 패딩
        public const int PADING_NO = 4;

        public const int PADING_MAJOR = 19;

        public const int PADING_COURSE_TITLE = 33;

        public const int PADING_DATE_TIME = 35;

        public const int PADING_COURSE_ROOM = 14;

        public const int PADING_LECTURER = 28;

        public const int PADING_LANGUAGE = 12;

        public const int KOREAN_BYTES= 2;

        //강의 검색후 뭐할건지 아닐건지 필요한가?????
        public const int COURSE_SEARCH_FIRST = 1;
        public const int COURSE_SEARCH_SECOND = 2;

        // 학점 담기 최고치
        public const int MAXIMUN_CREDITS = 21;

        public const int MAXIMUN_CREDITS_INTERESTED_COURSE = 24;

        // 데이터 no 숫자 크기
        public const int MAXIMUN_COURSE_NO_LENGTH = 3;

        public const int MINIMUN_COURSE_NO_LENGTH = 1;

        // 엑셀 데이터 넘버 범위
        public const int MAXIMUN_EXCEL_DATA_NO = 169;

        public const int MINIMUN_EXCEL_DATA_NO = 1;

        // 시간표 출력 행과 열 크기
        public const int TIMETABLE_COLUMN = 24;

        public const int TIMETABLE_ROW= 5;

        // 시간 간격
        public const double TIME_INTERVAL = 30;

        // 엑셀 출력
        public const int EXCEL_PADING_COURSE_TITLE = 40;
        public const int EXCEL_FIRST_COLUNM_INDEX = 1;
        public const int EXCEL_TIME_INDEX = 1;
        public const int EXCEL_MONDAY_INDEX = 2;
        public const int EXCEL_TUESDAY_INDEX = 3;
        public const int EXCEL_WEDNESDAY_INDEX = 4;
        public const int EXCEL_THURSDAY_INDEX = 5;
        public const int EXCEL_FRIDAY_INDEX = 6;

        public const int OVERLAPS_NUMBER = 0;

        public const int COUNT_SIZE_ZERO = 0;
        public const int FIRST_MONTH_INDEX = 0;
        public const int SECONDE_MONTH_INDEX = 1;

        // 요일 시간 나누기 switch 문
        public const int MONTH_TIME = 2;
        public const int MONTH_MONTH_TIME = 3;
        public const int MONTH_TIME_MONTH_TIME = 4;
        public const int MONTH_MONTH_TIME_MONTH_TIME = 5;

    }
}
