using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiffMergeProxyRunner.Models;
using System.Windows.Forms;
using System.IO;

namespace DiffMergeProxyRunner.Services
{
    public class ToolsStorage
    {
        public IEnumerable<ToolParameters> Load()
        {
            var configname = Path.Combine(Application.StartupPath, ".config");

            try
            {
                if (File.Exists(configname))
                {
                    var data = File.ReadAllText(configname);
                    var objData = XmlSerializer.Deserialize<ToolParameters[]>(data);

                    return objData.Where(i => i != null);
                }

                return Enumerable.Empty<ToolParameters>();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error while loading file .config" + Environment.NewLine + ex.Message);
                return Enumerable.Empty<ToolParameters>();
            }
        }

        public void Save(ToolParameters[] parameters)
        {
            var configname = Path.Combine(Application.StartupPath, ".config");
            var data = XmlSerializer.Serialize(parameters);
            File.WriteAllText(configname, data);
        }
    }
}
