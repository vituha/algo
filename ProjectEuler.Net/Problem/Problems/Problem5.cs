using System;
using System.Collections.Generic;

namespace Problem.Problems
{
    internal sealed class Problem5 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(20);
        }

        private void RunInternal(int max)
        {
            var multipliers = new Dictionary<int, int>();

            for (int i = 2; i < max; i++)
            {
                int j = 2;
                int current = i;
                while(current > 1)
                {
                    int cnt = 0;
                    while ((current % j) == 0)
                    {
                        cnt++;
                        current /= j;
                    }

                    if (cnt > 0)
                    {
                        int prevCnt;
                        if (!multipliers.TryGetValue(j, out prevCnt) || prevCnt < cnt)
                        {
                            multipliers[j] = cnt;
                        }
                    }

                    j++;
                }
            }

            long product = 1;
            foreach (KeyValuePair<int, int> pair in multipliers)
            {
                product *= (long)Math.Pow(pair.Key, pair.Value);
            }

            Console.WriteLine(product);
        }
    }
}
