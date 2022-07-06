using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MineImator_Import_Resources
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        //随机字符串
        private string RandomString(int codeLength)
        {
            string chars = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,P,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] charArray = chars.Split(new Char[] { ',' });
            string code = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 1; i < codeLength + 1; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(36);
                if (temp == t)
                {
                    return RandomString(codeLength);
                }
                temp = t;
                code += charArray[t];
            }
            return code;
        }

        //添加资源
        private void AddResources(string Path, string Type, string Filename)
        {
            string JsonPath = Path;
            string JsonString = File.ReadAllText(JsonPath, Encoding.UTF8);
            JObject jobject = JObject.Parse(JsonString);
            JObject resources = new JObject(
                new JProperty("id", RandomString(16)),
                new JProperty("type", Type),
                new JProperty("filename", Filename)
                );
            jobject["resources"].Last.AddAfterSelf(resources);
            string convertString = Convert.ToString(jobject);
            File.WriteAllText(JsonPath, convertString);
        }

        private int fileNum = 0;
        private string type = "";

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ADDFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "请选择资源文件";
            dialog.Filter = "资源文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                listBox1.Items.Clear();
                foreach (string file in dialog.FileNames)
                {
                    listBox1.Items.Add(file);
                }
                fileNum = listBox1.Items.Count;
            }
            label2.Text = fileNum.ToString() + "个文件";
        }

        private void Import_Click(object sender, EventArgs e)
        {
            if (fileNum == 0)
            {
                MessageBox.Show("请先添加资源文件");
            }
            else
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Title = "请选择工程文件";
                dialog.Filter = "工程文件(*.miproject)|*.miproject";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string file = dialog.FileName;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        type = "texture";
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        type = "skin";
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        type = "sound";
                    }
                    progressBar1.Maximum = fileNum - 1;
                    for (int i = 0; i <= fileNum - 1; i++)
                    {
                        AddResources(file, type, Path.GetFileName(listBox1.Items[i].ToString()));
                        FileInfo fileto = new FileInfo(listBox1.Items[i].ToString());
                        if (fileto.Exists)
                        {
                            fileto.CopyTo(Path.GetDirectoryName(file) + "\\" + Path.GetFileName(listBox1.Items[i].ToString()), true);
                        }
                        progressBar1.Value = i;
                    }
                    MessageBox.Show("完成导入");
                }
            }
        }
    }
}