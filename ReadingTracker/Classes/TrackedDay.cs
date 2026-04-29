namespace ReadingTracker.Classes
{
    internal class TrackedDay(Book book, DateOnly date, int charsRead, double minutesRead)
    {

        public Book Book { get; private set; } = book;
        public DateOnly Date { get; private set; } = date;
        public int CharsRead { get; private set; } = charsRead;
        public double MinutesRead { get; private set; } = minutesRead;
    }
}
