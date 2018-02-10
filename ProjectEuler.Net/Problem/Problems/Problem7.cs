using System;
using System.Collections.Generic;

namespace Problem.Problems
{
    internal sealed class Problem7 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(10001);
        }

        private void RunInternal(int primeIndex)
        {
            var primes = new List<int>(primeIndex);

            int candidate = 1;
            while (true)
            {
                candidate += 1;
                bool isPrime = true;
                foreach (int prime in primes)
                {
                    if ((candidate % prime) == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primes.Add(candidate);
                    if (primes.Count == primeIndex)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(primes[primeIndex - 1]);
        }
    }
}
