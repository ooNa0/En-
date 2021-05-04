using System;
using System.Data;
using MySql.Data.MySqlClient;

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
