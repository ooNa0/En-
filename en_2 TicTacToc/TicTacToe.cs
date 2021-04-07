using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace en_2_TicTacToc
{
    class TicTacToe
    {
        // 변수 선언
        
        private int _number;
        private int arrayNumber = 0;
        private int _checkException = 1;
        private string User1;
        private string User2;
        private bool _isFinished = false;

        public ArrayList userScore = new ArrayList();

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
                        //ArrayList userScore = new ArrayList();
                        userScore.Add(WhoAreYou());//.Add(WhoAreYou());
                        userScore.Add(0);
                        userScore.Add(0);
                        PlayGameWithComputer();
                        arrayNumber++;
                        break;
                    case 2:
                        PlayGameWithUser();
                        break;
                    case 3:
                        ShowScoreboard(arrayNumber);
                        break;
                    case 4:
                        _checkException = EndProgram();
                        if (_checkException == 0) // Y/y를 입력했을 경우
                        {
                            Console.WriteLine("\n\nOk,, Goodbye!!!!!");
                            return;
                        }
                        else if (_checkException != 1) // N/n이 아닌 다른 것을 입력했을 경우
                        {
                            Console.WriteLine("Please choose from Y/N (T.T) ..............");
                        }
                        Console.WriteLine("You return to the menu selection screen.");
                        break;
                    default:
                        break;
                }
            }
        }

        private void ShowScoreboard(int arrayNumber)
        {
            //throw new NotImplementedException();
            if(arrayNumber == 0)
            {
                Console.WriteLine("\n[!]No Score record. . . returning Menu");
                return;
            }
            Console.WriteLine("[index]   username   win   lose");

            for (int i = 0; i < arrayNumber; i++)
            {
                Console.WriteLine("[{0}]          {1}       {2}       {3}", i + 1, userScore[i*3], userScore[1 + i*3], userScore[2 + i*3]);
            }
        }

        private void PlayGameWithComputer()
        {
            Console.Clear();
            // 배열 생성 및 초기화
            ShowTile tile = new ShowTile();
            char[] arrangementOX = new char[9];
            for (int i = 0; i < 9; i++) arrangementOX[i] = (char)(i + 48);
            Random random = new Random();
            

            tile.Tile(arrangementOX, 10);

            int inputNumber;
            bool isEnd = false;

            int count = 0;
            while (!isEnd)
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nUser {0}, Enter the number(0~8)", userScore[0]);
                inputNumber = int.Parse(Console.ReadLine());
                arrangementOX[inputNumber] = 'o';
                tile.Tile(arrangementOX, inputNumber);
                //Console.WriteLine("\n\n\n\n\n");
                //Console.ForegroundColor = ConsoleColor.Blue;
                Thread.Sleep(1000);
                Console.Clear();
                bool isExist = true;
                while (isExist)
                {
                    if(count == 5)
                    {
                        Console.WriteLine("tie");
                        break;
                    }
                    else
                    {
                        inputNumber = random.Next(9); // 컴퓨터는 랜덤으로 값을 입력
                        if (arrangementOX[inputNumber] != 'x' && arrangementOX[inputNumber] != 'o')
                        {
                            arrangementOX[inputNumber] = 'x';
                            tile.Tile(arrangementOX, inputNumber);
                            isExist = false;
                        }
                    }
                }
                count++;
                Console.WriteLine("count = {0}", count);
                char checkWin = CheckWin(arrangementOX);
                Console.WriteLine("CheckWin = {0}", checkWin);
                if (checkWin == 'o')
                {
                    userScore[1 + arrayNumber*3] = (int)userScore[1] + 1;
                    Console.WriteLine("User Win!!!!");
                    isEnd = true;
                }
                else if(checkWin == 'x')
                {
                    userScore[2 + arrayNumber*3] = (int)userScore[2] + 1;
                    Console.WriteLine("Computer Win!!!");
                    isEnd = true;
                }
                
            }
            //Console.ForegroundColor = ConsoleColor.White;
            

        }

        private char CheckWin(char[] arrangementOX)
        {
            // 가로 빙고일 경우
            for (int i = 0; i < 3; i++)
            {
                if (arrangementOX[i * 3] == arrangementOX[i * 3 + 1] && arrangementOX[i * 3 + 1] == arrangementOX[i * 3 + 2])
                {
                    return arrangementOX[i * 3];
                }
            }
            // 세로 빙고일 경우
            for (int i = 0; i < 3; i++)
            {
                if (arrangementOX[i] == arrangementOX[i + 3] && arrangementOX[i + 3] == arrangementOX[i + 6])
                {
                    return arrangementOX[i];
                }
            }
            // 대각선 빙고일 경우
            if(arrangementOX[0] == arrangementOX[4] && arrangementOX[4] == arrangementOX[8])
            {
                return arrangementOX[0];
            }
            if (arrangementOX[2] == arrangementOX[4] && arrangementOX[4] == arrangementOX[6])
            {
                return arrangementOX[2];
            }
            return 'N';
        }

        private void PlayGameWithUser()
        {
            //throw new NotImplementedException();
            ShowTile tile = new ShowTile();
            // 배열 생성 및 초기화
            char[] arrangementOX = new char[9];
            for (int i = 0; i < 9; i++) arrangementOX[i] = (char)(i + 48);
            //arrangementOX = Enumerable.Repeat('_', 9).ToArray();

            tile.Tile(arrangementOX, 10);

            int inputNumber;
            bool isEnd = false;
            while (isEnd)
            {

                //Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("User1, Enter the number(0~8)");
                inputNumber = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Yellow;
                arrangementOX[inputNumber] = '0';
                Console.ForegroundColor = ConsoleColor.White;
                tile.Tile(arrangementOX, inputNumber);
                Console.Clear();
                //Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("User2, Enter the number");
                inputNumber = int.Parse(Console.ReadLine());
                arrangementOX[inputNumber] = 'X';
                tile.Tile(arrangementOX, inputNumber);
                Console.Clear();
            }
            Console.ForegroundColor = ConsoleColor.White;



        }


        private void ShowMenu()// 메뉴 출력
        {
            //Console.Clear(); 
            Console.WriteLine("\n\n       1. [PLAG GAME] WITH THE COMPUTER\n");
            Console.WriteLine("       2. [PLAG GAME] WITH THE USER\n");
            Console.WriteLine("       3. SHOW SCOREBOARD\n");
            Console.WriteLine("       4. END THE PROGRAM\n");
           //Console.WriteLine("                                                                                           ");
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
                Console.WriteLine("[+] Enter only in English");
                Console.WriteLine("[+] Character limit: 1~16");
                Console.Write("Please tell me your name :");

                _userName = Console.ReadLine();
                //Console.ForegroundColor = ConsoleColor.Red;
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
