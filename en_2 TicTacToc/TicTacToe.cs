using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace en_2_TicTacToc
{
    class TicTacToe
    {
        // 변수 선언
        private int _number;
        private int _checkException = 1;
        private string User1;
        private string User2;
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
                        User1 = WhoAreYou()
                        PlayGameWithComputer();
                        break;
                    case 2:
                        PlayGameWithUser();
                        break;
                    case 3:
                        ShowScoreboard();
                        break;
                    case 4:
                        _checkException = EndProgram();
                        if (_checkException == 0) // Y/y를 입력했을 경우
                        {
                            Console.WriteLine("Goodbye");
                            return;
                        }
                        else if (_checkException != 1) // N/n이 아닌 다른 것을 입력했을 경우
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

        private void PlayGameWithUser()
        {
            //throw new NotImplementedException();

            // 배열 생성 및 초기화
            char[] arrangementOX = new char[9];
            arrangementOX = Enumerable.Repeat(' ', 9).ToArray();

            Tile(arrangementOX);

            int inputNumber;
            bool isEnd = false;
            while (isEnd)
            {

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("User1, Enter the number(0~8)");
                inputNumber = int.Parse(Console.ReadLine());
                arrangementOX[inputNumber] = 'O';
                Tile(arrangementOX);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("User2, Enter the number");
                inputNumber = int.Parse(Console.ReadLine());
                arrangementOX[inputNumber] = 'X';
                Tile(arrangementOX);
            }
            Console.ForegroundColor = ConsoleColor.White;



        }

        private void Tile(char[] arrangementOX)
        {
            Console.WriteLine("\n                                                                ");
            Console.WriteLine("\n                ㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁ                      ");
            Console.WriteLine("\n                ㅁ0     ㅁ1     ㅁ2     ㅁ                      ");
            Console.WriteLine("\n                ㅁ  {0} ㅁ  {1} ㅁ  {2} ㅁ                      ", arrangementOX[0], arrangementOX[1], arrangementOX[2]);
            Console.WriteLine("\n                ㅁ      ㅁ      ㅁ      ㅁ                      ");
            Console.WriteLine("\n                ㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁ                      ");
            Console.WriteLine("\n                ㅁ3     ㅁ4     ㅁ5     ㅁ                      ");
            Console.WriteLine("\n                ㅁ  {0} ㅁ  {1} ㅁ  {2} ㅁ                      ", arrangementOX[3], arrangementOX[4], arrangementOX[5]);
            Console.WriteLine("\n                ㅁ      ㅁ      ㅁ      ㅁ                      ");
            Console.WriteLine("\n                ㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁ                      ");
            Console.WriteLine("\n                ㅁ6     ㅁ7     ㅁ8     ㅁ                      ");
            Console.WriteLine("\n                ㅁ  {0} ㅁ  {1} ㅁ  {2} ㅁ                      ", arrangementOX[6], arrangementOX[7], arrangementOX[8]);
            Console.WriteLine("\n                ㅁ      ㅁ      ㅁ      ㅁ                      ");
            Console.WriteLine("\n                ㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁ                      ");
            Console.WriteLine("\n                                                                ");
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

                if (number < 0 || number > 5)
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

        private string WhoAreYou()
        {
            string _userName = null;
            bool _isException = false;

            while (!_isException)
            {
                Console.WriteLine("Please tell me your name");
                Console.WriteLine("[+] Enter only in English");
                Console.WriteLine("[+] Character limit: 1~16");

                _userName = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                if (!(Regex.IsMatch(_userName, "^[a-zA-Z]*$")))//0-9
                {
                    Console.WriteLine("[!] Enter only in English");
                    continue;
                }
                else if (_userName.Length < 0 || 16 < _userName.Length)
                {
                    Console.WriteLine("[!] Character limit: 1~16");
                    continue;
                }
                _isException = true;
                break;
            }
            return _userName;
        }
    }
}
