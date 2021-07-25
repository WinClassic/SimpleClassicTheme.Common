using SimpleClassicTheme.Common.Configuration;

using System;
using System.Threading;
using System.Windows.Forms;

namespace SimpleClassicTheme.Common.Example
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BroadcastConfigButton_Click(object sender, EventArgs e)
        {
            GlobalConfig.Default.WriteToRegistry();
        }

        private void Config_Changed(object sender, ConfigChangedEventArgs e)
        {
            MessageBox.Show($"Receive config change: {e.Type}");
        }

        private void CrashButton_Click(object sender, EventArgs e)
        {
            new Thread(() => throw new Exception("This is a text exception in another thread")).Start();
        }

        private void FailButton_Click(object sender, EventArgs e)
        {
            throw new Exception("This is a test exception.");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GlobalConfig.Default.Changed += Config_Changed;
        }
    }
}