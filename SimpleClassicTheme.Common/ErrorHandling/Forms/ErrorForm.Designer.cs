
namespace SimpleClassicTheme.Common.ErrorHandling.Forms
{
    partial class ErrorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.headingLabel = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.dontSendButton = new System.Windows.Forms.Button();
            this.dontAskAgainCheckBox = new System.Windows.Forms.CheckBox();
            this.contentPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.descriptionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.submitLogCheckBox = new System.Windows.Forms.CheckBox();
            this.viewDetailsButton = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.contentPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Location = new System.Drawing.Point(0, 0);
            this.iconPictureBox.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.iconPictureBox.MinimumSize = new System.Drawing.Size(32, 32);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconPictureBox.TabIndex = 0;
            this.iconPictureBox.TabStop = false;
            // 
            // headingLabel
            // 
            this.headingLabel.AutoSize = true;
            this.headingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headingLabel.Location = new System.Drawing.Point(0, 0);
            this.headingLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(176, 13);
            this.headingLabel.TabIndex = 1;
            this.headingLabel.Text = "It seems like {0} has crashed.";
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sendButton.Location = new System.Drawing.Point(295, 8);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // dontSendButton
            // 
            this.dontSendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dontSendButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dontSendButton.Location = new System.Drawing.Point(214, 8);
            this.dontSendButton.Name = "dontSendButton";
            this.dontSendButton.Size = new System.Drawing.Size(75, 23);
            this.dontSendButton.TabIndex = 1;
            this.dontSendButton.Text = "Don\'t send";
            this.dontSendButton.UseVisualStyleBackColor = true;
            // 
            // dontAskAgainCheckBox
            // 
            this.dontAskAgainCheckBox.AutoSize = true;
            this.dontAskAgainCheckBox.Enabled = false;
            this.dontAskAgainCheckBox.Location = new System.Drawing.Point(0, 88);
            this.dontAskAgainCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.dontAskAgainCheckBox.Name = "dontAskAgainCheckBox";
            this.dontAskAgainCheckBox.Size = new System.Drawing.Size(100, 17);
            this.dontAskAgainCheckBox.TabIndex = 0;
            this.dontAskAgainCheckBox.Text = "Don\'t ask again";
            this.dontAskAgainCheckBox.UseVisualStyleBackColor = true;
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.AutoSize = true;
            this.contentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contentPanel.Controls.Add(this.headingLabel);
            this.contentPanel.Controls.Add(this.descriptionLinkLabel);
            this.contentPanel.Controls.Add(this.submitLogCheckBox);
            this.contentPanel.Controls.Add(this.dontAskAgainCheckBox);
            this.contentPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.contentPanel.Location = new System.Drawing.Point(40, 0);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(330, 105);
            this.contentPanel.TabIndex = 0;
            this.contentPanel.WrapContents = false;
            // 
            // descriptionLinkLabel
            // 
            this.descriptionLinkLabel.AutoSize = true;
            this.descriptionLinkLabel.LinkArea = new System.Windows.Forms.LinkArea(151, 10);
            this.descriptionLinkLabel.Location = new System.Drawing.Point(0, 21);
            this.descriptionLinkLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.descriptionLinkLabel.Name = "descriptionLinkLabel";
            this.descriptionLinkLabel.Size = new System.Drawing.Size(322, 42);
            this.descriptionLinkLabel.TabIndex = 3;
            this.descriptionLinkLabel.Text = "{0} exited due to an error. If you\'d like click on Send, to send us an error repo" +
    "rt over Sentry. To learn more about the data collected click here.";
            this.descriptionLinkLabel.UseCompatibleTextRendering = true;
            this.descriptionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DescriptionLinkLabel_LinkClicked);
            // 
            // submitLogCheckBox
            // 
            this.submitLogCheckBox.AutoSize = true;
            this.submitLogCheckBox.Checked = true;
            this.submitLogCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.submitLogCheckBox.Location = new System.Drawing.Point(0, 71);
            this.submitLogCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.submitLogCheckBox.Name = "submitLogCheckBox";
            this.submitLogCheckBox.Size = new System.Drawing.Size(167, 17);
            this.submitLogCheckBox.TabIndex = 4;
            this.submitLogCheckBox.Text = "Submit log file with error report";
            this.submitLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // viewDetailsButton
            // 
            this.viewDetailsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewDetailsButton.Location = new System.Drawing.Point(0, 8);
            this.viewDetailsButton.Name = "viewDetailsButton";
            this.viewDetailsButton.Size = new System.Drawing.Size(75, 23);
            this.viewDetailsButton.TabIndex = 3;
            this.viewDetailsButton.Text = "View Details";
            this.viewDetailsButton.UseVisualStyleBackColor = true;
            this.viewDetailsButton.Click += new System.EventHandler(this.ViewDetailsButton_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.iconPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.contentPanel, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.MaximumSize = new System.Drawing.Size(370, 370);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(370, 118);
            this.tableLayoutPanel.TabIndex = 4;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.viewDetailsButton);
            this.buttonPanel.Controls.Add(this.dontSendButton);
            this.buttonPanel.Controls.Add(this.sendButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(8, 126);
            this.buttonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPanel.MinimumSize = new System.Drawing.Size(0, 31);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(370, 31);
            this.buttonPanel.TabIndex = 5;
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(386, 165);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.buttonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "{0} crashed";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ErrorForm_FormClosing);
            this.Load += new System.EventHandler(this.ErrorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.Label headingLabel;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button dontSendButton;
        private System.Windows.Forms.CheckBox dontAskAgainCheckBox;
        private System.Windows.Forms.FlowLayoutPanel contentPanel;
        private System.Windows.Forms.Button viewDetailsButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.LinkLabel descriptionLinkLabel;
        private System.Windows.Forms.CheckBox submitLogCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel buttonPanel;
    }
}