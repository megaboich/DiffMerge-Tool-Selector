using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiffMergeSelector.Models;
using System.Threading;

namespace DiffMergeSelector.Services
{
    public class ToolExecution
    {
        private string[] _parameters;

        private static Queue<ToolExecutionResult> _tasksResultsQueue = new Queue<ToolExecutionResult>();
        private static List<ToolExecution> _executionTools = new List<ToolExecution>();

        public ToolExecution()
        {
            _executionTools.Add(this); //store the pointer to prevent GC from disposing it
        }

        private string GetParam(int index)
        {
            if (index >= _parameters.Length)
            {
                return string.Empty;
            }

            return "\"" + _parameters[index] + "\"";
        }

        public void ExecuteTool(ToolParameters tp, string[] parameters, Action<ToolExecutionResult> callback)
        {
            _parameters = parameters;
            var commandLine = tp.CommandLine;

            if (string.IsNullOrWhiteSpace(commandLine))
            {
                commandLine = "%1 %2 %3 %4 %5 %6 %7 %8 %9 %10 %11 %12 %13 %14 %15 %16 %17 %18 %19 %20";
            }

            commandLine = commandLine
                .Replace("%20", GetParam(19))
                .Replace("%19", GetParam(18))
                .Replace("%18", GetParam(17))
                .Replace("%17", GetParam(16))
                .Replace("%16", GetParam(15))
                .Replace("%15", GetParam(14))
                .Replace("%14", GetParam(13))
                .Replace("%13", GetParam(12))
                .Replace("%12", GetParam(11))
                .Replace("%11", GetParam(10))
                .Replace("%10", GetParam(9))
                .Replace("%1", GetParam(0))
                .Replace("%2", GetParam(1))
                .Replace("%3", GetParam(2))
                .Replace("%4", GetParam(3))
                .Replace("%5", GetParam(4))
                .Replace("%6", GetParam(5))
                .Replace("%7", GetParam(6))
                .Replace("%8", GetParam(7))
                .Replace("%9", GetParam(8))
                ;

            new Thread(() =>
            {
                try
                {
                    var process = System.Diagnostics.Process.Start(tp.Path, commandLine);

                    callback(new ToolExecutionResult(this, tp, ToolExecutionStatus.Started));

                    process.WaitForExit();

                    callback(new ToolExecutionResult(this, tp, ToolExecutionStatus.FinishedSuccess));
                }
                catch (Exception ex)
                {
                    callback(new ToolExecutionResult(this, tp, ToolExecutionStatus.Error)
                    {
                        Exception = ex,
                    });
                }
            }).Start();
        }

    }
}
