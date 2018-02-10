using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem.Problems
{
    internal sealed class Problem1 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(10, new[] { 3, 5 });
            RunInternal(1000, new[] { 3, 5 });
        }

        private void RunInternal(int maxValue, int[] multipliers)
        {
            Console.Write("Sum of all multipliers of 3 and 5 that are below " + maxValue + " is ");

            // Track previous multiplier to skip multiples that we already added.
            var processedMultipliers = new List<int>(multipliers.Length - 1);

            int sum = 0;
            foreach (int multiplier in multipliers)
            {
                // stores elements of sequence: multiplier, multiplier * 2, multiplier * 3, etc
                int multiple = multiplier;
                // add all multiples of multiplier that have not already been added with previeos multipliers
                while (multiple < maxValue)
                {
                    sum += multiple;
                    do
                    {
                        multiple += multiplier;
                    } while (multiple < maxValue && processedMultipliers.Any(pm => (multiple % pm) == 0));
                }
                // store processed multiplier
                processedMultipliers.Add(multiplier);
            }

            Console.WriteLine(sum);
        }
    }
}
