using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    public static class SolutionMartin
    {
        public static Solution Solve(Challenge challenge)
        {
            var solution = new Solution();
            var numDayLeft = challenge.NumberOfDays;
            
            // Sort books
            foreach (var library in challenge.Libraries)
            {
                library.Books = library.Books.Distinct().OrderByDescending(b => b.Score).ToList();
            }

            var libraries = challenge.Libraries;
            var sortedLibraries = new List<Library>();
            var daysLeft = challenge.NumberOfDays;
            var seenBooks = new List<Book>();
            
            while (libraries.Any())
            {
                var bestLibrary =
                    libraries.OrderBy(library => library.SignupTime)
                        .ThenByDescending(library => ScoreLibrary(library, daysLeft))
                        .FirstOrDefault();
                        
                sortedLibraries.Add(bestLibrary);
                daysLeft -= bestLibrary.SignupTime;
                libraries.Remove(bestLibrary);
            }
            //
            // var sortedLibraries = 
            //     challenge.Libraries
            //         .OrderBy(library => library.SignupTime)
            //         // .ThenByDescending(library => library.ScanVelocity)
            //         .ThenByDescending(library => ScoreLibrary(library, challenge.NumberOfDays)).ToList();
            var seenBook = new List<Book>();
            foreach (var library in sortedLibraries)
            {
                if (numDayLeft <= 0)
                    break;
            
                var solutionLibrary = new SolutionLibrary(library.Id);
                var totalShippingDays = numDayLeft - library.SignupTime;

                for (var i = 0; i < totalShippingDays * library.ScanVelocity - 1; i++)
                {
                    if (library.Books.Count > i)
                    {
                        var uniqueBooks = library.Books.Except(seenBook).ToList();
                        if (uniqueBooks.Any())
                        {
                            solutionLibrary.Books.Add(uniqueBooks.First());
                            seenBook.Add(uniqueBooks.First());
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                        break;
                }

                numDayLeft -= library.SignupTime;
                
                if (solutionLibrary.Books.Any())
                    solution.Libraries.Add(solutionLibrary);
            }
            
            return solution;
        }
        
        private static long ScoreLibrary(Library library, int totalDaysLeft)
        {
            if (totalDaysLeft <= 0)
                return totalDaysLeft;

            return library.Books.Take((totalDaysLeft - library.SignupTime) * library.ScanVelocity).Sum(b => b.Score);
        }
    }
}