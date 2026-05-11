using ReadingTracker.Data;

namespace ReadingTracker.Repositories
{
    internal class Tracker(BookLibrary bookLibrary)
    {
        private readonly List<TrackedDay> _days = [];
        private readonly BookLibrary _bookLibrary = bookLibrary;

        public void Add(TrackedDay day)
        {
            _days.Add(day);
            _bookLibrary.GetBookList().Find(m => m.Name == day.Book.Name)?.UpdateProgress(day.CharsRead);
        }

        public List<TrackedDay> GetAll() => _days;

        public BookLibrary GetBookLibrary() => _bookLibrary;

        public void Clear()
        {
            _days.Clear();
            _bookLibrary.GetBookList().Clear();
        }

        public void Load(List<Book> Books, List<TrackedDay> Days)
        {
            _days.AddRange(Days);
            _bookLibrary.Load(Books);
        }
    }
}
