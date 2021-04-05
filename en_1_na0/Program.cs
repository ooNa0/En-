using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace en_1_na0
{
    class PrintInvertedStar
    {
        public PrintInvertedStar(int LineNumber)
        {
<<<<<<< HEAD
            while (true)
            {
                ShowMenu();
                Console.Write("Please Input from the menu number :");
                number = InputNumber();
               
                if (number < 0 || 6 < number)
=======

            for (int i = LineNumber; i > 0; i--)
            {
                for (int j = LineNumber; j > i; j--)
>>>>>>> parent of 657fa60... 거의 다함
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < i * 2 - 1; j++)
                {
                    Console.Write("*");
                }
<<<<<<< HEAD
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
=======
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
>>>>>>> parent of 657fa60... 거의 다함
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

        static int InputNumber()
        {
            string stringNumber;
            int number;
            while (true)
            {
                stringNumber = Console.ReadLine();
                if (!(int.TryParse(stringNumber, out number)))
                {
                    Console.WriteLine("Please Input natural number");
                    continue;
                }
                if(number < 0)
                {
                    Console.WriteLine("Please Input >>>>>natural<<<<<< number");
                    continue;
                }
                break;
            }
            return number;
        }
<<<<<<< HEAD
        public void PrintTriangleStar(int LineNumber)
=======
        static void Main()
>>>>>>> parent of 657fa60... 거의 다함
        {
            bool count = true;
            while (count)
            {
<<<<<<< HEAD
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
=======
                ShowMenu(); // 메뉴 출력
>>>>>>> parent of 657fa60... 거의 다함

                int number = InputNumber();
                if(number < 0 || 6 < number)
                {
                    Console.WriteLine("Oh,,, please select the number on the menu");
                    continue;
                }
                Console.Write("* Please Input LineNumber :");
                
                int LineNumber = InputNumber();

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
                }
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
<<<<<<< HEAD
    

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
=======
}
>>>>>>> parent of 657fa60... 거의 다함
