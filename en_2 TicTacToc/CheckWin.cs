using System;
using System.Collections.Generic;
using System.Text;

namespace en_2_TicTacToc
{
    class CheckWin
    {
        public char Win(char[] arrangementOX)
        {
            // 가로 빙고일 경우
            for (int i = 0; i < 3; i++)
            {
                if (arrangementOX[i * 3] == arrangementOX[i * 3 + 1] && arrangementOX[i * 3 + 1] == arrangementOX[i * 3 + 2])
                {
                    return arrangementOX[i * 3];
                }
            }
            // 세로 빙고일 경우
            for (int i = 0; i < 3; i++)
            {
                if (arrangementOX[i] == arrangementOX[i + 3] && arrangementOX[i + 3] == arrangementOX[i + 6])
                {
                    return arrangementOX[i];
                }
            }
            // 대각선 빙고일 경우
            if (arrangementOX[0] == arrangementOX[4] && arrangementOX[4] == arrangementOX[8])
            {
                return arrangementOX[0];
            }
            if (arrangementOX[2] == arrangementOX[4] && arrangementOX[4] == arrangementOX[6])
            {
                return arrangementOX[2];
            }
            return 'N';
        }
    }
}
