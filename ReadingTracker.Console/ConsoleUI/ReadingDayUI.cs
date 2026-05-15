using ReadingTracker.Core.Data;
using ReadingTracker.Core.Services;
using Spectre.Console;

namespace ReadingTracker.Core.ConsoleUI
{
    internal class ReadingDayUI
    {
        public static void AddReadingDay(ReadingService repo)
        {
            if (repo.GetBooks().Count == 0)
            {
                AnsiConsole.MarkupLine("[bold red]Nenhum livro encontrado. Adicione um livro antes de adicionar um dia de leitura.[/]");
                return;
            }

            AnsiConsole.WriteLine();
            Book book = BookUI.PickABook(repo);

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

            int charsRead = AnsiConsole.Prompt(
                new TextPrompt<int>("Adicione a quantidade de [green]caracteres lidos hoje[/]:")
                    .Validate(chars =>
                    {
                        string? error = repo.ValidateCharsRead(book, chars);
                        if (error != null)
                            return ValidationResult.Error($"[red]{error}[/]");
                        return ValidationResult.Success();
                    })
            );

            double minutesRead = AnsiConsole.Prompt(
                new TextPrompt<double>("Adicione a quantidade de [green]minutos lidos hoje[/]:")
                    .Validate(minutes =>
                    {
                        string? error = ReadingService.ValidateMinsRead(minutes);
                        if (error != null)
                            return ValidationResult.Error($"[red]{error}[/]");
                        return ValidationResult.Success();
                    })
            );

            AnsiConsole.MarkupLine("\n[green]*** NOVO DIA DE LEITURA ***[/]");
            AnsiConsole.MarkupLine($"Livro: {book.Name}");
            AnsiConsole.MarkupLine($"Dia: {date}");
            AnsiConsole.MarkupLine($"Caracteres lidos: {charsRead}");
            AnsiConsole.MarkupLine($"Minutos lidos: {minutesRead}");

            if (AnsiConsole.Confirm("Confirma as informações acima?"))
            {

                TrackedDay newDay = new(book.BookID, date, charsRead, minutesRead);
                repo.AddDay(newDay);

                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[bold green]Dia de leitura adicionado com sucesso![/]\n");

            }
            else
            {
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("\n[red]Operação cancelada.[/]\n");
            }
        }
        public static void EditReadingDay(ReadingService repo)
        {
            string nomeMenu = "EDITANDO DIA DE LEITURA";
            TrackedDay day;
            if (repo.GetDays().Any())
            {
                day = PickAReadingDay(repo);
            }
            else
            {
                AnsiConsole.MarkupLine("[bold red]Nenhum dia de leitura registrado.[/]");
                return;
            }

            Dictionary<string, Action> cOptions = new()
            {
                { "Alterar livro", () =>
                    {
                        Book newBook = BookUI.PickABook(repo);
                        int prevBook = day.BookId;
                        day.BookId = newBook.BookID;
                        if (day.BookId == prevBook)
                        {
                            AnsiConsole.MarkupLine("[yellow]Esse livro já é o selecionado.[/]\n");
                        } else
                        {
                            AnsiConsole.MarkupLine($"[green]Alterado com sucesso.[/]\n\nNovo livro: {newBook.Name}\n");
                        }
                    }
                },
                { "Remover livro", () =>
                    {
                        if (AnsiConsole.Confirm("Confirma remoção do dia?"))
                        {
                            repo.RemoveDay(day.DayId);
                            AnsiConsole.Clear();
                            AnsiConsole.MarkupLine($"[green]Removido com sucesso.[/]\n");
                        } else
                        {
                            AnsiConsole.Clear();
                            AnsiConsole.MarkupLine("\n[red]Operação cancelada.[/]\n");
                        }
                    }
                },
                {
                    "Cancelar", () => { }
                }
            };

            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[green]--{nomeMenu}--[/]\nEscolha uma opção (dia selecionado: {day.Date}): ")
                    .AddChoices(cOptions.Keys)
            );
            cOptions[choice].Invoke();
        }

        public static void PrintSummary(ReadingService repo)
        {
            AnsiConsole.Clear();

            if (repo.GetDays().Count == 0)
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
            foreach (var day in repo.GetDays())
            {
                Book? book = repo.GetBooks().Find(b => b.BookID == day.BookId);
                table.AddRow(
                    day.Date.ToString(),
                    book?.Name ?? "--deleted--",
                    day.CharsRead.ToString(),
                    day.MinutesRead.ToString(),
                    (book != null ? book.CalculatePercentRead(repo.CalculateAlreadyRead(book)).ToString("F2") + "%" : "N/A")
                    );
            }

            AnsiConsole.Write(table);
        }
        static TrackedDay PickAReadingDay(ReadingService repo)
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<TrackedDay>()
                    .Title("Escolha um dia:")
                    .AddChoices(repo.GetDays())
                    .UseConverter(day => $"{day.Date} - {repo.GetBooks().Find(book => book.BookID == day.BookId)?.Name ?? "--deleted--"}")
            );
        }



    }
}
