using System.Collections.Generic;
using System.Linq;

namespace HashCode
{
    public class Solution
    {
        public Solution()
        {
            Libraries = new List<SolutionLibrary>();
        }
        
        /// <summary>
        /// Ordered list of the libraries. The first library in the list is signed up first, the last one last.
        /// </summary>
        public List<SolutionLibrary> Libraries { get; set; }

        public long Score()
        {
            return Libraries
                .SelectMany(l => l.Books)
                .Distinct()
                .Sum(b => b.Score);
        }
        
    }

    public class SolutionLibrary
    {
        public SolutionLibrary(int id)
        {
            Id = id;
            Books = new List<Book>();
        }
        
        /// <summary>
        /// The Id of the library.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Linked list of books the library is shipping.
        /// First book is shipped first, last book is shipped last
        /// </summary>
        public List<Book> Books { get; set; }
    }
}