using System;
using System.Collections.Generic;
using System.Text;

namespace en_6_Library_DB
{
    class InputManagement
    {
        private Exception exception;
        private OutputError outputError;
        private DataAccessObject dataAccessObject;
        private bool hasEnded;
        public InputManagement(Exception exception, OutputError outputError, DataAccessObject dataAccessObject)
        {
            this.exception = exception;
            this.outputError = outputError;
            hasEnded = false;
            this.dataAccessObject = dataAccessObject;
    }

        public string GetMenuNumber(int maximumMenuNumber)
        {
            string input;

            while (!hasEnded)
            {
                Console.Write("메뉴 번호 입력 :");
                input = Console.ReadLine();
                //if (inputMenuNumber == null || exception.IsMenuNumberForm(inputMenuNumber, maximumMenuNumber))
                if (input == null || exception.IsMenuNumberForm(input, maximumMenuNumber))
                {
                    return input;
                }
                else
                {
                    InitializeInputValue(Console.CursorLeft, Console.CursorTop);
                }
            }
            return Constant.BACK;
        }

        public string SearchName()
        {
            string input;

            while (!hasEnded)
            {
                Console.Write("확인할 정보 :");
                input = Console.ReadLine();
                if (exception.SearchDataName(input))
                {
                    return input;
                }
                else
                {
                    InitializeInputValue(Console.CursorLeft, Console.CursorTop);
                }
            }
            return Constant.BACK;
        }

        public string SearchAge()
        {
            string input;

            while (!hasEnded)
            {
                Console.Write("찾으실 유저의 태어난 연도 :");
                input = Console.ReadLine();
                if (exception.SearchDataName(input))
                {
                    return input;
                }
                else
                {
                    InitializeInputValue(Console.CursorLeft, Console.CursorTop);
                }
            }
            return Constant.BACK;
        }

        public string GetIdentity(bool isCheckUserExist)
        {
            Console.WriteLine("(b누르고 ENTER : 뒤로가기)");
            string input;

            while (!hasEnded)
            {
                Console.Write("(영어, 숫자 4~10글자)아이디 입력 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.HasEnglishAndNumber(input))
                {
                    if (isCheckUserExist) { // 회원가입 => 존재하면 안됨
                        if (dataAccessObject.CorrectDataInUser(input, Constant.USER_COLUMN_ID).Tables[0].Rows.Count != 0) { Console.WriteLine("이미 존재하는 아이디 입니다."); InitializeInputValue(Console.CursorLeft, Console.CursorTop); }
                        else { return input; }
                    }
                    else // 유저 삭제, 아이디 수정, 로그인 => 존재해야 댐
                    {
                        if(dataAccessObject.CorrectDataInUser(input, Constant.USER_COLUMN_ID).Tables[0].Rows.Count == 0) { Console.WriteLine("이미 존재하는 아이디가 아닙니다."); InitializeInputValue(Console.CursorLeft, Console.CursorTop); }
                        else { return input; }
                    }
                }
                else
                {
                    InitializeInputValue(Console.CursorLeft, Console.CursorTop);
                }
            }
            return Constant.BACK;
        }

        public string GetPassword()
        {
            string input;

            while (!hasEnded)
            {
                Console.Write("(영어, 숫자 4~10글자)비밀번호 입력 :");
                input = PrintStar();
                if (input == Constant.BACK) return input;
                if (exception.HasEnglishAndNumber(input))
                {///^(?=.*[a-zA-Z])((?=.*\d)|(?=.*\W)).{6,20}$/
                    return input;
                }
                else
                {
                    InitializeInputValue(Console.CursorLeft, Console.CursorTop);
                }
            }
            return Constant.BACK;
        }

        public string PrintStar()
        {
            ConsoleKeyInfo keyInput;
            string input = "";
            while (true)
            {
                keyInput = Console.ReadKey(Constant.IS_PASSWORD);
                switch (keyInput.Key)
                {
                    case ConsoleKey.Enter:
                        Console.WriteLine();
                        return input;
                    case ConsoleKey.Backspace:
                        if (input.Length > 0)
                        {
                            input = input.Substring(0, (input.Length - 1));
                            Console.Write("\b \b");
                        }
                        break;
                    default:
                        input += keyInput.KeyChar;
                        Console.Write("*");
                        break;
                }
            }
        }

        public string GetName()
        {
            string input;

            while (!hasEnded)
            {
                Console.Write("(공백없이 한글 2~4글자 입력)이름 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.HasKorean(input))
                {
                    return input;
                }
                else
                {
                    InitializeInputValue(Console.CursorLeft, Console.CursorTop);
                }
            }
            return Constant.BACK;
        }

        public string GetBirthYear()
        {
            string input;

            while (!hasEnded)
            {
                Console.Write("(연도만 입력, 예:2001,1998)태어난 연도 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.IsCorrectYear(input))
                {
                    return input;
                }
                else
                {
                    InitializeInputValue(Console.CursorLeft, Console.CursorTop);
                }
            }
            return Constant.BACK;
        }

        public string GetPhoneNumber()
        {
            string input;

            while (!hasEnded)
            {
                Console.Write("('-'없이 번호만)전화번호 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.IsCorrectPhoneNumber(input))
                {
                    return input;
                }
                else
                {
                    InitializeInputValue(Console.CursorLeft, Console.CursorTop);
                }
            }
            return Constant.BACK;
        }

        public string GetAddress()
        {
            string input;

            while (!hasEnded)
            {
                Console.Write("(충청남도 천안시 서북구 한들2로 88)주소 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.IsCorrectAddress(input))
                {
                    return input;
                }
                else
                {
                    InitializeInputValue(Console.CursorLeft, Console.CursorTop);
                }
            }
            return Constant.BACK;
        }

        public string GetBookNO()
        {
            Console.WriteLine("(b누르고 ENTER : 뒤로가기)");
            string input;

            while (!hasEnded)
            {
                Console.Write("책의 NO을 입력해주세요:");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.IsCorrectBookIDForm(input))
                {
                    return input;
                }
                else
                {
                    InitializeInputValue(Console.CursorLeft, Console.CursorTop);
                }
            }
            return Constant.BACK;
        }


        public string GetBookTitle()
        {
            Console.WriteLine("(b누르고 ENTER : 뒤로가기)");
            string input;

            while (!hasEnded)
            {
                Console.Write("(15글자 이내) 도서 제목 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input; // constant 변수 삭제
                if (exception.HasEnglishAndNumberAndKorean(input, Constant.MAXIMUM_LENGTH_BOOKTITLE))
                {
                    return input;
                }
                else
                {
                    InitializeInputValue(Console.CursorLeft, Console.CursorTop);
                }
            }
            return Constant.BACK;
        }

        public string GetBookAuthor()
        {
            string input;

            while (!hasEnded)
            {
                Console.Write("(10글자 이내) 도서 저자 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.HasEnglishAndNumberAndKorean(input, Constant.MAXIMUM_LENGTH_BOOKAUTHOR))
                {
                    return input;
                }
                else
                {
                    InitializeInputValue(Console.CursorLeft, Console.CursorTop);
                }
            }
            return Constant.BACK;
        }

        public string GetBookPublisher()
        {
            string input;

            while (!hasEnded)
            {
                Console.Write("(15글자 이내) 도서 출판사 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.HasEnglishAndNumberAndKorean(input, Constant.MAXIMUM_LENGTH_BOOKPUBLISHER))
                {
                    return input;
                }
                else
                {
                    InitializeInputValue(Console.CursorLeft, Console.CursorTop);
                }
            }
            return Constant.BACK;
        }

        public string GetBookNumber()
        {
            string input;

            while (!hasEnded)
            {
                Console.Write("(숫자만 입력) 도서 권수 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.IsCorrectBookNumber(input))
                {
                    return input;
                }
                else
                {
                    InitializeInputValue(Console.CursorLeft, Console.CursorTop);
                }
            }
            return Constant.BACK;
        }

        public string GetBookPrice()
        {
            string input;

            while (!hasEnded)
            {
                Console.Write("(숫자만 입력) 도서 가격 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.IsCorrectBookPrice(input))
                {
                    return input;
                }
                else
                {
                    InitializeInputValue(Console.CursorLeft, Console.CursorTop);
                }
            }
            return Constant.BACK;
        }

        public string GetNaverBookDisplay()
        {
            string input;

            while (!hasEnded)
            {
                Console.Write("검색할 도서 권 수 :");
                input = Console.ReadLine();
                if (input == Constant.BACK) return input;
                if (exception.IsCorrectBookPrice(input))
                {
                    return input;
                }
                else
                {
                    InitializeInputValue(Console.CursorLeft, Console.CursorTop);
                }
            }
            return Constant.BACK;
        }

        public void InitializeInputValue(int horizontalCursorPosition, int verticalCursorPosition) // 비밀번호 로그인시만 public 필요
        {
            //Console.WriteLine("ENTER을 눌러주세요. ");
            Console.ReadLine();
            Console.SetCursorPosition(horizontalCursorPosition, verticalCursorPosition - 2);
            Console.Write("                                                                        ");
            //Console.WriteLine("                                                                        ");
            Console.SetCursorPosition(horizontalCursorPosition, verticalCursorPosition-1);
            Console.WriteLine("                                                                        ");
            Console.WriteLine("                                                                        ");
            Console.WriteLine("                                                                        ");
            Console.SetCursorPosition(horizontalCursorPosition, verticalCursorPosition-2);
        }
    }
}