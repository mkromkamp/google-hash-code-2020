using System.Collections;

namespace HashCode
{
    public class SolutionAdrien
    {
        private BitArray _scannedBooks;

        public SolutionAdrien(Challenge challenge)
        {
            _scannedBooks = new BitArray(challenge.GetTotalNumberOfUniqueBooks());
        }
    }
}
