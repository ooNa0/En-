using System;
using System.Collections.Generic;
using System.Text;

namespace en_6_Library_DB
{
    class InputManagement
    {
        private Exception exception;
        private OutputError outputError;
        public InputManagement(Exception exception, OutputError outputError)
        {
            this.exception = exception;
            this.outputError = outputError;
        }

        public string GetMenuNumber(int maximumMenuNumber)
        {
            bool hasEnded = false;
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            string inputMenuNumber = "b";

            while (!hasEnded)
            {
                Console.Write("메뉴 번호 입력 :");
                inputMenuNumber = Console.ReadLine();
                if (exception.IsMenuNumberForm(inputMenuNumber, maximumMenuNumber))
                {
                    hasEnded = true;
                }
                else
                {
                    InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                }
            }
            return inputMenuNumber;
        }

        public string SearchName()
        {
            bool hasEnded = false;
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            string input = Constant.BACK;
            while (!hasEnded)
            {
                Console.Write("확인할 정보 :");
                input = Console.ReadLine();
                if (exception.SearchDataName(input))
                {
                    hasEnded = true;
                }
                else
                {
                    InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                }
            }
            return input;
        }

        public string SearchAge()
        {
            bool hasEnded = false;
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            string input = Constant.BACK;
            while (!hasEnded)
            {
                Console.Write("찾으실 유저의 태어난 연도 :");
                input = Console.ReadLine();
                if (exception.SearchDataName(input))
                {
                    hasEnded = true;
                }
                else
                {
                    InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                }
            }
            return input;
        }

        public string GetIdentity()
        {
            Console.WriteLine("(b누르고 ENTER : 뒤로가기)");
            bool hasEnded = false;
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            string inputIdentity = Constant.BACK;
            while (!hasEnded)
            {
                Console.Write("(영어, 숫자 4~10글자)아이디 입력 :");
                inputIdentity = Console.ReadLine();
                if (inputIdentity == Constant.BACK) return inputIdentity;
                if (exception.HasEnglishAndNumber(inputIdentity))
                {
                    hasEnded = true;
                }
                else
                {
                    InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                }
            }
            return inputIdentity;
        }

        public string GetPassword()
        {
            bool hasEnded = false;
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            string inputPassword = Constant.BACK;
            while (!hasEnded)
            {
                Console.Write("(영어, 숫자 4~10글자)비밀번호 입력 :");
                inputPassword = Console.ReadLine();
                if (inputPassword == Constant.BACK) return inputPassword;
                if (exception.HasEnglishAndNumber(inputPassword))
                {
                    hasEnded = true;
                }
                else
                {
                    InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                }
            }
            return inputPassword;
        }

        public string GetName()
        {
            bool hasEnded = false;
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            string input = Constant.BACK;
            while (!hasEnded)
            {
                Console.Write("(공백없이 한글 2~4글자 입력)이름 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.HasKorean(input))
                {
                    hasEnded = true;
                }
                else
                {
                    InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                }
            }
            return input;
        }

        public string GetBirthYear()
        {
            bool hasEnded = false;
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            string input = Constant.BACK;
            while (!hasEnded)
            {
                Console.Write("(연도만 입력, 예:2001,1998)태어난 연도 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.IsCorrectYear(input))
                {
                    hasEnded = true;
                }
                else
                {
                    InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                }
            }
            return input;
        }

        public string GetPhoneNumber()
        {
            bool hasEnded = false;
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            string input = Constant.BACK;
            while (!hasEnded)
            {
                Console.Write("('-'없이 번호만)전화번호 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.IsCorrectPhoneNumber(input))
                {
                    hasEnded = true;
                }
                else
                {
                    InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                }
            }
            return input;
        }

        public string GetAddress()
        {
            bool hasEnded = false;
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            string input = Constant.BACK;
            while (!hasEnded)
            {
                Console.Write("(우편번호 + 도로명 주소)주소 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.IsCorrectAddress(input))
                {
                    hasEnded = true;
                }
                else
                {
                    InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                }
            }
            return input;
        }

        public string GetBookNO()
        {
            bool hasEnded = false;
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            string inputIdentity = Constant.BACK;
            while (!hasEnded)
            {
                Console.Write("책의 NO을 입력해주세요:");
                inputIdentity = Console.ReadLine();
                if (inputIdentity == Constant.BACK) return inputIdentity;
                if (exception.IsCorrectBookIDForm(inputIdentity))
                {
                    hasEnded = true;
                }
                else
                {
                    InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                }
            }
            return inputIdentity;
        }


        public string GetBookTitle()
        {
            bool hasEnded = false;
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            string input = Constant.BACK;
            while (!hasEnded)
            {
                Console.Write("(15글자 이내) 도서 제목 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input; // constant 변수 삭제
                if (exception.HasEnglishAndNumberAndKorean(input, Constant.MAXIMUM_LENGTH_BOOKTITLE))
                {
                    hasEnded = true;
                }
                else
                {
                    InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                }
            }
            return input;
        }

        public string GetBookAuthor()
        {
            bool hasEnded = false;
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            string input = Constant.BACK;
            while (!hasEnded)
            {
                Console.Write("(10글자 이내) 도서 저자 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.HasEnglishAndNumberAndKorean(input, Constant.MAXIMUM_LENGTH_BOOKAUTHOR))
                {
                    hasEnded = true;
                }
                else
                {
                    InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                }
            }
            return input;
        }

        public string GetBookPublisher()
        {
            bool hasEnded = false;
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            string input = Constant.BACK;
            while (!hasEnded)
            {
                Console.Write("(15글자 이내) 도서 출판사 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.HasEnglishAndNumberAndKorean(input, Constant.MAXIMUM_LENGTH_BOOKPUBLISHER))
                {
                    hasEnded = true;
                }
                else
                {
                    InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                }
            }
            return input;
        }

        public string GetBookNumber()
        {
            bool hasEnded = false;
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            string input = Constant.BACK;
            while (!hasEnded)
            {
                Console.Write("(숫자만 입력) 도서 권수 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.IsCorrectBookNumber(input))
                {
                    hasEnded = true;
                }
                else
                {
                    InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                }
            }
            return input;
        }

        public string GetBookPrice()
        {
            bool hasEnded = false;
            int horizontalCursorPosition = Console.CursorLeft;
            int verticalCursorPosition = Console.CursorTop;
            string input = Constant.BACK;
            while (!hasEnded)
            {
                Console.Write("(숫자만 입력) 도서 가격 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.IsCorrectBookPrice(input))
                {
                    hasEnded = true;
                }
                else
                {
                    InitializeInputValue(horizontalCursorPosition, verticalCursorPosition);
                }
            }
            return input;
        }

        public void InitializeInputValue(int horizontalCursorPosition, int verticalCursorPosition) // 비밀번호 로그인시만 public 필요
        {
            Console.WriteLine("ENTER을 눌러주세요. ");
            Console.ReadLine();
            Console.SetCursorPosition(horizontalCursorPosition, verticalCursorPosition);
            Console.WriteLine("                                                                        ");
            Console.WriteLine("                                                                        ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("                                                         ");
            Console.SetCursorPosition(horizontalCursorPosition, verticalCursorPosition);
        }
    }
}

/*
 * public string KeyChar(bool isPassword)
        {
            string input = "";
            while (Constant.RECEIVE_KEY_INPUT)
            {
                keyInput = Console.ReadKey(isPassword);
                switch (keyInput.Key)
                {
                    case ConsoleKey.Enter:
                        return input;
                    case ConsoleKey.Backspace:
                        if(input.Length > 0)
                        {
                            if (isPassword)
                            {
                                input = input.Substring(0, (input.Length - 1));
                                Console.Write("\b \b");
                            }
                            else
                            {
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                                Console.Write(" ");
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                input = input.Substring(0, (input.Length - 1));
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        return "ESC";
                    default:
                        input += keyInput.KeyChar;
                        if (isPassword)
                        {
                            Console.Write("*");
                        }
                        break;
                }
            }
        }
*/