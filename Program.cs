using FinalWindow.Model;
using FinalWindow.View.Director;
using FinalWindow.View.Director.FacilityCRUD;
using FinalWindow.View.Director.List;
using FinalWindow.View.Manager.ShiftCRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalWindow
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
           

            Application.Run(new LoginForm());
            //Application.Run(new ShiftWorkForm());
            Application.Run(new ListLongContractForm());
        }
    }
}
