using ReadingTrackerConsole.ConsoleUI;
using ReadingTrackerConsole.Repositories;
using ReadingTrackerConsole.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

JsonRepository repo = new();

repo.Load();

ReadingService tracker = new(repo);

ConsoleUI.Start(tracker);