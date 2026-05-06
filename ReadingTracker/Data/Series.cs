using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ReadingTracker.Data
{
    internal class Series
    {
        public int SeriesID { get; set; } = Guid.NewGuid().GetHashCode();
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public List<Genre> Genre { get; set; } = [];
        public List<Book> Books { get; set; } = [];

        public Series() { }
    }
}
