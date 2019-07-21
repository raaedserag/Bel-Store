using System;
using System.Windows.Forms;
using Belal.Controller;
using Belal.Controller.ادارة_المنتجات;
using Belal.Controller.الرئسيه;
namespace Belal
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
            Application.Run(new الرئسية());

        }
    }
}
