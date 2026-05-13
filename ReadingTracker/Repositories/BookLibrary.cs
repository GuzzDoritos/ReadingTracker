using ReadingTracker.Data;

namespace ReadingTracker.Repositories
{
    internal class BookLibrary
    {
        private readonly List<Book> _bookList = [];
        public void AddBook(string name, string author, Genre genre, int totalChars)
            {
                Book book = new(name, author, genre, totalChars);
                _bookList.Add(book);
            }

        public void RemoveBook(Book book)
        {
            _bookList.Remove(book);
        }
        public List<Book> GetBookList() => _bookList;

        public void Load(List<Book> Books)
        {
            _bookList.AddRange(Books);
        }
    }
}
