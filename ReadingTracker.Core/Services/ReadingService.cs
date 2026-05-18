using ReadingTracker.Core.Data;
using ReadingTracker.Core.Repositories;

namespace ReadingTracker.Core.Services
{
    public class ReadingService(IReadingRepository repository)
    {
        private readonly IReadingRepository _readingRepository = repository;


        public void AddBook(Book book)
        {
            _readingRepository.AddBook(book);
        }
        public void RemoveBook(int bookId)
        {
            _readingRepository.RemoveBook(bookId);
        }

        public List<Book> GetBooks()
        {
            return _readingRepository.GetBooks();
        }

        public void AddDay(TrackedDay day)
        {
            _readingRepository.AddDay(day);
        }

        public void RemoveDay(int dayId)
        {
            _readingRepository.RemoveDay(dayId);
        }

        public List<TrackedDay> GetDays()
        {
            return _readingRepository.GetDays();
        }

        public List<TrackedDay> GetDaysFromBookId(int bookId)
        {
            return _readingRepository.GetDays().FindAll(d => d.BookId == bookId);
        }

        public string? ValidateCharsRead(Book book, int chars)
        {
            if (chars <= 0)
                return "O número de caracteres lidos não pode ser nulo ou negativo.";
            if (chars + CalculateAlreadyRead(book) > book.TotalChars)
                return $"Não pode exceder o total do livro ({book.TotalChars}).";
            return null;
        }

        public static string? ValidateMinsRead(double mins)
        {
            if (mins < 0) 
                return "O número de minutos lidos não pode ser negativo.";
            return null;
        }

        public int CalculateAlreadyRead(Book book)
        {
            return _readingRepository.GetDays()
                .Where(d => d.BookId == book.BookID)
                .Sum(d => d.CharsRead);
        }
    }
}
