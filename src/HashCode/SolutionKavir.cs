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

            var orderedList = challenge.Libraries.OrderBy(l => l.SignupTime).ThenByDescending(l => l.Score).ToList();

            bool[] booksScanned = new bool[challenge.Books.Count];
            int totalLibraries = challenge.Libraries.Count;
            int processingLibraryNumber = 0;
            var processingLibrary = orderedList[processingLibraryNumber];
            int numOfBooksThatCanBeAdded = 0;

            for (int currentDay = 0; currentDay < challenge.NumberOfDays; currentDay++)
            {
                if (--processingLibrary.SignupTime > 0)
                    continue;

                numOfBooksThatCanBeAdded = ((challenge.NumberOfDays - 1) - currentDay) * processingLibrary.ScanVelocity;

                var booksToBeAdded = processingLibrary.Books
                .OrderByDescending(b => b.Score)
                .Where(b => !booksScanned[b.Id])
                .Take(numOfBooksThatCanBeAdded)
                .ToList();

                if (numOfBooksThatCanBeAdded > 0 && booksToBeAdded.Count > 0)
                {
                    solution.Libraries.Add(
                        new SolutionLibrary(orderedList[processingLibraryNumber].Id)
                        {
                            Books = booksToBeAdded
                        });

                    foreach (var book in booksToBeAdded)
                        booksScanned[book.Id] = true;
                }

                if (++processingLibraryNumber >= totalLibraries)
                    break;

                processingLibrary = orderedList[processingLibraryNumber];
            }

            return solution;
        }
    }
}