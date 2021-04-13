using en_3_Libray.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace en_3_Libray.View
{
    class AdministratorMenu
    {
        public List<BookVO> book = new List<BookVO>();
        public void UserSelectMenu(List<UserVO> userVO)
        {
            CerserControl cerserControl = new CerserControl();
            Printing print = new Printing();
            print.AdministratorMode();

            switch (cerserControl.cerserControl(0, 8))
            {
                case 0: // 도서 등록
                    editBook(book);
                    break;
                case 1: // 도서 삭제
                    removeBook(book);
                    break;
                case 2: // 도서 검색
                    print.HowToSearchBook();
                    SearchBook(cerserControl.cerserControl(0, 3), book);
                    break;
                case 3: // 전체 도서 출력
                    print.BookList(book);
                    break;
                case 4: // 회원 리스트
                    PrintUserList(userVO);
                    break;
                case 5: // 회원 검색
                    SearchUser(userVO);
                    break;
                case 6: // 회원 삭제
                    RemoveUser(userVO);
                    break;
                case 7: // 돌아가기
                    Console.Clear();
                    Console.ReadLine();
                    break;
            }
        }

        public void SearchBook(int number, List<BookVO> bookVO)
        {
            Console.Clear(); // 도서명, 출판사, 저자
            string howToSearch = Console.ReadLine();
            int count = bookVO.Count - 1;

            switch (number)
            {
                case 1: // 도서명

                    while (count >= 0)
                    {
                        if (howToSearch == bookVO[count].BookName)
                        {
                            foreach (BookVO book in bookVO)
                            {
                                Console.WriteLine("{0}", book.ToString());
                            }
                            break;
                        }
                    }
                    break;
                case 2: // 출판사
                    while (count >= 0)
                    {
                        if (howToSearch == bookVO[count].Publisher)
                        {
                            foreach (BookVO book in bookVO)
                            {
                                Console.WriteLine("{0}", book.ToString());
                            }
                            break;
                        }
                    }
                    break;
                case 3: // 저자
                    while (count >= 0)
                    {
                        if (howToSearch == bookVO[count].Author)
                        {
                            foreach (BookVO book in bookVO)
                            {
                                Console.WriteLine("{0}", book.ToString());
                            }
                            break;
                        }
                    }
                    break;
                case 4:
                    break;
            }
        }

        private void removeBook(List<BookVO> book)
        {
            Console.Clear();
            Console.WriteLine("지울 책의 제목을 입력해주세요.");

            string wantRemove = Console.ReadLine();
            int count = book.Count - 1;

            while (count >= 0)
            {
                if (wantRemove == book[count].BookName)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine("존재하는 아이디가 아닙니다.");
                    Console.ForegroundColor = ConsoleColor.White;
                    book.RemoveAt(count);
                    Console.WriteLine("회원 삭제 완료!\n아무 키나 입력해주세요..");
                    Console.ReadLine();
                    break;
                }
            }
        }

        private void editBook(List<BookVO> book)
        {
            string identity = "";
            string bookName = "";
            string publisher = "";
            string author = "";
            int quantity = 0;
            string recode = "도서 제목 :";
            string mass;
            bool isSet = false;
            Menu menu = new Menu();

            int count = book.Count - 1;

            
            //recode += identity + "\n";
            
            while (!isSet) // 도서 이름
            {
                Console.Clear();
                //string star = "";
                //Console.Write(recode);
                Console.Write("도서 제목 : ");//길이 8이상, 영어 + 숫자 + 특수문자)
                bookName = Console.ReadLine();


                if (!(Regex.IsMatch(identity, "^[a-zA-Z0-9가-힣]{1,10}$")))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("10글자 이내 한글, 영어, 숫자만 입력이가능합니다.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
                else
                {
                    isSet = false;
                }
                while (count >= 0)
                {
                    if (bookName == book[count].BookName)
                    {
                        Console.WriteLine("등록된 동일한 책제목이 존재합니다. 몇개를 추가하시겠습니까?");

                        while (true)
                        {
                            mass = Console.ReadLine();

                            if (!(Regex.IsMatch(mass, "^[0-9]$")))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("숫자만 입력해주세요.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                            }
                            else
                            {
                                break;
                            }
                        }
                        Console.WriteLine("수량 추가가 완료되었습니다.");
                        book[count].Quantity += int.Parse(mass);
                        Console.WriteLine("아무키나 입력해주세요..");
                        Console.ReadLine();
                        return;
                        //isSet = true;
                    }
                    count--;
                }
            }
            recode += "도서 제목 : " + bookName;

            while (isSet) // 출판사
            {
                Console.Clear();
                Console.Write(recode);
                Console.Write("출판사 : ");
                publisher = Console.ReadLine();

                recode += "출판사 : " + publisher + "\n";

                if (publisher.Length < 1 || publisher.Length > 17)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("글자 길이에 문제가 있습니다.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
                else
                {
                    isSet = false;
                }

            }

            while (!isSet) // 저자
            {
                Console.Clear();
                Console.Write(recode);
                Console.Write("저자 : ");//(숫자만 입력)
                author = Console.ReadLine();


                recode += "저자 : " + author + "\n";
                if (publisher.Length < 1 || publisher.Length > 17)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("글자 길이에 문제가 있습니다.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
                else
                {
                    isSet = true;
                }
            }

            while (isSet) // 수량
            {
                Console.Clear();
                Console.Write(recode);
                Console.Write("수량 : ");
                //int quantity;
                while (true)
                {
                    mass = Console.ReadLine();
                    if (!(Regex.IsMatch(mass, "^[0-9]$")))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("숫자만 입력해주세요.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }
                quantity = int.Parse(mass);
                recode += "수량 : " + quantity + "\n";
                isSet = false;
            }
            book.Add(new BookVO(bookName, publisher, author, quantity));// { Id = identity, BookName = bookName, Publisher = publisher, Author = author, Quantity = quantity});

            /*foreach (List<> userVOs in user)
            {
                Console.WriteLine("{0}", userVOs.ToString);
            }*/

            Console.WriteLine("아무키나 눌러주세요.");
            Console.ReadLine();
        }

        private void PrintUserList(List<UserVO> userVO)
        {
            string wantSearch = Console.ReadLine();
            int count = userVO.Count - 1;

            while (count >= 0)
            {
                foreach (UserVO user in userVO)
                {
                    Console.WriteLine("{0}", user.ToString());
                }
            }
        }

        private void SearchUser(List<UserVO> userVO)
        {
            Console.Clear();
            Console.WriteLine("찾을 회원의 아이디를 입력해주세요.");

            string wantSearch = Console.ReadLine();
            int count = userVO.Count - 1;

            while (count >= 0)
            {
                if (wantSearch == userVO[count].Id)
                {
                    foreach (UserVO user in userVO)
                    {
                        Console.WriteLine("{0}", user.ToString());
                    }
                    break;
                }
            }
        }

        private void RemoveUser(List<UserVO> userVO)
        {
            Console.Clear();
            Console.WriteLine("지울 회원의 아이디를 입력해주세요.");

            string wantRemove = Console.ReadLine();
            int count = userVO.Count - 1;

            while (count >= 0)
            {
                if (wantRemove == userVO[count].Id)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine("존재하는 아이디가 아닙니다.");
                    Console.ForegroundColor = ConsoleColor.White;
                    userVO.RemoveAt(count);
                    Console.WriteLine("회원 삭제 완료!\n아무 키나 입력해주세요..");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}
/*
while (isSet) // 도서 아이디
            {
                Console.Clear();
                Console.Write(recode);

                identity = Console.ReadLine();

                if (!(Regex.IsMatch(identity, "^[0-9]{1,10}$")))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("10글자 이내 숫자만 입력이가능합니다.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
                else
                {
                    isSet = false;
                }
                while (count >= 0)
                {
                    if (identity == book[count].Id)
                    {
                        Console.WriteLine("등록된 동일한 아이디가 존재합니다. 몇개를 추가하시겠습니까?");

                        while (true)
                        {
                            mass = Console.ReadLine();

                            if (!(Regex.IsMatch(mass, "^[0-9]$")))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("숫자만 입력해주세요.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();
                            }
                            else
                            {
                                break;
                            }
                        }
                        Console.WriteLine("수량 추가가 완료되었습니다.");
                        book[count].Quantity += int.Parse(mass);
                        Console.WriteLine("아무키나 입력해주세요..");
                        Console.ReadLine();
                        return;
                        //isSet = true;
                    }
                    count--;
                }
            }
*/