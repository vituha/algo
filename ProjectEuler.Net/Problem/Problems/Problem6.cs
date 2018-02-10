using System;

namespace Problem.Problems
{
    internal sealed class Problem6 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(100);
        }

        private void RunInternal(int max)
        {
            int sum = 0;

            for (int i = 1; i <= max; i++)
            {
                sum += i * i * (i - 1);
            }

            Console.WriteLine(sum);
        }
    }
}
