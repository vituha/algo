using System;
using System.Collections.Generic;

namespace Problem.Problems
{
    /*
     
n! means n × (n − 1) × ... × 3 × 2 × 1

For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

Find the sum of the digits in the number 100!
     
     */
    internal sealed class Problem20 : ProblemBase
    {
        public override void Run()
        {
            int sum = RunInternal(100);
            Console.WriteLine(sum);
        }

        private int RunInternal(int n)
        {
            var result = new List<int> { 1 };

            checked
            {
                for (int i = 2; i <= 100; i++)
                {
                    int reminder = 0;
                    for (int j = 0; j < result.Count; j++)
                    {
                        int product = result[j] * i + reminder;
                        result[j] = product % 10;
                        reminder = product / 10;
                    }

                    while (reminder > 0)
                    {
                        result.Add(reminder % 10);
                        reminder /= 10;
                    }
                }

                int sum = 0;
                result.ForEach(digit => sum += digit);
                return sum;
            }
        }
    }
}
