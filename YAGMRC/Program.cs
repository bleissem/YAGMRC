using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace YAGMRC
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            CultureInfo de = CultureInfo.GetCultureInfo("de-de");
            System.Threading.Thread.CurrentThread.CurrentCulture = de;
            System.Threading.Thread.CurrentThread.CurrentUICulture = de;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}