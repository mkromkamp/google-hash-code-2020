using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace HashCode
{
    public static class SolutionJames
    {
        public static Solution Solve(Challenge challenge)
        {
            var solution = new Solution();
            var numDayLeft = challenge.NumberOfDays;

            foreach (var library in challenge.Libraries)
            {
                library.Score = CalculateLibraryScore(library);
            }

            
            
            
            
            
            
            foreach (var library in challenge.Libraries.OrderByDescending(x => x.Score))
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

        private static int CalculateLibraryScore(Library library)
        {
            var daysToProcess = library.SignupTime + (library.Books.Count() / library.ScanVelocity);
            var totalScore = library.Books.Sum(x => x.Score);
            return totalScore / daysToProcess;
        }
    }
}