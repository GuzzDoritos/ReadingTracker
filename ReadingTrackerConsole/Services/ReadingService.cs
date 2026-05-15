using ReadingTrackerConsole.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingTrackerConsole.Services
{
    public class ReadingService(IReadingRepository repository)
    {
       private readonly IReadingRepository _readingRepository = repository;


    }
}
