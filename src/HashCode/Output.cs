using System.IO;
using System.Linq;

namespace HashCode
{
    public static class Output
    {
        public static void Write(Solution solution, string fileName)
        {
            using (var outputFile = File.Open(fileName, FileMode.Truncate))
            {
                using (var writer = new StreamWriter(outputFile))
                {
                    // First line contains the number of libraries we signed up
                    writer.WriteLine(solution.Libraries.Count);
                    
                    // For each library we create two lines.
                    foreach (var library in solution.Libraries)
                    {
                        // The first line contains the id of the library followed by the number of scanned books
                        writer.WriteLine($"{library.Id} {library.Books.Count}");
                        
                        // The second line contains the order list of book ids
                        var bookIds = string.Join(" ", library.Books.Select(book => book.Id));
                        writer.WriteLine(bookIds);
                    }
                    
                    writer.Flush();
                }
            }
        }
    }
}