using ReadingTracker.Data;
using ReadingTracker.Repositories;
using ReadingTracker.Services;
using System.Runtime.InteropServices;

Console.OutputEncoding = System.Text.Encoding.UTF8;

BookLibrary bookLibrary = new();
Tracker tracker = new(bookLibrary);

FileService.Load(tracker);

ConsoleUI.Start(tracker);