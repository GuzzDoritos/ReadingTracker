using ReadingTracker.Repositories;
using ReadingTracker.Services;
using Spectre.Console;

Console.OutputEncoding = System.Text.Encoding.UTF8;

BookLibrary bookLibrary = new();
Tracker tracker = new(bookLibrary);

int chosenOption = 0;

while (chosenOption != 4)
{
    ConsoleUI.DisplayMenu();
    if (int.TryParse(Console.ReadLine(), out chosenOption))
    {
        switch (chosenOption)
        {
            case 1:
                ConsoleUI.AddReadingDay(tracker);
                break;
            case 2:
                ConsoleUI.AddBook(tracker);
                break;
            case 3:
                ConsoleUI.PrintSummary(tracker);
                break;
            case 4:
                AnsiConsole.MarkupLine("[bold red]Exiting...[/]");
                break;
            default:
                AnsiConsole.MarkupLine("[bold yellow]Invalid option. Please try again.[/]");
                break;
        }
    }
    else
    {
        AnsiConsole.MarkupLine("[bold yellow]Please enter a valid number.[/]");
    }
}