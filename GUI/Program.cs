using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var splash = new SplashScreen())
            {
                var timer = new System.Windows.Forms.Timer { Interval = 3000 }; // 3 segundos
                timer.Tick += (s, e) =>
                {
                    timer.Stop();
                    splash.Close();
                };

                splash.Show();
                timer.Start();

                Application.Run(splash);
            }

            Application.Run(new FLogin());

        }
    }
}
