using System;
using System.Collections.Generic;
using System.Text;

namespace en_5_LectureTimeTable
{
    class Print
    {
        public void ShowStartMenu() // 처음 시작 메뉴
        {
            Console.WriteLine("1. 관심과목");
            Console.WriteLine("2. 수강신청");
            Console.WriteLine("3. 나의 시간표");
            Console.WriteLine("4. 종료");
        }

        public void ShowInterestedCourseMenu() // 관심과목 메뉴
        {
            Console.WriteLine("0. 뒤로가기");
            Console.WriteLine("1. 전체강의 보기");
            Console.WriteLine("2. 관심과목 추가");
            Console.WriteLine("3. 관심과목 삭제");
            Console.WriteLine("4. 담은 관심과목 조회");
        }

        public void ShowCourseRegistrationMenu() // 수강신청 메뉴
        {
            Console.WriteLine("0. 뒤로가기");
            Console.WriteLine("1. 전체강의 보기");
            Console.WriteLine("2. 강의 추가");
            Console.WriteLine("3. 강의 삭제");
            Console.WriteLine("4. 담은 강의 조회");
        }

        public void ShowMyTimeTableMenu()
        {
            Console.WriteLine("0. 뒤로가기");
            Console.WriteLine("1. 시간표 보기");
            Console.WriteLine("2. 시간표 저장(엑셀)");
        }

        public void ShowSearchCourseMenu(int addInterestedCourse) // 과목찾기 메뉴(+수강신청시 관심과목으로 조회 추가)
        {
            Console.WriteLine("[강의 검색]\n");
            Console.WriteLine("0. 뒤로가기");
            Console.WriteLine("1. 개설학과 전공으로");
            Console.WriteLine("2. 학수 번호로");
            Console.WriteLine("3. 교과목명으로");
            Console.WriteLine("4. 강의 대상 학년으로");
            Console.WriteLine("5. 교수명으로");
            if(addInterestedCourse == 1) Console.WriteLine("6. 관심과목 검색");
        }

        public void NoticeBack()
        {
            Console.WriteLine("아무키나 누루면 뒤로갑니다.");
            Console.ReadLine();
            //Console.Clear();
        }

        public void ShowAllCourse(List<CourseVO> courseList)
        {
            //Console.Clear();
            Console.SetWindowSize(Constant.CONSOLE_SHOW_ALL_COURSE_SIZE_X, Constant.CONSOLE_SHOW_ALL_COURSE_SIZE_Y);
            Console.Title = "모든 수업 보기";
            //Console.WriteLine("  [모든 수업 보기]");
            int count = courseList.Count - 1;
            Console.WriteLine(" NO  개설학과전공          학수번호  분반  교과목명                이수구분 학년 학점 요일 및 강의시간              강의실  메인교수명           강의언어");
            Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
            if(count < 0)
            {
                Console.WriteLine("\n등록된 시간표가 없습니다!\n");
            }
            while (count >= 0)
            {
                foreach (CourseVO course in courseList)
                {
                    Console.WriteLine("{0}\n", course.ToString());
                }
                //Console.WriteLine("───────────────────────────────────────────────────────────────────────");

                break;
            }
        }
    }
}
