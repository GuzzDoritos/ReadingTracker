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
            AnsiConsole.MarkupLine("[bold cyan]Escolha uma opção:[/]");
            AnsiConsole.MarkupLine("[green]1.[/] Adicionar novo dia de leitura");
            AnsiConsole.MarkupLine("[green]2.[/] Adicionar novo livro");
            AnsiConsole.MarkupLine("[green]3.[/] Ver resumo");
            AnsiConsole.MarkupLine("[green]4.[/] Sair");
        }

        public static void AddReadingDay(Tracker tracker)
        {
            if (tracker.GetBookLibrary().Count == 0)
            {
                AnsiConsole.MarkupLine("[bold red]Nenhum livro encontrado. Adicione um livro antes de adicionar um dia de leitura.[/]");
                return;
            }
            AnsiConsole.WriteLine();

            Book book = PickABook(tracker);
            int charsRead = AnsiConsole.Ask<int>("Adicione a quantidade de [green]caracteres lidos hoje[/]:");
            double minutesRead = AnsiConsole.Ask<double>("Adicione a quantidade de [green]minutos lidos hoje[/]:");

            TrackedDay newDay = new(book, DateOnly.FromDateTime(DateTime.Now), charsRead, minutesRead);
    
            tracker.Add(newDay);
    
            AnsiConsole.MarkupLine("[bold green]Dia de leitura adicionado com sucesso![/]");
        }

        public static void AddBook(Tracker tracker)
        {
            AnsiConsole.WriteLine();
            string name = AnsiConsole.Ask<string>("Adicione o [green]nome do livro[/]:");
            int totalChars = AnsiConsole.Ask<int>("Adicione a quantidade de [green]caracteres totais no livro[/]:");
            Book newBook = new(name, totalChars);
    
            tracker.GetBookLibrary().Add(newBook);
    
            AnsiConsole.MarkupLine("[bold green]Livro adicionado com sucesso![/]");
        }

        static Book PickABook(Tracker tracker)
        {
            int chosen = 0;
            foreach (Book book in tracker.GetBookLibrary()) { 
                AnsiConsole.MarkupLine($"[green]{tracker.GetBookLibrary().IndexOf(book) + 1}.[/] {book.Name}");
            }

            while (chosen < 1 || chosen > tracker.GetBookLibrary().Count)
            {
                chosen = AnsiConsole.Ask<int>("Escolha um [green]livro[/] da lista acima:");
            }

            return tracker.GetBookLibrary()[chosen - 1];
        }

        public static void PrintSummary(Tracker t)
        {

            var table = new Table();

            table.AddColumn("Data");
            table.AddColumn("Livro");
            table.AddColumn("Caracteres Lidos");
            table.AddColumn("Minutos Lidos");
            table.AddColumn("Porcentagem Lida");
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
