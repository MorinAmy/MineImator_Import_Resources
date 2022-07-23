using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineImator_Import_Resources
{
    public partial class UserUI : UserControl
    {
        public UserUI()
        {
            InitializeComponent();
        }

        public string projectFilePath;

        private void UserUI_Load(object sender, EventArgs e)
        {
            BatchFiles2.Height = 17;

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            //pictureBox1.BackgroundImage = Image.FromFile(Path.GetDirectoryName(projectFilePath) + "\\" + "thumbnail.png");
        }

        private void projectVideo_widthText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
            if (projectVideo_widthText.Text.Length > 0)
            {
                if (projectVideo_widthText.Text[0] == '0')
                {
                    projectVideo_widthText.Text = projectVideo_widthText.Text.Substring(0, 0);
                }
            }
        }

        private void projectVideo_heightText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
            if (projectVideo_heightText.Text.Length > 0)
            {
                if (projectVideo_heightText.Text[0] == '0')
                {
                    projectVideo_heightText.Text = projectVideo_heightText.Text.Substring(0, 0);
                }
            }
        }

        private void projectTempoText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
            if (projectTempoText.Text.Length > 0)
            {
                if (projectTempoText.Text[0] == '0')
                {
                    projectTempoText.Text = projectTempoText.Text.Substring(0, 0);
                }
            }
        }

        public void ProjectWrites(object sender, EventArgs e)
        {
            MessageBox.Show(projectNameText.Text);
        }

        private void FrameSync_CheckedChanged(object sender, EventArgs e)
        {
            if (FrameSync.Checked == true)
            {
                Frame.Enabled = false;
            }
            else if (FrameSync.Checked == false)
            {
                Frame.Enabled = true;
            }
        }
    }
}