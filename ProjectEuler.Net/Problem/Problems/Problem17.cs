using System;
namespace Problem.Problems
{
    /*
If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?

NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of "and" when writing out numbers is in compliance with British usage.
     */
    internal sealed class Problem17 : ProblemBase
    {
        public override void Run()
        {
            int sum = 0;
            for (int i = 1; i <= 1000; i++)
            {
                sum += RunInternal(i);
            }
            Console.WriteLine(sum);
        }

        private int RunInternal(long x)
        {
            int digitCount = (int)Math.Ceiling(Math.Log10(x + 1));

            int thousandIndex = (digitCount - 1) / 3 - 1; 

            long tupleDivider = (long)Math.Pow(10, 3 * (digitCount / 3));
            int tuple = (int)(x / tupleDivider);
            x %= tupleDivider;

            int letterCount = CountTouple(tuple);

            if (thousandIndex >= 0)
            {
                letterCount += thousands[thousandIndex].Length;
                Console.Write(" " + thousands[thousandIndex--]);
            }

            while (x > 0)
            {
                tupleDivider /= 1000;
                tuple = (int)(x / tupleDivider);
                x %= tupleDivider;

                letterCount += CountTouple(tuple);

                if (thousandIndex >= 0)
                {
                    letterCount += thousands[thousandIndex].Length;
                    Console.Write(" " + thousands[thousandIndex--]);
                }
            }

            Console.WriteLine(Environment.NewLine + letterCount);
            return letterCount;
        }

        private int CountTouple(int tuple)
        {
            int cnt = 0;

            int hundreds = tuple / 100;
            tuple %= 100;

            if (hundreds > 0)
            {
                Console.Write(" " + teens[hundreds] + " hundred");
                cnt += teens[hundreds].Length + 7;
            }

            if (tuple == 0)
            {
                return cnt;
            }

            if (cnt > 0)
            {
                Console.Write(" and");
                cnt += 3;
            }

            if (tuple < 20)
            {
                Console.Write(" " + teens[tuple]);
                cnt += teens[tuple].Length;
            }
            else 
            {
                int high = tuple / 10;
                int low = tuple % 10;
                if (high > 1)
                {
                    Console.Write(" " + tens[high - 2]);
                    cnt += tens[high - 2].Length;
                }
                if (low > 0)
                {
                    Console.Write(" " + teens[low]);
                    cnt += teens[low].Length;
                }
            }

            return cnt;
        }

        string[] teens = 
            {
                "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", 
                "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
            };

        string[] tens = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        string[] thousands = { "thousand", "million", "billion" };
    }
}
