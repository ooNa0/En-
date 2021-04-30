using en_5_LectureTimeTable.Management;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace en_5_LectureTimeTable
{
    class CourseVO // 
    {
        private CourseDataManagement management = new CourseDataManagement();
        private CourseDataCalculation calculation = new CourseDataCalculation();
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
            int padingLengthCourseTitle = Constant.PADING_COURSE_TITLE - calculation.StringByteLength(CourseTitle);
            int padingLengthDateTime = Constant.PADING_DATE_TIME - calculation.StringByteLength(DateTime);
            int padingLengthCourseRoom = Constant.PADING_COURSE_ROOM - calculation.StringByteLength(CourseRoom);
            int padingLengthLecturer = Constant.PADING_LECTURER - calculation.StringByteLength(Lecturer);
            int padingLengthLanguage = Constant.PADING_LANGUAGE - calculation.StringByteLength(Language);

            return " " + No + "".PadLeft(Constant.PADING_NO - No.ToString().Length) + Major + "".PadLeft(Constant.PADING_MAJOR - Constant.KOREAN_BYTES * Major.Length) +
                CourseNumber + "   " + DivisionNumber + "  " + 
                CourseTitle + "".PadLeft(padingLengthCourseTitle) + Categorization + "  " + 
                TargetStudent + "    " + Credit + "   " + DateTime + "".PadLeft(padingLengthDateTime) + 
                CourseRoom + "".PadLeft(padingLengthCourseRoom) + Lecturer + 
                " ".PadLeft(padingLengthLecturer) + Language + "".PadLeft(padingLengthLanguage);
        }
    }
}