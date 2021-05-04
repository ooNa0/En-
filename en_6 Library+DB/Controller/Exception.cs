using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace en_6_Library_DB
{
    class Exception
    {
        public Exception()
        {
            
        }

        public bool IsMenuNumberForm(string inputMenuNumber, int maximumNumber)
        {
            //bool hasEnded = false;
            if (inputMenuNumber == Constant.BACK) return true; // "b"하고 ENTER를 누르면 뒤로가기
            if (IsNumber(inputMenuNumber))
            {
                if (IsCorrectNumberRange(inputMenuNumber, maximumNumber))
                { return true; }
            }
            return false;
        }

        private bool IsNumber(string inputMenuNumber)
        {
            if (!(Regex.Match(inputMenuNumber, "^[0-9]*$").Success))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("숫자를 입력해주세요!");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }

        private bool IsCorrectNumberRange(string inputMenuNumber, int maximumNumber)
        {
            if (inputMenuNumber.Length != Constant.NUMBER_LENGTH)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("한자리 숫자만 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            if (Constant.MENU_NUMBER_MINIMUN > Int32.Parse(inputMenuNumber) || Int32.Parse(inputMenuNumber) > maximumNumber)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("숫자를 {0}이상, {1}이하로 입력해주세요.", Constant.MENU_NUMBER_MINIMUN, maximumNumber);
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }

        public bool HasEnglishAndNumber(string input)
        {
            if (!(Regex.Match(input, "^[a-zA-Z0-9]{4,10}$").Success))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("영어와 숫자를 5~10글자로 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                //Console.ReadLine();
                return false;
            }
            return true;
        }

        public bool HasKorean(string input)
        {
            if (!(Regex.IsMatch(input, "^[가-힣]{2,4}$")))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("2~4글자 이내 한글을 제대로 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }

        public bool IsCorrectYear(string input)
        {
            if (!(Regex.IsMatch(input, "^([1|2])([8|9|0|1])[0-9]{2}$")))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("입력값을 정확히 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }
        //
        public bool IsCorrectPhoneNumber(string input)
        {
            if (!(Regex.IsMatch(input, "^(0[1-9]{1,2})([0-9]{3,4})([0-9]{4})")))//, ,$1-$2-$3
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("전화번호를 '-'없이 제대로 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }
        public bool IsCorrectAddress(string input)
        {
            if (!(Regex.IsMatch(input, "^([가-힣0-9]{2,}(대로|로|길)+)$")))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("(도로명) (건물번호)를 입력해주세요. 예: 한들2로");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }

        public bool IsCorrectBookID(string input)
        {
            if (!(Regex.IsMatch(input, "^([2|1]?)?([0-9]{3})$")))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("4자리 숫자만 입력해주세요. 예: 2001, 1998");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }

        public bool IsCorrectLength(string input, int maximumLength)
        {
            if(Constant.MINIMUN_LENGTH < input.Length && input.Length < maximumLength)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("문자열 길이에 문제가 있습니다.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }

        public bool IsCorrectBookNumber(string input)
        {
            if (IsNumber(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("숫자를 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            if (IsCorrectLength(input, Constant.MAXIMUM_BOOKNUMBER))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("입력한 수량의 크기를 확인해주세요! 책 수량이 5자리가 넘는건 너무 많아요!");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }

        public bool IsCorrectBookPrice(string input)
        {
            if (IsNumber(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("숫자를 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            if (IsCorrectLength(input, Constant.MAXIMUM_BOOKPRICE))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("입력한 가격을 확인해주세요! 도서가 너무 비싸요 ㅠ");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            return true;
        }
    }
}
