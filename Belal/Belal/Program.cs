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
<<<<<<< HEAD
            Application.Run(new Receipts());
=======
            Application.Run(new FRM_Receipts());
>>>>>>> 9543968ab4fbc4a6fe84765f19b24b43730b5705
        }
    }
}
