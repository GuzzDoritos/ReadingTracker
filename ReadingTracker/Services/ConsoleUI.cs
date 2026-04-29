using ReadingTracker.Classes;
using ReadingTracker.Repositories;
using Spectre.Console;

namespace ReadingTracker.Services
{

    internal class ConsoleUI
    {
        public static void DisplayMenu()
        {
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[bold cyan]Choose an option:[/]");
            AnsiConsole.MarkupLine("[green]1.[/] Add new reading day");
            AnsiConsole.MarkupLine("[green]2.[/] Add new book");
            AnsiConsole.MarkupLine("[green]3.[/] View summary");
            AnsiConsole.MarkupLine("[green]4.[/] Exit");
        }

        public static void AddReadingDay(Tracker tracker)
        {
            if (tracker.GetBookLibrary().Count == 0)
            {
                AnsiConsole.MarkupLine("[bold red]No books found. Please add a book before adding a reading day.[/]");
                return;
            }
            AnsiConsole.WriteLine();

            Book book = PickABook(tracker);
            int charsRead = AnsiConsole.Ask<int>("Enter the [green]characters read today[/]:");
            double minutesRead = AnsiConsole.Ask<double>("Enter the [green]minutes read today[/]:");

            TrackedDay newDay = new(book, DateOnly.FromDateTime(DateTime.Now), charsRead, minutesRead);
    
            tracker.Add(newDay);
    
            AnsiConsole.MarkupLine("[bold green]Reading day added successfully![/]");
        }

        public static void AddBook(Tracker tracker)
        {
            AnsiConsole.WriteLine();
            string name = AnsiConsole.Ask<string>("Enter the [green]name of the book[/]:");
            int totalChars = AnsiConsole.Ask<int>("Enter the [green]total characters in the book[/]:");
            Book newBook = new(name, totalChars);
    
            tracker.GetBookLibrary().Add(newBook);
    
            AnsiConsole.MarkupLine("[bold green]Book added successfully![/]");
        }

        static Book PickABook(Tracker tracker)
        {
            int chosen = 0;
            foreach (Book book in tracker.GetBookLibrary()) { 
                AnsiConsole.MarkupLine($"[green]{tracker.GetBookLibrary().IndexOf(book) + 1}.[/] {book.Name}");
            }

            while (chosen < 1 || chosen > tracker.GetBookLibrary().Count)
            {
                chosen = AnsiConsole.Ask<int>("Pick a [green]book[/] from the list above:");
            }

            return tracker.GetBookLibrary()[chosen - 1];
        }

        public static void PrintSummary(Tracker t)
        {

            var table = new Table();

            table.AddColumn("Date");
            table.AddColumn("Book");
            table.AddColumn("Characters Read");
            table.AddColumn("Minutes Read");
            table.AddColumn("Percent Read");

            foreach (var day in t.GetAll())
            {
                table.AddRow(
                    day.Date.ToString(),
                    day.Book.Name,
                    day.CharsRead.ToString(),
                    day.MinutesRead.ToString(),
                    day.Book.CalculatePercentRead().ToString("F2") + "%");
            }

            AnsiConsole.Write(table);
        }
    }
}
