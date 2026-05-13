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
            string nomeMenu = "MENU PRINCIPAL";
            RunMenu(nomeMenu, new()
            {
                { "Gerenciar dias de leitura", () => ManageReadingDay(tracker) },
                { "Gerenciar livros", () => ManageBooks(tracker) },
                { "Imprimir sumário", () => PrintSummary(tracker) },
            }, "Sair");
            FileService.Save(tracker);
        }

        public static void ManageReadingDay(Tracker tracker)
        {
            string nomeMenu = "GERENCIAR DIAS DE LEITURA";
            RunMenu(nomeMenu, new()
            {
                { "Adicionar um dia de leitura", () => AddReadingDay(tracker) },
                { "Editar ou remover um dia de leitura", () => EditReadingDay(tracker) }
            }, "Voltar");
            FileService.Save(tracker);

        }

        public static void EditReadingDay(Tracker tracker)
        {
            string nomeMenu = "";
        }

        public static void ManageBooks(Tracker tracker)
        {
            string nomeMenu = "GERENCIAR LIVROS";
            RunMenu(nomeMenu, new()
            {
                { "Adicionar livros", () => AddBook(tracker) },
                { "Remover ou editar livros", () => EditBooks(tracker)  },
                { "Listar livros", () => PrintBooks(tracker) }
            }, "Voltar");
            FileService.Save(tracker);
        }


        public static void EditBooks(Tracker tracker)
        {
            string nomeMenu = "EDITANDO LIVRO";
            Book book = PickABook(tracker);

            RunMenu(nomeMenu, new()
            {
                { "Editar nome", () =>
                    {
                        String novoNome = AnsiConsole.Ask<string>("Adicione o [green]nome do livro[/]:", book.Name);
                        string nomeAnterior = book.Name;
                        book.Name = novoNome;
                        if (book.Name == nomeAnterior)
                        {
                            AnsiConsole.MarkupLine("[yellow]Nome sem alteração.[/]\n");
                        } else
                        {
                            AnsiConsole.MarkupLine($"[green]Alterado com sucesso.[/]\n\nNovo nome: {book.Name}\n");
                            FileService.Save(tracker);
                        }                        
                    }
                },
                { "Remover livro", () => 
                    { 
                        if (AnsiConsole.Confirm("Confirma remoção do livro?"))
                        {
                            tracker.GetBookLibrary().RemoveBook(book);
                            AnsiConsole.MarkupLine($"[green]Removido com sucesso.[/]\n");
                            FileService.Save(tracker);
                        } else
                        {
                            AnsiConsole.MarkupLine("\n[red]Operação cancelada.[/]\n");
                        }
                    } 
                }
            }, "Voltar", runOnce: true, $"Escolha uma opção (livro selecionado: {book.Name}): ");
        }

        private static void RunMenu(string menuName, Dictionary<string, Action> options, string exit, bool runOnce = false, string prompt = "Escolha uma opção:")
        {
            Dictionary<string, Action> cOptions = new(options)
            {
                { "Limpar console", () => { AnsiConsole.Clear(); } },
                { exit, () => { } }
            };
            string choice = GetChoice(menuName, prompt, cOptions);
            if (!runOnce)
            {
                while (choice != exit)
                {
                    cOptions[choice].Invoke();
                    choice = GetChoice(menuName, prompt, cOptions);
                }
            } 
            else
            {
                cOptions[choice].Invoke();
            }
        }

        private static string GetChoice(string menuName, string prompt, Dictionary<string, Action> options)
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[green]--{menuName}--[/]\n{prompt}")
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

            DateOnly defaultDate = DateOnly.FromDateTime(DateTime.Now);

            string dateString = AnsiConsole.Prompt(
                new TextPrompt<string>("Informe a [green]data de leitura[/]:")
                    .DefaultValue(defaultDate.ToString())
                    .Validate(str =>
                    {
                        DateOnly aux;
                        if (!DateOnly.TryParse(str, out aux))
                        {
                            return ValidationResult.Error("[red]Formato inválido[/]");
                        }

                        return ValidationResult.Success();
                    }));


            DateOnly date = DateOnly.Parse(dateString);



            AnsiConsole.MarkupLine("\n[green]*** NOVO DIA DE LEITURA ***[/]");


            AnsiConsole.MarkupLine($"Dia: {date}");
            AnsiConsole.MarkupLine($"Livro: {book.Name}");
            AnsiConsole.MarkupLine($"Caracteres lidos: {charsRead}");
            AnsiConsole.MarkupLine($"Minutos lidos: {minutesRead}");


            if (AnsiConsole.Confirm("Confirma as informações acima?"))
            {

                TrackedDay newDay = new(book, date, charsRead, minutesRead);
                tracker.Add(newDay);

                FileService.Save(tracker);

                AnsiConsole.MarkupLine("[bold green]Dia de leitura adicionado com sucesso![/]\n");

            }
            else
            {
                AnsiConsole.MarkupLine("\n[red]Operação cancelada.[/]\n");
            }
        }

        public static void AddBook(Tracker tracker)
        {

            AnsiConsole.WriteLine();
            string name = AnsiConsole.Ask<string>("Adicione o [green]nome do livro[/]:", "Livro");
            string author = AnsiConsole.Ask<string>("Informe o [green]nome do autor[/]:", "Autor");

            List<Genre> genres = Enum.GetValues<Genre>().ToList();

            SelectionPrompt<Genre> prompt = new SelectionPrompt<Genre>()
                                .Title("Selecione um [green]gênero[/]:")
                                .PageSize(8)
                                .EnableSearch()
                                .SearchPlaceholderText("Type to filter...")
                                .AddChoices(genres);

            Genre genre = AnsiConsole.Prompt(prompt);
            AnsiConsole.MarkupLine($"Selecione um [green]gênero[/]: {genre}");


            int totalChars = AnsiConsole.Ask<int>("Adicione a quantidade de [green]caracteres totais no livro[/]:", 10000);

            AnsiConsole.MarkupLine("\n[green]*** NOVO LIVRO ***[/]");


            AnsiConsole.MarkupLine($"Nome: {name}");
            AnsiConsole.MarkupLine($"Autor: {author}");
            AnsiConsole.MarkupLine($"Gênero: {genre.ToString()}");
            AnsiConsole.MarkupLine($"Total de caracteres: {totalChars}");

            if (AnsiConsole.Confirm("Confirma as informações acima?"))
            {

                tracker.GetBookLibrary().AddBook(name, author, genre, totalChars);

                AnsiConsole.MarkupLine("[bold green]Livro adicionado com sucesso![/]\n");

                FileService.Save(tracker);

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
            table.AddColumn("Total de Chars.");

            foreach (Book book in tracker.GetBookLibrary().GetBookList())
            {
                table.AddRow(book.Name, book.Author, book.BookGenre.ToString(), book.TotalChars.ToString());
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

        static Book PickAReadingDay(Tracker tracker)
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
