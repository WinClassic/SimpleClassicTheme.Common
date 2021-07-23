
namespace SimpleClassicTheme.Common.Example
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.broadcastConfigButton = new System.Windows.Forms.Button();
            this.crashButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.failButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // broadcastConfigButton
            // 
            this.broadcastConfigButton.Location = new System.Drawing.Point(3, 3);
            this.broadcastConfigButton.Name = "broadcastConfigButton";
            this.broadcastConfigButton.Size = new System.Drawing.Size(314, 23);
            this.broadcastConfigButton.TabIndex = 0;
            this.broadcastConfigButton.Text = "Broadcast global config change";
            this.broadcastConfigButton.UseVisualStyleBackColor = true;
            this.broadcastConfigButton.Click += new System.EventHandler(this.BroadcastConfigButton_Click);
            // 
            // crashButton
            // 
            this.crashButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.crashButton.Location = new System.Drawing.Point(3, 32);
            this.crashButton.Name = "crashButton";
            this.crashButton.Size = new System.Drawing.Size(314, 23);
            this.crashButton.TabIndex = 1;
            this.crashButton.Text = "Crash";
            this.crashButton.UseVisualStyleBackColor = true;
            this.crashButton.Click += new System.EventHandler(this.CrashButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.broadcastConfigButton);
            this.flowLayoutPanel1.Controls.Add(this.crashButton);
            this.flowLayoutPanel1.Controls.Add(this.failButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(320, 91);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // failButton
            // 
            this.failButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.failButton.Location = new System.Drawing.Point(3, 61);
            this.failButton.Name = "failButton";
            this.failButton.Size = new System.Drawing.Size(314, 23);
            this.failButton.TabIndex = 2;
            this.failButton.Text = "Fail";
            this.failButton.UseVisualStyleBackColor = true;
            this.failButton.Click += new System.EventHandler(this.FailButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(320, 91);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "SimpleClassicTheme.Common Example";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button broadcastConfigButton;
        private System.Windows.Forms.Button crashButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button failButton;
    }
}

