using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace SimpleClassicTheme.Common.ErrorHandling.Forms
{
    public partial class ErrorForm : Form
    {
        private readonly ErrorDetails _details;

        public ErrorForm()
        {
            InitializeComponent();
        }

        public ErrorForm(ErrorDetails details) : this()
        {
            _details = details;
        }

        private static string ApplicationName
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                var attribute = assembly.GetCustomAttribute<AssemblyProductAttribute>();
                return attribute.Product;
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_details.Exception == null)
            {
                MessageBox.Show(
                    this,
                    "No report could be sent because the application didn't provide an exception.",
                    "Report failed to send",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                ErrorHandler.SubmitError(_details, submitLogCheckBox.Checked);
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show(
                    this,
                    "Report has been sent successfully.",
                    "Report sent",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    this,
                    "We failed to send the error report. Please check the application logs and explain this occurrance over at GitHub.",
                    "This is embarrassing...",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            if (_details.Fatal)
            {
                Close();
            }
        }

        private void DescriptionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(this,
                Properties.Resources.ErrorForm_DataCollection,
                "Data collected",
                MessageBoxButtons.OK,
                MessageBoxIcon.None);
        }

        private void ErrorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                e.Cancel = true;
            }
            else if (_details.Fatal)
            {
                Environment.Exit(1);
            }
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            iconPictureBox.Image = _details.Fatal
                ? Properties.Resources.CrashIcon
                : Properties.Resources.ProblemIcon;

            LoadStrings();
        }

        private void LoadStrings()
        {
            var keyType = _details.Fatal ? "Crash" : "Problem";

            var titleString = Properties.Resources.ResourceManager.GetString($"ErrorForm_{keyType}_Title");
            Text = string.Format(titleString, ApplicationName);

            var headingString = Properties.Resources.ResourceManager.GetString($"ErrorForm_{keyType}_Header");
            headingLabel.Text = string.Format(headingString, ApplicationName);

            var descriptionString = Properties.Resources.ResourceManager.GetString($"ErrorForm_{keyType}_Description");
            descriptionLinkLabel.Text = string.Format(descriptionString, ApplicationName);

            var linkAreaString = Properties.Resources.ResourceManager.GetString($"ErrorForm_{keyType}_DescriptionLink");
            descriptionLinkLabel.LinkArea = ParseLinkArea(linkAreaString);
        }

        private LinkArea ParseLinkArea(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                var str = "click here";
                var index = descriptionLinkLabel.Text.IndexOf(str);
                return new LinkArea(index, str.Length);
            }
            else
            {
                var split = value.Split(',');
                var index = int.Parse(split[0]);
                var length = int.Parse(split[1]);
                return new(index, length);
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            sendButton.Text = "Sending...";

            // Disable UI
            Enabled = false;
            ControlBox = false;

            backgroundWorker.RunWorkerAsync();
        }

        private void ViewDetailsButton_Click(object sender, EventArgs e)
        {
            using (var detailsForm = new ErrorDetailsForm(_details.Exception))
            {
                detailsForm.ShowDialog();
            }
        }
    }
}