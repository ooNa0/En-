using System;
using System.Collections.Generic;
using System.Text;

namespace en_2_TicTacToc
{
    class ShowTile
    {
        public void Tile(char[] arrangementOX, int inputNumber)//, int position)
        {
            Console.WriteLine("\nㅁ      ㅁ      ㅁ      ㅁ\n  ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (inputNumber == i * 3 + j)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("    {0}    ", arrangementOX[i * 3 + j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("    {0}    ", arrangementOX[i * 3 + j]);
                    }
                }
                Console.WriteLine("\n\nㅁ      ㅁ      ㅁ      ㅁ\n");
            }
        }
    }
}
