using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace en_5_LectureTimeTable
{
    class Menu
    {
        private Print print;
        private InputCheck inputCheck;
        private CourseDataManagement management;
        private List<CourseVO> courseList; // 엑셀 과목 데이터
        private List<CourseVO> interestedCourseList; // 관심과목
        private List<CourseVO> timeTableList; // 수강 과목
        private string[,] timetable;
        public Menu()
        {
            print = new Print();
            inputCheck = new InputCheck();
            management = new CourseDataManagement();
            courseList = new List<CourseVO>();
            interestedCourseList = new List<CourseVO>();
            timeTableList = new List<CourseVO>();
            timetable = new string[24, 5];
        }
        public void Setting()
        {
            //StartMenu(); // 메뉴 시작
            
            Console.WriteLine("\n로딩중. .. .\n");
            
            try
            {
                // Excel Application 객체 생성
                Excel.Application application = new Excel.Application();

                // Workbook 객체 생성 및 파일 오픈 (바탕화면에 있는 excelStudy.xlsx 가져옴)
                Excel.Workbook workbook = application.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\2021년도 1학기 강의시간표.xlsx");

                // sheets에 읽어온 엑셀값을 넣기 (한 workbook 내의 모든 sheet 가져옴)
                Excel.Sheets sheets = workbook.Sheets;

                // 특정 sheet의 값 가져오기
                Excel.Worksheet worksheet = sheets["Sheet1"] as Excel.Worksheet;
                // 첫번째 워크 시트 가져오기
                //Excel.Worksheet worksheet = workbook.Worksheets.get_Item(1) as Excel.Worksheet;

                // 범위 설정 (좌측 상단, 우측 하단)
                //Excel.Range cellRange = worksheet.get_Range(Constant.EXCEL_LOCATION_TOP_LEFT, Constant.EXCEL_LOCATION_BOTTOM_RIGHT) as Excel.Range;
                Excel.Range cellRange = worksheet.get_Range("A2", "L170") as Excel.Range;

                // 설정한 범위만큼 데이터 담기 (Value2 -셀의 기본 값 제공)
                Array data = cellRange.Cells.Value2;

                // 사용중인 범위 가져오기
                //Excel.Range range = worksheet.UsedRange;

                // 데이터 출력

                for (int row = 1; row < Constant.EXCEL_ROW_RANGE; row++)
                {

                    courseList.Add(new CourseVO((double)data.GetValue(row, Constant.COLUMN_NO), ((string)data.GetValue(row, Constant.COLUMN_MAJOR)).TrimEnd(), (string)data.GetValue(row, Constant.COLUMN_COURSE_NUMBER),
                    (string)data.GetValue(row, Constant.COLUMN_DIVISION_NUMBER), (string)data.GetValue(row, Constant.COLUMN_COURSE_TITLE), (string)data.GetValue(row, Constant.COLUMN_CATEGORIZATION),
                    (double)data.GetValue(row, Constant.COLUMN_TARGET_STUDENT), (double)data.GetValue(row, Constant.COLUMN_CREDIT), (string)data.GetValue(row, Constant.COLUMN_DATETIME),
                    Convert.ToString(data.GetValue(row, Constant.COLUMN_COURSEROOM)), Convert.ToString(data.GetValue(row, Constant.COLUMN_LECTURER)), (string)data.GetValue(row, Constant.COLUMN_LANGUAGE))); // ~12

                }

                StartMenu(); // 메뉴 시작

                Console.WriteLine("\n프로그램을 이용해주셔서 감사합니다.\n");

                // 모든 워크북 닫기
                application.Workbooks.Close();

                // application 종료
                application.Quit();
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void StartMenu()
        {
            bool hasEnded = false;
            while (!hasEnded)
            {
                print.ShowStartMenu();
                switch (inputCheck.EnterMenuNumber(Constant.MINIMUN_STARTMENU_NUMBER, Constant.MAXIMUN_STARTMENU_NUMBER))
                {
                    case Constant.INTERESTED_COURSE_MENU: // 관심 과목 담기
                        CourseMenu(Constant.IS_INTERESTED_COURSE);
                        break;
                    case Constant.SOURSE_REGISTRATION_MENU: // 수강 신청
                        CourseMenu(!Constant.IS_INTERESTED_COURSE);
                        break;
                    case Constant.MY_TIMETABLE: // 나의 시간표
                        TimeTable();
                        break;
                    case Constant.EXIT: // 프로그램 종료
                        hasEnded = true;
                        break;
                }
            }
        }

        public void CourseMenu(bool isInterestedCourse) // 관심과목, 수강신청 메뉴
        {
            bool hasEnded = false;
            int addInterestedCourse = 0;
            while (!hasEnded)
            {
                if (isInterestedCourse) // 관심과목일 경우
                {
                    print.ShowInterestedCourseMenu();
                }
                else // 수강신청일 경우
                {
                    print.ShowCourseRegistrationMenu();
                    addInterestedCourse = 1; // 수강신청시, 관심과목 검색 추가
                }
                switch (inputCheck.EnterMenuNumber(Constant.MINIMUN_INTERESTEDCOURSE_NUMBER, Constant.MAXIMUN_INTERESTEDCOURSE_NUMBER + addInterestedCourse))
                {
                    case Constant.BACK: // 뒤로가기
                        //print.NoticeBack();
                        return;
                    case Constant.SHOW_ALL_COURSE: // 전체 강의 보기
                        print.isShowAllCourse(courseList);
                        break;
                    case Constant.ADD_COURSE: // 강의 추가
                        if (isInterestedCourse) // 관심과목일 경우
                        {
                            //print.ShowInterestedCourseMenu();
                            management.Add(courseList, interestedCourseList, addInterestedCourse);
                        }
                        else // 수강신청일 경우
                        {
                            //print.ShowCourseRegistrationMenu();
                            management.Add(courseList, timeTableList, addInterestedCourse);
                        }
                        break;
                    case Constant.REMOVE_COURSE: // 강의 삭제
                        if (isInterestedCourse) // 관심과목일 경우
                        {
                            management.Remove(courseList, interestedCourseList);
                        }
                        else // 수강신청일 경우
                        {
                            management.Remove(courseList, timeTableList);
                        }
                        break;
                    case Constant.PRINT_COURSE: // 나의 시간표 출력
                        if (isInterestedCourse) // 관심과목일 경우
                        {
                            print.isShowAllCourse(interestedCourseList);
                        }
                        else // 수강신청일 경우
                        {
                            print.isShowAllCourse(timeTableList);
                        }
                        break;
                }
            }
        }

        public void TimeTable() // 나의 강의 보기
        {
            bool hasEnded = false;

            while (!hasEnded)
            {
                print.ShowMyTimeTableMenu();
                switch (inputCheck.EnterMenuNumber(Constant.MINIMUN_SHOWMYTIMETABLE_MENU_NUMBER, Constant.MAXIMUN_SHOWMYTIMETABLE_MENU_NUMBER))
                {
                    case Constant.BACK:
                        print.NoticeBack();
                        return;
                    case Constant.SHOW_MYTIMETABLE:

                        //print.ShowMyTimeTable(timetable);
                        break;
                    case Constant.SAVE_TIMETABLE:
                        // Excel Application 객체 생성
                        Excel.Application application = new Excel.Application();
                        // 워크북 추가
                        Excel.Workbook workbook = application.Workbooks.Add();
                        // 첫번째 워크 시트 가져오기
                        Excel.Worksheet worksheet = workbook.Worksheets.get_Item(1) as Excel.Worksheet;
                        int time = 9;
                        int minute = 0;
                        for (int index = 0; index < timeTableList.Count; index++)
                        {
                            //worksheet.Cells[] 
                        }
                        // 열 너비 자동 맞춤 
                        worksheet.Columns.AutoFit();
                        // 엑셀 파일 저장
                        //application.workbook.SaveAs(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "나의시간표.xlsx"), Excel.XlFileFormat.xlWorkbookDefault);
                        workbook.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\나의시간표.xlsx");
                        break;
                }
            }
        }
    }
}
