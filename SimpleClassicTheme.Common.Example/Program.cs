using SimpleClassicTheme.Common.ErrorHandling;

using System;
using System.Windows.Forms;

namespace SimpleClassicTheme.Common.Example
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var handler = new ErrorHandler();
            handler.SubscribeToErrorEvents();

            Application.Run(new MainForm());
        }
    }
}