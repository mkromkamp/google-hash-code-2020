using System.Collections.Generic;

namespace HashCode
{
    public class Challenge
    {
        public int NumberOfDays { get; set; }
        public int TotalNumberOfBooks { get; set; }
        
        public List<Library> Type { get; set; }
    }

    public class Library
    {
        public int Id { get; set; }
        public List<Book> Type { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }
        public int Score { get; set; }
    }
}