using System;
using System.Linq;

namespace Problem.Problems
{
    internal sealed class Problem24 : ProblemBase
    {
        public override void Run()
        {
            RunInternal(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, 1000000);
        }

        private void RunInternal(int[] numbers, int targetIteration)
        {
            for (int i = 1; i < targetIteration; i++)
            {
                if (!TryPermute(numbers))
                {
                    Console.WriteLine("Target iteration cannot be reached.");
                    return;
                }
                //Console.WriteLine(string.Concat(numbers.Reverse()));
            }

            Console.WriteLine(string.Concat(numbers.Reverse()));
        }

        private bool TryPermute(int[] numbers)
        {
            int bubbleTarget = 1;
            while (numbers[bubbleTarget] > numbers[bubbleTarget - 1])
            {
                bubbleTarget++;

                if (bubbleTarget == numbers.Length)
                {
                    return false;
                }
            }

            int bubbleSource = 0;
            for (int i = 0; i < bubbleTarget; i++)
            {
                if (numbers[i] > numbers[bubbleTarget])
                {
                    bubbleSource = i;
                    break;
                }
            }

            Swap(numbers, bubbleTarget, bubbleSource);

            while (bubbleSource > 0 && numbers[bubbleSource] < numbers[bubbleSource - 1])
            {
                Swap(numbers, bubbleSource, bubbleSource - 1);
                bubbleSource--;
            }
            while (bubbleSource < bubbleTarget - 1 && numbers[bubbleSource] > numbers[bubbleSource + 1])
            {
                Swap(numbers, bubbleSource, bubbleSource + 1);
                bubbleSource++;
            }

            Array.Reverse(numbers, 0, bubbleTarget);

            return true;
        }

        private static void Swap(int[] numbers, int index1, int index2)
        {
            int temp = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = temp;
        }
    }
}
