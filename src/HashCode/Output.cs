using System.IO;

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
                    // TODO: use writer to output the solution to the file we have to submit
                }
            }
        }
    }
}