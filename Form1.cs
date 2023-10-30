using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaPlayer1
{
    public partial class MediaPlayer : Form
    {
        public MediaPlayer()
        {
            InitializeComponent();
        }

        String[] paths, files;

        private void selectMediaBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                files = ofd.SafeFileNames;
                paths = ofd.FileNames;

                // Clear the listBox1 before adding new items
                listBox1.Items.Clear();

                foreach (var file in files)
                {
                    listBox1.Items.Add(file);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;

            // Check if a valid item is selected
            if (selectedIndex >= 0 && selectedIndex < paths.Length)
            {
                // Set the source URL for the MediaElement
                axWindowsMediaPlayer1.URL = paths[selectedIndex];
            }
        }

        private void exitBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}