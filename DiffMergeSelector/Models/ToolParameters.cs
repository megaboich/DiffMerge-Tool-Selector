using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiffMergeProxyRunner.Models
{
    public enum ToolCategory
    {
        Diff = 0,
        Merge = 1
    }

    public class ToolParameters
    {
        public ToolCategory ToolCategory { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public string CommandLine { get; set; }

        public int OrderIndex { get; set; }
    }
}
