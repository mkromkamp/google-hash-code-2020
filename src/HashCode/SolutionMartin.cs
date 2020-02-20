using System.Linq;

namespace HashCode
{
    public static class SolutionMartin
    {
        public static Solution Solve(Challenge challenge)
        {
            var solution = new Solution();
            var numDayLeft = challenge.NumberOfDays;
            
            foreach (var library in challenge.Libraries)
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
    }
}