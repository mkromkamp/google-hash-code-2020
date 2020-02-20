using System.Linq;

namespace HashCode
{
    public static class SolutionKavir
    {
        public static Solution Solve(Challenge challenge)
        {
            var solution = new Solution();

            foreach (var library in challenge.Libraries)
            {
                library.Score = library.Books.Sum(l => l.Score);
            }

            var orderedList = challenge.Libraries.OrderBy(l => l.SignupTime).ThenBy(l => l.Score).ToList();

            int totalLibraries = challenge.Libraries.Count;
            int processingLibraryNumber = 0;
            var processingLibrary = orderedList[processingLibraryNumber];
            int libraryId = orderedList[processingLibraryNumber].Id;
            int numOfBooksThatCanBeAdded = 0;

            for (int currentDay = 0; currentDay < challenge.NumberOfDays; currentDay++)
            {
                if (processingLibrary.SignupTime-- > 0)
                    continue;

                numOfBooksThatCanBeAdded = ((challenge.NumberOfDays - 1) - currentDay) * processingLibrary.ScanVelocity;

                var booksToBeAdded = processingLibrary.Books.OrderBy(b => b.Score).Take(numOfBooksThatCanBeAdded).ToList();

                if (numOfBooksThatCanBeAdded > 0 && booksToBeAdded.Count > 0)
                {
                    solution.Libraries.Add(
                        new SolutionLibrary(libraryId)
                        {
                            Books = booksToBeAdded
                        });
                }
                
                if (++processingLibraryNumber >= totalLibraries)
                    break;

                processingLibrary = orderedList[processingLibraryNumber];
            }

            return solution;
        }
    }
}