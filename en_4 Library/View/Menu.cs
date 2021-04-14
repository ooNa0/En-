using en_4_Library.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace en_4_Library
{
    class Menu
    {
        public List<BookVO> book = new List<BookVO>(); // BookVO 리스트
        public List<UserVO> user = new List<UserVO>(); // UserVO 리스트
        Cursor cursor = new Cursor();
        Print print = new Print();
        public void StartMenu()
        {
            Console.Title = "Library - Menu";
            //print.ShowMenu();
            cursor.controlCursor(0, 3);

        }
    }
}
