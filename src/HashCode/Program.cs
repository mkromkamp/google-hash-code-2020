using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting!");
        var scores = new List<long>();
            
            for (int i = 1; i <= 6; i++)
            {
                var challenge = Input.Parse(Path.Combine("input", $"sample{i}.in"));
                var solution = SolutionMartin.Solve(challenge);
                Output.Write(solution, $"output/sample{i}.out");
                
                scores.Add(solution.Score());
                
                Console.WriteLine($"Input {i}: {solution.Score()} points");
            }
            
            Console.WriteLine($"Finished with total {scores.Sum()}");
        }
    }
}
