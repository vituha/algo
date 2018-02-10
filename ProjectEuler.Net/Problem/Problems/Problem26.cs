using System;
using System.Collections.Generic;
namespace Problem.Problems
{
    internal sealed class Problem26 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(1000);
        }

        private void RunInternal(int max)
        {
            int longestNumber = 1;
            int longestValue = 1;

            for (int i = 2; i < max; i++)
            {
                int length = CalcLength(i);
                if (length > longestValue)
                {
                    longestNumber = i;
                    longestValue = length;
                }
            }

            Console.WriteLine(longestNumber);
        }

        private int CalcLength(int i)
        {
            var reminders = new HashSet<int>();
            int reminder = 1;
            do
            {
                while (reminder < i)
                {
                    reminder *= 10;
                }

                reminder = reminder % i;
            } while (reminder > 0 && reminders.Add(reminder));

            return reminders.Count;
        }
    }
}
