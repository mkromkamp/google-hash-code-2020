using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    public class Challenge
    {
        public int NumberOfDays { get; set; }
        public int TotalNumberOfBooks { get; set; }

        public List<Library> Libraries { get; set; }

        public int GetTotalNumberOfUniqueBooks()
        {
            var mergedBooks = new List<int>();

            Libraries.ForEach(lib => mergedBooks.AddRange(lib.Books.Select(b => b.Id)));

            return mergedBooks.Distinct().Count();
        }
        // ref to the books, might not be needed
        public List<Book> Books { get; set; }
    }

    public class Library
    {
        public int Id { get; set; }
        public int SignupTime { get; set; }
        public int ScanVelocity { get; set; }
        public List<Book> Books { get; set; }

        public int Score { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }
        public int Score { get; set; }
    }
}