using System;

namespace Problem.Problems
{
    internal sealed class Problem28 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(1001);
        }

        private void RunInternal(int max)
        {
            int sum = 1;
            int adder = 1;
            int round2 = 2;

            while (round2 < max)
            {
                for (int i = 0; i < 4; i++)
                {
                    adder += round2;
                    sum += adder;
                }
                round2 += 2;
            }

            Console.WriteLine(sum);
        }
    }
}
