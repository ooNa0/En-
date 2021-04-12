using System;
using System.Collections.Generic;
using System.Text;

namespace en_3_Libray.View
{
    class Printing
    {
        public void ShowMenu()
        {
            Console.WriteLine("▷ 로그인");
            Console.WriteLine("▷ 회원가입");
            Console.WriteLine("▷ 관리자 모드");
            Console.WriteLine("▷ 종료");
        }

        public void UserMenu()
        {
            Console.WriteLine("▷ 도서 대출");
            Console.WriteLine("▷ 도서 반납");
            Console.WriteLine("▷ 전체 도서 출력");
            Console.WriteLine("▷ 도서 검색");
            Console.WriteLine("▷ 나의 정보");
            Console.WriteLine("▷ 로그아웃");
        }

        public void AdministratorMode()
        {
            Console.WriteLine("▷ 도서 등록");
            Console.WriteLine("▷ 도서 삭제");
            Console.WriteLine("▷ 도서 검색");
            Console.WriteLine("▷ 전체 도서 출력");
            Console.WriteLine("▷ 회원 리스트");
            Console.WriteLine("▷ 회원 검색");
            Console.WriteLine("▷ 회원 삭제");
            Console.WriteLine("▷ 돌아가기");
        }

        public void HowToSearchBook()
        {
            Console.WriteLine("▷ 도서명");
            Console.WriteLine("▷ 출판사");
            Console.WriteLine("▷ 저자");
            Console.WriteLine("▷ 돌아가기");
        }
        public void BookList(List<BookVO> bookVO)
        {
            string wantSearch = Console.ReadLine();
            int count = bookVO.Count - 1;
            while (count >= 0)
            {
                if (wantSearch == bookVO[count].Id)
                {
                    foreach (BookVO book in bookVO)
                    {
                        Console.WriteLine("{0}", book.ToString());
                    }
                    break;
                }
            }
        }
    }
}
