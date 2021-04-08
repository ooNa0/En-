using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

// 동일 유저 네임?
namespace en_2_TicTacToc
{
    class TicTacToe
    {
        // 변수 선언
        private int _number;
        private int arrayNumber = 0;
        private int _checkException = 1;
        private bool _isFinished = false;
        private bool _isInMenuNumber;
        private string trushvalue;
        private ArrayList userScore = new ArrayList();

        public void StartGame()
        {
            
            while (!_isFinished)
            {
                Console.Clear();
                // Menu 출력
                ShowMenu();

                _isInMenuNumber = true;
                // menuNumber 입력
                while (_isInMenuNumber)
                {
                    _number = InputNumber();
                    if (_number < 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n[!] Please Input natural number");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    else if (_number > 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n[!] Please enter only the numbers 1-4 in the menu");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    _isInMenuNumber = false;
                }
                

                switch (_number)
                {
                    case 1:
                        userScore.Add(WhoAreYou());
                        userScore.Add(0);
                        userScore.Add(0);
                        PlayGameWithComputer();
                        break;
                    case 2:
                        PlayGameWithUser();
                        Console.WriteLine("Please enter any key . . . ");
                        trushvalue = Console.ReadLine(); // 클릭시 메뉴로 넘어감
                        break;
                    case 3:
                        ShowScoreboard(arrayNumber);
                        Console.WriteLine("\nPlease enter any key . . . ");
                        trushvalue = Console.ReadLine(); // 클릭시 메뉴로 넘어감
                        continue;
                    case 4:
                        Console.WriteLine("\n You want to close the tic-tac-toe?\n");
                        _checkException = EndProgram();
                        if (_checkException == 0) // Y/y를 입력했을 경우
                        {
                            Console.WriteLine("\n\nOk,, Goodbye!!!!!");
                            return;
                        }
                        Console.WriteLine("Please enter any key . . . ");
                        trushvalue = Console.ReadLine(); // 클릭시 메뉴로 넘어감
                        break;
                    default:
                        break;
                }
            }
        }

        private void ShowScoreboard(int arrayNumber)
        {
            if(arrayNumber == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[!] No Score record. . . returning Menu");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            Console.WriteLine("[index]   username        win   lose");

            for (int i = 0; i < arrayNumber; i++)
            {
                Console.WriteLine("[{0}]       {1}{2}     {3}", i + 1, userScore[i*3], userScore[1 + i*3], userScore[2 + i*3]);
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
                bool isExist = true;
                inputNumber = IsExist(arrangementOX);
                arrangementOX[inputNumber] = 'o';
                tile.Tile(arrangementOX, inputNumber);
                Thread.Sleep(1000);
                Console.Clear();
                       
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
                char checkWin = CheckWin(arrangementOX);
                if (checkWin == 'o')
                {
                    userScore[1 + arrayNumber*3] = (int)userScore[1 + arrayNumber*3] + 1;
                    Console.WriteLine("User Win!!!!");
                    Console.WriteLine("Would you like to play the game again?");
                    int anwser = EndProgram();
                    if(anwser == 0)
                    {
                        count = 0;
                        // 초기화
                        for (int i = 0; i < 9; i++) arrangementOX[i] = (char)(i + 48);
                        tile.Tile(arrangementOX, 10);
                    }
                    if(anwser == 1)
                    {
                        isEnd = true;
                        Console.WriteLine("Return to the menu.");
                    }
                    else if(anwser == 2)
                    {
                        isEnd = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYou entered it incorrectly. Return to the menu.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }   
                }
                else if(checkWin == 'x')
                {
                    userScore[2 + arrayNumber*3] = (int)userScore[2] + 1;
                    Console.WriteLine("Computer Win!!!");
                    isEnd = true;
                }   
            }
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
            ShowTile tile = new ShowTile();
            // 배열 생성 및 초기화
            char[] arrangementOX = new char[9];
            for (int i = 0; i < 9; i++) arrangementOX[i] = (char)(i + 48);
            
            tile.Tile(arrangementOX, 10);

            int inputNumber;
            bool isEnd = false;

            int count = 0;
            while (!isEnd)
            {
                if(count == 9)
                {
                    Console.WriteLine("tie");
                    break;
                }
                if(count % 2 == 0)
                {
                    Console.WriteLine("User1, Enter the number(0~8)");
                    inputNumber = IsExist(arrangementOX);
                    arrangementOX[inputNumber] = 'o';
                }
                else
                {
                    Console.WriteLine("User2, Enter the number(0~8)");
                    inputNumber = IsExist(arrangementOX);
                    arrangementOX[inputNumber] = 'x';
                }
                
                Thread.Sleep(500);
                Console.Clear();
                tile.Tile(arrangementOX, inputNumber);
               
                count++;
                char checkWin = CheckWin(arrangementOX);
                Console.WriteLine(checkWin);
                if (checkWin == 'o')
                {

                    Console.WriteLine("User1 Win!!!!");
                    isEnd = true;
                    Console.WriteLine("Return to the menu.");
                }
                else if (checkWin == 'x')
                {
                    Console.WriteLine("User2 Win!!!");
                    isEnd = true;
                    Console.WriteLine("Return to the menu.");
                }
            }
        }


        private void ShowMenu()// 메뉴 출력
        {
            Console.WriteLine("\n\n--------------------------------------------------");
            Console.WriteLine("\n    1. [PLAG GAME] WITH THE COMPUTER\n");
            Console.WriteLine("    2. [PLAG GAME] WITH THE USER\n");
            Console.WriteLine("    3. SHOW SCOREBOARD(only play with computer)\n");
            Console.WriteLine("    4. END THE PROGRAM\n");
            Console.WriteLine("--------------------------------------------------");
        }
        private int InputNumber() // menuNumber 입력
        {
            // 변수 선언
            string stringNumber;
            int number = 0;
            bool isException = true;
            
            // menuNumber 예외 처리
            while (isException)
            {
                Console.Write("\nPlease Input from the menu number :");
                stringNumber = Console.ReadLine();
                
                 if(stringNumber.Length != 1) // 길이 예외처리, 음수, 그냥 enter 도 예외 처리
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[!] Problem with the length of the number");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if((Regex.IsMatch(stringNumber, "^[0-8]*$"))) // 0~8 만 입력
                {
                    number = Convert.ToInt32(stringNumber);
                    isException = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[!] You entered it incorrectly,\n please enter it again");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return number;
        }
        private int EndProgram() // 프로그램 종료 시 한번 더 물어봄
        {
            Console.WriteLine("Please answer Y/N");
            bool isYN = true;

            while (isYN)
            {
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please choose from Y/N (T.T) ..............");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                }
            }
            return 0;
            
        }

        private string WhoAreYou()
        {
            string _userName = null;
            bool _isException = false;
            Console.WriteLine("\n\nOk,, and who you are??");
            Console.WriteLine("[+] Please enter only English and numbers");
            Console.WriteLine("[+] Character limit: 1~16");

            while (!_isException)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please tell me your name :");

                _userName = Console.ReadLine();
                if (_userName.Length == 0) // enter 예외처리
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[!]problem with the length of the number");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else if (!(Regex.IsMatch(_userName, "^[a-zA-Z0-9]*$")))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[!] Please enter only English and numbers");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else if (16 < _userName.Length)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[!] Character limit: 1~16");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                _isException = true;
                break;
            }
            return _userName.PadRight(16, ' ');
        }
        private int IsExist(char[] arrangementOX)
        {
            int inputNumber = 0;
            bool isExist = true;
            while (isExist)
            {
                //Console.WriteLine("Please enter the number(0~8)");
                inputNumber = InputNumber();
                if (arrangementOX[inputNumber] != 'x' && arrangementOX[inputNumber] != 'o')
                {
                    isExist = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[!] Value is already..\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    
                }
            }
            return inputNumber;
        }
    }
    
}
