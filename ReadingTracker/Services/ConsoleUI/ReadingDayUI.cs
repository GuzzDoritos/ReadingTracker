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
        public static void AddReadingDay(Tracker tracker)
        {
            if (tracker.GetBookLibrary().GetBookList().Count == 0)
            {
                AnsiConsole.MarkupLine("[bold red]Nenhum livro encontrado. Adicione um livro antes de adicionar um dia de leitura.[/]");
                return;
            }

            AnsiConsole.WriteLine();
            Book book = BookUI.PickABook(tracker);

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

            AnsiConsole.MarkupLine("\n[green]*** NOVO DIA DE LEITURA ***[/]");
            AnsiConsole.MarkupLine($"Livro: {book.Name}");
            AnsiConsole.MarkupLine($"Dia: {date}");
            AnsiConsole.MarkupLine($"Caracteres lidos: {charsRead}");
            AnsiConsole.MarkupLine($"Minutos lidos: {minutesRead}");

            if (AnsiConsole.Confirm("Confirma as informações acima?"))
            {

                TrackedDay newDay = new(book, date, charsRead, minutesRead);
                tracker.Add(newDay);

                JsonRepository.Save(tracker);

                AnsiConsole.MarkupLine("[bold green]Dia de leitura adicionado com sucesso![/]\n");

            }
            else
            {
                AnsiConsole.MarkupLine("\n[red]Operação cancelada.[/]\n");
            }
        }
        public static void EditReadingDay(Tracker tracker)
        {
            string nomeMenu = "";
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
        static Book PickAReadingDay(Tracker tracker)
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<Book>()
                    .Title("Escolha um livro:")
                    .AddChoices(tracker.GetBookLibrary().GetBookList())
                    .UseConverter(book => book.Name)
            );
        }

    }
}
