using Spectre.Console;

namespace ReadingTracker.Classes
{
    public class Tracker
    {
        private readonly List<TrackedDay> _days = [];
    
        private readonly List<Media> _mediaList = [];

        public void Add(TrackedDay day)
        {
            _days.Add(day);
            _mediaList.Find(m => m.Name == day.Media.Name)?.UpdateProgress(day.CharsRead);
        }

        public void AddMedia(Media media) => _mediaList.Add(media);

        public List<TrackedDay> GetAll() => _days;

        public List<Media> GetMediaList() => _mediaList;
    }
}
