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
        //public List<BookVO> book = new List<BookVO>();
        public void UserSelectMenu(List<UserVO> userVO, List<BookVO> book)
        {
            CerserControl cerserControl = new CerserControl();
            Printing print = new Printing();
            bool isSet = true;
            while (isSet)
            {
                Console.Clear(); 
                print.AdministratorMode();

                switch (cerserControl.cerserControl(0, 7))
                {
                    case 0: // 도서 등록
                        editBook(book);
                        break;
                    case 1: // 도서 삭제
                        removeBook(book);
                        break;
                    case 2: // 도서 검색
                        Console.Clear();
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
                        isSet = false;
                        //Console.ReadLine();
                        break;
                }
            }

        }

        public void SearchBook(int number, List<BookVO> bookVO)
        {
            Console.Clear(); // 도서명, 출판사, 저자
            string howToSearch;
            int count = bookVO.Count - 1;
            int search = 0;

            switch (number)
            {
                case 0: // 도서명
                    Console.WriteLine("찾으실 도서의 제목을 입력해주세요.");
                    howToSearch = Console.ReadLine();
                    while (count >= 0)
                    {
                        if (howToSearch == bookVO[count].BookName)
                        {
                            Console.WriteLine("{0}", bookVO[count].ToString());
                            search++;
                        }
                        count--;
                    }
                    break;
                case 1: // 출판사
                    Console.WriteLine("찾으실 도서의 출판사를 입력해주세요.");
                    howToSearch = Console.ReadLine();
                    while (count >= 0)
                    {
                        if (howToSearch == bookVO[count].Publisher)
                        {
                            Console.WriteLine("{0}", bookVO[count].ToString());
                            search++;

                        }
                        count--;
                    }
                    break;
                case 2: // 저자
                    Console.WriteLine("찾으실 도서의 저자를 입력해주세요.");
                    howToSearch = Console.ReadLine();
                    while (count >= 0)
                    {
                        if (howToSearch == bookVO[count].Author)
                        {
                            Console.WriteLine("{0}", bookVO[count].ToString());
                            search++;
                        }
                        count--;
                    }
                    break;
                case 3:
                    return;
            }
            if(search == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("찾는 것이 없습니다.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("아무 키나 눌러주세요. . .");
            Console.ReadLine();
        }

        private void removeBook(List<BookVO> book)
        {
            Console.Clear();
            Console.WriteLine("지울 도서의 제목을 입력해주세요.");

            string wantRemove = Console.ReadLine();
            int count = book.Count - 1;
            int remove = 0;
            while (count >= 0)
            {
                if (wantRemove == book[count].BookName)
                {
                    remove++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine("존재하는 아이디가 아닙니다.");
                    Console.ForegroundColor = ConsoleColor.White;
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

        private void editBook(List<BookVO> book)
        {
            string bookName = "";
            string publisher = "";
            string author = "";
            int quantity = 0;
            string recode = "도서 제목 :";
            string mass = "";
            bool isSet = false;
            Menu menu = new Menu();

            int count = book.Count - 1;

            while (!isSet) // 도서 이름
            {
                Console.Clear();
                //string star = "";
                //Console.Write(recode);
                Console.Write("도서 제목 : ");//길이 8이상, 영어 + 숫자 + 특수문자)
                bookName = Console.ReadLine();
                if (bookName.Length < 1 || bookName.Length > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("입력하신 길이에 문제가 있습니다.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    continue;
                }
                if (!(Regex.IsMatch(bookName, "^[a-zA-Z0-9가-힣]*$")))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("10글자 이내 한글, 영어, 숫자만 입력이 가능합니다.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
                else
                {
                    isSet = true;
                }
            }
            while (count >= 0)
            {
                //Console.WriteLine(count);
                if (bookName == book[count].BookName)
                {
                    Console.WriteLine("등록된 동일한 책제목이 존재합니다. 몇개를 추가하시겠습니까?");

                    while (true)
                    {
                        mass = Console.ReadLine();
                        if (mass.Length < 1 || mass.Length > 10)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("입력하신 길이에 문제가 있습니다.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Console.Write("도서 제목 : " + bookName);

                            continue;
                        }
                        if (!(Regex.IsMatch(mass, "^[0-9]*$")))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("숫자만 입력해주세요.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadLine();
                            Console.Clear();
                            Console.Write("도서 제목 : " + bookName);
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

            recode += bookName + "\n" + "출판사 : ";

            while (isSet) // 출판사
            {
                Console.Clear();
                Console.Write(recode);
                publisher = Console.ReadLine();

                if (publisher.Length < 1 || publisher.Length > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("글자 길이에 문제가 있습니다.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("아무 키나 입력해주세요. . .");
                    Console.ReadLine();
                }
                else
                {
                    isSet = false;
                }
            }
            recode += publisher + "\n" + "저자 : ";

            while (!isSet) // 저자
            {
                Console.Clear();
                Console.Write(recode);
                author = Console.ReadLine();

                if (author.Length < 1 || author.Length > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("글자 길이에 문제가 있습니다.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("아무 키나 입력해주세요. . .");
                    Console.ReadLine();
                }
                else
                {
                    isSet = true;
                }
            }
            recode += author + "\n" + "수량 : ";

            while (isSet) // 수량
            {
                Console.Clear();
                Console.Write(recode);

                mass = Console.ReadLine();
                if (!(Regex.IsMatch(mass, "^[0-9]+$")))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("숫자만 입력해주세요.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
                else
                {
                    isSet = false;
                    break;
                }
            }
            quantity = int.Parse(mass);
            recode += quantity + "\n";


            book.Add(new BookVO(bookName, publisher, author, quantity));// { Id = identity, BookName = bookName, Publisher = publisher, Author = author, Quantity = quantity});

            /*foreach (List<> userVOs in user)
            {
                Console.WriteLine("{0}", userVOs.ToString);
            }*/

            //Console.WriteLine("아무키나 눌러주세요.");
            //Console.ReadLine();
        }

        private void PrintUserList(List<UserVO> userVO)
        {
            int count = userVO.Count - 1;
            Console.Clear();
            if (count < 0)
            {
                Console.WriteLine("등록된 회원 리스트가 없습니다.");
            }
            else
            {
                while (count >= 0)
                {
                    foreach (UserVO user in userVO)
                    {
                        Console.WriteLine("{0}", user.ToString());
                    }
                    count--;
                }
            }
            Console.ReadLine();
        }

        private void SearchUser(List<UserVO> userVO)
        {
            Console.Clear();
            Console.WriteLine("찾을 회원의 이름을 입력해주세요.");

            string wantSearch = Console.ReadLine();
            int count = userVO.Count - 1;
            int search = 0;

            if (count < 0)
            {
                Console.WriteLine("등록된 회원 리스트가 없습니다.");
            }
            else
            {
                while (count >= 0)
                {
                    if (wantSearch == userVO[count].Name)
                    {
                        search++;
                        foreach (UserVO user in userVO)
                        {
                            Console.WriteLine("{0}", user.ToString());
                        }
                    }
                    count--;
                }
            }
            if (userVO.Count != search)
            {
                Console.WriteLine("찾을 회원이 존재하지 않거나, 잘못입력하셨습니다.");
            }
            Console.ReadLine();
        }

        private void RemoveUser(List<UserVO> userVO)
        {
            Console.Clear();
            Console.WriteLine("지울 회원의 이름을 입력해주세요.");

            string wantRemove = Console.ReadLine();
            int count = userVO.Count - 1;
            int remove = 0;

            if (count < 0)
            {
                Console.WriteLine("등록된 회원 리스트가 없습니다.");
            }
            else
            {
                while (count >= 0)
                {
                    if (wantRemove == userVO[count].Name)
                    {
                        remove++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        //Console.WriteLine("존재하는 아이디가 아닙니다.");
                        Console.ForegroundColor = ConsoleColor.White;
                        userVO.RemoveAt(count);
                        Console.WriteLine("회원 삭제 완료!");
                        break;
                    }
                }
            }
            if (userVO.Count == remove)
            {
                Console.WriteLine("지울 책이 존재하지 않거나, 잘못입력하셨습니다.");
                Console.ReadLine();
            }
            Console.WriteLine("아무 키나 입력해주세요..");
            Console.ReadLine();
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