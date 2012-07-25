using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DiffMergeSelector.Models;
using DiffMergeSelector.Services;
using System.Threading;
using System.Diagnostics;

namespace DiffMergeSelector
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] parameters)
        {
            var config = Config.Instance;

            if (parameters.Contains("-r"))
            {
                config.LastChoiceValid = DateTime.Now.AddMinutes(-1);
                config.Save();
                return;
            }

            bool toolExecuted = false;
            if (DateTime.Now < config.LastChoiceValid)
            {
                config.LastChoiceValid = DateTime.Now.AddMinutes(config.LastChoiceDuration);
                config.Save();

                var ti = config.LastChoiceToolIndex;
                var tp = config.ToolParameters[ti];

                toolExecuted = true;
                ToolExecutionManager.ExecuteTool(tp, parameters);
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AppForm(!toolExecuted));
        }
    }
}
