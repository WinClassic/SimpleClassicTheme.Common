
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.crashDialogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.failMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crashMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.broadcastConfigChangeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemPopupMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crashDialogMenuItem,
            this.configToolStripMenuItem,
            this.systemPopupMenuToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(320, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // crashDialogMenuItem
            // 
            this.crashDialogMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failMenuItem,
            this.crashMenuItem});
            this.crashDialogMenuItem.Name = "crashDialogMenuItem";
            this.crashDialogMenuItem.Size = new System.Drawing.Size(77, 20);
            this.crashDialogMenuItem.Text = "Crash dialog";
            // 
            // failMenuItem
            // 
            this.failMenuItem.Name = "failMenuItem";
            this.failMenuItem.Size = new System.Drawing.Size(101, 22);
            this.failMenuItem.Text = "Fail";
            this.failMenuItem.Click += new System.EventHandler(this.failMenuItem_Click);
            // 
            // crashMenuItem
            // 
            this.crashMenuItem.Name = "crashMenuItem";
            this.crashMenuItem.Size = new System.Drawing.Size(101, 22);
            this.crashMenuItem.Text = "Crash";
            this.crashMenuItem.Click += new System.EventHandler(this.crashMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.broadcastConfigChangeMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // broadcastConfigChangeMenuItem
            // 
            this.broadcastConfigChangeMenuItem.Name = "broadcastConfigChangeMenuItem";
            this.broadcastConfigChangeMenuItem.Size = new System.Drawing.Size(193, 22);
            this.broadcastConfigChangeMenuItem.Text = "Broadcast config change";
            this.broadcastConfigChangeMenuItem.Click += new System.EventHandler(this.broadcastConfigChangeMenuItem_Click);
            // 
            // systemPopupMenuToolStripMenuItem
            // 
            this.systemPopupMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuToolStripMenuItem});
            this.systemPopupMenuToolStripMenuItem.Name = "systemPopupMenuToolStripMenuItem";
            this.systemPopupMenuToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.systemPopupMenuToolStripMenuItem.Text = "System popup menu";
            // 
            // openMenuToolStripMenuItem
            // 
            this.openMenuToolStripMenuItem.Name = "openMenuToolStripMenuItem";
            this.openMenuToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.openMenuToolStripMenuItem.Text = "Open menu";
            this.openMenuToolStripMenuItem.Click += new System.EventHandler(this.openMenuToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 24);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "SimpleClassicTheme.Common Example";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem crashDialogMenuItem;
        private System.Windows.Forms.ToolStripMenuItem failMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crashMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem broadcastConfigChangeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemPopupMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuToolStripMenuItem;
    }
}

