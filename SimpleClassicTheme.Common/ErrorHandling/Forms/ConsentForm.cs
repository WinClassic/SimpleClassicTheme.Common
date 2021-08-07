using SimpleClassicTheme.Common.Configuration;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleClassicTheme.Common.ErrorHandling.Forms
{
    public partial class ConsentForm : Form
    {
        public ConsentForm()
        {
            InitializeComponent();
        }

        private void DescriptionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ErrorHandler.ShowErrorCollectionDetails();
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SentryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            sentryOptionsPanel.Enabled = sentryCheckBox.Checked;
        }

        private void ConsentForm_Load(object sender, EventArgs e)
        {
            sentryCheckBox.Checked = GlobalConfig.Default.EnableSentry == SentryConsent.Accepted;
            trackSessionCheckBox.Checked = GlobalConfig.Default.EnableSessionTracking;
        }

        private void ConsentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalConfig.Default.EnableSentry = sentryCheckBox.Checked
                ? SentryConsent.Accepted
                : SentryConsent.Declined;

            GlobalConfig.Default.EnableSessionTracking = trackSessionCheckBox.Checked;

            GlobalConfig.Default.WriteToRegistry();
        }
    }
}
