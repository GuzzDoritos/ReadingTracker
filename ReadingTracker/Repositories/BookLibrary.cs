using ReadingTracker.Data;

namespace ReadingTracker.Repositories
{
    internal class BookLibrary
    {
        private readonly List<Book> _bookList = [];
        public void AddBook(string name, int totalChars)
            {
                Book book = new(name, totalChars);
                _bookList.Add(book);
            }
        public List<Book> GetBookList() => _bookList;

        public void Load(List<Book> Books)
        {
            _bookList.AddRange(Books);
        }
    }
}
