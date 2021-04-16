using en_4_Library.View;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace en_4_Library
{
    class Book
    {
        public void Search(Cursor cursor, List<BookVO> bookList, Print print)
        {
            Console.Clear(); print.Library();
            string howToSearch;
            int count = bookList.Count - 1;
            int search = 0;

            switch ((cursor.controlCursor(0, 3, Constant.HOW_TO_SEARCH_BOOK)-Constant.Y_POSITION)/2)
            {
                case Constant.ESC:
                    return;
                case Constant.SEARCH_BOOK_NAME:
                    Console.Clear(); print.Library();
                    Console.WriteLine("찾으실 도서의 제목을 입력해주세요.");
                    howToSearch = Console.ReadLine();
                    while (count >= 0)
                    {
                        if (bookList[count].BookName.Contains(howToSearch))
                        {
                            Console.WriteLine("{0}\n", bookList[count].ToString());
                            search++;
                        }
                        count--;
                    }
                    if(search == 0)
                    {
                        Console.WriteLine("찾고자 하는 책이 없습니다!");
                    }
                    Console.ReadLine();
                    break;
                case Constant.SEARCH_BOOK_PUBLISHER:
                    Console.Clear(); print.Library();
                    Console.WriteLine("찾으실 도서의 출판사를 입력해주세요.");
                    howToSearch = Console.ReadLine();
                    while (count >= 0)
                    {
                        if (bookList[count].Publisher.Contains(howToSearch))
                        {
                            Console.WriteLine("{0}\n", bookList[count].ToString());
                            search++;

                        }
                        count--;
                    }
                    if (search == 0)
                    {
                        Console.WriteLine("찾고자 하는 책이 없습니다!");
                    }
                    Console.ReadLine();
                    break;
                case Constant.SEARCH_BOOK_AUTHOR:
                    Console.Clear(); print.Library();
                    Console.WriteLine("찾으실 도서의 저자를 입력해주세요.");
                    howToSearch = Console.ReadLine();
                    while (count >= 0)
                    {
                        if (bookList[count].Author.Contains(howToSearch))
                        {
                            Console.WriteLine("{0}", bookList[count].ToString());
                            search++;
                        }
                        count--;
                    }
                    if (search == 0)
                    {
                        Console.WriteLine("찾고자 하는 책이 없습니다!");
                    }
                    Console.ReadLine();
                    break;
                default:
                    return;
            }
        }
        
        public void Add(List<BookVO> book, Print print, Input input)
        {
            string bookName = "";
            string publisher = "";
            string author = "";
            int quantity = 0;
            string recode = "도서 제목 :";
            string mass = "";
            bool isSet = false;
            Menu menu = new Menu();
            Check check = new Check();

            int count = book.Count - 1;

            while (!isSet) // 도서 이름
            {
                Console.Clear();
                print.Library();
                Console.Write("도서 제목 : ");
                bookName = input.KeyChar(Constant.IS_NOT_PASSWORD);
                if(bookName == "ESC")
                {
                    return;
                }
                if (!check.Length(bookName, Constant.BOOKNAME_MIN_LENGTH, Constant.BOOKNAME_MAX_LENGTH, print))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("입력하신 길이에 문제가 있습니다.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    continue;
                }
                if ((Regex.IsMatch(bookName, "^[a-zA-Z0-9가-힣]*$")))
                {
                    isSet = true;
                }
            }
            while (count >= 0)
            {
                if (bookName == book[count].BookName)
                {
                    Console.WriteLine("등록된 동일한 책제목이 존재합니다.");
                    while (Constant.SAME_BOOK_EXIST)
                    {
                        Console.WriteLine("몇개를 추가하시겠습니까?");

                        mass = Console.ReadLine();
                        if (!check.Length(mass, Constant.BOOKNAME_MIN_LENGTH, Constant.BOOKNAME_MAX_LENGTH, print))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("입력하신 길이에 문제가 있습니다.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            continue;
                        }
                        if (!check.Number(mass, print))
                        {
                            Console.Clear(); print.Library();
                            Console.Write("도서 제목 : " + bookName);
                            continue;
                        }
                        break;
                    }
                    Console.WriteLine("수량 추가가 완료되었습니다.");
                    book[count].Quantity += int.Parse(mass);
                    Console.WriteLine("아무키나 입력해주세요..");
                    Console.ReadLine();
                    return;
                }
                count--;
            }
            recode += bookName + "\n" + "출판사 : ";

            while (isSet) // 출판사
            {
                Console.Clear(); print.Library();
                Console.Write(recode);
                publisher = input.KeyChar(Constant.IS_NOT_PASSWORD);
                if (publisher == "ESC")
                {
                    return;
                }
                if (!check.Length(publisher, Constant.BOOKNAME_MIN_LENGTH, Constant.BOOKNAME_MAX_LENGTH, print))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("입력하신 길이에 문제가 있습니다.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    continue;
                }
                isSet = false;
            }
            recode += publisher + "\n" + "저자 : ";

            while (!isSet) // 저자
            {
                Console.Clear(); print.Library();
                Console.Write(recode);
                author = input.KeyChar(Constant.IS_NOT_PASSWORD);
                if (author == "ESC")
                {
                    return;
                }
                if (!check.Length(author, Constant.BOOKNAME_MIN_LENGTH, Constant.BOOKNAME_MAX_LENGTH, print))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("입력하신 길이에 문제가 있습니다.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    continue;
                }
                isSet = true;
            }
            recode += author + "\n" + "수량 : ";

            while (isSet) // 수량
            {
                Console.Clear(); print.Library();
                Console.Write(recode);

                mass = Console.ReadLine();
                if (!(Regex.IsMatch(mass, "^[0-9]+$")))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("숫자만 입력해주세요.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    continue;
                }
                isSet = false;
            }
            quantity = int.Parse(mass);
            recode += quantity + "\n";

            book.Add(new BookVO(bookName, publisher, author, quantity));
        }

        public void Remove(List<BookVO> book, Print print)
        {
            Console.Clear(); print.Library();
            print.ShowBookList(book, print);

            Console.WriteLine("\n\n지울 도서의 제목을 입력해주세요.");

            string wantRemove = Console.ReadLine();
            
            int count = book.Count - 1;
            int remove = 0;
            while (count >= 0)
            {
                if (wantRemove == book[count].BookName)
                {
                    remove++;
                    book.RemoveAt(count);
                    Console.WriteLine("도서 삭제 완료!\n아무 키나 입력해주세요..");
                    Console.ReadLine();
                    break;
                }
                count--;
            }
            if (remove < 1)
            {
                Console.WriteLine("지울 책이 존재하지 않거나, 잘못입력하셨습니다.");
                Console.ReadLine();
            }
        }
    }
}
