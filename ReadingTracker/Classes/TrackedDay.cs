namespace ReadingTracker.Classes
{
    public class TrackedDay(Media media, DateOnly date, int charsRead, double minutesRead)
    {

        public Media Media { get; private set; } = media;
        public DateOnly Date { get; private set; } = date;
        public int CharsRead { get; private set; } = charsRead;
        public double MinutesRead { get; private set; } = minutesRead;
    }
}
