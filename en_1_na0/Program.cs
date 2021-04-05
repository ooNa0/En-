using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace en_1_na0
{
    class PrintInvertedStar
    {
        public PrintInvertedStar(int LineNumber)
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
    }
    class PrintStar
    {
        //int LineNum;
        public PrintStar(int LineNumber)
        {
            for (int i = 0; i < LineNumber; i++)
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
    }
    class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("*                                            *");
            Console.WriteLine("*         1. PrintTriangleStar               *");
            Console.WriteLine("*         2. PrintInvertedTriangleStar       *");
            Console.WriteLine("*         3. PrintHourglassStar              *");
            Console.WriteLine("*         4. PrintDiamondStar                *");
            Console.WriteLine("*         5. Ending~~~~~~~~~~                *");
            Console.WriteLine("*                                            *");
            Console.WriteLine("==============================================");
            Console.Write("* Please Input Number :");
        }
        static void Main(string[] args)
        {
            bool count = true;
            while (count)
            {
                ShowMenu(); // 메뉴 출력
                string stringNumber;
                int number;
                stringNumber = Console.ReadLine();
                number = Convert.ToInt32(stringNumber);

                Console.Write("* Please Input LineNumber :");
                string stringLineNumber;
                int LineNumber;
                stringLineNumber = Console.ReadLine();
                LineNumber = Convert.ToInt32(stringLineNumber);

                switch (number)
                {
                    case 1:
                        PrintStar a = new PrintStar(LineNumber);
                        break;
                    case 2:
                        PrintInvertedStar b = new PrintInvertedStar(LineNumber);
                        break;
                    case 3:
                        PrintStar c = new PrintStar(LineNumber);
                        PrintInvertedStar d = new PrintInvertedStar(LineNumber);
                        break;
                    case 4:
                        PrintInvertedStar e = new PrintInvertedStar(LineNumber);
                        PrintStar f = new PrintStar(LineNumber);
                        break;
                    case 5:
                        count = false;
                        break;
                    default:
                        Console.WriteLine("Oh,,, please select the number on the menu");
                        break;
                }
            }
        }
    }
}
