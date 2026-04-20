using System;
using System.Windows.Forms;


namespace StudentTracker
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Налаштування конфігурації для сучасних версій .NET
            ApplicationConfiguration.Initialize();

            // Запускаємо нашу головну форму
            Application.Run(new MainForm());
        }
    }
}