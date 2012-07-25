using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DiffMergeSelector.Models;
using DiffMergeSelector;
using DiffMergeSelector.Services;

namespace DiffMergeSelector
{
    public partial class ToolNotificationForm : Form
    {
        private DateTime _timeWhenStartClose;

        public ToolNotificationForm(ToolParameters toolParameters, int seconds)
        {
            InitializeComponent();

            lbText.Text = lbText.Text.Replace("%ToolName%", toolParameters.Name);

            picIcon.Image = toolParameters.GetAssociatedIcon();

            //TODO: somehow identify screen on which diff merge tool opens
            var screen = Screen.PrimaryScreen;
            Top = screen.WorkingArea.Bottom - Height;
            Left = screen.WorkingArea.Right - Width;

            timer1.Enabled = true;
            timer1.Interval = 100;
            timer1.Tag = "wait for close";
            _timeWhenStartClose = DateTime.Now.AddSeconds(seconds);

            TopMost = true;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;

                //p.Style |= 0x40000000; // WS_CHILD
                p.ExStyle |= 0x8000000; // WS_EX_NOACTIVATE - requires Win 2000 or higher :)

                return p;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TopMost = true;
            switch ((string)timer1.Tag)
            {
                case "wait for close":
                    if (DateTime.Now > _timeWhenStartClose)
                    {
                        timer1.Tag = "fadeout";
                        timer1.Interval = 100;
                    }
                    break;
                case "fadeout":
                    Opacity -= 0.07;
                    if (Opacity <= 0)
                    {
                        Close();
                    }
                    break;
            }
        }

        private void ToolNotificationForm_Click(object sender, EventArgs e)
        {
            AppForm.Instance.Value.ShowMainForm();
            Close();
        }

        private void ToolNotificationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
