using ReadingTrackerConsole.Data;
using ReadingTrackerConsole.Services;

namespace ReadingTrackerConsole.Tests
{
    public class ReadingServiceTests
    {
        private static ReadingService CreateService(List<TrackedDay> existingDays, Book book)
        {
            InMemoryRepository repo = new();
            repo.AddBook(book);
            foreach (var day in existingDays)
            {
                repo.AddDay(day);
            }
            return new ReadingService(repo);
        }

        [Fact]
        public void ValidateCharsRead_NegativeChars_ReturnsError()
        {;
            Book book = new() { TotalChars = 1000 };
            ReadingService service = CreateService([], book);

            string? result = service.ValidateCharsRead(book, -1);

            Assert.NotNull(result);
        }

        [Fact]
        public void ValidateCharsRead_ExceedsTotal_ReturnsError()
        {
            Book book = new() { BookID = 1, TotalChars = 1000 };
            TrackedDay existingDay = new(book.BookID, DateOnly.FromDateTime(DateTime.Now), 800, 30);
            ReadingService service = CreateService([existingDay], book);

            string? result = service.ValidateCharsRead(book, 300);

            Assert.NotNull(result);
        }

        [Fact]
        public void ValidateCharsRead_ExactlyRemaining_ReturnsNull()
        {
            Book book = new() { BookID = 1, TotalChars = 1000 };
            TrackedDay existingDay = new(book.BookID, DateOnly.FromDateTime(DateTime.Now), 800, 30);
            ReadingService service = CreateService([existingDay], book);

            string? result = service.ValidateCharsRead(book, 200);

            Assert.Null(result);
        }

        [Fact]
        public void ValidateCharsRead_ValidAmount_ReturnsNull()
        {
            Book book = new() { TotalChars = 1000 };
            ReadingService service = CreateService([], book);

            string? result = service.ValidateCharsRead(book, 800);

            Assert.Null(result);
        }
    }
}
