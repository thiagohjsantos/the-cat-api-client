using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatAsService
{
    static class Program
    {
        public static string ApiKey;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Env.TraversePath().Load();
            ApiKey = Environment.GetEnvironmentVariable("API_KEY");

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMainScreen());
        }
    }
}
