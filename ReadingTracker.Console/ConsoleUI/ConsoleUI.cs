using ReadingTracker.Core.ConsoleUI;
using ReadingTracker.Core.Services;
using Spectre.Console;

namespace ReadingTracker.Console.ConsoleUI
{
    internal class ConsoleUI
    {
        public static void Start(ReadingService tracker)
        {
            string nomeMenu = "MENU PRINCIPAL";
            RunMenu(nomeMenu, new()
            {
                { "Gerenciar dias de leitura", () => ManageReadingDay(tracker) },
                { "Gerenciar livros", () => ManageBooks(tracker) },
                { "Imprimir sumário", () => ReadingDayUI.PrintSummary(tracker) },
            }, "Sair");
        }

        public static void ManageReadingDay(ReadingService tracker)
        {
            string nomeMenu = "GERENCIAR DIAS DE LEITURA";
            RunMenu(nomeMenu, new()
            {
                { "Adicionar um dia de leitura", () => ReadingDayUI.AddReadingDay(tracker) },
                { "Editar ou remover um dia de leitura", () => ReadingDayUI.EditReadingDay(tracker) }
            }, "Voltar");

        }


        public static void ManageBooks(ReadingService tracker)
        {
            string nomeMenu = "GERENCIAR LIVROS";
            RunMenu(nomeMenu, new()
            {
                { "Adicionar livros", () => BookUI.AddBook(tracker) },
                { "Remover ou editar livros", () => BookUI.EditBooks(tracker)  },
                { "Listar livros", () => BookUI.PrintBooks(tracker) }
            }, "Voltar");
        }



        private static void RunMenu(string menuName, Dictionary<string, Action> options, string exit, string prompt = "Escolha uma opção:")
        {
            Dictionary<string, Action> cOptions = new(options)
            {
                { "Limpar console", () => { AnsiConsole.Clear(); } },
                { exit, () => { } }
            };
            string choice = GetChoice(menuName, prompt, cOptions);

            while (choice != exit)
            {
                cOptions[choice].Invoke();
                choice = GetChoice(menuName, prompt, cOptions);
            }
        }

        internal static string GetChoice(string menuName, string prompt, Dictionary<string, Action> options)
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[green]--{menuName}--[/]\n{prompt}")
                    .AddChoices(options.Keys)
            );
        }



    }
}
