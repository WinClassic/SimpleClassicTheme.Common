using SimpleClassicTheme.Common.Configuration;
using SimpleClassicTheme.Common.Native.Controls;

using System;
using System.Drawing;
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

        private void broadcastConfigChangeMenuItem_Click(object sender, EventArgs e)
        {
            GlobalConfig.Default.WriteToRegistry();
        }

        private void Config_Changed(object sender, ConfigChangedEventArgs e)
        {
            MessageBox.Show($"Receive config change: {e.Type}");
        }

        private void crashMenuItem_Click(object sender, EventArgs e)
        {
            new Thread(() => throw new Exception("This is a test exception in another thread")).Start();
        }

        private void failMenuItem_Click(object sender, EventArgs e)
        {
            throw new Exception("This is a test exception.");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GlobalConfig.Default.Changed += Config_Changed;
        }

        private void openMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemPopupMenuItem item = new SystemPopupMenuItem() { Text = "Item", Id = 1 };

            var menu = new SystemPopupMenu()
            {
                item,
                new SystemPopupMenuItem { Text = "Disabled Item", Enabled = false },
                new SystemPopupMenuItem { Text = "Checked Item", Checked = true },
                new SystemPopupMenuItem { Image = Properties.Resources.ItemBitmap },
                new SystemPopupMenuSeparator(),
                new SystemPopupMenuItem {
                    Text = "Item with sub menu",
                    SubMenu = new () { new SystemPopupMenuItem() { Text = "Item 3" } }
                },
                new SystemPopupMenuItem() {
                    Text = "Item in another column",
                    Break = SystemPopupMenuItemBreak.MenuBarBreak,
                }
            };

            item.Click += Item_Click;

            menu.Show(this, 0, 0);
        }

        private void Item_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click");
        }
    }
}