using System;
using System.IO;

namespace HashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting!");
            Input.Parse(Path.Combine("input", "sample1.in"));
            
            Console.WriteLine("Finished");
        }
    }
}
