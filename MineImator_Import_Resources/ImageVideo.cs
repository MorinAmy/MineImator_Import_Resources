using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineImator_Import_Resources
{
    public partial class ImageVideo : Form
    {
        public string path;
        private LoadResource loadResource = new LoadResource();
        public MainWindow mainWindow;
        public ListBox listBox;
        public bool ffmpegonoff = false;
        public string ffmpeg = "";
        private Task task;
        private Task task1;

        public ImageVideo()
        {
            InitializeComponent();
        }

        public string ffmegFilePath = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "没有找到指定物体")
            {
                MessageBox.Show("没有在工程文件里找到平面物体\n建议创建完平面物体后保存一下");
            }
            else
            {
                if (textBox4.Text != "")
                {
                    string JsonString = File.ReadAllText(path, Encoding.UTF8);
                    JObject json = JObject.Parse(JsonString);

                    string frame = "";
                    if (checkBox2.Checked)
                    {
                        frame = " -r " + ((string)((JObject)json["project"])["tempo"]);
                    }
                    else if (textBox5.Text == "")
                    {
                        frame = "";
                    }
                    else if (textBox5.Text != "")
                    {
                        frame = " -r " + textBox5.Text;
                    }
                    bool autioonoff = true;
                    if (checkBox1.Checked)
                    {
                        autioonoff = true;
                    }
                    else if (!checkBox1.Checked)
                    {
                        autioonoff = false;
                    }
                    int index = Convert.ToInt32(comboBox1.Text.Substring(1, 1));
                    //new Thread(() =>

                    int a = int.Parse(textBox1.Text);
                    int b = int.Parse(textBox3.Text);
                    string v = "00";
                    int c = 0;
                    new Task(() =>
                    {
                        loadResource.VideoFrame(ffmpeg, listBox.Items[0].ToString(), Path.GetDirectoryName(path) + "\\" + textBox4.Text + "%03d.png", Path.GetDirectoryName(path) + "\\" + textBox4.Text + ".mp3", frame, autioonoff);//).Start();
                    }).Start();
                    try
                    {
                        //for (int i = 1; i > 0; i++)
                        //{
                        //    if (i > 9)
                        //    {
                        //        v = "0";
                        //    }
                        //    if (i > 99)
                        //    {
                        //        v = "";
                        //    }
                        //    if (File.Exists(Path.GetDirectoryName(path) + "\\" + textBox4.Text + v + i + ".png"))
                        //    {
                        //        num++;
                        //    }
                        //    else
                        //    {
                        //        break;
                        //    }
                        //}
                        //this.Invoke(new Action(() =>
                        //{
                        //    progressBar.Maximum = num;
                        //}));

                        loadResource.task = new Task(() =>
                        {
                            int files = Directory.GetFiles(Path.GetDirectoryName(path)).Length;
                            for (int i = 1; i > 0; i++)
                            {
                                if (i > 9)
                                {
                                    v = "0";
                                }
                                if (i > 99)
                                {
                                    v = "";
                                }
                                if (File.Exists(Path.GetDirectoryName(path) + "\\" + textBox4.Text + v + i + ".png"))
                                {
                                    loadResource.AddFrames(path, a + (i - 1) + c, index, loadResource.RandomString(16), textBox4.Text + v + i + ".png");
                                    c = c + b;
                                    this.Invoke(new Action(() =>
                                    {
                                    }));
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (autioonoff)
                            {
                                loadResource.AddAudio(path, loadResource.RandomString(16), textBox4.Text, a);
                            }

                            MessageBox.Show("完成");
                        });
                        //}).Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    textBox4.BackColor = Color.Yellow;
                }
            }
        }

        private void ImageVideo_Load(object sender, EventArgs e)
        {
            if (ffmpegonoff)
            {
                ffmpeg = @"bin\ffmpeg.exe";
            }
            else if (!ffmpegonoff)
            {
                ffmpeg = @"ffmpeg.exe";
            }
            if (checkBox2.Checked)
            {
                textBox5.Enabled = false;
            }
            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;//提示信息的可见时间
            toolTip1.InitialDelay = 500;//事件触发多久后出现提示
            toolTip1.ReshowDelay = 500;//指针从一个控件移向另一个控件时，经过多久才会显示下一个提示框
            toolTip1.ShowAlways = true;//是否显示提示框

            toolTip1.SetToolTip(this.checkBox1, "视频如果存在音轨择添加");//设置提示按钮和提示内容
            toolTip1.SetToolTip(this.checkBox2, "工程帧率和视频帧率可以除尽的话,推荐勾选\n勾选尽量减少音频与视频延迟\n不勾选逐帧添加,但音频不会同步");//设置提示按钮和提示内容
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox5.Enabled = false;
            }
            else if (!checkBox2.Checked)
            {
                textBox5.Enabled = true;
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == '\b' || (e.KeyChar >= '1' && e.KeyChar <= '9')))
            {
                e.Handled = true;
            }
            if (textBox5.Text.Length > 0)
            {
                if (textBox5.Text[0] == '0')
                {
                    textBox5.Text = textBox5.Text.Substring(0, 0);
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

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "0";
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "1";
            }
        }
    }
}