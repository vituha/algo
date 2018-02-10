using System;

namespace Problem.Problems
{
    internal sealed class Problem15 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(20);
        }

        private void RunInternal(int n)
        {
            long f = 1;

            checked
            {
                for (int i = 0; i < n; i++)
                {
                    f = f * (i + i + 1)*(i + i + 2)/(i + 1)/(i + 1);
                }
            }

            Console.WriteLine(f);
        }
    }
}
