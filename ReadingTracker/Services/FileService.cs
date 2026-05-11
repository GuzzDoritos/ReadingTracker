using ReadingTracker.Data;
using ReadingTracker.Repositories;
using Spectre.Console;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace ReadingTracker.Services
{

    internal class SaveData() 
    {
        public List<Book> Books { get; set; } = [];
        public List<TrackedDay> Days { get; set; } = [];
    }

    internal class FileService
    {
        private readonly static JsonSerializerOptions options = new()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.Preserve,
            IncludeFields = true
        };

        internal static void Save(Tracker tracker) {

            SaveData dataToSave = new()
            {
                Books = tracker.GetBookLibrary().GetBookList(),
                Days = tracker.GetAll()
            };

            string jsonString = JsonSerializer.Serialize(dataToSave, options);

            File.WriteAllText("data.json", jsonString);

        }

        internal static void Load(Tracker tracker) 
        { 
            if (!File.Exists("data.json"))
            {
                AnsiConsole.MarkupLine("[bold red]Nenhum arquivo de salvamento encontrado. Iniciando com um tracker vazio.[/]");
                return;
            }

            string jsonString = File.ReadAllText("data.json");
            var loadedData = JsonSerializer.Deserialize<SaveData>(jsonString, options);

            if (loadedData != null)
            {
                tracker.Clear();

                tracker.Load(loadedData.Books, loadedData.Days);
            }
        }
    }
}
