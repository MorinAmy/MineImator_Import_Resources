using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineImator_Import_Resources
{
    public partial class PictureSequence : Form
    {
        public string path;
        public string filenum;
        public ListBox filepath;
        public MainWindow mainWindow;
        private LoadResource loadResource = new LoadResource();
        public ProgressBar progressBar;

        public PictureSequence()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "没有找到指定物体")
            {
                MessageBox.Show("没有在工程文件里找到平面物体\n建议创建完平面物体后保存一下");
            }
            else
            {
                int a = int.Parse(textBox1.Text);
                int b = int.Parse(textBox3.Text);
                int d = int.Parse(textBox2.Text);
                int f = 0;
                if (d > 0)
                {
                    f = (d / (b + 1)) + 1;
                }
                else if (d == 0 | d > filepath.Items.Count)
                {
                    f = filepath.Items.Count;
                }
                int c = 0;
                int index = Convert.ToInt32(comboBox1.Text.Substring(1, 1));
                progressBar.Maximum = f - 1;
                new Task(() =>
                {
                    for (int i = 0; i < f; i++)
                    {
                        loadResource.AddFrames(path, a + i + c, index, loadResource.RandomString(16), Path.GetFileName(filepath.Items[i].ToString()));
                        c = c + b;
                        FileInfo fileto = new FileInfo(filepath.Items[i].ToString());
                        if (fileto.Exists)
                        {
                            try
                            {
                                fileto.CopyTo(Path.GetDirectoryName(path) + "\\" + Path.GetFileName(filepath.Items[i].ToString()), true);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                        progressBar.Value = i;
                    }
                    MessageBox.Show("完成");
                }).Start();

                Close();
            }
        }

        private void PictureSequence_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(loadResource.LinkType(path));
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.Items.Add("没有找到指定物体");
                comboBox1.SelectedIndex = 0;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
            if (textBox1.Text.Length > 0)
            {
                if (textBox1.Text[0] == '0')
                {
                    textBox1.Text = textBox1.Text.Substring(0, 0);
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
            if (textBox3.Text.Length > 0)
            {
                if (textBox2.Text[0] == '0')
                {
                    textBox2.Text = textBox2.Text.Substring(0, 0);
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '0' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
            if (textBox3.Text.Length > 0)
            {
                if (textBox3.Text[0] == '0')
                {
                    textBox3.Text = textBox3.Text.Substring(0, 0);
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "0";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "0";
            }
        }
    }
}