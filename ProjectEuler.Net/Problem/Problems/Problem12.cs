using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem.Problems
{
    internal sealed class Problem12 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(500);
        }

        /// <summary>
        /// We consder 1 + 2 + 3 + ... + n = n * (n + 1) / 2
        /// So to count divisors of Xn we have to count all divisors (D) of n and n + 1 except one 2.
        /// Then total number of divisors of Xn would be Product(Occurances(D[i]) + (D[i] == 2 ? 0 : 1))
        /// </summary>
        private void RunInternal(int divisorCount)
        {
            long candidate = 2;

            var primes = new List<long>();

            var factors = new Dictionary<long, int>();

            int maxDivisors = 1;

            while (true)
            {
                Dictionary<long, int> prevFactors = factors;

                factors = CalculateFactors(candidate, primes);
                int divisors = CountDivisors(factors, prevFactors);

                if (maxDivisors < divisors)
                {
                    maxDivisors = divisors;
                    Console.WriteLine("New maxDivisors: " + maxDivisors);
                }

                if (divisorCount < divisors)
                {
                    break;
                }

                candidate++;
            }

            Console.WriteLine(candidate * (candidate - 1) / 2);
        }

        private Dictionary<long, int> CalculateFactors(long candidate, List<long> primes)
        {
            var factors = new Dictionary<long, int>();

            long current = candidate;
            foreach (long prime in primes)
            {
                int count = 0;
                while (current > 1 && (current % prime) == 0)
                {
                    current /= prime;
                    count++;
                }
                if (count > 0)
                {
                    factors[prime] = count;
                }
            }

            if (factors.Count == 0)
            {
                primes.Add(candidate);
                factors[candidate] = 1;
            }

            return factors;
        }

        private int CountDivisors(Dictionary<long, int> factors, Dictionary<long, int> prevFactors)
        {
            int cnt = 1;

            foreach (long prime in factors.Keys.Union(prevFactors.Keys))
            {
                int total = 0;
                int primeCnt;
                if (factors.TryGetValue(prime, out primeCnt))
                {
                    total += primeCnt;
                }
                if (prevFactors.TryGetValue(prime, out primeCnt))
                {
                    total += primeCnt;
                }

                if (prime != 2)
                {
                    total++; // We have to exclude one 2.
                }

                cnt *= total;
            }

            return cnt;
        }
    }
}
