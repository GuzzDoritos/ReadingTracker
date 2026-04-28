namespace ReadingTracker.Classes
{
    public class Tracker
    {
        private List<TrackedDay> _days = new();

        public void Add(TrackedDay day) => _days.Add(day);

        public List<TrackedDay> GetAll() => _days;

        public void PrintSummary()
        {
            foreach (var day in _days)
                Console.WriteLine($"{day.date}");
        }
    }
}
