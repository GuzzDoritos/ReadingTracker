namespace ReadingTracker.Data
{
    internal class TrackedDay
    {
        public int BookId { get; set; } 
        public DateOnly Date { get; set; }
        public int CharsRead { get; set; }
        public double MinutesRead { get; set; }

        public TrackedDay() { }

        public TrackedDay(int bookId, DateOnly date, int charsRead, double minutesRead)
        {
            BookId = bookId;
            Date = date;
            CharsRead = charsRead;
            MinutesRead = minutesRead;
        }
    }
}