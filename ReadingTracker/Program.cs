using ReadingTracker.Classes;

Tracker tracker = new();
TrackedDay dayOne = new("123");

tracker.Add(dayOne);

tracker.PrintSummary();