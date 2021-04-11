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
            Console.WriteLine("▷ 종료하기");
        }

        public void AdministratorMode()
        {
            Console.WriteLine("▷ 도서 등록");
            Console.WriteLine("▷ 도서 정보 수정");
            Console.WriteLine("▷ 도서 삭제");
            Console.WriteLine("▷ 도서 검색");
            Console.WriteLine("▷ 전체 도서 출력");
            Console.WriteLine("▷ 돌아가기");
        }
    }
}
