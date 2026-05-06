using ReadingTracker.Data;
using ReadingTracker.Repositories;
using ReadingTracker.Services;
using System.Runtime.InteropServices;

Console.OutputEncoding = System.Text.Encoding.UTF8;

BookLibrary bookLibrary = new();
Tracker tracker = new(bookLibrary);

FileService.Load(tracker);

Series s = new();
s.Name = "Rezero";
s.Author = "Tappei";
s.Genre.Add(Genre.Fantasy);
s.Books.Add(bookLibrary.GetBookList()[0]);

Console.WriteLine($"{s.Name}, {s.Author}, {s.SeriesID}, {string.Join(", ", s.Genre)}, {string.Join(", ", s.Books.ConvertAll(b => b.Name))}");

ConsoleUI.Start(tracker);