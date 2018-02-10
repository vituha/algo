using System;
using System.Collections.Generic;

namespace Problem.Problems
{
    internal sealed class Problem25 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(1000);
        }

        private void RunInternal(int digits)
        {
            int index = 2;
            var lowNumber = new List<int>() { 1 };
            var highNumber = new List<int>() { 1 };

            while (highNumber.Count < digits)
            {
                Sum(lowNumber, highNumber);
                var temp = lowNumber;
                lowNumber = highNumber;
                highNumber = temp;

                index++;
            }

            Console.WriteLine(index);
        }

        private void Sum(List<int> lowNumber, List<int> highNumber)
        {
            while (lowNumber.Count < highNumber.Count)
            {
                lowNumber.Add(0);
            }

            int carry = 0;

            for (int i = 0; i < lowNumber.Count; i++)
            {
                carry = lowNumber[i] + highNumber[i] + carry;
                lowNumber[i] = carry % 10;
                carry /= 10;
            }

            while (carry > 0)
            {
                lowNumber.Add(carry % 10);
                carry /= 10;
            }
        }
    }
}
