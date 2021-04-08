using System;
using System.Collections.Generic;
using System.Text;

namespace en_2_TicTacToc
{
    class ShowTile
    {
        public void Tile(char[] arrangementOX, int inputNumber)
        {
            Console.Write("\n            ㅁ      ㅁ      ㅁ      ㅁ\n\n");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("            ");
                for (int j = 0; j < 3; j++)
                {
                    if (inputNumber == i * 3 + j)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("    {0}    ", arrangementOX[i * 3 + j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("    {0}    ", arrangementOX[i * 3 + j]);
                    }
                }
                Console.WriteLine("\n\n            ㅁ      ㅁ      ㅁ      ㅁ\n           ");
            }
        }
    }
}
 // 중간 ,, 가운데!!로 이벤트들 많이 사용 
  // 5번에서 바로 끝나는게 아쉬움 종료할거니?
  // 깃,, 메시지가 별루다

    // 클래스 생성 -> 생성자 표시 매직넘버?????
    // 메소드 사이의 간격 기능별 구분 개행 필요!
    // switch case  // 매직 넘버------ + 주석 너무 없다
    // 메뉴 보여주는 거를 static X 매직넘버 ㄱㄴ--
    // 바로 X 변수하나 써주기 조건  -- while(true) 에서
    // 파라미터 변수는 카멜 표기법