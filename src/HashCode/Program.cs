using System;
using System.IO;

namespace HashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            
            var lib1 = new SolutionLibrary(1);
            lib1.Books.AddLast(new Book() {Id = 1});
            lib1.Books.AddLast(new Book() {Id = 2});
            solution.Libraries.AddLast(lib1);
            
            
            var lib2 = new SolutionLibrary(2);
            lib2.Books.AddLast(new Book() {Id = 8});
            lib2.Books.AddLast(new Book() {Id = 9});
            solution.Libraries.AddLast(lib2);
            
            Output.Write(solution, "output/sample1.out");
            
            Console.WriteLine("Starting!");
            Input.Parse(Path.Combine("input", "sample1.in"));
            Console.WriteLine("Finished");
        }
    }
}
