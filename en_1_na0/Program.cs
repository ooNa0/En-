using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.InteropServices;

namespace en_1_na0
{
    class PrintingStar
    {
        private int number;
        private int lineNumber;
        public void StartPrinting()
        {
            while (true)
            {
                ShowMenu();
                Console.Write("Please Input from the menu number :");
                number = InputNumber();
               
                if (number < 0 || 6 < number)
                {
                    Console.WriteLine("Oh,,, please select the number on the menu");
                    continue;
                }
                if (number == 5)
                {
                    Console.WriteLine("Ok, Bye~!!");
                    break;
                }
                Console.Write("Please Input from the linenumber :");
                lineNumber = InputNumber();
                switch (number)
                {
                    case 1:
                        PrintTriangleStar(lineNumber);
                        break;
                    case 2:
                        PrintInvertedTriangleStar(lineNumber);
                        break;
                    case 3:
                        PrintInvertedTriangleStar(lineNumber);
                        PrintTriangleStar(lineNumber);
                        break;
                    case 4:
                        PrintDiamondStar(lineNumber);
                        break;
                }
            }
        }
        private static void ShowMenu()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("|                                            |");
            Console.WriteLine("|         1. PrintTriangleStar               |");
            Console.WriteLine("|         2. PrintInvertedTriangleStar       |");
            Console.WriteLine("|         3. PrintHourglassStar              |");
            Console.WriteLine("|         4. PrintDiamondStar                |");
            Console.WriteLine("|         5. Ending                          |");
            Console.WriteLine("|                                            |");
            Console.WriteLine("==============================================");
        }
        private int InputNumber()
        {
            int num;
            string stringNumber;
            while (true)
            {
                stringNumber = Console.ReadLine();
                if (!(int.TryParse(stringNumber, out num)))
                {
                    Console.Write("[!]Please Input natural number :");
                    continue;
                }
                if (num <= 0)
                {
                    Console.Write("[!]Please Input >>natural<< number :");
                    continue;
                }
                break;
            }
            return num;
        }
        public void PrintTriangleStar(int LineNumber)
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

        public void PrintInvertedTriangleStar(int LineNumber)
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
        public void PrintDiamondStar(int LineNumber)
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
            Console.SetWindowSize(127, 36);

            PrintingStar printingStar = new PrintingStar(); // 별찍기 객체 생성
            printingStar.StartPrinting(); // 별찍기 내 메소드 실행
        }
    }
}