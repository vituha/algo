using System;
using System.Collections.Generic;

namespace Problem.Problems
{
    internal sealed class Problem10 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(2 * 1000 * 1000);
        }

        private void RunInternal(int max)
        {
            var primes = new List<int>() {2};
            int candidate = 1;
            long sum = 2;

            while (candidate < max)
            {
                candidate += 2;

                bool isPrime = true;
                int sqrtc = (int)Math.Ceiling(Math.Sqrt(candidate));
                foreach (int prime in primes)
                {
                    if (prime >= sqrtc)
                    {
                        break;
                    }
                    if ((candidate % prime) == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    sum += candidate;
                    primes.Add(candidate);
                }
            }

            Console.WriteLine(sum);
        }
    }
}
