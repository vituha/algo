using System;

namespace Problem.Problems
{
    internal sealed class Problem9 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(1000);
        }

        private void RunInternal(int sum)
        {
            for (int a = 1; a < sum - 1; a++)
            {
                for (int b = a; b < sum - a; b++)
                {
                    int c = sum - a - b; // c is always > 0

                    if (a * a + b * b == c * c)
                    {
                        Console.WriteLine(a * b * c);
                        return;
                    }
                }
            }
        }
    }
}
