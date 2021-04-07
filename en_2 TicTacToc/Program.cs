using System;

namespace en_2_TicTacToc
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "TicTacToe";
            //Console.SetWindowSize(95, 30);

            // Creates and initializes a new ArrayList.
            //ArrayList _userScore = new ArrayList();

            TicTacToe ticTacToe = new TicTacToe(); // 틱택토 객체 실행
            ticTacToe.StartGame(); // 틱택토 내 메소드 실행
        }
    }
}
