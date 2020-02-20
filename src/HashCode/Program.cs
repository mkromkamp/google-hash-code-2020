using System;
using System.IO;
using System.Linq;

namespace HashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting!");

            for (int i = 1; i <= 6; i++)
            {
                var challenge = Input.Parse(Path.Combine("input", $"sample{i}.in"));
                var solution = SolutionMartin.Solve(challenge);
                Output.Write(solution, $"output/sample{i}.out");
            }
            
            // var challenge = Input.Parse(Path.Combine("input", $"sample2.in"));
            // var solution = SolutionMartin.Solve(challenge);
            // Output.Write(solution, $"output/sample2.out");
            
            Console.WriteLine("Starting!");
            //var challenge = Input.Parse(Path.Combine("input", "sample2.in"));
            Console.WriteLine("Finished");
        }
    }
}
