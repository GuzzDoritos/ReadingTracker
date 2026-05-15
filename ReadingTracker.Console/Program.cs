using ReadingTracker.Console.ConsoleUI;
using ReadingTracker.Core.Repositories;
using ReadingTracker.Core.Services;
using Spectre.Console;

Console.OutputEncoding = System.Text.Encoding.UTF8;

JsonRepository repo = new();

string? error = repo.Load();
if (error != null) AnsiConsole.MarkupLine($"[red]{error}[/]");

ReadingService tracker = new(repo);

ConsoleUI.Start(tracker);