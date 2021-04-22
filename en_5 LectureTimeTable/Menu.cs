using System;
using System.Collections.Generic;
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
        public Menu()
        {
            print = new Print();
            inputCheck = new InputCheck();
            management = new CourseDataManagement();
        }
        public void Setting()
        {
            StartMenu(); // 메뉴 시작

            Console.WriteLine("\n프로그램을 이용해주셔서 감사합니다.\n");
            /*
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

                // 범위 설정 (좌측 상단, 우측 하단)
                Excel.Range cellRange = worksheet.get_Range("A1", "C3") as Excel.Range;

                // 설정한 범위만큼 데이터 담기 (Value2 -셀의 기본 값 제공)
                Array data = cellRange.Cells.Value2;

                // 데이터 출력

                Console.WriteLine(data.GetValue(1, 1));
                Console.WriteLine(data.GetValue(1, 2));
                Console.WriteLine(data.GetValue(1, 3));
                Console.WriteLine(data.GetValue(2, 1));
                Console.WriteLine(data.GetValue(2, 2));
                Console.WriteLine(data.GetValue(2, 3));
                Console.WriteLine(data.GetValue(3, 1));
                Console.WriteLine(data.GetValue(3, 2));
                Console.WriteLine(data.GetValue(3, 3));
                

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
            }*/
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
                        management.TimeTable();
                        print.NoticeBack();
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
                    addInterestedCourse = 1; // 수강신청시, 관심과목 검색도 추가
                }
                switch (inputCheck.EnterMenuNumber(Constant.MINIMUN_INTERESTEDCOURSE_NUMBER, Constant.MAXIMUN_INTERESTEDCOURSE_NUMBER + addInterestedCourse))
                {
                    case Constant.BACK: // 뒤로가기
                        print.NoticeBack();
                        return;
                    case Constant.SHOW_ALL_COURSE: // 전체 강의 보기

                        break;
                    case Constant.ADD_COURSE: // 강의 추가

                        break;
                    case Constant.REMOVE_COURSE: // 강의 삭제

                        break;
                    case Constant.PRINT_COURSE: // 나의 시간표 출력
                        management.ShowMyCourseList(isInterestedCourse);
                        print.NoticeBack();
                        break;
                }
            }
        }
    }
}
