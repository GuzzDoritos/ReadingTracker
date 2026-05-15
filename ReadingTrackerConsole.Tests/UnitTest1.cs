using ReadingTrackerConsole.Data;
using ReadingTrackerConsole.Repositories;

namespace ReadingTrackerConsole.Tests
{
    public class BookTests
    {
        [Fact]
        public void CalculatePercentRead_HalfRead_Returns50()
        {
            Book book = new();
            book.TotalChars = 1000;

            double result = book.CalculatePercentRead(500);

            Assert.Equal(50.0, result);
        }

        [Fact]
        public void CalculatePercentRead_ZeroTotal_ReturnsZero()
        {
            Book book = new();
            book.TotalChars = 0;

            double result = book.CalculatePercentRead(100);

            Assert.Equal(0.0, result);
        }

        [Fact]
        public void TestIdGeneration_AddBook()
        {
            JsonRepository repo = new();
            Book book1 = new();
            Book book2 = new();

            repo.AddBook(book1);
            repo.AddBook(book2);

            Assert.Equal(1, book1.BookID);
            Assert.Equal(2, book2.BookID);
        }
    }
}
