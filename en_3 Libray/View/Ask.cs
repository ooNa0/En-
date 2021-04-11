using System;
using System.Collections.Generic;
using System.Text;

namespace en_3_Libray.View
{
    class Ask
    {
        public int AskYesOrNo()
        {
            Console.WriteLine("\"Yes\"나 \"No\"를 입력해주세요.");
            bool isFinished = true;

            while (isFinished)
            {
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "Yes":
                        return 0;
                    case "No":
                        return 1;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\"Yes\" 아니면 \"No\"만 입력이 가능합니다..!");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                }
            }
            return 0;

        }
    }
}
