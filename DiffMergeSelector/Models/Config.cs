using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiffMergeSelector.Models;
using System.IO;
using System.Windows.Forms;
using DiffMergeSelector.Services;

namespace DiffMergeSelector.Models
{
    public class Config
    {
        public ToolParameters[] ToolParameters { get; set; }

        public DateTime LastChoiceValid { get; set; }

        public int LastChoiceToolIndex { get; set; }

        public static Config _instance;

        public static Config Instance {
            get
            {
                return _instance ?? Load();
            }
            private set
            {
                _instance = value;
            } 
        }

        private Config()
        {
            Instance = this;
            ToolParameters = new ToolParameters[] { };
        }

        private static Config Load()
        {
            var configname = Path.Combine(Application.StartupPath, ".config");
            Config conf = null;
            try
            {
                if (File.Exists(configname))
                {
                    var data = File.ReadAllText(configname);
                    conf = XmlSerializer.Deserialize<Config>(data);
                }
                else
                {
                    conf = new Config();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading file .config" + Environment.NewLine + ex.Message);
                conf = new Config();
            }

            return conf;
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
