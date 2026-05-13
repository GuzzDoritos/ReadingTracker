using ReadingTracker.Data;
using ReadingTracker.Repositories;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingTracker.Services.ConsoleUI
{
    internal class BookUI
    {
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

        public static void EditBooks(Tracker tracker)
        {
            string nomeMenu = "EDITANDO LIVRO";
            Book book = PickABook(tracker);

            Dictionary<string, Action> cOptions = new()
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
                },
                {
                    "Cancelar", () => { }
                }
            };

            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[green]--{nomeMenu}--[/]\nEscolha uma opção (livro selecionado: {book.Name}): ")
                    .AddChoices(cOptions.Keys)
            );
            cOptions[choice].Invoke();
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

        internal static Book PickABook(Tracker tracker)
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
