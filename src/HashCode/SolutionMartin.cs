using System.Linq;

namespace HashCode
{
    public static class SolutionMartin
    {
        public static Solution Solve(Challenge challenge)
        {
            var solution = new Solution();
            var numDayLeft = challenge.NumberOfDays;
            
            var sortedLibraries = 
                challenge.Libraries
                    .OrderBy(library => library.SignupTime)
                    // .ThenByDescending(library => library.ScanVelocity)
                    .ThenByDescending(ScoreLibrary);
                    
            foreach (var library in sortedLibraries)
            {
                if (numDayLeft <= 0)
                    break;
            
                var solutionLibrary = new SolutionLibrary(library.Id);
                var totalShippingDays = numDayLeft - library.SignupTime;
                var sortedBooks = library.Books.Distinct().OrderByDescending(b => b.Score).ToList();

                for (var i = 0; i < totalShippingDays * library.ScanVelocity - 1; i++)
                {
                    if (sortedBooks.Count > i)
                        solutionLibrary.Books.Add(sortedBooks[i]);
                    else
                        break;
                }

                numDayLeft -= library.SignupTime;
                
                if (solutionLibrary.Books.Any())
                    solution.Libraries.Add(solutionLibrary);
            }
            
            return solution;
        }
        
        private static long ScoreLibrary(Library library)
        {
            return library.ScanVelocity * (library.Books.Distinct().Sum(b => b.Score) / library.Books.Distinct().Count());
        }
    }
}