using ReadingTracker.Data;
using ReadingTracker.Repositories;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingTracker.Services.ConsoleUI
{
    internal class ReadingDayUI
    {
        public static void AddReadingDay(IReadingRepository repo)
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
                        if (chars <= 0)
                        {
                            return ValidationResult.Error("[red]O número de caracteres lidos não pode ser nulo ou negativo.[/]");
                        }
                        if (chars + CalculateAlreadyRead(repo, book) > book.TotalChars)
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

            AnsiConsole.MarkupLine("\n[green]*** NOVO DIA DE LEITURA ***[/]");
            AnsiConsole.MarkupLine($"Livro: {book.Name}");
            AnsiConsole.MarkupLine($"Dia: {date}");
            AnsiConsole.MarkupLine($"Caracteres lidos: {charsRead}");
            AnsiConsole.MarkupLine($"Minutos lidos: {minutesRead}");

            if (AnsiConsole.Confirm("Confirma as informações acima?"))
            {

                TrackedDay newDay = new(book.BookID, date, charsRead, minutesRead);
                repo.AddDay(newDay);

                AnsiConsole.MarkupLine("[bold green]Dia de leitura adicionado com sucesso![/]\n");

            }
            else
            {
                AnsiConsole.MarkupLine("\n[red]Operação cancelada.[/]\n");
            }
        }
        public static void EditReadingDay(IReadingRepository repo)
        {
            string nomeMenu = "";
        }

        public static void PrintSummary(IReadingRepository repo)
        {

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
                    (book != null ? book.CalculatePercentRead(CalculateAlreadyRead(repo, book)).ToString("F2") + "%" : "N/A")
                    );
            }

            AnsiConsole.Write(table);
        }
        static Book PickAReadingDay(IReadingRepository repo)
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<Book>()
                    .Title("Escolha um livro:")
                    .AddChoices(repo.GetBooks())
                    .UseConverter(book => book.Name)
            );
        }


        static int CalculateAlreadyRead(IReadingRepository repo, Book book)
        {
            return repo.GetDays()
                .Where(d => d.BookId == book.BookID)
                .Sum(d => d.CharsRead);
        }
    }
}
