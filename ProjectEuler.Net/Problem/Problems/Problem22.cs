using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Problem.Problems
{
    /*
     
Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.

What is the total of all the name scores in the file?
     
     */
    internal sealed class Problem22 : ProblemBase
    {
        public override void Run()
        {
            RunInternal("..\\..\\Problems\\p022_names.txt");
        }

        private void RunInternal(string filename)
        {
            string[] names = ReadNames(filename);
            Array.Sort(names, StringComparer.Ordinal);

            int sum = 0;

            for (int i = 0; i < names.Length; i++)
            {
                int sumAlpha = 0;
                string name = names[i];
                foreach (char c in name)
                {
                    sumAlpha += c - 'A' + 1;
                }
                sum += (i + 1) * sumAlpha;
            }

            Console.WriteLine(sum);
        }

        private string[] ReadNames(string filename)
        {
            string contents;
            using (var stream = new FileStream(filename, FileMode.Open))
            using (var reader = new StreamReader(stream, Encoding.ASCII))
            {
                contents = reader.ReadToEnd();
            }

            return contents.Split(',').Select(s => s.Trim('"')).ToArray();
        }
    }
}
