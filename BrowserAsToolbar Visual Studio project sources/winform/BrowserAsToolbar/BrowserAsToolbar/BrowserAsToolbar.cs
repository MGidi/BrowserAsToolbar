using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserAsToolbar
{
    public partial class BrowserAsToolbar : Form
    {
        public BrowserAsToolbar()
        {
            InitializeComponent();
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                this.webBrowser1.Navigate(args[1]);
            }
            else
            {
                MessageBox.Show("no arguments provided, please re-run with a URL to display as like: BrowserAsToolbar.exe http://google.com");
                Environment.Exit(0);
            }
        }

        private void BrowserAsToolbar_Load(object sender, EventArgs e)
        {
            this.WindowState = Properties.Settings.Default.F1State;
            this.Location = Properties.Settings.Default.F1Location;
            this.Size = Properties.Settings.Default.F1Size;
        }

        private void BrowserAsToolbar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.F1State = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                // save location and size if the state is normal
                Properties.Settings.Default.F1Location = this.Location;
                Properties.Settings.Default.F1Size = this.Size;
            }
            else
            {
                // save the RestoreBounds if the form is minimized or maximized!
                Properties.Settings.Default.F1Location = this.RestoreBounds.Location;
                Properties.Settings.Default.F1Size = this.RestoreBounds.Size;
            }

            // don't forget to save the settings
            Properties.Settings.Default.Save();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
