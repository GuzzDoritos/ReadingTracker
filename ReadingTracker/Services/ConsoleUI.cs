using ReadingTracker.Data;
using ReadingTracker.Repositories;
using Spectre.Console;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace ReadingTracker.Services
{
    internal class ConsoleUI
    {
        public static void Start(Tracker tracker)
        {
            RunMenu("Escolha uma opção:", new()
            {
                { "Gerenciar dias de leitura", () => ManageReadingDay(tracker) },
                { "Gerenciar livros", () => ManageBooks(tracker) },
                { "Imprimir sumário", () => PrintSummary(tracker) },
                { "Limpar console", () => { AnsiConsole.Clear(); } }
            }, "Sair");
            FileService.Save(tracker);
        }

        public static void ManageReadingDay(Tracker tracker)
        {
            RunMenu("Escolha uma opção:", new()
            {
                { "Adicionar um dia de leitura", () => AddReadingDay(tracker) },
                { "Editar ou remover um dia de leitura", () => { } }
            }, "Voltar");
            FileService.Save(tracker);

        }

        public static void ManageBooks(Tracker tracker)
        {
            RunMenu("Escolha uma opção:", new()
            {
                { "Adicionar livros", () => AddBook(tracker) },
                { "Remover ou editar livros", () => EditBooks(tracker)  },
                { "Listar livros", () => PrintBooks(tracker) }
            }, "Voltar");
            FileService.Save(tracker);
        }


        public static void EditBooks(Tracker tracker)
        {
            Book book = PickABook(tracker);

            RunMenu($"Escolha uma opção (Livro selecionado: {book.Name}): ", new()
            {
                { "Editar nome", () =>
                    {
                        String novoNome = AnsiConsole.Ask<string>("Adicione o [green]nome do livro[/]:", "Livro");
                        book.Name = novoNome;
                        return;
                    }
                },
                { "Todo", () => {  } }
            }, "Voltar");
        }

        private static void RunMenu(string title, Dictionary<string, Action> options, string exit)
        {
            Dictionary<string, Action> cOptions = new(options)
            {
                { exit, () => { } }
            };
            string choice = GetChoice(title, cOptions);
            while (choice != exit)
            {
                cOptions[choice].Invoke();
                choice = GetChoice(title, cOptions);
            }
        }

        private static string GetChoice(string title, Dictionary<string, Action> options)
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(title)
                    .AddChoices(options.Keys)
            );
        }
        public static void AddReadingDay(Tracker tracker)
        {
            if (tracker.GetBookLibrary().GetBookList().Count == 0)
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
                        if (chars <= 0)
                        {
                            return ValidationResult.Error("[red]O número de caracteres lidos não pode ser nulo ou negativo.[/]");
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
                        if (minutes < 0) return ValidationResult.Error("[red]O número de minutos lidos não pode ser negativo.[/]");
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
            string name = AnsiConsole.Ask<string>("Adicione o [green]nome do livro[/]:", "Livro");

            int totalChars = AnsiConsole.Ask<int>("Adicione a quantidade de [green]caracteres totais no livro[/]:", 10000);

            AnsiConsole.WriteLine(name);
            AnsiConsole.WriteLine(totalChars);

            if (AnsiConsole.Confirm("Confirma as informações acima?"))
            {

                tracker.GetBookLibrary().AddBook(name, totalChars);

                AnsiConsole.MarkupLine("[bold green]Livro adicionado com sucesso![/]\n");

            }
            else
            {
                AnsiConsole.MarkupLine("\n[red]Operação cancelada.[/]\n");
            }
        }
        public static void PrintBooks(Tracker tracker)
        {
            var table = new Table()
                .RoundedBorder()
                .BorderColor(Color.Grey);

            table.AddColumn("Nome");
            table.AddColumn("Autor");
            table.AddColumn("Gênero");

            foreach (Book book in tracker.GetBookLibrary().GetBookList())
            {
                table.AddRow(book.Name);
            }

            AnsiConsole.Write(table);
        }

        static Book PickABook(Tracker tracker)
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<Book>()
                    .Title("Escolha um livro:")
                    .AddChoices(tracker.GetBookLibrary().GetBookList())
                    .UseConverter(book => book.Name)
            );
        }

        public static void PrintSummary(Tracker tracker)
        {

            if (tracker.GetAll().Count() == 0) 
            {
                AnsiConsole.MarkupLine("[red]Sem registros.[/]\n"); 
                return; 
            }

            var table = new Table();

            table.AddColumn("Data");
            table.AddColumn("Livro");
            table.AddColumn("Caracteres Lidos");
            table.AddColumn("Minutos Lidos");
            table.AddColumn("Porcentagem Lida");
            foreach (var day in tracker.GetAll())
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
