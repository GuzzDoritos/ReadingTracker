using ReadingTrackerConsole.Data;
using ReadingTrackerConsole.Repositories;

namespace ReadingTrackerConsole.Tests
{
    internal class InMemoryRepository : IReadingRepository
    {

        private readonly List<Book> _bookList = [];
        private readonly List<TrackedDay> _daysList = [];

        public void AddBook(Book book)
        {
            if (_bookList.Count == 0)
            {
                book.BookID = 1;
            }
            else
            {
                book.BookID = _bookList.Max(b => b.BookID) + 1;
            }

            _bookList.Add(book);
        }

        public void AddDay(TrackedDay day)
        {
            if (_daysList.Count == 0)
            {
                day.DayId = 1;
            }
            else
            {
                day.DayId = _daysList.Max(d => d.DayId) + 1;
            }

            _daysList.Add(day); _daysList.Sort((d1, d2) => d1.Date.CompareTo(d2.Date));
        }

        public List<Book> GetBooks()
        {
            return [.. _bookList];
        }

        public List<TrackedDay> GetDays()
        {
            return [.. _daysList];
        }

        public void RemoveBook(int bookId)
        {
            _bookList.RemoveAll(b => b.BookID == bookId);
        }

        public void RemoveDay(int dayId)
        {
            _daysList.RemoveAll(d => d.DayId == dayId);
        }
    }
}
