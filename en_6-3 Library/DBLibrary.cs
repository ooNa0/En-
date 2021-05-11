using System;
using System.Data;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
// 관리자 비밀번호 * 입니다! 별하나요
namespace en_6_Library_DB
{
    class DBLibrary
    {
        static void Main()
        {
            Menu menu = new Menu();
            menu.MainMenu();
        }
    }
}
