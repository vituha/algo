using System;

namespace Problem.Problems
{
    internal sealed class Problem3 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(600851475143);
        }

        private void RunInternal(long num)
        {
            int i = 2;

            while (i < Math.Sqrt(num))
            {
                while ((num % i) == 0)
                {
                    num /= i;
                }
                i++;
            }

            Console.WriteLine(num);
        }
    }
}
