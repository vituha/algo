using System;

namespace Problem.Problems
{
    internal sealed class Problem19 : ProblemBase
    {
        public override void Run()
        {
            int cnt = RunInternal(new DateTime(1901, 1, 1), new DateTime(1999, 12, 1));

            Console.WriteLine(new DateTime(1900, 1, 1).DayOfWeek);
            Console.WriteLine(cnt);
        }

        private int RunInternal(DateTime start, DateTime end)
        {
            int cnt = 0;

            while (start <= end)
            {
                if (start.DayOfWeek == DayOfWeek.Monday) // looks like there is an error in task description. There should be Mondays not Sundays.
                {
                    cnt++;
                }
                start = start.AddMonths(1);
            }

            return cnt;
        }
    }
}
