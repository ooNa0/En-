using en_3_Libray.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace en_3_Libray.View
{
    class UserMenu
    {
        public void UserSelectMenu(List<UserVO> userVO, List<BookVO> bookVO)
        {
            CerserControl cerserControl = new CerserControl();
            AdministratorMenu administrator = new AdministratorMenu();
            Printing print = new Printing();
            //UserVO userVO = new UserVO();
            Ask ask = new Ask();
            bool isFinished = true;
           
            while (isFinished)
            {
                print.UserMenu();
                Console.WriteLine();
                switch (cerserControl.cerserControl(0, 6))
                {
                    case 0: // 도서 대출

                        break;
                    case 1: // 도서 반납
                        if()
                        break;
                    case 2: // 전체 도서 출력
                        print.BookList(bookVO);
                        break;
                    case 3: // 도서 검색
                        print.HowToSearchBook();
                        administrator.SearchBook(cerserControl.cerserControl(0, 3), bookVO);
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
