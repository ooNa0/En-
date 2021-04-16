using en_3_Libray.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace en_3_Libray.View
{
    class UserMenu// : AdministratorMenu
    {
        public void UserSelectMenu(List<UserVO> userVO, int index, List<BookVO> book)
        {
            CerserControl cerserControl = new CerserControl();
            AdministratorMenu administrator = new AdministratorMenu();
            Printing print = new Printing();
            Ask ask = new Ask();
            bool isFinished = true;
            string borrowBook;
            int count;// = book.Count - 1;
            int search;
            while (isFinished)
            {
                search = 0;
                print.UserMenu();
                Console.WriteLine();
                //DateTime now = DateTime.Now;
                switch (cerserControl.cerserControl(0, 5))
                {
                    case 0: // 도서 대출
                        Console.Clear();
                        Console.WriteLine("무슨 책을 대출하시겠습니까?");
                        borrowBook = Console.ReadLine();
                        count = book.Count - 1;
                        while (count >= 0)
                        {
                            if (borrowBook == book[count].BookName)
                            {
                                book[count].BorrowDate = DateTime.Now.ToString("yyyyMMdd");
                                book[count].RorrowDate = DateTime.Now.AddDays(7);
                                book[count].Quantity -= 1;
                                search++;
                            }
                            count--;
                        }
                        if (search == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("찾는 것이 없습니다.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.WriteLine("대출을 완료하였습니다!");
                        }
                        Console.WriteLine("아무 키나 눌러주세요. . .");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 1: // 도서 반납
                        Console.WriteLine("죄송합니다.");
                        Console.Clear();
                        break;
                    case 2: // 전체 도서 출력
                        print.BookList(book);
                        break;
                    case 3: // 도서 검색
                        Console.Clear();
                        print.HowToSearchBook();
                        administrator.SearchBook(cerserControl.cerserControl(0, 3), book);

                        Console.Clear();
                        break;
                    case 4: // 사용자 정보
                        Console.Clear();
                        foreach(UserVO user in userVO)
                        {
                            Console.WriteLine("{0}", user.ToString());
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5: // 로그아웃
                        Console.Clear();
                        isFinished = false;
                        break;
                }
            }
        }
    }
}
