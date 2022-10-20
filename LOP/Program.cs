using System.Runtime.InteropServices;

namespace LOP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [STAThread]
        static void Main()
        {
            AllocConsole();
            MainUpdater.Instance.Init();
            MainUpdater.Instance.Start();
            Thread updateThread = new Thread(new ThreadStart(update));
            updateThread.Start();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            FreeConsole();
            Environment.Exit(0);
        }
        private static void update()
        {
            while(true)
            {
                MainUpdater.Instance.Update();
                Thread.CurrentThread.Join(100);
            }
        }
    }
}