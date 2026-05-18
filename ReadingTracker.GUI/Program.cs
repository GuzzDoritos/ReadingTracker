using ReadingTracker.Core.Repositories;
using ReadingTracker.Core.Services;

namespace ReadingTracker.GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            JsonRepository repo = new();
            repo.Load();
            ReadingService readingService = new(repo);

            Application.Run(new MainWindow(readingService));
        }
    }
}