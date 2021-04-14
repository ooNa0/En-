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
            if (!(Regex.IsMatch(input, "^[a-zA-Z]*$")))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("영문자가 입력이 되지 않았습니다.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
            }
        }
    }
}
