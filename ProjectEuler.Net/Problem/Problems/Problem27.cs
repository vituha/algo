using System;

namespace Problem.Problems
{
    internal sealed class Problem27 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(1000);
        }

        private void RunInternal(int max)
        {
            var primes = new PrimeGenerator();
            long maxA = 0, maxB = 0, maxPrimeCount = 0;

            foreach(long b in primes.GeneratePrimes(max))
            {
                for (long a = 0; a < max; a++)
                {
                    TestPrimeCount(primes, a, b, ref maxA, ref maxB, ref maxPrimeCount);
                    TestPrimeCount(primes, -a, b, ref maxA, ref maxB, ref maxPrimeCount);
                    TestPrimeCount(primes, a, -b, ref maxA, ref maxB, ref maxPrimeCount);
                    TestPrimeCount(primes, -a, -b, ref maxA, ref maxB, ref maxPrimeCount);
                }
            }

            Console.WriteLine(maxA * maxB);
        }

        private void TestPrimeCount(PrimeGenerator primes, long a, long b, ref long maxA, ref long maxB, ref long maxPrimeCount)
        {
            int primeCount = CalcPrimeCount(primes, a, b);
            if (primeCount > maxPrimeCount)
            {
                maxPrimeCount = primeCount;
                maxA = a;
                maxB = b;
                Console.WriteLine("New pair found. A={0}, B={1}, SequenceLength={2}.", maxA, maxB, maxPrimeCount);
            }
        }

        private int CalcPrimeCount(PrimeGenerator primes, long a, long b)
        {
            int i = 0;
            while (true)
            {
                long candidate = i * (i + a) + b;

                if (!primes.IsPrime(candidate))
                {
                    return i;
                }

                i++;
            }
        }
    }
}
