using Microsoft.VisualBasic.ApplicationServices;

namespace NarodResolutionUtility
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
            var app = new MyApplication();
            app.Run(Environment.GetCommandLineArgs());
        }
    }

    public class MyApplication : WindowsFormsApplicationBase
    {
        public MyApplication()
        {
            this.ShutdownStyle = ShutdownMode.AfterAllFormsClose;
        }
        protected override void OnCreateMainForm()
        {
            MainForm = new singleForm();
        }
    }
}