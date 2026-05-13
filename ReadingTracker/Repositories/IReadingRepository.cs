using ReadingTracker.Data;

namespace ReadingTracker.Repositories
{
    internal interface IReadingRepository
    {
        List<Book> GetBooks();
        void AddBook(Book book);
        void RemoveBook(int bookId);
        List<TrackedDay> GetDays();
        void AddDay(TrackedDay day);
    }
}
