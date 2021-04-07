using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;

namespace en_2_TicTacToc
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "TicTacToe";
            Console.SetWindowSize(50, 35);

            // Creates and initializes a new ArrayList.
            //ArrayList _userScore = new ArrayList();

            TicTacToe ticTacToe = new TicTacToe(); // 틱택토 객체 실행
            ticTacToe.StartGame(); // 틱택토 내 메소드 실행
        }
    }
}
