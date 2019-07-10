using Belal.Controller;
using System;
using System.Windows.Forms;
using Belal.Controller.Invoice;

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
            Application.Run(new FRM_Receipts());
        }
    }
}
