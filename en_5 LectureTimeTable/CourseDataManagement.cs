using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
//List<CourseVO> courseList = courseList.OrderBy(x => x.No).ToList();
namespace en_5_LectureTimeTable
{
    class CourseDataManagement
    {
        private InputCheck inputCheck;
        private Print print;
        private int numberCount;
        //private CourseVO CourseVO;

        public CourseDataManagement()
        {
            inputCheck = new InputCheck();
            print = new Print();
            //numberCount = 0;
        }

        public void Add(List<CourseVO> courseList, List<CourseVO> editCourses, int addInterestedCourse) // 강의 추가
        {
            print.ShowAllCourse(courseList);
            Console.WriteLine("(뒤로가기 \"b\" 하고 ENTER)\n강의 검색 후, 추가하기 : 1번, \n바로 강의 번호로 추가하기 : 2번\n");

            //int numberCount = 0;
            string searchOrBack = inputCheck.EnterMenuNumber(Constant.COURSE_SEARCH_FIRST, Constant.COURSE_SEARCH_SECOND);
            if (searchOrBack == "1")
            {
                Search(courseList, addInterestedCourse);
            }
            else if(searchOrBack == "b")
            {
                return;
            }
            Console.WriteLine("(뒤로가기 \"b\" 하고 ENTER)");
            Console.Write("추가하실 ");
            searchOrBack= inputCheck.EnterCourseDataNumber(Constant.MINIMUN_EXCEL_DATA_NO, Constant.MAXIMUN_EXCEL_DATA_NO);
            if (searchOrBack == "b")
            {
                return;
            }
            numberCount = 0;
            for (int i = 0; i <= courseList.Count; i++)
            {
                if (courseList[numberCount].No == Convert.ToDouble(searchOrBack))
                {
                    break;
                }
                numberCount++;
            }
            //editCourses.Insert(editCourses.Count, courseList[numberCount]); // 강의 시간표에 강의 추가
            editCourses.Add(new CourseVO(courseList[numberCount].No, courseList[numberCount].Major, courseList[numberCount].CourseNumber, courseList[numberCount].DivisionNumber,
                        courseList[numberCount].CourseTitle, courseList[numberCount].Categorization,
                        courseList[numberCount].TargetStudent, courseList[numberCount].Credit, courseList[numberCount].DateTime,
                        courseList[numberCount].CourseRoom, courseList[numberCount].Lecturer, courseList[numberCount].Language));
            courseList.RemoveAt(numberCount); // 기존 시간표에 삭제
            Console.WriteLine("시간표 추가 완료 >ㅡ0");
            print.NoticeBack();
        }

        public void Remove(List<CourseVO> courseList, List<CourseVO> editCourses) // 강의 지우기
        {
            print.ShowAllCourse(editCourses);
            Console.Write("(뒤로가기 \"b\" 하고 ENTER)\n삭제하실 ");
            string wantRemove = inputCheck.EnterCourseDataNumber(Constant.MINIMUN_EXCEL_DATA_NO, Constant.MAXIMUN_EXCEL_DATA_NO);
            if (wantRemove == "b")
            {
                return;
            }
            for (int i = 0; i < editCourses.Count; i++, numberCount++)
            {
                if (editCourses[numberCount].No == Convert.ToDouble(wantRemove))
                {
                    break;
                }
            }
            courseList.Add(editCourses[Convert.ToInt32(wantRemove)]);
            editCourses.RemoveAt(Convert.ToInt32(wantRemove)+1);
            Console.Write("시간표 삭제 완료 >ㅡ0");
            print.NoticeBack();
        }

        public void PrintMyCourse(List<CourseVO> editCourses) // 나의 강의 출력
        {
            print.ShowAllCourse(editCourses);
            print.NoticeBack();
        }

        public void Search(List<CourseVO> courseList, int addInterestedCourse) // 강의 찾기, addInterestedCourse는 수강신청시에 1, 아닐시에 0이다.
        {
            bool hasEnded = false;

            while (!hasEnded)
            {
                print.ShowSearchCourseMenu(addInterestedCourse);
                switch (inputCheck.EnterMenuNumber(Constant.MINIMUN_SEARCHCOURSE_MENU_NUMBER, Constant.MAXIMUN_SEARCHCOURSE_MENU_NUMBER + addInterestedCourse))
                {
                    case Constant.BACK:
                        print.NoticeBack();
                        return;
                    case Constant.BY_MAJOR: // 개설 학과 전공으로
                        Console.WriteLine("개설 학과 전공으로 검색하기");
                        break;
                    case Constant.BY_COURSE_NUMBER: // 학수 번호로
                        Console.WriteLine("학수번호로 검색하기");
                        break;
                    case Constant.BY_COURSE_TITLE: // 교과목 명으로
                        Console.WriteLine("교과목 명으로 검색하기");
                        break;
                    case Constant.BY_TARGET_STUDENT: // 강의 대상 학년으로
                        Console.WriteLine("강의 대상 학년으로 검색하기");
                        break;
                    case Constant.BY_LECTURER: // 교수명으로
                        Console.WriteLine("교수명으로 검색하기");
                        break;
                    case Constant.BY_INTERESTED_COURSE: // (수강신청 시에만)관심과목으로 찾기
                        Console.WriteLine("관심과목으로 검색하기");
                        //print.ShowAllCourse(ed)
                        break;
                }
            }
        }
    }
}
