using ReadingTracker.Data;
using ReadingTracker.Repositories;
using Spectre.Console;

namespace ReadingTracker.Services
{

    

    internal class ConsoleUI
    {

        public static void Start(Tracker tracker)
        {
            string option = GetOption();
            while (option != "Sair")
            {
                switch (option)
                {
                    case "Adicionar novo dia de leitura":
                        AddReadingDay(tracker);
                        break;
                    case "Adicionar novo livro":
                        AddBook(tracker);
                        break;
                    case "Ver resumo":
                        PrintSummary(tracker);
                        break;
                }
                FileService.Save(tracker);
                option = GetOption();
            }
        }

        public static string GetOption()
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Escolha uma opção:")
                    .AddChoices(
                        "Adicionar novo dia de leitura",
                        "Adicionar novo livro",
                        "Ver resumo",
                        "Sair"
                    )
                );
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

            int charsRead = AnsiConsole.Prompt(
                new TextPrompt<int>("Adicione a quantidade de [green]caracteres lidos hoje[/]:")
                    .Validate(chars =>
                    {
                        if (chars < 0)
                        {
                            return ValidationResult.Error("[red]O número de caracteres lidos não pode ser negativo.[/]");
                        }
                        if (chars + book.ReadChars > book.TotalChars)
                        {
                            return ValidationResult.Error($"[red]Não pode exceder o total do livro ({book.TotalChars}).[/]");
                        }
                        return ValidationResult.Success();
                    })
            );

            double minutesRead = AnsiConsole.Prompt(
                new TextPrompt<double>("Adicione a quantidade de [green]minutos lidos hoje[/]:")
                    .Validate(minutes =>
                    {
                        if (minutes < 0)
                        {
                            return ValidationResult.Error("[red]O número de minutos lidos não pode ser negativo.[/]");
                        }
                        return ValidationResult.Success();
                    })
            );

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
            return AnsiConsole.Prompt(
                new SelectionPrompt<Book>()
                    .Title("Escolha um livro:")
                    .AddChoices(tracker.GetBookLibrary())
                    .UseConverter(book => book.Name)
            );
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
