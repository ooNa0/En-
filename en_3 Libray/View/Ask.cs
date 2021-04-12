using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace en_3_Libray.View
{
    class Ask
    {
        Menu menu = new Menu();
        public int AskYesOrNo()
        {
            Console.WriteLine("\"Yes\"나 \"No\"를 입력해주세요.");
            bool isFinished = true;
            ConsoleKeyInfo keyInput;

            while (isFinished)
            {
                string answer = "";
                keyInput = Console.ReadKey(false);
                while (keyInput.Key != ConsoleKey.Enter)
                {
                    if (keyInput.Key == ConsoleKey.Escape)
                    {
                        menu.MainMenu();
                    }
                    answer += keyInput;
                    keyInput = Console.ReadKey(false);
                }
                
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
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("정말로 프로그램을 종료하시겠어요?");
                        Console.WriteLine("\"Yes\"나 \"No\"를 입력해주세요.");
                        continue;
                }
            }
            return 0;

        }
    }
}
