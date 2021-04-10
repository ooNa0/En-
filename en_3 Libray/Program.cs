using en_3_Libray.View;
using System;

namespace en_3_Libray
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.MainMenu();

            Console.Title = "Library";
            //Console.SetWindowSize(50, 37);
        }
    }
}
