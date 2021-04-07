using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace en_2_TicTacToc
{
    class TicTacToe
    {
        // 변수 선언
        private int _number;
        private int _checkException = 1;
        private bool _isFinished = false;
        public void StartGame()
        {
            while (!_isFinished)
            {
                // Menu 출력
                ShowMenu();

                // menuNumber 입력
                
                _number = InputNumber();


                switch (_number)
                {
                    case 1:
                        ShowMenu();
                        break;
                    case 2:
                        PlayGameWithComputer playComputer = new PlayGameWithComputer();
                        break;
                    case 3:
                        PlayGameWithUser playuser = new PlayGameWithUser();
                        break;
                    case 4:
                        _checkException = EndProgram();
                        if (_checkException == 0) // Y/y를 입력했을 경우
                        {
                            Console.WriteLine("Goodbye");
                            return;
                        }
                        else if(_checkException != 1) // N/n이 아닌 다른 것을 입력했을 경우
                        {
                            Console.WriteLine("Please choose from Y/N.");
                            Console.WriteLine("You return to the menu selection screen.");
                        }
                        break;
                    default:
                        break;
                }
            }

        }
        private void ShowMenu()// 메뉴 출력
        {
            //Console.Clear(); 
            Console.WriteLine("\n\n                                  1. [PLAG GAME] WITH THE COMPUTER                         ");
            Console.WriteLine("                                  2. [PLAG GAME] WITH THE USER                             ");
            Console.WriteLine("                                  3. SHOW SCOREBOARD                                       ");
            Console.WriteLine("                                  4. END THE PROGRAM                                       ");
            Console.WriteLine("                                                                                           ");
        }
        private int InputNumber() // menuNumber 입력
        {
            // 변수 선언
            int number = 0;
            //string stringNumber;
            bool isException = true;

            //Console.ForegroundColor = ConsoleColor.Red;
            // menuNumber 예외 처리
            while (isException)
            {
                Console.Write("\nPlease Input from the menu number :");
                //stringNumber = Console.ReadLine();
                number = int.Parse(Console.ReadLine());

                if(number < 0 || number > 5)
                {
                    Console.Write("\n[!]Please Input natural number :");
                    continue;
                }
                
                
                isException = false;
            }
            return number;
        }
        private int EndProgram() // 프로그램 종료 시 한번 더 물어봄
        {
            Console.WriteLine("Are you sure you want to close the tic-tac-toe program?");
            Console.WriteLine("Please answer Y/N");

            string answer = Console.ReadLine();

            switch (answer)
            {
                case "Y":
                    return 0;
                case "y":
                    return 0;
                case "N":
                    return 1;
                case "n":
                    return 1;
                default:
                    return 2;
            }
        }

    }

}
