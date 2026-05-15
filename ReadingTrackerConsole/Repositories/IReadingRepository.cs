using ReadingTrackerConsole.Data;

namespace ReadingTrackerConsole.Repositories
{
    public interface IReadingRepository
    {
        List<Book> GetBooks();
        void AddBook(Book book);
        void RemoveBook(int bookId);
        List<TrackedDay> GetDays();
        void AddDay(TrackedDay day);
        void RemoveDay(int dayId);

        int CalculateAlreadyRead(Book book);
    }
}
