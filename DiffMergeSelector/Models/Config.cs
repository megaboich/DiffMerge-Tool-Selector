using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiffMergeProxyRunner.Models;
using System.IO;
using System.Windows.Forms;
using DiffMergeProxyRunner.Services;

namespace DiffMergeSelector.Models
{
    public class Config
    {
        public ToolParameters[] ToolParameters { get; set; }

        public DateTime LastChoiceValid { get; set; }

        public int LastChoiceToolIndex { get; set; }


        private Config()
        {
            ToolParameters = new ToolParameters[] { };
        }

        public static Config Load()
        {
            var configname = Path.Combine(Application.StartupPath, ".config");

            try
            {
                if (File.Exists(configname))
                {
                    var data = File.ReadAllText(configname);
                    var objData = XmlSerializer.Deserialize<Config>(data);

                    return objData;
                }

                return new Config();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading file .config" + Environment.NewLine + ex.Message);
                return new Config();
            }
        }

        public void Save()
        {
            var configname = Path.Combine(Application.StartupPath, ".config");
            var data = XmlSerializer.Serialize(this);
            File.WriteAllText(configname, data);
        }

        public int LastChoiceDuration { get; set; }
    }
}
