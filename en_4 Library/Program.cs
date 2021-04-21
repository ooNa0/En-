using System;

namespace en_4_Library
{
    // 관리자 모드로 접속하는 방법, 비밀번호 **** 입니다. (별 네개)
    // 기본 회원, 기본 책을 저장하였습니다!
    // 테스트 편함을 위해 어떤 회원은 아이디가 a, 비밀번호가 a이며, 어떤 도서 제목은 a입니다!
    // 테스트할때 참고해주시면 감사하겠습니다!
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.StartMenu();
        }
    }
}
