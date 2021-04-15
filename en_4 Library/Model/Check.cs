using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace en_4_Library
{
    class Check
    {
        public bool English(string input)
        {
            if (!(Regex.IsMatch(input, "^[a-zA-Z]+$")))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("영문자가 입력이 되지 않았습니다.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                return false;
            }
            return true;
        }

        public bool Number(string input)
        {
            if (!(Regex.IsMatch(input, "^[0-9]+$")))
            {
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
            if (minLength < input.Length && input.Length < maxLength)
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
            if (!(Regex.IsMatch(input, "^[가-힣]*$")))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("한글을 제대로 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                return false;
            }
            return true;
        }

        public bool PhoneNumber(string input)
        {
            if (!(Regex.IsMatch(input, "^[0-9]{2,3}-?([0-9]{4})-?([0-9]{4})$")))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("000-0000-0000형식으로 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                return false;
            }
            return true;
        }
    }
}
