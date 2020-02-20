using System.Collections.Generic;

namespace HashCode
{
    public class Solution
    {
        /// <summary>
        /// Ordered list of the libraries. The first library in the list is signed up first, the last one last.
        /// </summary>
        public LinkedList<SolutionLibrary> Libraries { get; set; }
    }

    public class SolutionLibrary
    {
        /// <summary>
        /// The Id of the library.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Linked list of books the library is shipping.
        /// First book is shipped first, last book is shipped last
        /// </summary>
        public LinkedList<Book> Books { get; set; }
    }
}