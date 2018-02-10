using System;

namespace Problem.Problems
{
    internal sealed class Problem14 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(1000 * 1000);
        }

        private void RunInternal(int maxStart)
        {
            int max = 0;
            int winner = 0;

            for (int i = 3; i < maxStart; i ++)
            {
                int cnt = CalcCollatzLength(i);
                if (cnt > max)
                {
                    max = cnt;
                    winner = i;
                }
            }

            Console.WriteLine(winner);
        }

        private int CalcCollatzLength(int start)
        {
            int count = 2;
            long current = start;

            while (true)
            {
                while ((current % 2) == 0)
                {
                    current /= 2;
                    count++;
                }

                if (current == 1)
                {
                    break;
                }

                current = 3 * current + 1;
                count++;
            }

            return count;
        }
    }
}
