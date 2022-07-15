using System;
using System.IO;
using System.Windows.Forms;

namespace MineImator_Import_Resources
{
    public partial class MainWindow : Form
    {
        private PictureSequence pictureSequence = new PictureSequence();
        private ImageVideo imageVideo = new ImageVideo();
        private LoadResource loadrresource = new LoadResource();
        private int fileNum = 0;
        private string type = "";
        public string path;

        private string combox = "";

        public MainWindow()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"bin\ffmpeg.exe"))
            {
                imageVideo.ffmpegonoff = true;
            }
            else
            {
                imageVideo.ffmpegonoff = false;
            }
        }

        private void ADDFile_Click(object sender, EventArgs e)
        {
            bool multiselect = true;
            string filetype = "";
            if (comboBox1.Text == "视频")
            {
                multiselect = false;
                filetype = "(视频文件)|*.mp4;*.avi";
            }
            else if (comboBox1.Text == "图片" | comboBox1.Text == "皮肤" | comboBox1.Text == "序列")
            {
                multiselect = true;
                filetype = "(图片文件)|*.png;*.jpg;*.jpeg;*.bmp";
            }
            else if (comboBox1.Text == "音频")
            {
                multiselect = true;
                filetype = "(音频文件)|*.wav;*.mp3;*.ogg;*.aac";
            }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = multiselect;
            dialog.Title = "请选择资源文件";
            dialog.Filter = filetype;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();
                foreach (string file in dialog.FileNames)
                {
                    listBox1.Items.Add(file);
                }
                fileNum = listBox1.Items.Count;
                pictureSequence.filepath = listBox1;
                imageVideo.listBox = listBox1;
            }
            label2.Text = fileNum.ToString() + "个文件";
        }

        private void Import_Click(object sender, EventArgs e)
        {
            if (listBox1.Items[0].ToString() == "请重新添加对应的文件" | fileNum == 0)
            {
                MessageBox.Show("请先添加资源文件");
            }
            else
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Title = "请选择工程文件";
                dialog.Filter = "工程文件(*.miproject)|*.miproject";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageVideo.progressBar = progressBar1;
                    pictureSequence.progressBar = progressBar1;
                    string file = dialog.FileName;
                    if (comboBox1.Text == "图片")
                    {
                        type = "texture";
                    }
                    else if (comboBox1.Text == "皮肤")
                    {
                        type = "skin";
                    }
                    else if (comboBox1.Text == "音频")
                    {
                        type = "sound";
                    }
                    if (comboBox1.Text == "序列")
                    {
                        type = "texture";
                        pictureSequence.mainWindow = this;
                        pictureSequence.path = file;
                        pictureSequence.ShowDialog();
                    }
                    else
                    {
                        if (comboBox1.Text == "视频")
                        {
                            type = "texture";
                            imageVideo.mainWindow = this;
                            imageVideo.path = file;
                            imageVideo.ShowDialog();
                        }
                        else
                        {
                            progressBar1.Maximum = fileNum - 1;
                            for (int i = 0; i <= fileNum - 1; i++)
                            {
                                loadrresource.AddResources(file, type, Path.GetFileName(listBox1.Items[i].ToString()), loadrresource.RandomString(16));
                                FileInfo fileto = new FileInfo(listBox1.Items[i].ToString());
                                if (fileto.Exists)
                                {
                                    try
                                    {
                                        fileto.CopyTo(Path.GetDirectoryName(file) + "\\" + Path.GetFileName(listBox1.Items[i].ToString()), true);
                                    }
                                    catch (SystemException ex)
                                    {
                                        MessageBox.Show(ex.Message.ToString());
                                        return;
                                    }
                                    progressBar1.Value = i;
                                }
                                MessageBox.Show("完成");
                            }
                        }
                    }
                }
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            combox = comboBox1.Text;
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.Text != combox)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("请重新添加对应的文件");
            }
        }
    }
}