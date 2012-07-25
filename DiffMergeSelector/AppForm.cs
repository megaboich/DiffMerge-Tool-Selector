using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DiffMergeSelector.Services;

namespace DiffMergeSelector
{
    public partial class AppForm : Form
    {
        public static Lazy<AppForm> Instance;

        public bool AutoCloseWhenFinished { get; set; }

        public AppForm(bool showMainForm)
        {
            Instance = new Lazy<AppForm>(() => this);
            
            InitializeComponent();
            AutoCloseWhenFinished = false;

            if (showMainForm)
            {
                ShowMainForm();
            }
        }

        private void AppForm_Load(object sender, EventArgs e)
        {

        }

        public void ShowMainForm()
        {
            new MainForm().Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ToolExecutionManager.CheckStatus((status) =>
            {
                switch (status.CheckStatusCode)
                {
                    case CheckStatusCode.AllFinished:
                        if (AutoCloseWhenFinished)
                        {
                            Close();
                        }
                        break;
                    case CheckStatusCode.Started:
                        new ToolNotificationForm(status.CurrentToolResult.ToolParameters, 5).Show();
                        AutoCloseWhenFinished = true;
                        break;
                    case CheckStatusCode.Error:
                        var ex = (Exception)status.CurrentToolResult.Exception;
                        MessageBox.Show(ex.Message);
                        break;
                }
            });
        }

        private void AppForm_VisibleChanged(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
