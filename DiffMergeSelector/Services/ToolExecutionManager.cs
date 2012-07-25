using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiffMergeSelector.Models;
using System.Threading;

namespace DiffMergeSelector.Services
{
    public enum ToolExecutionStatus
    {
        Started,
        FinishedSuccess,
        Error
    }

    public class ToolExecutionResult
    {
        public ToolExecutionResult(ToolExecution te, ToolParameters tp, ToolExecutionStatus status)
        {
            ToolExecution = te;
            ToolParameters = tp;
            Status = status;
        }

        public ToolExecution ToolExecution { get; private set; }

        public ToolExecutionStatus Status { get; set; }

        public ToolParameters ToolParameters { get; set; }

        public Exception Exception { get; set; }
    }

    public enum CheckStatusCode
    {
        AllFinished,
        Error,
        Started
    }

    public class CheckStatusResult
    {
        public CheckStatusCode CheckStatusCode { get; set; }

        public ToolExecutionResult CurrentToolResult { get; set; }
    }

    public class ToolExecutionManager
    {
        private static Queue<ToolExecutionResult> _tasksResultsQueue = new Queue<ToolExecutionResult>();
        private static List<ToolExecution> _executionTools = new List<ToolExecution>();

        public static void ExecuteTool(ToolParameters tp, string[] parameters)
        {
            var toolEx = new ToolExecution();
            _executionTools.Add(toolEx);
            toolEx.ExecuteTool(tp, parameters, (result) =>
            {
                lock (_tasksResultsQueue)
                {
                    _tasksResultsQueue.Enqueue(result);
                }
            });
        }

        public static void CheckStatus(Action<CheckStatusResult> callback)
        {
            lock (_tasksResultsQueue)
            {
                if (_tasksResultsQueue.Any())
                {
                    var result = _tasksResultsQueue.Dequeue();
                    switch (result.Status)
                    {
                        case ToolExecutionStatus.Started:
                            callback(new CheckStatusResult
                            {
                                CheckStatusCode = CheckStatusCode.Started,
                                CurrentToolResult = result,
                            });
                            break;

                        case ToolExecutionStatus.FinishedSuccess:
                            _executionTools.Remove(result.ToolExecution);   //remove pointer, let GC to dispose resources

                            if (_executionTools.Count == 0)
                            {
                                callback(new CheckStatusResult
                                {
                                    CheckStatusCode = CheckStatusCode.AllFinished
                                });
                            }

                            break;

                        case ToolExecutionStatus.Error:
                            _executionTools.Remove(result.ToolExecution);   //remove pointer, let GC to dispose resources

                            callback(new CheckStatusResult
                            {
                                CheckStatusCode = CheckStatusCode.Error,
                                CurrentToolResult = result
                            });
                            break;
                    }
                }

                if (_executionTools.Count == 0)
                {
                    callback(new CheckStatusResult
                    {
                        CheckStatusCode = CheckStatusCode.AllFinished
                    });
                }
            }
        }

    }
}
