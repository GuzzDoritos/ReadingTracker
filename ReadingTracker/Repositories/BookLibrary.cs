using ReadingTracker.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingTracker.Repositories
{
    internal class BookLibrary
    {
        private readonly List<Book> _bookList = [];
        public void AddBook(Book book) => _bookList.Add(book);
        public List<Book> GetBookList() => _bookList;
    }
}
