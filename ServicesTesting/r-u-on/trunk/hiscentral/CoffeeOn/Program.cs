// All rights reserved R-U-ON 2006
// www.r-u-on.com

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CoffeeOn
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
            Application.Run(new CoffeeMachine());
        }
    }
}