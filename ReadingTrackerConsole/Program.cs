using ReadingTrackerConsole.ConsoleUI;
using ReadingTrackerConsole.Repositories;

Console.OutputEncoding = System.Text.Encoding.UTF8;

JsonRepository repo = new();

repo.Load();

ConsoleUI.Start(repo);