using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace en_5_LectureTimeTable
{
    class CourseDataManagement
    {
        private InputCheck inputCheck;
        private Print print;
        public CourseDataManagement()
        {
            inputCheck = new InputCheck();
            print = new Print();
        }

        public void Add() // 강의 추가
        {

        }

        public void Remove() // 강의 지우기
        {

        }

        public void PrintAll() // 모든 강의 출력
        {

        }

        public void Search(int addInterestedCourse) // 강의 찾기, addInterestedCourse는 수강신청시에 1, 아닐시에 0이다.
        {
            bool hasEnded = false;

            while (!hasEnded)
            {
                print.ShowSearchCourseMenu();
                switch (inputCheck.EnterMenuNumber(Constant.MINIMUN_SEARCHCOURSE_MENU_NUMBER, Constant.MAXIMUN_SEARCHCOURSE_MENU_NUMBER + addInterestedCourse))
                {
                    case Constant.BACK:
                        print.NoticeBack();
                        return;
                    case Constant.BY_MAJOR: // 개설 학과 전공으로

                        break;
                    case Constant.BY_COURSE_NUMBER: // 학수 번호로

                        break;
                    case Constant.BY_COURSE_TITLE: // 교과목 명으로

                        break;
                    case Constant.BY_TARGET_STUDENT: // 강의 대상 학년으로

                        break;
                    case Constant.BY_LECTURER: // 교수명으로

                        break;
                    case Constant.BY_INTERESTED_COURSE: // (수강신청 시에만)관심과목으로 찾기

                        break;
                }
            }
        }

        public void ShowMyCourseList(bool isInterestedCourse) // 내가 추가한 과목 출력
        {
            // 카테고리 추가
            if (isInterestedCourse) // 관심과목일 경우, true
            {

            }
            else // 수강 신청일 경우, false
            {

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

                        break;
                    case Constant.SAVE_TIMETABLE:

                        break;
                }
            }
        }
    }
}
