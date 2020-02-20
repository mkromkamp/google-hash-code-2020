using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace HashCode
{
    public static class Input
    {
        public static Challenge Parse(string filePath)
        {
            var lines = File.ReadLines(filePath).ToList();
            var challengeInputs = lines[0].Split(' ');

            // first line is the challenge
            var challenge = new Challenge
            {
                TotalNumberOfBooks = int.Parse(challengeInputs[0]),
                Libraries = new List<Library>(int.Parse(challengeInputs[1])),
                NumberOfDays = int.Parse(challengeInputs[2])
            };

            var booksInput = lines[1].Split(' ');
            challenge.Books = new List<Book>(booksInput.Count());

            for (int i = 0; i < booksInput.Count(); i++)
            {
                challenge.Books.Add(new Book
                {
                    Id = i,
                    Score = int.Parse(booksInput[i])
                });
            }

            var libraryId = -1;
            for (int i = 1; i < lines.Count()-1; i++)
            {
                var libraryLine = lines[i].Split(' ');
                var library = new Library()
                {
                    Id = ++libraryId,
                    Books = new List<Book>(int.Parse(libraryLine[0])),
                    SignupTime = int.Parse(libraryLine[1]),
                    ScanVelocity = int.Parse(libraryLine[2]),
                };

                var bookLine = lines[++i].Split(' ');
                foreach (var id in bookLine)
                {
                    library.Books.Add(challenge.Books[int.Parse(id)]);
                }
                challenge.Libraries.Add(library);
            }


            return challenge;
        }
    }
}