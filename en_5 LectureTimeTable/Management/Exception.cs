using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using System.Text.RegularExpressions;

namespace en_5_LectureTimeTable
{
    class Checking
    {
        private string inputMenuNumber;
        public Checking()
        {
            
        }
        public string EnterMenuNumber(int minimunNumber, int maximumNumber)
        {
            bool hasEnded = false;

            int left = Console.CursorLeft, top = Console.CursorTop;

            while (!hasEnded)
            {
                Console.Write("번호 입력 :");
                inputMenuNumber = Console.ReadLine();
                if (inputMenuNumber == "b") return inputMenuNumber; // "b"하고 ENTER를 누르면 뒤로가기
                if (isNumberLength())
                {
                    if (isNumber())
                    {
                        if (isNumberRange(minimunNumber, maximumNumber))
                        {
                            hasEnded = true;
                        }
                    }
                }
            }
            
            //Console.Clear();
            return inputMenuNumber;
        }

        public string EnterCourseDataNumber(int minimunNumber, int maximumNumber)
        {
            bool hasEnded = false;

            while (!hasEnded)
            {
                Console.Write("번호 입력 :");
                inputMenuNumber = Console.ReadLine();
                if (inputMenuNumber == "b") return inputMenuNumber; // "b"하고 ENTER를 누르면 뒤로가기
                if (isLength(Constant.MINIMUN_COURSE_NO_LENGTH, Constant.MAXIMUN_COURSE_NO_LENGTH))
                {
                    if (isNumber())
                    {
                        if (isNumberRange(minimunNumber, maximumNumber))
                        {
                            hasEnded = true;
                        }
                    }
                }
            }
            //Console.Clear();
            return inputMenuNumber;
        }
        private bool isNumber()
        {
            int left = Console.CursorLeft, top = Console.CursorTop;
            if (!(Regex.Match(inputMenuNumber, "^[0-9]*$").Success))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("숫자를 입력해주세요!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.SetCursorPosition(left, top);
                Console.WriteLine("                                 ");
                Console.SetCursorPosition(left, top - 1);
                Console.WriteLine("                                 ");
                Console.SetCursorPosition(left, top - 1);
                return false;
            }
            return true;
        }

        private bool isLength(int minimumLength, int maxLength)
        {
            int left = Console.CursorLeft, top = Console.CursorTop;
            if (minimumLength > inputMenuNumber.Length || inputMenuNumber.Length > maxLength)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("길이를 {0}이상, {1}이하로 입력해주세요.", minimumLength, maxLength); ;
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.SetCursorPosition(left, top);
                Console.WriteLine("                                                   ");
                Console.SetCursorPosition(left, top - 1);
                Console.WriteLine("                                         ");
                Console.SetCursorPosition(left, top - 1);
                //Console.ReadLine();
                return false;
            }
            return true;
        }

        private bool isNumberLength()
        {
            int left = Console.CursorLeft, top = Console.CursorTop;
            if (inputMenuNumber.Length != Constant.NUMBER_LENGTH)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("한자리 숫자만 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.SetCursorPosition(left, top);
                Console.WriteLine("                                 ");
                Console.SetCursorPosition(left, top - 1);
                Console.WriteLine("                                 ");
                Console.SetCursorPosition(left, top - 1);
                return false;
            }
            return true;
        }

        private bool isNumberRange(int minimumNumber, int maxNumber)
        {
            int left = Console.CursorLeft, top = Console.CursorTop;
            if (minimumNumber > Int32.Parse(inputMenuNumber) || Int32.Parse(inputMenuNumber) > maxNumber)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("숫자를 {0}이상, {1}이하로 입력해주세요.", minimumNumber, maxNumber); ;
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.SetCursorPosition(left, top);
                Console.WriteLine("                                                 ");
                Console.SetCursorPosition(left, top - 1);
                Console.Write("                                        ");
                Console.SetCursorPosition(left, top - 1);
                return false;
            }
            return true;
        }
    }
}
