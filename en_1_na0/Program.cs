using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;

namespace en_1_na0
{
    class PrintingStar
    {
        // 변수 선언
        private int number;
        private int lineNumber;
        public void StartPrinting()
        {
            while (true)
            {
                ShowMenu();
                Console.Write("\nPlease Input from the menu number :");
                number = InputNumber();
               // 메뉴 숫자번호 예외처리
                if (number < 0 || 6 < number)
                {
                    Console.WriteLine("\nOh,,, please select the number on the menu");
                    continue;
                }
                if (number == 5)
                {
                    Console.WriteLine("\nOk, Bye~!!");
                    break;
                }

                Console.Write("\nPlease Input from the linenumber :");
                lineNumber = InputNumber();
                Console.WriteLine("\n\n                                           [RESULT]");
                Console.WriteLine("============================================================================================");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                // 케이스 나누기
                switch (number)
                {
                    case 1:
                        PrintTriangleStar(lineNumber);
                        break;
                    case 2:
                        PrintInvertedTriangleStar(lineNumber);
                        break;
                    case 3: // 역삼각형별 + 삼각형별 = 모래시계별
                        PrintInvertedTriangleStar(lineNumber);
                        PrintTriangleStar(lineNumber);
                        break;
                    case 4:
                        PrintDiamondStar(lineNumber);
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("============================================================================================");
            }
        }
        private static void ShowMenu()
        {
            Console.Write("\n\n");
            Thread.Sleep(300);
            Console.Write("Loading");
            for(int i = 0; i < 4; i++)
            {
                Thread.Sleep(200);
                Console.Write(" . ");
            } // 로딩중
            Console.Clear(); // 메뉴 출력
            Console.WriteLine("============================================================================================");
            Console.WriteLine("|                                                                                           |");
            Console.WriteLine("|                                  1. PrintTriangleStar                                     |");
            Console.WriteLine("|                                  2. PrintInvertedTriangleStar                             |");
            Console.WriteLine("|                                  3. PrintHourglassStar                                    |");
            Console.WriteLine("|                                  4. PrintDiamondStar                                      |");
            Console.WriteLine("|                                  5. Ending                                                |");
            Console.WriteLine("|                                                                                           |");
            Console.WriteLine("============================================================================================");
        }
        private int InputNumber()
        {
            int num;
            string stringNumber;
            while (true)
            {
                stringNumber = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Red;
                // 예외 처리(자연수)
                if (!(int.TryParse(stringNumber, out num)))
                {
                    Console.Write("\n[!]Please Input natural number :");
                    continue;
                }
                if (num <= 0)
                {
                    Console.Write("\n[!]Please Input >>natural<< number :");
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.White;
                break;
            }
            return num;
        }
        public void PrintTriangleStar(int LineNumber) // 삼각형별 출력
        {
            for (int i = 1; i <= LineNumber; i++)
            {
                for (int j = LineNumber; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < i * 2 - 1; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
        }

        public void PrintInvertedTriangleStar(int LineNumber) // 역삼각형별 출력
        {

            for (int i = LineNumber; i > 0; i--)
            {
                for (int j = LineNumber; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < i * 2 - 1; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
        }
        public void PrintDiamondStar(int LineNumber) // 다이아몬드 모양 출력
        {
            for (int i = 1; i <= LineNumber+1; i++)
            {
                for (int j = LineNumber+1; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < i * 2 - 1; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            for (int i = LineNumber; i > 0; i--)
            {
                for (int j = LineNumber+1; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < i * 2 - 1; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
        }
    }
    

    class Program
    {
        static void Main()
        {
            Console.Title = "Printing Stars";
            Console.SetWindowSize(95, 30);

            PrintingStar printingStar = new PrintingStar(); // 별찍기 객체 생성
            printingStar.StartPrinting(); // 별찍기 내 메소드 실행
        }
    }
}