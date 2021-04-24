using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace en_5_LectureTimeTable
{
    class CourseVO // 
    {
        private double no; // NO
        private string major; // 개설 학과 전공
        private string courseNumber; // 학수 번호
        private string divisionNumber; // 분반
        private string courseTitle; // 교과목명
        private string categorization; // 이수 구분
        private double targetStudent; // 학년
        private double credit; // 학점
        private string dateTime; // 요일 및 강의시간
        private string courseRoom = " "; // 강의실
        private string lecturer = " "; // 메인 교수명
        private string language; // 강의 언어

        public CourseVO(double no, string major, string courseNumber, string divisionNumber, string courseTitle, string categorization, double targetStudent, double credit, string dateTime, string courseRoom, string lecturer, string language)
        {
            No = no;
            Major = major;
            CourseNumber = courseNumber;
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

        public double No { get; set; }
        public string Major { get; set; }
        public string CourseNumber { get; set; }
        public string DivisionNumber { get; set; }
        public string CourseTitle { get; set; }
        public string Categorization { get; set; }
        public double TargetStudent { get; set; }
        public double Credit { get; set; }
        public string DateTime { get; set; }
        public string CourseRoom { get; set; }
        public string Lecturer { get; set; }
        public string Language { get; set; }

        public override string ToString()
        {//BigEndianUnicode
            int padingLengthCourseTitle = Constant.PADING_COURSE_TITLE - StringByteLength(CourseTitle);
            int padingLengthDateTime = Constant.PADING_DATE_TIME - StringByteLength(DateTime);
            int padingLengthCourseRoom = Constant.PADING_COURSE_ROOM - StringByteLength(CourseRoom);
            int padingLengthLecturer = Constant.PADING_LECTURER - StringByteLength(Lecturer);
            int padingLengthLanguage = Constant.PADING_LANGUAGE - StringByteLength(Language);

            return " " + No + "".PadLeft(Constant.PADING_NO - No.ToString().Length) + Major + "".PadLeft(Constant.PADING_MAJOR - Constant.KOREAN_BYTES * Major.Length) +
                " " + CourseNumber + " " + DivisionNumber + " " + 
                CourseTitle + "".PadLeft(padingLengthCourseTitle) + Categorization + " " + 
                TargetStudent + " " + Credit + " " + DateTime + "".PadLeft(padingLengthDateTime) + 
                CourseRoom + "".PadLeft(padingLengthCourseRoom) + Lecturer + 
                " ".PadLeft(padingLengthLecturer) + Language + "".PadLeft(padingLengthLanguage);
        }


        protected int StringByteLength(string wantReplaceString)
        {
            //Console.WriteLine(wantReplaceString);
            int byteLength = 0;
            int stringLength = wantReplaceString.Length;
            char[] splitCharacter = wantReplaceString.ToCharArray();
            //int byteCount = Encoding.GetEncoding("euc-kr").GetByteCount(splitCharacter);
            for (int i = 0; i < stringLength; i++)
            {
                //byte bytenumber = byteCount[i].;
                string stringCharactor = Convert.ToString(splitCharacter[i]);
                if (Regex.Match(stringCharactor, "^[가-힣]*$").Success)
                {
                    byteLength += 2;
                }
                else
                {
                    byteLength += 1;
                }
            }
            return byteLength;
        }
    }
}

/*
return " " + No + " ".PadLeft(Constant.PADING_NO - No.ToString().Length) + Major +
                "".PadLeft(Constant.PADING_MAJOR - Constant.KOREAN_BYTES * Major.Length) + 
                " " + CourseNumber + " " + DivisionNumber + " " + 
                CourseTitle + "".PadLeft(padingLengthCourseTitle) + Categorization + " " + 
                TargetStudent + " " + Credit + " " + DateTime + "".PadLeft(padingLengthDateTime) + 
                CourseRoom + "".PadLeft(padingLengthCourseRoom) + Lecturer + 
                " ".PadLeft(padingLengthLecturer) + Language + "".PadLeft(padingLengthLanguage);
*/
