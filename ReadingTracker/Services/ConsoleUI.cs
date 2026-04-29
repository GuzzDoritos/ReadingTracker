using Spectre.Console;

namespace ReadingTracker.Classes
{

    public class ConsoleUI
    {
        public void DisplayMenu()
        {
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[bold cyan]Choose an option:[/]");
            AnsiConsole.MarkupLine("[green]1.[/] Add new reading day");
            AnsiConsole.MarkupLine("[green]2.[/] Add new book");
            AnsiConsole.MarkupLine("[green]3.[/] View summary");
            AnsiConsole.MarkupLine("[green]4.[/] Exit");
        }

        public void AddReadingDay(Tracker tracker)
        {
            if (tracker.GetMediaList().Count == 0)
            {
                AnsiConsole.MarkupLine("[bold red]No books found. Please add a book before adding a reading day.[/]");
                return;
            }
            AnsiConsole.WriteLine();

            Media media = PickAMedia(tracker);
            int charsRead = AnsiConsole.Ask<int>("Enter the [green]characters read today[/]:");
            double minutesRead = AnsiConsole.Ask<double>("Enter the [green]minutes read today[/]:");

            TrackedDay newDay = new(media, DateOnly.FromDateTime(DateTime.Now), charsRead, minutesRead);
    
            tracker.Add(newDay);
    
            AnsiConsole.MarkupLine("[bold green]Reading day added successfully![/]");
        }

        public void AddBook(Tracker tracker)
        {
            AnsiConsole.WriteLine();
            string name = AnsiConsole.Ask<string>("Enter the [green]name of the book[/]:");
            int totalChars = AnsiConsole.Ask<int>("Enter the [green]total characters in the book[/]:");
            Media newMedia = new(name, totalChars);
    
            tracker.AddMedia(newMedia);
    
            AnsiConsole.MarkupLine("[bold green]Book added successfully![/]");
        }

        static Media PickAMedia(Tracker tracker)
        {
            int chosen = 0;
            foreach (Media book in tracker.GetMediaList()) { 
                AnsiConsole.MarkupLine($"[green]{tracker.GetMediaList().IndexOf(book) + 1}.[/] {book.Name}");
            }

            while (chosen < 1 || chosen > tracker.GetMediaList().Count)
            {
                chosen = AnsiConsole.Ask<int>("Pick a [green]book[/] from the list above:");
            }

            return tracker.GetMediaList()[chosen - 1];
        }
    }
}
