using System;
using System.Net;

namespace en_1_na0
{
    class PrintInvertedStar
    {
        int LineNum;
        public PrintInvertedStar(int LineNum)
        {

            for (int i = LineNum; i > 0; i--)
            {
                for (int j = LineNum; j > i; j--)
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
        int LineNum;
        public PrintStar(int LineNum)
        {
            for (int i = 0; i < LineNum; i++)
            {
                for (int j = LineNum; j > i; j--)
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
            Console.WriteLine("*                                            *");
            Console.WriteLine("==============================================");
        }
        static void Main(string[] args)
        {
            ShowMenu(); // 메뉴 출력
        }
    }
}
