using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GestionClinic_WIN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Loading());// Minimale:25°C, Maximale:42 et Normale:36,1 °C et 37,8 °C
            //Application.Run(new frmMainMenu());
        }
    }
}
