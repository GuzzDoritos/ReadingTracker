using ReadingTracker.Data;
using ReadingTracker.Repositories;
using ReadingTracker.Services.ConsoleUI;
using System.Runtime.InteropServices;

Console.OutputEncoding = System.Text.Encoding.UTF8;

JsonRepository repo = new();

repo.Load();

ConsoleUI.Start(repo);