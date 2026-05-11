using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ReadingTracker.Data
{
    internal class Series
    {
        public int SeriesID { get; private set; } = Guid.NewGuid().GetHashCode();
        public string Name { get; private set; } = string.Empty;
        public string Author { get; private set; } = string.Empty;
        private List<Genre> Genre { get; set; } = [];
        private List<Book> Books { get; set; } = [];

        public List<Genre> GetGenres() => Genre;

        public List<Book> GetBooks() => Books;

        public void AddGenre(Genre genre)
        {
            if (!Genre.Contains(genre))
            {
                Genre.Add(genre);
            }
        }

        public void AddBook(Book book)
        {
            if (!Books.Any(b => b.BookID == book.BookID))
            {
                Books.Add(book);
            }
        }

        public Series() { }
    }
}
