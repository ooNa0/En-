using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;

namespace en_5_LectureTimeTable.Management
{
    class CourseDataCalculation
    {

        public double SumCredits(List<CourseVO> timeTable)
        {
            int count = 0;
            double sumCredits = 0;

            while (count < timeTable.Count)
            {
                sumCredits += timeTable[count].Credit;
                count++;
            }
            return sumCredits;
        }

        public int Month(string month) // 요일값 index 로 리턴
        {
            int monthNumber = 0;
            switch (month)
            {
                case "월":
                    monthNumber = 1;
                    break;
                case "화":
                    monthNumber = 2;
                    break;
                case "수":
                    monthNumber = 3;
                    break;
                case "목":
                    monthNumber = 4;
                    break;
                case "금":
                    monthNumber = 5;
                    break;
            }
            return monthNumber;
        }

        public int Time(DateTime time) // 시간 값 index로 리턴
        {
            DateTime dateTime = new DateTime(2021, 04, 26, 09, 00, 00);
            int index;

            for (index = 0; index < Constant.TIMETABLE_COLUMN; index++)
            {
                if (dateTime.ToString("hh:mm") == time.ToString("hh:mm"))
                {
                    break;
                }
                dateTime = dateTime.AddMinutes(Constant.TIME_INTERVAL);
            }
            return index;
        }

        public int StringByteLength(string wantReplaceString)
        {
            if (wantReplaceString == null)
            {
                return 0;
            }
            int byteLength = 0;
            int stringLength = wantReplaceString.Length;
            char[] splitCharacter = wantReplaceString.ToCharArray();

            for (int i = 0; i < stringLength; i++)
            {
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

        public bool TimeCompare(int compareTimetableindex, List<CourseVO> editCourseList, List<CourseVO> courseList)
        {
            string[,] timeTableArray = InputTimeTable(editCourseList); // 배열 선언
            List<CourseVO> compareTimetableList = new List<CourseVO>();

            compareTimetableList.Add(new CourseVO(courseList[compareTimetableindex].No, courseList[compareTimetableindex].Major,
                courseList[compareTimetableindex].CourseNumber, courseList[compareTimetableindex].DivisionNumber,
                courseList[compareTimetableindex].CourseTitle, courseList[compareTimetableindex].Categorization,
                courseList[compareTimetableindex].TargetStudent, courseList[compareTimetableindex].Credit,
                courseList[compareTimetableindex].DateTime, courseList[compareTimetableindex].CourseRoom,
                courseList[compareTimetableindex].Lecturer, courseList[compareTimetableindex].Language));

            string[,] compareTimeTableArray = InputTimeTable(compareTimetableList);

            for (int i = 1; i < Constant.TIMETABLE_COLUMN; i++)
            {
                for (int j = 1; j < Constant.TIMETABLE_ROW; j++)
                {
                    if (timeTableArray[i, j] != null && compareTimeTableArray[i, j] != null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public string[,] InputTimeTable(List<CourseVO> timeTable)
        {
            string[,] timeTableArray = new string[Constant.TIMETABLE_COLUMN + 1, Constant.TIMETABLE_ROW + 1]; // 배열 선언
            DateTime dateTime = new DateTime(2021, 04, 27, 09, 00, 00);
            timeTableArray[0, 0] = "     ";

            for (int index = 0; index < Constant.TIMETABLE_COLUMN; index++)
            {
                timeTableArray[index, 0] = dateTime.ToString("HH:mm");
                dateTime = dateTime.AddMinutes(Constant.TIME_INTERVAL);
            } // 시간 넣기

            int count = timeTable.Count;
            string[] sliceString;
            string[] sliceTimeString;
            DateTime[] sliceTime = new DateTime[2];
            int monthNumber;
            int firstmonthNumber;
            int secondmonthNumber;
            int timeNumber;

            while (count > Constant.COUNT_SIZE_ZERO)
            {
                foreach (CourseVO course in timeTable)
                {
                    sliceString = course.DateTime.Split(" ");
                    switch (sliceString.Length)
                    {
                        case Constant.MONTH_TIME:// 요일 시간
                            monthNumber = Month(sliceString[Constant.FIRST_MONTH_INDEX]);
                            sliceTimeString = sliceString[1].Split("~");
                            sliceTime[0] = DateTime.ParseExact(sliceTimeString[0], "HH:mm", null);
                            sliceTime[1] = DateTime.ParseExact(sliceTimeString[1], "HH:mm", null);
                            timeNumber = Time(sliceTime[0]);

                            for (int index = 0; index < (((sliceTime[1] - sliceTime[0]).Hours * 60) + (sliceTime[1] - sliceTime[0]).Minutes) / 30; index++)
                            {
                                timeTableArray[timeNumber, monthNumber] = course.CourseTitle + "(" + course.CourseRoom + ")";
                                timeNumber++;
                            }
                            break;
                        case Constant.MONTH_MONTH_TIME: // 요일 요일 시간
                            firstmonthNumber = Month(sliceString[Constant.FIRST_MONTH_INDEX]);
                            secondmonthNumber = Month(sliceString[Constant.SECONDE_MONTH_INDEX]);
                            sliceTimeString = sliceString[2].Split("~");
                            sliceTime[0] = DateTime.ParseExact(sliceTimeString[0], "HH:mm", null);
                            sliceTime[1] = DateTime.ParseExact(sliceTimeString[1], "HH:mm", null);
                            timeNumber = Time(sliceTime[0]);

                            for (int index = 0; index < (((sliceTime[1] - sliceTime[0]).Hours * 60) + (sliceTime[1] - sliceTime[0]).Minutes) / 30; index++)
                            {
                                timeTableArray[timeNumber, firstmonthNumber] = course.CourseTitle + "(" + course.CourseRoom + ")";
                                timeTableArray[timeNumber, secondmonthNumber] = course.CourseTitle + "(" + course.CourseRoom + ")";
                                timeNumber++;
                            }
                            break;
                        case Constant.MONTH_TIME_MONTH_TIME: // 요일 시간, 요일 시간
                            monthNumber = Month(sliceString[Constant.FIRST_MONTH_INDEX]);
                            sliceTimeString = sliceString[1].Replace(",", "").Split("~");
                            sliceTime[0] = DateTime.ParseExact(sliceTimeString[0], "HH:mm", null);
                            sliceTime[1] = DateTime.ParseExact(sliceTimeString[1], "HH:mm", null);
                            timeNumber = Time(sliceTime[0]);

                            for (int index = 0; index < (((sliceTime[1] - sliceTime[0]).Hours * 60) + (sliceTime[1] - sliceTime[0]).Minutes) / 30; index++)
                            {
                                timeTableArray[timeNumber, monthNumber] = course.CourseTitle + "(" + course.CourseRoom + ")";
                                timeNumber++;
                            }
                            monthNumber = Month(sliceString[Constant.FIRST_MONTH_INDEX]);
                            sliceTimeString = sliceString[1].Replace(",", "").Split("~");
                            sliceTime[0] = DateTime.ParseExact(sliceTimeString[0], "HH:mm", null);
                            sliceTime[1] = DateTime.ParseExact(sliceTimeString[1], "HH:mm", null);
                            timeNumber = Time(sliceTime[0]);

                            for (int index = 0; index < (((sliceTime[1] - sliceTime[0]).Hours * 60) + (sliceTime[1] - sliceTime[0]).Minutes) / 30; index++)
                            {
                                timeTableArray[timeNumber, monthNumber] = course.CourseTitle + "(" + course.CourseRoom + ")";
                                timeNumber++;
                            }
                            break;
                        case Constant.MONTH_MONTH_TIME_MONTH_TIME: // 요일 요일 시간, 요일 시간
                            firstmonthNumber = Month(sliceString[Constant.FIRST_MONTH_INDEX]);
                            secondmonthNumber = Month(sliceString[Constant.SECONDE_MONTH_INDEX]);
                            sliceTimeString = sliceString[1].Replace(",", "").Split("~");
                            sliceTime[0] = DateTime.ParseExact(sliceTimeString[0], "HH:mm", null);
                            sliceTime[1] = DateTime.ParseExact(sliceTimeString[1], "HH:mm", null);
                            timeNumber = Time(sliceTime[0]);

                            for (int index = 0; index < (((sliceTime[1] - sliceTime[0]).Hours * 60) + (sliceTime[1] - sliceTime[0]).Minutes) / 30; index++)
                            {
                                timeTableArray[timeNumber, firstmonthNumber] = course.CourseTitle + "(" + course.CourseRoom + ")";
                                timeTableArray[timeNumber, secondmonthNumber] = course.CourseTitle + "(" + course.CourseRoom + ")";
                                timeNumber++;
                            }
                            monthNumber = Month(sliceString[Constant.FIRST_MONTH_INDEX]);
                            sliceTimeString = sliceString[1].Split("~");
                            sliceTime[0] = DateTime.ParseExact(sliceTimeString[0], "HH:mm", null);
                            sliceTime[1] = DateTime.ParseExact(sliceTimeString[1], "HH:mm", null);
                            timeNumber = Time(sliceTime[0]);

                            for (int index = 0; index < (((sliceTime[1] - sliceTime[0]).Hours * 60) + (sliceTime[1] - sliceTime[0]).Minutes) / 30; index++)
                            {
                                timeTableArray[timeNumber, monthNumber] = course.CourseTitle + "(" + course.CourseRoom + ")";
                                timeNumber++;
                            }
                            break;
                    }
                }
                count--;
            }
            return timeTableArray;
        }

        public void ManageTimeTable(List<CourseVO> timeTableList) // 시간표 엑셀에 넣기
        {
            string[,] timeTableArray;
            timeTableArray = InputTimeTable(timeTableList);
            FileInfo fileInfomation = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\나의시간표.xlsx");
            if (fileInfomation.Exists)
            {
                fileInfomation.Delete();
            }
            Console.Write("엑셀 저장중입니다.");
            // Excel Application 객체 생성
            Excel.Application application = new Excel.Application();
            Console.Write(".");
            // 워크북 추가
            Excel.Workbook workbook = application.Workbooks.Add();
            Console.Write(".");
            // 첫번째 워크 시트 가져오기
            Excel.Worksheet worksheet = workbook.Worksheets.get_Item(1) as Excel.Worksheet;

            worksheet.Cells[Constant.EXCEL_FIRST_COLUNM_INDEX, Constant.EXCEL_TIME_INDEX] = "시간";
            worksheet.Cells[Constant.EXCEL_FIRST_COLUNM_INDEX, Constant.EXCEL_MONDAY_INDEX] = "월";
            worksheet.Cells[Constant.EXCEL_FIRST_COLUNM_INDEX, Constant.EXCEL_TUESDAY_INDEX] = "화";
            worksheet.Cells[Constant.EXCEL_FIRST_COLUNM_INDEX, Constant.EXCEL_WEDNESDAY_INDEX] = "수";
            worksheet.Cells[Constant.EXCEL_FIRST_COLUNM_INDEX, Constant.EXCEL_THURSDAY_INDEX] = "목";
            worksheet.Cells[Constant.EXCEL_FIRST_COLUNM_INDEX, Constant.EXCEL_FRIDAY_INDEX] = "금";

            Console.WriteLine("!!!");

            for (int index = 0; index < Constant.TIMETABLE_COLUMN; index++)
            {
                int padingCourseTitleindex1 = Constant.EXCEL_PADING_COURSE_TITLE - StringByteLength(timeTableArray[index, 1]);
                int padingCourseTitleindex2 = Constant.EXCEL_PADING_COURSE_TITLE - StringByteLength(timeTableArray[index, 2]);
                int padingCourseTitleindex3 = Constant.EXCEL_PADING_COURSE_TITLE - StringByteLength(timeTableArray[index, 3]);
                int padingCourseTitleindex4 = Constant.EXCEL_PADING_COURSE_TITLE - StringByteLength(timeTableArray[index, 4]);
                int padingCourseTitleindex5 = Constant.EXCEL_PADING_COURSE_TITLE - StringByteLength(timeTableArray[index, 5]);

                worksheet.Cells[index + 2, Constant.EXCEL_TIME_INDEX] = timeTableArray[index, 0];
                worksheet.Cells[index + 2, Constant.EXCEL_MONDAY_INDEX] = Convert.ToString(timeTableArray[index, 1]) + "".PadLeft(padingCourseTitleindex1);
                worksheet.Cells[index + 2, Constant.EXCEL_TUESDAY_INDEX] = Convert.ToString(timeTableArray[index, 2]) + "".PadLeft(padingCourseTitleindex2);
                worksheet.Cells[index + 2, Constant.EXCEL_WEDNESDAY_INDEX] = Convert.ToString(timeTableArray[index, 3]) + "".PadLeft(padingCourseTitleindex3);
                worksheet.Cells[index + 2, Constant.EXCEL_THURSDAY_INDEX] = Convert.ToString(timeTableArray[index, 4]) + "".PadLeft(padingCourseTitleindex4);
                worksheet.Cells[index + 2, Constant.EXCEL_FRIDAY_INDEX] = Convert.ToString(timeTableArray[index, 5]) + "".PadLeft(padingCourseTitleindex5);
            }
            // 열 너비 자동 맞춤 
            worksheet.Columns.AutoFit();
            // 엑셀 파일 저장 application.
            workbook.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\나의시간표.xlsx");
            application.Workbooks.Close();

            // application 종료
            application.Quit();
        }
    }
}