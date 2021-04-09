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
        //public 
        private int _menuNumber; // 메뉴 넘버
        private int arrayNumber = 0; // 컴퓨터와 게임한 사용자 수
        private bool _isFinished = false; // 게임을 끝내는지
        private bool _isInMenuNumber; // 메뉴 번호 예외처리
        private string trushvalue; // 쓰레기 변수, clear를 위해 선언
        private ArrayList userScore = new ArrayList(); // 유저 스코어로 0:username 1:win 2:lose 가 저장

        public void StartGame()
        {
            while (!_isFinished)
            {
                Console.Clear();
                ShowMenu(); // 메뉴 출력

                _isInMenuNumber = true;

                // 메뉴 번호가 1~ 4에서 벗어났는지
                while (_isInMenuNumber)
                {
                    _menuNumber = InputNumber(); // 메뉴 번호 입력

                    if (_menuNumber < 1) // 자연수가 아닐때
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[!] Please Input natural number\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    else if (_menuNumber > 4) // 메뉴 번호보다 넘어갔을때
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[!] Please enter only the numbers 1-4 in the menu\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    _isInMenuNumber = false;
                }

                switch (_menuNumber)
                {
                    case 1: // 컴퓨터와 게임
                        userScore.Add(WhoAreYou()); // 사용자 이름 입력(중복허용)
                        userScore.Add(0); // win
                        userScore.Add(0); // lose
                        PlayGameWithComputer();
                        arrayNumber++; // user 수 증가
                        break;
                    case 2: // 혼자서 게임
                        PlayGameWithUser();
                        Console.WriteLine("Please enter any key . . . ");
                        trushvalue = Console.ReadLine(); // 클릭시 메뉴로 넘어감
                        break;
                    case 3: // 스코어보드 보여줌
                        ShowScoreboard(arrayNumber);
                        Console.WriteLine("\nPlease enter any key . . . ");
                        trushvalue = Console.ReadLine(); // 클릭시 메뉴로 넘어감
                        continue;
                    case 4: // 프로그램 종료
                        Console.WriteLine("\nYou want to close the tic-tac-toe?\n");
                        if (EndProgram() == 0) // Y/y를 입력했을 경우, 프로그램 종료
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

        private void ShowScoreboard(int arrayNumber) // 스코어보드 출력
        {
            if (arrayNumber == 0) // user 가 없다면
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[!] No Score record. . . returning Menu");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Console.WriteLine("[index]   username        win   lose");

            for (int i = 0; i < arrayNumber; i++)
            {
                Console.WriteLine("[{0}]       {1}{2}     {3}", i + 1, userScore[i * 3], userScore[1 + i * 3], userScore[2 + i * 3]);
            }

        }

        private void PlayGameWithComputer() // 컴퓨터와 게임
        {
            Console.Clear();
            char[] arrangementOX = new char[9];
            // 변수 선언 및 초기화
            ShowTile tile = new ShowTile();
            //Random random = new Random(); // 컴퓨터 입력(랜덤값)
            int inputNumber; // 숫자 입력
            int round = 0; // 라운드 횟수
            char checkWin; // 이긴 것 확인
            bool isEnd = false; // 게임을 끝낸다고 했을 때

            for (int i = 0; i < 9; i++) arrangementOX[i] = (char)(i + 48); // char 형 0~8까지 저장
            tile.Tile(arrangementOX, 10);

            while (!isEnd)
            {
                bool isExist = true;
                inputNumber = IsExist(arrangementOX);
                arrangementOX[inputNumber] = 'o';
                tile.Tile(arrangementOX, inputNumber);

                round++;

                while (isExist)
                {
                    if (round >= 5) // 마지막 라운드 일때
                    {
                        checkWin = CheckWin(arrangementOX);
                        if (checkWin == 'o') // user가 이길 경우
                        {
                            userScore[1 + arrayNumber * 3] = (int)userScore[1 + arrayNumber * 3] + 1;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("User Win!!!!\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else // 무승부
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("tie");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        isExist = false;
                    }
                    else
                    {
                        //inputNumber = random.Next(9); // 컴퓨터는 랜덤으로 값을 입력
                        inputNumber = AIComputer(arrangementOX);
                        //if (arrangementOX[inputNumber] != 'x' && arrangementOX[inputNumber] != 'o')
                        //{
                        arrangementOX[inputNumber] = 'x';
                        Console.Clear();
                        tile.Tile(arrangementOX, inputNumber);
                        isExist = false;
                        //}
                    }
                }
                if (round < 5) { // 마지막 라운드가 아닐 경우
                    checkWin = CheckWin(arrangementOX);
                    if (checkWin == 'o') // user win
                    {
                        userScore[1 + arrayNumber * 3] = (int)userScore[1 + arrayNumber * 3] + 1;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("User Win!!!!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (checkWin == 'x') // user lose
                    {
                        userScore[2 + arrayNumber * 3] = (int)userScore[2 + arrayNumber * 3] + 1;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Computer Win!!!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        continue;
                    }
                }

                // 다시 게임을 할 것인지
                Console.WriteLine("Would you like to play the game again?");
                int anwser = EndProgram();
                if (anwser == 0)
                {
                    round = 0;

                    // 초기화
                    for (int i = 0; i < 9; i++) arrangementOX[i] = (char)(i + 48);
                    tile.Tile(arrangementOX, 10);
                }
                if (anwser == 1)
                {
                    isEnd = true;
                }
            }
        }

        private int AIComputer(char[] arrangementOX)
        {
            if (WinAndBlock(arrangementOX) >= 0) { return WinAndBlock(arrangementOX); }
            else if (Fork(arrangementOX) >= 0) { return Fork(arrangementOX); }
            else if (Center(arrangementOX) >= 0) { return Center(arrangementOX); }
            else { return EmptySide(arrangementOX); }
        }

        private int WinAndBlock(char[] arrangementOX)
        {
            // 가로에서 2개 이상있을 경우
            for (int i = 0; i < 3; i++)
            {
                if (arrangementOX[i * 3] == arrangementOX[i * 3 + 1])
                {
                    if (arrangementOX[i * 3 + 2] != 'o' && arrangementOX[i * 3 + 2] != 'x')
                    {
                        return i * 3 + 2;
                    }
                }
                if (arrangementOX[i * 3] == arrangementOX[i * 3 + 2])
                {
                    if (arrangementOX[i * 3 + 1] != 'o' && arrangementOX[i * 3 + 1] != 'x')
                    {
                        return i * 3 + 1;
                    }
                }
                if (arrangementOX[i * 3 + 2] == arrangementOX[i * 3 + 1])
                {
                    if (arrangementOX[i * 3] != 'o' && arrangementOX[i * 3] != 'x')
                    {
                        return i * 3;
                    }
                }
            }

            // 세로에서 두개 이상
            for (int i = 0; i < 3; i++)
            {
                if (arrangementOX[i] == arrangementOX[i + 3])
                {
                    if (arrangementOX[i + 6] != 'o' && arrangementOX[i + 6] != 'x')
                    {
                        return i + 6;
                    }
                }
                if (arrangementOX[i] == arrangementOX[i + 6])
                {
                    if (arrangementOX[i + 3] != 'o' && arrangementOX[i + 3] != 'x')
                    {
                        return i + 3;
                    }
                }
                if (arrangementOX[i+3] == arrangementOX[i + 6])
                {
                    if (arrangementOX[i] != 'o' && arrangementOX[i] != 'x')
                    {
                        return i;
                    }
                }
            }

            // 대각선 빙고일 경우
            if (arrangementOX[0] == arrangementOX[4])
            {
                if(arrangementOX[8] != 'o' && arrangementOX[8] != 'x')
                {
                    return 8;
                }
            }
            if(arrangementOX[4] == arrangementOX[8])
            {
                if (arrangementOX[0] != 'o' && arrangementOX[0] != 'x')
                {
                    return 0;
                }
            }
            if (arrangementOX[0] == arrangementOX[8])
            {
                if (arrangementOX[4] != 'o' && arrangementOX[4] != 'x')
                {
                    return 4;
                }
            }
            return -1;
        }

        private int Fork(char[] arrangementOX) // 2목을 만들 가능성 (or 연산 사용)
        {
            bool True = true;
            // 가로
            for (int i = 0; i < 3; i++)
            {
                if (arrangementOX[i * 3] != 'o' && arrangementOX[i * 3 + 1] != 'o' && arrangementOX[i * 3 + 2] != 'o')
                {
                    if ((arrangementOX[i * 3] != 'x' || arrangementOX[(i * 3) + 1] != 'x' || arrangementOX[(i * 3) + 2] != 'x') == True) // or 연산
                    {
                        if(arrangementOX[i*3] == 'x')
                        {
                            return i * 3 + 1;
                        }
                        else
                        {
                            return i * 3;
                        }
                    }
                }
            }
            // 세로
            for (int i = 0; i < 3; i++)
            {
                if (arrangementOX[i] != 'o' && arrangementOX[i + 3] != 'o' && arrangementOX[i + 6] != 'o')
                {
                    if ((arrangementOX[i] != 'x' || arrangementOX[i + 3] != 'x' || arrangementOX[i + 6] != 'x') == True) // or 연산
                    {
                        if (arrangementOX[i] == 'x')
                        {
                            return i + 3;
                        }
                        else
                        {
                            return i;
                        }
                    }
                }
            }
            // 대각선
            if (arrangementOX[0] != 'o' && arrangementOX[4] != 'o' && arrangementOX[8] != 'o')
            {
                if ((arrangementOX[0] != 'x' || arrangementOX[4] != 'x' || arrangementOX[8] != 'x') == True) // or 연산
                {
                    if (arrangementOX[0] == 'x')
                    {
                        return 0;
                    }
                    else
                    {
                        return 4;
                    }
                }
            }
            return -1;
        }
        private int Center(char[] arrangementOX)
        {
            if (arrangementOX[4] != 'x' && arrangementOX[4] != 'o') { return 4; }
            return -1;
        }
        private int EmptySide(char[] arrangementOX)
        {
            Random random = new Random();
            return random.Next(9);
        }

        private char CheckWin(char[] arrangementOX) // 게임이 이겼는지 확인, 이기면 이긴 사람의 o, x를 반환
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

        private void PlayGameWithUser() // 혼자서 게임
        {
            Console.Clear();
            ShowTile tile = new ShowTile();
            // 배열 생성 및 초기화
            char[] arrangementOX = new char[9];
            for (int i = 0; i < 9; i++) arrangementOX[i] = (char)(i + 48);
            
            tile.Tile(arrangementOX, 10);

            int inputNumber;
            bool isEnd = false;
            int round = 0;

            while (!isEnd)
            {
                if(round == 9)
                {
                    Console.WriteLine("tie");
                    break;
                }
                if(round % 2 == 0)
                {
                    Console.WriteLine("User1,");
                    inputNumber = IsExist(arrangementOX);
                    arrangementOX[inputNumber] = 'o';
                }
                else
                {
                    Console.WriteLine("User2,");
                    inputNumber = IsExist(arrangementOX);
                    arrangementOX[inputNumber] = 'x';
                }
                
                Console.Clear();
                tile.Tile(arrangementOX, inputNumber);
               
                round++;
                char checkWin = CheckWin(arrangementOX);

                if (checkWin == 'o')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("User1 Win!!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    isEnd = true;
                }
                else if (checkWin == 'x')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("User2 Win!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    isEnd = true;
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
                Console.Write("\nPlease Input from the number :");
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
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[!] You entered it incorrectly");
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

        private string WhoAreYou() // username 예외처리
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
                    Console.WriteLine("[!] Problem with the length of the number\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else if (!(Regex.IsMatch(_userName, "^[a-zA-Z0-9]*$"))) // 영어와 숫자만 받음
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[!] Please enter only English and numbers\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else if (16 < _userName.Length) // 길이 예외처리
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[!] Character limit: 1~16\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                _isException = true;
                break;
            }
            return _userName.PadRight(16, ' ');
        }
        private int IsExist(char[] arrangementOX) // 중복되어 선택했는지
        {
            int inputNumber = 0;
            bool isExist = true;
            while (isExist)
            {
                Console.WriteLine("Please enter the number(0~8)");
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
