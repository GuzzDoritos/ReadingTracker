using ReadingTracker.Data;
using Spectre.Console;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace ReadingTracker.Repositories
{

    internal class SaveData() 
    {
        public List<Book> Books { get; set; } = [];
        public List<TrackedDay> Days { get; set; } = [];
    }

    internal class JsonRepository : IReadingRepository
    {

        private readonly List<Book> _bookList = [];
        private readonly List<TrackedDay> _daysList = [];

        public List<Book> GetBooks()
        {
            return [.. _bookList];
        }

        public void AddBook(Book book)
        {
            if (_bookList.Count == 0)
            {
                book.BookID = 1;
            }
            else
            {
                book.BookID = _bookList.Max(b => b.BookID) + 1;
            }

            _bookList.Add(book); 
            Save();
        }

        public void RemoveBook(int bookId)
        {
            _bookList.RemoveAll(b => b.BookID == bookId);
            Save();
        }

        public List<TrackedDay> GetDays()
        {
            return [.. _daysList];
        }

        public void AddDay(TrackedDay day)
        {
            if (_daysList.Count == 0)
            {
                day.DayId = 1;
            }
            else
            {
                day.DayId = _daysList.Max(d => d.DayId) + 1;
            }

            _daysList.Add(day); _daysList.Sort((d1, d2) => d1.Date.CompareTo(d2.Date));
            Save();
        }

        public void RemoveDay(int dayId)
        {
            throw new NotImplementedException();
        }

        private readonly static JsonSerializerOptions options = new()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true,
            IncludeFields = true
        };
        internal void Save()
        {

            SaveData dataToSave = new()
            {
                Books = _bookList,
                Days = _daysList
            };

            string jsonString = JsonSerializer.Serialize(dataToSave, options);

            File.WriteAllText("data.json", jsonString);

        }
        internal void Load()
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
                _bookList.Clear();
                _daysList.Clear();

                _bookList.AddRange(loadedData.Books);
                _daysList.AddRange(loadedData.Days);
            }
        }

        public int CalculateAlreadyRead(Book book)
        {
            return GetDays()
                .Where(d => d.BookId == book.BookID)
                .Sum(d => d.CharsRead);
        }
    }
}
