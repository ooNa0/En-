using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace en_4_Library
{
    class Check
    {
        public bool EnglishAndNumber(string input)
        {
            Console.Clear();
            if (!(Regex.Match(input, "^[a-zA-Z0-9]*$").Success))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("영어와 숫자만 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                return false;
            }
            return true;
        }

        public bool English(string input)
        {
            Console.Clear();
            if (!(Regex.Match(input, "^[a-zA-Z]*$").Success))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("영어를 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                return false;
            }
            return true;
        }

        // 이거 안됨
        public bool Number(string input)
        {
            Console.Clear();
            if (!(Regex.Match(input, "^[0-9]+$").Success))
            {
                Console.WriteLine(Regex.IsMatch(input, "^[0-9]+$"));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("숫자가 입력이 되지 않았습니다.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                return false;
            }
            return true;
        }
        
        public bool Length(string input, int minLength, int maxLength)
        {
            Console.Clear();
            if (minLength > input.Length || input.Length > maxLength)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("길이가 {0}이상, {1}이하로 입력해주세요.", minLength, maxLength); ;
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                return false;
            }
            return true;
        }

        public bool Korean(string input)
        {
            Console.Clear();
            if (!(Regex.IsMatch(input, "^[가-힣]{1,4}$")))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("4글자 이내 한글을 제대로 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                return false;
            }
            return true;
        }
        /*
        public bool PhoneNumber(string input)
        {
            Console.Clear();
            if (!(Regex.IsMatch(input, "^[0-9]{2,3}-?([0-9]{4})-?([0-9]{4})$")))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("000-0000-0000형식으로 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                return false;
            }//https://docs.microsoft.com/ko-kr/dotnet/csharp/how-to/search-strings
            return true;
        }*/
    }
}
