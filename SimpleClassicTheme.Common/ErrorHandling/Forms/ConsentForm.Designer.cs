
namespace SimpleClassicTheme.Common.ErrorHandling.Forms
{
    partial class ConsentForm
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
            this.continueButton = new System.Windows.Forms.Button();
            this.sentryCheckBox = new System.Windows.Forms.CheckBox();
            this.descriptionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.trackSessionCheckBox = new System.Windows.Forms.CheckBox();
            this.trackSessionLabel = new System.Windows.Forms.Label();
            this.sentryOptionsPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.sentryOptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // continueButton
            // 
            this.continueButton.Location = new System.Drawing.Point(328, 216);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(75, 23);
            this.continueButton.TabIndex = 0;
            this.continueButton.Text = "&Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // sentryCheckBox
            // 
            this.sentryCheckBox.AutoSize = true;
            this.sentryCheckBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sentryCheckBox.Location = new System.Drawing.Point(16, 56);
            this.sentryCheckBox.Name = "sentryCheckBox";
            this.sentryCheckBox.Size = new System.Drawing.Size(141, 17);
            this.sentryCheckBox.TabIndex = 1;
            this.sentryCheckBox.Text = "Enable use of Sentry";
            this.sentryCheckBox.UseVisualStyleBackColor = true;
            this.sentryCheckBox.CheckedChanged += new System.EventHandler(this.SentryCheckBox_CheckedChanged);
            // 
            // descriptionLinkLabel
            // 
            this.descriptionLinkLabel.LinkArea = new System.Windows.Forms.LinkArea(101, 10);
            this.descriptionLinkLabel.Location = new System.Drawing.Point(16, 16);
            this.descriptionLinkLabel.Name = "descriptionLinkLabel";
            this.descriptionLinkLabel.Size = new System.Drawing.Size(384, 32);
            this.descriptionLinkLabel.TabIndex = 2;
            this.descriptionLinkLabel.TabStop = true;
            this.descriptionLinkLabel.Text = "SCT programs use Sentry for checking the stability of the programs in real world " +
    "use. To learn more, click here.";
            this.descriptionLinkLabel.UseCompatibleTextRendering = true;
            this.descriptionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DescriptionLinkLabel_LinkClicked);
            // 
            // trackSessionCheckBox
            // 
            this.trackSessionCheckBox.AutoSize = true;
            this.trackSessionCheckBox.Location = new System.Drawing.Point(0, 0);
            this.trackSessionCheckBox.Name = "trackSessionCheckBox";
            this.trackSessionCheckBox.Size = new System.Drawing.Size(175, 17);
            this.trackSessionCheckBox.TabIndex = 3;
            this.trackSessionCheckBox.Text = "Release health (track sessions)";
            this.trackSessionCheckBox.UseVisualStyleBackColor = true;
            // 
            // trackSessionLabel
            // 
            this.trackSessionLabel.Location = new System.Drawing.Point(16, 24);
            this.trackSessionLabel.Name = "trackSessionLabel";
            this.trackSessionLabel.Size = new System.Drawing.Size(368, 48);
            this.trackSessionLabel.TabIndex = 4;
            this.trackSessionLabel.Text = "Release health will provide insight into the impact of crashes and bugs as it rel" +
    "ates to user experience, and reveal trends with each new issue through the relea" +
    "se details, graphs, and filters.";
            // 
            // sentryOptionsPanel
            // 
            this.sentryOptionsPanel.Controls.Add(this.trackSessionCheckBox);
            this.sentryOptionsPanel.Controls.Add(this.trackSessionLabel);
            this.sentryOptionsPanel.Enabled = false;
            this.sentryOptionsPanel.Location = new System.Drawing.Point(16, 88);
            this.sentryOptionsPanel.Name = "sentryOptionsPanel";
            this.sentryOptionsPanel.Size = new System.Drawing.Size(384, 72);
            this.sentryOptionsPanel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(384, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "In case of a crash you will be asked separately how much information about the cr" +
    "ash you want to submit.";
            // 
            // ConsentForm
            // 
            this.AcceptButton = this.continueButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 248);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sentryOptionsPanel);
            this.Controls.Add(this.descriptionLinkLabel);
            this.Controls.Add(this.sentryCheckBox);
            this.Controls.Add(this.continueButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsentForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure Sentry telemetry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsentForm_FormClosing);
            this.Load += new System.EventHandler(this.ConsentForm_Load);
            this.sentryOptionsPanel.ResumeLayout(false);
            this.sentryOptionsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.CheckBox sentryCheckBox;
        private System.Windows.Forms.LinkLabel descriptionLinkLabel;
        private System.Windows.Forms.CheckBox trackSessionCheckBox;
        private System.Windows.Forms.Label trackSessionLabel;
        private System.Windows.Forms.Panel sentryOptionsPanel;
        private System.Windows.Forms.Label label2;
    }
}