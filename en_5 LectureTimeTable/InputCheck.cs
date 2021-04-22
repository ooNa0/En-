using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace en_5_LectureTimeTable
{
    class InputCheck
    {
        private string inputMenuNumber;
        public InputCheck()
        {
            
        }

        public string EnterMenuNumber(int minimunNumber, int maximumNumber)
        {
            bool hasEnded = false;
            while (!hasEnded)
            {
                Console.Write("\n메뉴 번호 입력 :");
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
            Console.Clear();
            return inputMenuNumber;
        }
        private bool isNumber()
        {
            if (!(Regex.Match(inputMenuNumber, "^[0-9]*$").Success))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("숫자를 입력해주세요!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                return false;
            }
            return true;
        }

        private bool isLength(string input, int minimumLength, int maxLength)
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

        private bool isNumberLength()
        {
            if (inputMenuNumber.Length != Constant.NUMBER_LENGTH)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("한자리 숫자만 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                return false;
            }
            return true;
        }

        private bool isNumberRange(int minimumNumber, int maxNumber)
        {
            if (minimumNumber > Int32.Parse(inputMenuNumber) || Int32.Parse(inputMenuNumber) > maxNumber)
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
