using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem
{
    internal sealed class DividerGenerator
    {
        private readonly ICollection<int> _primes;

        public DividerGenerator()
            : this(new List<int>())
        {
        }

        public DividerGenerator(ICollection<int> primes)
        {
            if (primes == null) throw new ArgumentNullException("primes");

            _primes = primes;
        }

        /// <summary>
        /// Generates all valid dividers of given number in increased order excluding 1 and the number itself.
        /// </summary>
        public IEnumerable<int> GenerateDividers(int number)
        {
            var primeCounts = GetFactorization(number);

            if (primeCounts.Length == 0) // prime encountered
            {
                _primes.Add(number);
                yield break;
            }

            List<int> takenCount = primeCounts.Select(p => p.Value).ToList();
            List<int> multipliers = primeCounts.Select(p => 1).ToList();

            while (true)
            {
                Decrement(takenCount, primeCounts, multipliers);

                int divider = 1;
                foreach (int multiplier in multipliers)
                {
                    divider *= multiplier;
                }

                if (divider == number)
                {
                    break;
                }

                yield return divider;
            }
        }

        /// <summary>
        /// Calculates factorization of given number, i.e. its prime dividers and their counts.
        /// </summary>
        private KeyValuePair<int, int>[] GetFactorization(int number)
        {
            var primeCounts = new List<KeyValuePair<int, int>>();

            int current = number;
            foreach (int prime in _primes)
            {
                int cnt = 0;
                while ((current%prime) == 0)
                {
                    cnt++;
                    current /= prime;
                }
                if (cnt > 0)
                {
                    primeCounts.Add(new KeyValuePair<int, int>(prime, cnt));
                }
            }
            return primeCounts.ToArray();
        }

        private void Decrement(IList<int> takenCount, IReadOnlyList<KeyValuePair<int, int>> primeCounts, IList<int> multipliers)
        {
            for (int i = 0; i < takenCount.Count; i++)
            {
                if (takenCount[i] > 0)
                {
                    takenCount[i]--;
                    multipliers[i] *= primeCounts[i].Key;
                    break;
                }

                takenCount[i] = primeCounts[i].Value;
                multipliers[i] = 1;
            }
        }
    }
}
