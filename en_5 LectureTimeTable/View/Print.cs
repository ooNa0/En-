using en_5_LectureTimeTable.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace en_5_LectureTimeTable
{
    class Print
    {
        public void ShowDefaultOutput()
        {
            Console.WriteLine();
            Console.WriteLine("                            ◇");
            Console.WriteLine("                        ◇◇◇◇◇");
            Console.WriteLine("               ◇◇◇◇◇        ◇◇◇◇◇");
            Console.WriteLine();
            Console.WriteLine("               ■■■ ■    ■     ▣   ▣");
            Console.WriteLine("               ■     ■■  ■    ■#▣##");
            Console.WriteLine("               ■■■ ■ ■ ■   ▣   ▣");
            Console.WriteLine("               ■     ■  ■■  #▣■##");
            Console.WriteLine("               ■■■ ■    ■ ▣   ▣");
            Console.WriteLine();
            Console.WriteLine("               ◇◇◇◇◇        ◇◇◇◇◇");
            Console.WriteLine("                        ◇◇◇◇◇");
            Console.WriteLine("                            ◇");
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
        }

        public void ShowIntro()
        {
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine("                            ◇");
            Thread.Sleep(5);
            Console.WriteLine("                        ◇◇◇◇◇");
            Thread.Sleep(500);
            Console.WriteLine("               ◇◇◇◇◇        ◇◇◇◇◇");
            Thread.Sleep(500);
            Console.WriteLine();
            Thread.Sleep(500);
            Console.WriteLine("               ■■■ ■    ■     ▣   ▣");
            Thread.Sleep(1000);
            Console.WriteLine("               ■     ■■  ■    ■#▣##");
            Thread.Sleep(1000);
            Console.WriteLine("               ■■■ ■ ■ ■   ▣   ▣");
            Thread.Sleep(1000);
            Console.WriteLine("               ■     ■  ■■  #▣■##");
            Thread.Sleep(1000);
            Console.WriteLine("               ■■■ ■    ■ ▣   ▣");
            Thread.Sleep(500);
            Console.WriteLine();
            Thread.Sleep(500);
            Console.WriteLine("               ◇◇◇◇◇        ◇◇◇◇◇");
            Thread.Sleep(500);
            Console.WriteLine("                        ◇◇◇◇◇");
            Thread.Sleep(500);
            Console.WriteLine("                            ◇");
            Thread.Sleep(500);
            Console.WriteLine();
            Console.Write("                   로딩중 입니다 ."); Thread.Sleep(500); Console.Write(" ."); Thread.Sleep(500); Console.Write(" . "); Thread.Sleep(500);
            Console.CursorVisible = true; Console.Write("!!!");
        }

        public void ShowStartMenu() // 처음 시작 메뉴
        {
            Console.Clear();
            Console.SetWindowSize(Constant.CONSOLE_SIZE_X, Constant.CONSOLE_SIZE_Y);
            ShowDefaultOutput();
            Console.WriteLine("                      1. 관심과목\n");
            Console.WriteLine("                      2. 수강신청\n");
            Console.WriteLine("                      3. 나의 시간표\n");
            Console.WriteLine("                      4. 종료\n");
        }

        public void ShowInterestedCourseMenu() // 관심과목 메뉴
        {
            Console.Clear();
            Console.SetWindowSize(Constant.CONSOLE_SIZE_X, Constant.CONSOLE_SIZE_Y);
            ShowDefaultOutput();
            Console.WriteLine("                      0. 뒤로가기\n");
            Console.WriteLine("                      1. 전체강의 보기\n");
            Console.WriteLine("                      2. 관심과목 추가\n");
            Console.WriteLine("                      3. 관심과목 삭제\n");
            Console.WriteLine("                      4. 담은 관심과목 조회\n");
        }

        public void ShowCourseRegistrationMenu() // 수강신청 메뉴
        {
            Console.Clear();
            Console.SetWindowSize(Constant.CONSOLE_SIZE_X, Constant.CONSOLE_SIZE_Y);
            ShowDefaultOutput();
            Console.WriteLine("                      0. 뒤로가기\n");
            Console.WriteLine("                      1. 전체강의 보기\n");
            Console.WriteLine("                      2. 강의 추가\n");
            Console.WriteLine("                      3. 강의 삭제\n");
            Console.WriteLine("                      4. 담은 강의 조회\n");
        }

        public void ShowMyTimeTableMenu() // 시간표 메뉴
        {
            Console.Clear();
            Console.SetWindowSize(Constant.CONSOLE_SIZE_X, Constant.CONSOLE_SIZE_Y);
            ShowDefaultOutput();
            Console.WriteLine("                      0. 뒤로가기\n");
            Console.WriteLine("                      1. 시간표 보기\n");
            Console.WriteLine("                      2. 시간표 저장(엑셀)\n");
        }

        public void ShowSearchCourseMenu(int addInterestedCourse) // 과목찾기 메뉴(+수강신청시 관심과목으로 조회 추가)
        {
            Console.Clear();
            Console.SetWindowSize(Constant.CONSOLE_SIZE_X, Constant.CONSOLE_SIZE_Y);
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("                        [강의 검색]\n");
            Console.WriteLine("                      0. 뒤로가기\n");
            Console.WriteLine("                      1. 개설학과 전공으로\n");
            Console.WriteLine("                      2. 학수 번호로\n");
            Console.WriteLine("                      3. 교과목명으로\n");
            Console.WriteLine("                      4. 강의 대상 학년으로\n");
            Console.WriteLine("                      5. 교수명으로\n");
            if (addInterestedCourse == 1) Console.WriteLine("                      6. 관심과목 검색\n");
        }

        public void NoticeBack() // 뒤로가기 
        {
            Console.WriteLine("아무키나 누르면 뒤로갑니다.");
            Console.ReadLine();
        }

        public bool isShowAllCourse(List<CourseVO> courseList) // 과목들 출력
        {
            Console.SetWindowSize(Constant.CONSOLE_SHOW_ALL_COURSE_SIZE_X, Constant.CONSOLE_SHOW_ALL_COURSE_SIZE_Y);
            int count = courseList.Count - 1;
            courseList = courseList.OrderBy(x => x.No).ToList();// 시간표 정렬 no 대로

            Console.WriteLine(" NO  개설학과전공       학수번호 분반 교과목명                         이수구분 학년 학점 요일및강의시간                     강의실       메인교수명                  강의언어");
            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
            if (count < 0)
            {
                Console.WriteLine("\n등록된 시간표가 없습니다!\n");return false;
            }
            else
            {
                foreach (CourseVO course in courseList)
                {
                        Console.WriteLine("{0}\n", course.ToString());
                }
            }
            return true;
        }

        public void ShowMyTimeTable(string [,] timeTableArray, CourseDataCalculation calculation) // 나의 시간표 출력
        {
            Console.Clear();
            Console.WriteLine("");
            CourseDataManagement management = new CourseDataManagement();
            Console.SetWindowSize(Constant.CONSOLE_SHOW_ALL_COURSE_SIZE_X+55, Constant.CONSOLE_SHOW_ALL_COURSE_SIZE_Y);
            Console.Title = "나의 시간표";
            Console.WriteLine(" 시간                        월                                         화                                         수                                        목                                       금     ");
            Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
            for (int index = 0; index < Constant.TIMETABLE_COLUMN; index++)
            {// 시간 월 화 수 목 금
                //Console.WriteLine(Constant.EXCEL_PADING_COURSE_TITLE - calculation.StringByteLength(timeTableArray[index, 1]));
                int padingCourseTitleindex1 = ((Constant.EXCEL_PADING_COURSE_TITLE - calculation.StringByteLength(timeTableArray[index, 1]))); 
                //if (Constant.EXCEL_PADING_COURSE_TITLE - calculation.StringByteLength(timeTableArray[index, 1]) % 2 == 1) { count1 = 2; Console.WriteLine("--"); }
                int padingCourseTitleindex2 = ((Constant.EXCEL_PADING_COURSE_TITLE - calculation.StringByteLength(timeTableArray[index, 2])));// if (Constant.EXCEL_PADING_COURSE_TITLE - calculation.StringByteLength(timeTableArray[index, 2]) % 2 == 1) { count2 = 2; }
                int padingCourseTitleindex3 = ((Constant.EXCEL_PADING_COURSE_TITLE - calculation.StringByteLength(timeTableArray[index, 3]))); //if (Constant.EXCEL_PADING_COURSE_TITLE - calculation.StringByteLength(timeTableArray[index, 3]) % 2 == 1) { count3 = 2; Console.WriteLine("--"); }
                int padingCourseTitleindex4 = ((Constant.EXCEL_PADING_COURSE_TITLE - calculation.StringByteLength(timeTableArray[index, 4])));// if (Constant.EXCEL_PADING_COURSE_TITLE - calculation.StringByteLength(timeTableArray[index, 4]) % 2 == 1) { count4 = 2; Console.WriteLine("--"); }
                int padingCourseTitleindex5 = ((Constant.EXCEL_PADING_COURSE_TITLE - calculation.StringByteLength(timeTableArray[index, 5]))); //if (Constant.EXCEL_PADING_COURSE_TITLE - calculation.StringByteLength(timeTableArray[index, 5]) % 2 == 1) { count5 = 2; Console.WriteLine("--"); }

                Console.WriteLine(" " + timeTableArray[index, 0] + " | " 
                    //+ "".PadLeft(padingCourseTitleindex1) 
                    + timeTableArray[index, 1] + "".PadLeft(padingCourseTitleindex1) +
                    " | "
                    //+ "".PadLeft(padingCourseTitleindex2) 2
                    + timeTableArray[index, 2] + "".PadLeft(padingCourseTitleindex2) +
                    " | " 
                   // + "".PadLeft(padingCourseTitleindex3) 
                    + timeTableArray[index, 3] + "".PadLeft(padingCourseTitleindex3) + 
                    " | " 
                    //+ "".PadLeft(padingCourseTitleindex4) 
                    + timeTableArray[index, 4] + "".PadLeft(padingCourseTitleindex4) + 
                    " | " 
                    //+ "".PadLeft(padingCourseTitleindex5) 
                    + timeTableArray[index, 5] + "".PadLeft(padingCourseTitleindex5) + 
                    " |");


                Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");

            }

            NoticeBack();
        }
    }
}