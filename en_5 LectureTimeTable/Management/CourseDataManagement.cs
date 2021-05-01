using en_5_LectureTimeTable.Management;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace en_5_LectureTimeTable
{
    class CourseDataManagement
    {
        private Checking inputCheck;
        private Print print;
        private CourseDataCalculation calculation;
        private Menu menu = new Menu();

        public CourseDataManagement()
        {
            inputCheck = new Checking();
            print = new Print();
            calculation = new CourseDataCalculation();
        }

        public void AddCourse(List<CourseVO> courseList, List<CourseVO> editCourses, List<CourseVO> referenceCourses, int addInterestedCourse) // 강의 추가
        {
            int i;
            int count = 0;
            int back = 1;
            double sumCredits = calculation.SumCredits(editCourses);
            print.isShowAllCourse(courseList);
            Console.WriteLine("(뒤로가기 \"b\" 하고 ENTER)\n강의 검색 후, 추가하기 : 1번, \n바로 강의 번호로 추가하기 : 2번\n");

            int numberCount = 0;
            string searchOrBack = inputCheck.EnterMenuNumber(Constant.COURSE_SEARCH_FIRST, Constant.COURSE_SEARCH_SECOND);
            if (searchOrBack == "b") { return; }
            if (searchOrBack == "1")
            {
                back = SearchCourse(courseList, referenceCourses, addInterestedCourse);
            }
            if(back == 1)
            {
                Console.WriteLine("(뒤로가기 \"b\" 하고 ENTER)");
                Console.WriteLine("시간표에 추가할");
                searchOrBack = inputCheck.EnterCourseDataNumber(Constant.MINIMUN_EXCEL_DATA_NO, Constant.MAXIMUN_EXCEL_DATA_NO);
                if (searchOrBack == "b") { return; }

                for (i = 0; i < courseList.Count; i++)
                {
                    if (courseList[i].No == Convert.ToDouble(searchOrBack))
                    {
                        count = 0;

                        for (int j = 0; j < editCourses.Count; j++)
                        {
                            if (editCourses[j].CourseTitle == courseList[i].CourseTitle) { count++; }// 같은 과목?
                            if (editCourses[j].CourseNumber == courseList[i].CourseNumber) { count++; } // 같은 학수 번호?
                            if (!calculation.TimeCompare(i, editCourses, courseList)) { count++; } // 시간이 겹치는지
                        }
                        if (count == Constant.OVERLAPS_NUMBER)
                        {
                            if (addInterestedCourse == 1) // 수강신청일 경우, 최대 학점 21
                            {
                                if (sumCredits + Convert.ToInt32(courseList[i].Credit) >= Constant.MAXIMUN_CREDITS)
                                {
                                    Console.WriteLine("수강 가능 학점을 초과했습니다!");
                                    print.NoticeBack();
                                    return;
                                }
                                Console.WriteLine("나의 학점 ==> {0}/{1}\n", sumCredits + Convert.ToInt32(courseList[i].Credit), Constant.MAXIMUN_CREDITS);
                            }
                            else // 관심과목일 경우, 최대 학점 24
                            {
                                if (sumCredits + Convert.ToInt32(courseList[i].Credit) >= Constant.MAXIMUN_CREDITS_INTERESTED_COURSE)
                                {
                                    Console.WriteLine("수강 가능 학점을 초과했습니다!");
                                    print.NoticeBack();
                                    return;
                                }
                                Console.WriteLine("나의 학점 ==>  {0}/{1}\n", sumCredits + Convert.ToInt32(courseList[i].Credit), Constant.MAXIMUN_CREDITS_INTERESTED_COURSE);
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("과목, 학수번호, 시간이 겹치는지 확인해주세요.");
                            print.NoticeBack();
                            return;
                        }
                    }
                    numberCount++;
                }
                if (numberCount == courseList.Count)
                {
                    Console.WriteLine("입력하신 번호에 해당하는 과목이 없습니다.");
                    print.NoticeBack();
                    return;
                }
                // 강의 시간표에 강의 추가
                editCourses.Add(new CourseVO(courseList[numberCount].No, courseList[numberCount].Major, courseList[numberCount].CourseNumber, courseList[numberCount].DivisionNumber,
                            courseList[numberCount].CourseTitle, courseList[numberCount].Categorization,
                            courseList[numberCount].TargetStudent, courseList[numberCount].Credit, courseList[numberCount].DateTime,
                            courseList[numberCount].CourseRoom, courseList[numberCount].Lecturer, courseList[numberCount].Language));

                editCourses = editCourses.OrderBy(x => x.No).ToList();// 시간표 정렬 no 대로

                if (addInterestedCourse == 1)
                {
                    int countInterestedCourses = 0;

                    while (countInterestedCourses <= referenceCourses.Count - 1)
                    {
                        if (courseList[numberCount].No == referenceCourses[countInterestedCourses].No)
                        {
                            referenceCourses.RemoveAt(countInterestedCourses); // 관심과목 시간표에 삭제
                            break;
                        }
                        countInterestedCourses++;
                    }
                    courseList.RemoveAt(numberCount); // 기존 시간표에 삭제
                }
                Console.WriteLine("시간표 추가 완료 >ㅡ0");
            }
            print.NoticeBack();
        }

        public int SearchCourse(List<CourseVO> courseList, List<CourseVO> interestedCourseList, int addInterestedCourse) // 강의 찾기, addInterestedCourse는 수강신청시에 1, 아닐시에 0이다.
        {
            print.ShowSearchCourseMenu(addInterestedCourse);
            switch (inputCheck.EnterMenuNumber(Constant.MINIMUN_SEARCHCOURSE_MENU_NUMBER, Constant.MAXIMUN_SEARCHCOURSE_MENU_NUMBER + addInterestedCourse))
            {
                case "b":
                    return 0;
                case Constant.BACK:
                    print.isShowAllCourse(courseList);
                    return 0;
                case Constant.BY_MAJOR: // 개설 학과 전공으로
                    Console.WriteLine("[개설 학과 전공으로 검색하기]");
                    return InputSearch(courseList, Constant.BY_MAJOR);
                    break;
                case Constant.BY_COURSE_NUMBER: // 학수 번호로
                    Console.WriteLine("[학수번호로 검색하기]");
                    return InputSearch(courseList, Constant.BY_COURSE_NUMBER);
                    break;
                case Constant.BY_COURSE_TITLE: // 교과목 명으로
                    Console.WriteLine("[교과목 명으로 검색하기]");
                    return InputSearch(courseList, Constant.BY_COURSE_TITLE);
                    break;
                case Constant.BY_TARGET_STUDENT: // 강의 대상 학년으로
                    Console.WriteLine("[강의 대상 학년으로 검색하기]");
                    return InputSearch(courseList, Constant.BY_TARGET_STUDENT);
                    break;
                case Constant.BY_LECTURER: // 교수명으로
                    Console.WriteLine("[교수명으로 검색하기]");
                    return InputSearch(courseList, Constant.BY_LECTURER);
                    break;
                case Constant.BY_INTERESTED_COURSE: // (수강신청 시에만)관심과목으로 찾기
                    Console.WriteLine("[관심과목]");
                    if (print.isShowAllCourse(interestedCourseList)) { return 1; }
                    break;
            }
            return 1;
        }

        public void RemoveCourse(List<CourseVO> courseList, List<CourseVO> editCourses, int addInterestedCourse) // 강의 지우기
        {
            double sumCredits = calculation.SumCredits(editCourses); // 몇 학점 있는지
            if (!print.isShowAllCourse(editCourses)) // 강의가 아무것도 담겨있지 않으면 리턴
            {
                print.NoticeBack();
                return;
            }
            if (addInterestedCourse == 1)
            {
                Console.WriteLine("나의 학점 ==>  {0}/{1}\n", sumCredits, Constant.MAXIMUN_CREDITS);
            }
            Console.WriteLine("(뒤로가기 \"b\" 하고 ENTER)");
            Console.WriteLine("삭제하실");
            string wantRemove = inputCheck.EnterCourseDataNumber(Constant.MINIMUN_EXCEL_DATA_NO, Constant.MAXIMUN_EXCEL_DATA_NO);
            if (wantRemove == "b")
            {
                return;
            }
            int i;
            int numberCount = 0;

            for (i = 0; i < editCourses.Count; i++)
            {
                if (editCourses[i].No == Convert.ToDouble(wantRemove))
                {
                    break;
                }
                numberCount++;
            }
            if (numberCount == editCourses.Count)
            {
                Console.WriteLine("입력하신 번호에 해당하는 과목이 없습니다.");
                print.NoticeBack();
                return;
            }

            if (addInterestedCourse == 1)
            {
                courseList.Add(editCourses[numberCount]); // 기존 시간표에 추가
            }
            courseList = courseList.OrderBy(x => x.No).ToList();// 시간표 정렬 no 대로
            editCourses.RemoveAt(i);
            Console.Write("시간표 삭제 완료 >ㅡ0");
            print.NoticeBack();
        }

        public int InputSearch(List<CourseVO> courseList, string menuNumber)
        {
            int count = 0;
            int search = 0;
            Console.WriteLine("(뒤로가기 \"b\" 하고 ENTER)");
            Console.Write("검색할 것을 입력 :");
            string inputedString = Console.ReadLine();
            if (inputedString == "b") { return 0; }
            Console.SetWindowSize(Constant.CONSOLE_SHOW_ALL_COURSE_SIZE_X, Constant.CONSOLE_SHOW_ALL_COURSE_SIZE_Y);
            switch (menuNumber)
            {
                case Constant.BACK:
                    print.NoticeBack();
                    break;
                case Constant.BY_MAJOR:
                    while (count < courseList.Count)
                    {
                        if (courseList[count].Major.Contains(inputedString))
                        {
                            Console.WriteLine("{0}\n", courseList[count].ToString());
                            search++;
                        }
                        count++;
                    }
                    break;
                case Constant.BY_COURSE_NUMBER: // 학수 번호
                    Console.Write("분반 입력 :");
                    string inputedDivision = Console.ReadLine();
                    if(inputedDivision == "b") { return 0; }
                    while (count < courseList.Count)
                    {
                        if (courseList[count].CourseNumber == inputedString)
                        {
                            if (courseList[count].DivisionNumber.Contains(inputedDivision))
                            {
                                Console.WriteLine("{0}\n", courseList[count].ToString());
                            }
                            search++;
                        }
                        count++;
                    }
                    break;
                case Constant.BY_COURSE_TITLE: // 강의 이름
                    while (count < courseList.Count)
                    {
                        if (courseList[count].CourseTitle.Contains(inputedString))
                        {
                            Console.WriteLine("{0}\n", courseList[count].ToString());
                            search++;
                        }
                        count++;
                    }
                    break;
                case Constant.BY_TARGET_STUDENT: // 학년
                    while (count < courseList.Count)
                    {
                        if (courseList[count].TargetStudent == Convert.ToDouble(inputedString))
                        {
                            Console.WriteLine("{0}\n", courseList[count].ToString());
                            search++;
                        }
                        count++;
                    }
                    break;
                case Constant.BY_LECTURER: // 강의자
                    while (count < courseList.Count)
                    {
                        if (courseList[count].Lecturer.Contains(inputedString))
                        {
                            Console.WriteLine("{0}\n", courseList[count].ToString());
                            search++;
                        }
                        count++;
                    }
                    break;
                case Constant.BY_INTERESTED_COURSE: // 관심과목(+수강신청일시)
                    while (count < courseList.Count)
                    {
                        if (courseList[count].Major.Contains(inputedString))
                        {
                            Console.WriteLine("{0}\n", courseList[count].ToString());
                            search++;
                        }
                        count++;
                    }
                    break;
            }
            if (search == 0)
            {
                Console.WriteLine("찾고자 하는 것이 없습니다!");
            }
            return 1;
        }
    }
}