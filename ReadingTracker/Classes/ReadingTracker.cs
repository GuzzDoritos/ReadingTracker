using Spectre.Console;

namespace ReadingTracker.Classes
{
    public class Tracker
    {
        private readonly List<TrackedDay> _days = [];
    
        private readonly List<Media> _mediaList = [];

        public readonly ConsoleUI ui = new();

        public void Add(TrackedDay day)
        {
            _days.Add(day);
            _mediaList.Find(m => m.Name == day.Media.Name)?.UpdateProgress(day.CharsRead);
        }

        public void AddMedia(Media media) => _mediaList.Add(media);

        public List<TrackedDay> GetAll() => _days;

        public List<Media> GetMediaList() => _mediaList;

        public void PrintSummary()
        {

            var table = new Table();

            table.AddColumn("Date");
            table.AddColumn("Book");
            table.AddColumn("Characters Read");
            table.AddColumn("Minutes Read");
            table.AddColumn("Percent Read");

            foreach (var day in _days)
            {
               table.AddRow(
                   day.Date.ToString(), 
                   day.Media.Name, 
                   day.CharsRead.ToString(), 
                   day.MinutesRead.ToString(), 
                   day.Media.CalculatePercentRead().ToString("F2") + "%");
            }

            AnsiConsole.Write(table);
        }
    }
}
