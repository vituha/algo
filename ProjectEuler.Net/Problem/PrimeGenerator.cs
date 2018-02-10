using System;
using System.Collections.Generic;

namespace Problem
{
    public sealed class PrimeGenerator
    {
        private readonly IList<long> _primes;

        public PrimeGenerator()
            : this(new List<long> {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 57, 59, 61, 67, 71, 73, 79, 83, 89, 97})
        {
        }

        public PrimeGenerator(IList<long> primes)
        {
            if (primes == null) throw new ArgumentNullException("primes");

            _primes = primes;
        }

        public bool IsPrime(long candidate)
        {
            if (candidate < 2)
            {
                return false;
            }

            long start = _primes[_primes.Count - 1];
            for (long i = start; i < MaxPrimeDivider(candidate); i++)
            {
                if (TestPrime(i))
                {
                    _primes.Add(i);
                }
            }

            return TestPrime(candidate);
        }

        private bool TestPrime(long candidate)
        {
            var maxPrimeDivider = MaxPrimeDivider(candidate);

            bool isPrime = true;
            foreach (long prime in _primes)
            {
                if (prime >= maxPrimeDivider)
                {
                    break;
                }
                if (candidate%prime == 0)
                {
                    isPrime = false;
                }
            }
            return isPrime;
        }

        public long[] GeneratePrimes(long max = 1000, long min = 2)
        {
            if (min < 2)
            {
                throw new ArgumentOutOfRangeException("min");
            }
            if (max < min)
            {
                throw new ArgumentOutOfRangeException("max");
            }

            var result = new List<long>();

            int i = 0;
            while (i < _primes.Count && _primes[i] < min)
            {
                i++;
            }
            while (i < _primes.Count && _primes[i] < max)
            {
                result.Add(_primes[i++]);
            }

            if (i == _primes.Count)
            {
                long candidate = _primes[_primes.Count - 1];
                while (++candidate < max)
                {
                    if (TestPrime(candidate))
                    {
                        _primes.Add(candidate);
                        result.Add(candidate);
                    }
                }
            }

            return result.ToArray();
        }

        private static long MaxPrimeDivider(long candidate)
        {
            return (long)Math.Ceiling(Math.Sqrt(candidate));
        }
    }
}
