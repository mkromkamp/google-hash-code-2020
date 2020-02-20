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
                    .ThenByDescending(library => library.ScanVelocity)
                    .ThenByDescending(library => library.Books.Count);
                    
            foreach (var library in sortedLibraries)
            {
                if (numDayLeft <= 0)
                    break;
            
                var solutionLibrary = new SolutionLibrary(library.Id);
                var totalShippingDays = numDayLeft - library.SignupTime;

                for (var i = 0; i < totalShippingDays * library.ScanVelocity - 1; i++)
                {
                    if (library.Books.Count > i)
                        solutionLibrary.Books.Add(library.Books[i]);
                    else
                        break;
                }

                numDayLeft -= library.SignupTime;
                
                if (solutionLibrary.Books.Any())
                    solution.Libraries.Add(solutionLibrary);
            }
            
            return solution;
        }
        //
        // private static void ScoreLibrary(Library library)
        // {
        //     library.Score = library.ScanVelocity + library.SignupTime
        // }
    }
}