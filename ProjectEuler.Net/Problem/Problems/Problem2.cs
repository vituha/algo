using System;

namespace Problem.Problems
{
    internal sealed class Problem2 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(4000000);
        }

        private void RunInternal(int max)
        {
            int sum = 0;

            int prev = 1;
            int current = 2;
            while (current <= max)
            {
                if (current % 2 == 0)
                {
                    sum += current;
                }
                int pprev = prev;
                prev = current;
                current = prev + pprev;
            }

            Console.WriteLine(sum);
        }
    }
}
