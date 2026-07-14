namespace _1СBackUpManager
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
            //ApplicationConfiguration.Initialize();
            //Application.Run(new MainForm());
            try
            {
             
                ApplicationConfiguration.Initialize();
                Application.Run(new MainForm());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Помилка");
            }

        }
    }
}