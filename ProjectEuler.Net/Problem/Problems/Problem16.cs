using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem.Problems
{
    internal sealed class Problem16 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(1000);
        }

        private void RunInternal(int pow)
        {
            var digits = new List<int> { 1 };

            for (int i = 0; i < pow; i++)
            {
                Sum(digits);
            }

            Console.WriteLine(digits.Sum());
        }

        private void Sum(IList<int> digits)
        {
            int remainder = 0;

            for (int i = 0; i < digits.Count; i++)
            {
                remainder += digits[i] * 2;
                digits[i] = remainder % 10;
                remainder /= 10;
            }

            while (remainder > 0)
            {
                digits.Add(remainder % 10);
                remainder /= 10;
            }
        }
    }
}
