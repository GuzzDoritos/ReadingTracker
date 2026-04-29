namespace ReadingTracker.Classes
{
    internal class Book(string name, int totalChars)
    {
        public string Name { get; private set; } = name;
        public int TotalChars { get; private set; } = totalChars;

        public int ReadChars { get; private set; }

        public bool IsCompleted { get; private set; }

        public double CalculatePercentRead()
        {
            if (TotalChars == 0) return 0;
            return (double) ReadChars / TotalChars * 100;
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
