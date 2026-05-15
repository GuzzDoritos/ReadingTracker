using System.Text.Json.Serialization;

namespace ReadingTrackerConsole.Data
{
    public class Book
    {
        [JsonInclude]
        public int BookID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public Genre BookGenre { get; set; }
        public int TotalChars { get; set; }
        public bool IsCompleted { get; set; }

        public Book() { }

        internal Book(string name, string author, Genre genre, int totalChars)
        {
            Name = name;
            Author = author;
            BookGenre = genre;
            TotalChars = totalChars;
        }

        public double CalculatePercentRead(int readChars)
        {
            if (TotalChars == 0) return 0;
            return (double)readChars / TotalChars * 100;
        }
    }
}