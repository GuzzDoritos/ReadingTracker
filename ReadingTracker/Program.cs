using ReadingTracker.Classes;
using Spectre.Console;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Tracker tracker = new();

int chosenOption = 0;

while (chosenOption != 4)
{
    tracker.ui.DisplayMenu();
    if (int.TryParse(Console.ReadLine(), out chosenOption))
    {
        switch (chosenOption)
        {
            case 1:
                tracker.ui.AddReadingDay(tracker);
                break;
            case 2:
                tracker.ui.AddBook(tracker);
                break;
            case 3:
                tracker.PrintSummary();
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