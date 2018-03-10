//가능한 모든 경우의 수를 시험하고, 그 결과를 콘솔 상에 출력하는 예제입니다.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECardCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            EmperorPlayer emperorPlayer = new EmperorPlayer();
            SlavePlayer slavePlayer = new SlavePlayer();

            int emperorWinCnt = 0;
            int slaveWinCnt = 0;
            int drawCnt = 0;

            for (int cnt = 1; ; cnt++) 
            {
                Console.Clear();

                emperorPlayer.ShuffleDeck();
                emperorPlayer.PrintCards();

                slavePlayer.ShuffleDeck();
                slavePlayer.PrintCards();

                bool? result = emperorPlayer.Play(slavePlayer);

                switch(result)
                {
                    case true:
                        Console.WriteLine("황제 측 승리!");
                        Console.WriteLine();
                        emperorWinCnt++;
                        break;
                    case false:
                        Console.WriteLine("노예 측 승리!");
                        Console.WriteLine();
                        slaveWinCnt++;
                        break;
                    case null:
                        drawCnt++;
                        break;
                }

                Console.WriteLine("황제 " + emperorWinCnt.ToString() + "회 승리, 승률 " + (emperorWinCnt / (double)cnt * 100.0).ToString() + "%");
                Console.WriteLine("노예 " + slaveWinCnt.ToString() + "회 승리, 승률 " + (slaveWinCnt / (double)cnt * 100.0).ToString() + "%");
                Console.WriteLine("무승부 " + drawCnt.ToString() + "회");

                Console.WriteLine();
                Console.WriteLine("엔터 키를 누르면 계속합니다.");

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key.Equals(ConsoleKey.Enter)) continue;
                else break;
            }
        }
    }
}
