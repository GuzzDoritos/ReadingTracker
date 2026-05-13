using ReadingTracker.ConsoleUI;
using ReadingTracker.Data;
using ReadingTracker.Repositories;
using System.Runtime.InteropServices;

Console.OutputEncoding = System.Text.Encoding.UTF8;

JsonRepository repo = new();

repo.Load();

ConsoleUI.Start(repo);