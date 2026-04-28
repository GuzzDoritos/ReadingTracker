using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingTracker.Classes
{
    public class TrackedDay(string date)
    {
        
        Media? media;
        public string date = date;
        int charsRead;
        double minutesRead;
    }
}
