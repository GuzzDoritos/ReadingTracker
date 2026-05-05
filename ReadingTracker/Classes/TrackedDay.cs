namespace ReadingTracker.Classes
{
    internal class TrackedDay
    {
        public Book Book { get; set; } = null!; 
        public DateOnly Date { get; set; }
        public int CharsRead { get; set; }
        public double MinutesRead { get; set; }

        public TrackedDay() { }

        public TrackedDay(Book book, DateOnly date, int charsRead, double minutesRead)
        {
            Book = book;
            Date = date;
            CharsRead = charsRead;
            MinutesRead = minutesRead;
        }
    }
}