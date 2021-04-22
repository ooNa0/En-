using System;
using System.Collections.Generic;
using System.Text;

namespace en_5_LectureTimeTable
{
    class CourseVO // 
    {
        private string no; // NO
        private string major; // 개설 학과 전공
        private string courseNumber; // 학수 번호
        private string divisionNumber; // 분반
        private string courseTitle; // 교과목명
        private string categorization; // 이수 구분
        private string targetStudent; // 학년
        private string credit; // 학점
        private string dateTime; // 요일 및 강의시간
        private string courseRoom; // 강의실
        private string lecturer; // 메인 교수명
        private string language; // 강의 언어

        public CourseVO(string no, string major, string courseNumber, string divisionNumber, string courseTitle, string categorization, string targetStudent, string credit, string dateTime, string courseRoom, string lecturer, string language)
        {
            this.No = no;
            this.Major = major;
            this.CourseNumber = courseNumber;
            DivisionNumber = divisionNumber;
            CourseTitle = courseTitle;
            Categorization = categorization;
            TargetStudent = targetStudent;
            Credit = credit;
            DateTime = dateTime;
            CourseRoom = courseRoom;
            Lecturer = lecturer;
            Language = language;
        }

        public string No { get; set; }
        public string Major { get; set; }
        public string CourseNumber { get; set; }
        public string DivisionNumber { get; set; }
        public string CourseTitle { get; set; }
        public string Categorization { get; set; }
        public string TargetStudent { get; set; }
        public string Credit { get; private set; }
        public string DateTime { get; private set; }
        public string CourseRoom { get; private set; }
        public string Lecturer { get; private set; }
        public string Language { get; private set; }

        public override string ToString()
        {
            int padingLengthCourseTitle = Constant.PADING_COURSE_TITLE - Encoding.Default.GetBytes(CourseTitle).Length;
            int padingLengthDateTime = Constant.PADING_DATE_TIME - Encoding.Default.GetBytes(DateTime).Length;
            int padingLengthCourseRoom = Constant.PADING_COURSE_ROOM - Encoding.Default.GetBytes(CourseRoom).Length;
            int padingLengthLecturer = Constant.PADING_LECTURER - Encoding.Default.GetBytes(Lecturer).Length;
            int padingLengthLanguage = Constant.PADING_LANGUAGE - Encoding.Default.GetBytes(Language).Length;
            return No.PadLeft(Constant.PADING_NO - No.Length) + Major.PadLeft(Constant.PADING_MAJOR - Major.Length) + CourseNumber + DivisionNumber + CourseTitle + " ".PadLeft(padingLengthCourseTitle) + Categorization + TargetStudent + Credit + DateTime + " ".PadLeft(padingLengthDateTime) + CourseRoom + " ".PadLeft(padingLengthCourseRoom) + Lecturer + " ".PadLeft(padingLengthLecturer) + Language + " ".PadLeft(padingLengthLanguage);
        }
    }
}
