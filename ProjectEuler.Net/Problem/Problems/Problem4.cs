using System;

namespace Problem.Problems
{
    internal sealed class Problem4 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(3);
        }

        private void RunInternal(int digits)
        {
            int palindrome = 0;
            int palX = 0, palY = 0;

            int min = (int)Math.Pow(10, digits - 1);
            int max = (int)Math.Pow(10, digits);
            for (int i = min; i < max; i++)
            {
                for (int j = i; j < max; j++)
                {
                    int candidate = i * j;
                    if (IsPalindrome(candidate) && palindrome < candidate)
                    {
                        palX = i;
                        palY = j;
                        palindrome = candidate;
                    }
                }
            }

            Console.WriteLine("{0} ({1} x {2})", palindrome, palX, palY);
        }

        private bool IsPalindrome(int candidate)
        {
            int original = candidate;
            int reversed = 0;
            while (candidate > 0)
            {
                reversed = 10 * reversed + candidate % 10;
                candidate /= 10;
            }

            return original == reversed;
        }
    }
}
