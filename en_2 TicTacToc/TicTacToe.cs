using System;
using System.Collections.Generic;
using System.Text;

namespace en_2_TicTacToc
{
    class TicTacToe
    {
        // 변수 선언
        private int _number;
        private bool _isFinished = false;
        public void StartGame()
        {
            while (!_isFinished)
            {
                ShowMenu();
                Console.Write("\nPlease Input from the menu number :");
            }

        }
        private void ShowMenu()
        {
            //Console.Clear(); 
            // 메뉴 출력
            Console.WriteLine("\n\n                                  1. [PLAG GAME] WITH THE COMPUTER                         ");
            Console.WriteLine("                                  2. [PLAG GAME] WITH THE USER                             ");
            Console.WriteLine("                                  3. SHOW SCOREBOARD                                       ");
            Console.WriteLine("                                  4. END THE PROGRAM                                       ");
            Console.WriteLine("                                                                                           ");
        }
    }
}
