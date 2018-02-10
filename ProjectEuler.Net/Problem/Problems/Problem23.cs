using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem.Problems
{
    internal sealed class Problem23 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(28123);
        }

        private void RunInternal(int max)
        {
            var dividerGenerator = new DividerGenerator();
            ICollection<int> abundants = new List<int>();

            for (int i = 2; i <= max; i++)
            {
                if (IsAbundant(dividerGenerator, i))
                {
                    abundants.Add(i);
                }
            }

            abundants = new HashSet<int>(abundants); // prepare for efficient Contains cheks.
            long sum = 0;

            checked
            {
                for (int i = 1; i <= max; i++)
                {
                    bool passed = true;
                    foreach (int abundant in abundants)
                    {
                        if (abundants.Contains(i - abundant))
                        {
                            passed = false;
                            break;
                        }
                    }
                    if (passed)
                    {
                        sum += i;
                    }
                }
            }

            Console.WriteLine(sum);
        }

        private bool IsAbundant(DividerGenerator dividerGenerator, int number)
        {
            var sumDividers = dividerGenerator.GenerateDividers(number).Sum(n => (long)n) + 1;
            return sumDividers > number;
        }
    }
}
