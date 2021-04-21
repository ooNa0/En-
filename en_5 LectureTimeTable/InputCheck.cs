using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace en_5_LectureTimeTable
{
    class InputCheck
    {

        public int EnterMenuNumber(int minimunNumber, int maximumNumber)
        {

        }
        private bool Number(string input)
        {
            if (!(Regex.Match(input, "^[0-9]*$").Success))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("숫자를 입력해주세요!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                return false;
            }
            return true;
        }

        private bool Length(string input, int minimumLength, int maxLength)
        {
            if (minimumLength > input.Length || input.Length > maxLength)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("길이를 {0}이상, {1}이하로 입력해주세요.", minimumLength, maxLength); ;
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                return false;
            }
            return true;
        }

        private bool NumberRange(int number, int minimumNumber, int maxNumber)
        {
            if (minimumNumber > number || number > maxNumber)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("숫자를 {0}이상, {1}이하로 입력해주세요.", minimumNumber, maxNumber); ;
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                return false;
            }
            return true;
        }
    }
}
