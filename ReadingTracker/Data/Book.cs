namespace ReadingTracker.Data
{
    internal class Book
    {
        public int BookID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TotalChars { get; set; }
        public int ReadChars { get; set; }
        public bool IsCompleted { get; set; }

        public Book() { }

        internal Book(string name, int totalChars)
        {
            Name = name;
            TotalChars = totalChars;
        }

        public double CalculatePercentRead()
        {
            if (TotalChars == 0) return 0;
            return (double)ReadChars / TotalChars * 100;
        }

        public void UpdateProgress(int charsRead)
        {
            ReadChars += charsRead;
            if (ReadChars >= TotalChars)
            {
                ReadChars = TotalChars;
                IsCompleted = true;
            }
        }
    }
}