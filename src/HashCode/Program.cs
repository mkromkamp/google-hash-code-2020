using System;
using System.IO;

namespace HashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting!");
            
            var challenge = Input.Parse(Path.Combine("input", "sample1.in"));
            var solution = SolutionMartin.Solve(challenge);
            Output.Write(solution, "output/sample1.out");
            
            Console.WriteLine("Finished");
        }
    }
}
