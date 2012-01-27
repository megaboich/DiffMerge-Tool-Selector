using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DiffMergeSelector.Models;

namespace DiffMergeProxyRunner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] parameters)
        {
            if (parameters.Contains("-r"))
            {
                var config = Config.Load();
                config.LastChoiceValid = DateTime.Now.AddMinutes(-1);
                config.Save();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(parameters));
        }
    }
}
