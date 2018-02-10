using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem
{
    class Program
    {
        private static IDictionary<string, Type> _problemByName = EnumerateProblems();

        private static IDictionary<string, Type> EnumerateProblems()
        {
            return
                typeof (Program).Assembly.GetTypes()
                    .Where(type => typeof (ProblemBase).IsAssignableFrom(type))
                    .ToDictionary(type => type.Name);
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Write("Enter problem number (0 - for exit): ");
                string inputString = Console.ReadLine();
                int problemIndex;
                if (int.TryParse(inputString, out problemIndex) && TryRun(problemIndex))
                {
                    break;
                }
                Console.WriteLine("Solution is not yet implemented.");
            } while (true);

            Console.WriteLine("Done. Press <Enter> to exit...");
            Console.ReadLine();
        }

        private static bool TryRun(int problemIndex)
        {
            if (problemIndex == 0)
            {
                return true;
            }

            var typeName = "Problem" + problemIndex;
            Type type;
            if (!_problemByName.TryGetValue(typeName, out type))
            {
                return false;
            }
            ProblemBase instance = (ProblemBase) Activator.CreateInstance(type);
            instance.Run();
            
            return true;
        }
    }
}
