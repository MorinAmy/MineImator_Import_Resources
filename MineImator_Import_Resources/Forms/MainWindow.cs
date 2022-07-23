using MineImator;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineImator_Import_Resources.Forms
{
    //protected override CreateParams CreateParams
    //{
    //    get
    //    {
    //        CreateParams cp = base.CreateParams;
    //        cp.ExStyle |= 0x02000000; // 用双缓冲绘制窗口的所有子控件
    //        return cp;
    //    }
    //}

    public partial class MainWindow : Form
    {
        private string MIFolderPath = "";
        private ToolTip toolTip1 = new ToolTip();
        private Attribute attribute = new Attribute();
        private MIConfig miConfig = new MIConfig();
        private Panel miConfigpath = new Panel();
        private static UserUI[] TableUserUI = new UserUI[1000];
        private static String[] projectContent = new String[1000];
        private Resource resource = new Resource();
        private Conversion conversion = new Conversion();
        private string MisettingsTXT = "";

        public static List<FileInfo> getFile(string path, string extName, List<FileInfo> lst)
        {
            try
            {
                string[] dir = Directory.GetDirectories(path); //文件夹列表
                DirectoryInfo fdir = new DirectoryInfo(path);
                FileInfo[] file = fdir.GetFiles();
                //FileInfo[] file = Directory.GetFiles(path); //文件列表
                if (file.Length != 0 || dir.Length != 0) //当前目录文件或文件夹不为空
                {
                    foreach (FileInfo f in file) //显示当前目录所有文件
                    {
                        if (extName.ToLower().IndexOf(f.Extension.ToLower()) >= 0)
                        {
                            lst.Add(f);
                        }
                    }
                    foreach (string d in dir)
                    {
                        getFile(d, extName, lst);//递归
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MainWindow()

        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LoadMIProgram.Text = "加载";
            miConfig.Dock = DockStyle.Fill;
            miConfigpath.Dock = DockStyle.Fill;
            miConfigpath.AutoScroll = true;
            miConfigpath.Controls.Add(miConfig);
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
        }

        private void LoadMIProgram_Menu(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(Mine-imator)|Mine-imator.exe";
            ofd.Title = "选择Mine-imator.exe";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                panel1.Visible = false;
                tabControl1.TabPages[0].Controls.Remove(miConfigpath);
                tabControl1.TabPages[0].Controls.Add(miConfigpath);
                ProjectsFiles.Text = "未加载工程文件";
                foreach (var item in tabControl1.TabPages)
                {
                    if (tabControl1.TabPages.Count != 1)
                    {
                        tabControl1.TabPages[1].Dispose();
                        ProjectsList.ForeColor = Color.Black;
                        ProjectsList.Font = new Font("微软雅黑", 9, FontStyle.Regular);
                    }
                }

                ProjectsList.Items.Clear();
                ProjectIcon.Images.Clear();
                MIFolderPath = Path.GetDirectoryName(ofd.FileNames[0]);
                MisettingsTXT = File.ReadAllText(MIFolderPath + "\\" + "Data" + "\\" + "settings.midata");
                JObject fileProjectPathjson = JObject.Parse(MisettingsTXT);
                miConfig.ProjectLinkView.Items.Clear();
                imageListLink.Images.Clear();
                miConfig.AddLink.Click += AddLink;
                miConfig.DelLink.Click += DelLink;

                for (int i = 0; i < ((JArray)fileProjectPathjson["recent_files"]).Count; i++)
                {
                    string fileProjectPath = (string)fileProjectPathjson["recent_files"][i]["filename"];
                    string fileProjectName = (string)fileProjectPathjson["recent_files"][i]["name"];
                    imageListLink.Images.Add(Image.FromFile(Path.GetDirectoryName(fileProjectPath) + "\\" + "thumbnail.png"));
                    miConfig.ProjectLinkView.SmallImageList = imageListLink;
                    miConfig.ProjectLinkView.LargeImageList = imageListLink;
                    miConfig.ProjectLinkView.Items.Add(fileProjectName);
                    miConfig.ProjectLinkView.Items[i].ToolTipText = fileProjectPath;
                    miConfig.ProjectLinkView.Items[i].ImageIndex = i;
                }
                try
                {
                    DirectoryInfo d = new DirectoryInfo(MIFolderPath + "\\" + "Projects");
                    DirectoryInfo[] directs = d.GetDirectories();
                    //for (int i = 0; i < directs.Length; i++)
                    //{
                    //    string MIProjectPath = MIFolderPath + "\\" + "Projects" + "\\" + directs[i] + "\\" + directs[i] + ".miproject";
                    //    string MIProjectPNG = MIFolderPath + "\\" + "Projects" + "\\" + directs[i] + "\\" + "thumbnail.png";

                    //    //string MIProjectSettings = File.ReadAllText(MIFolderPath + "\\" + "Data" + "\\" + "settings.midata");
                    //    //try
                    //    //{
                    //    //    string MIProjectContent = File.ReadAllText(MIProjectPath);
                    //    //    JObject json = JObject.Parse(MIProjectContent);
                    //    //    string projectName = ((string)((JObject)json["project"])["name"]);
                    //    //    string projectAuthor = ((string)((JObject)json["project"])["author"]);
                    //    //    ProjectIcon.Images.Add(Image.FromFile(MIProjectPNG));
                    //    //    ProjectsList.Items.Add(Text = projectName, i);
                    //    //}
                    //    //catch (Exception)
                    //    //{ }
                    //}
                    List<FileInfo> lst = new List<FileInfo>();
                    string strPath = MIFolderPath + "\\" + "Projects";
                    List<FileInfo> lstFiles = getFile(strPath, ".miproject", lst);

                    progressBar1.Maximum = lstFiles.Count - 1;
                    Debug.WriteLine(lstFiles.Count);
                    int i = 0;
                    int a = 0;
                    Task.Factory.StartNew(() =>
                    {
                        bool projectInspection = false;
                        foreach (FileInfo shpFile in lstFiles)
                        {
                            Invoke(new Action(() =>
                            {
                                Debug.WriteLine(i);

                                progressBar1.Value = a;
                            }));
                            string MIProjectContent = File.ReadAllText(shpFile.FullName);
                            try
                            {
                                JObject json = JObject.Parse(MIProjectContent);
                                string projectName = ((string)((JObject)json["project"])["name"]);
                                string projectAuthor = ((string)((JObject)json["project"])["author"]);
                                Invoke(new Action(() =>
                                {
                                    if (File.Exists(Path.GetDirectoryName(shpFile.FullName) + "\\" + "thumbnail.png"))
                                    {
                                        ProjectIcon.Images.Add(Image.FromFile(Path.GetDirectoryName(shpFile.FullName) + "\\" + "thumbnail.png"));
                                    }
                                    else if (!File.Exists(Path.GetDirectoryName(shpFile.FullName) + "\\" + "thumbnail.png"))
                                    {
                                        ProjectIcon.Images.Add(ExecutablePrograms.Mineimator);
                                    }
                                    ProjectsList.Items.Add(ProjectsList.Text = projectName, i);
                                    ProjectsList.Items[i].ToolTipText = shpFile.FullName;
                                    ProjectsList.Items[i].Tag = i;
                                    i++;
                                    ProjectsFiles.Text = "已加载" + i + "个工程文件!";
                                    a++;
                                }));
                            }
                            catch (Exception)
                            {
                                Debug.WriteLine(i);
                                progressBar1.Value = a;
                                projectInspection = true;
                                a++;
                                File.AppendAllText(Path.GetTempPath() + "\\未被加载的工程.txt", "[" + DateTime.Now.ToString("yyyyMMddHHmmss") + "] " + shpFile.FullName + "\n");
                            }
                        }
                        if (projectInspection)
                        {
                            if (MessageBox.Show("部分工程未加载,是否查看详细信息", "未加载的工程", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Process.Start("notepad.exe", Path.GetTempPath() + "未被加载的工程.txt").WaitForExit();
                            }
                        }
                    }, TaskCreationOptions.LongRunning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void OprenSingleProject_Menu(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(MI工程文件)|*.miproject";
            ofd.Title = "选择工程文件";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                panel1.Visible = true;
                tabControl1.TabPages[0].Controls.Remove(miConfigpath);
                ProjectsFiles.Text = "工程文件";

                foreach (var item in tabControl1.TabPages)
                {
                    if (tabControl1.TabPages.Count != 1)
                    {
                        tabControl1.TabPages[1].Dispose();
                        ProjectsList.ForeColor = Color.Black;
                        ProjectsList.Font = new Font("微软雅黑", 9, FontStyle.Regular);
                    }
                }
                ProjectsList.Items.Clear();
                ProjectIcon.Images.Clear();
                MIFolderPath = Path.GetDirectoryName(ofd.FileNames[0]);

                try
                {
                    string MIProjectContent = File.ReadAllText(ofd.FileName);
                    JObject json = JObject.Parse(MIProjectContent);
                    string projectName = ((string)((JObject)json["project"])["name"]);
                    string projectAuthor = ((string)((JObject)json["project"])["author"]);
                    if (File.Exists(Path.GetDirectoryName(ofd.FileName) + "\\" + "thumbnail.png"))
                    {
                        ProjectIcon.Images.Add(Image.FromFile(Path.GetDirectoryName(ofd.FileName) + "\\" + "thumbnail.png"));
                    }
                    else if (!File.Exists(Path.GetDirectoryName(ofd.FileName) + "\\" + "thumbnail.png"))
                    {
                        ProjectIcon.Images.Add(ExecutablePrograms.Mineimator);
                    }
                    ProjectsList.Items.Add(ProjectsList.Text = projectName, 0);
                    ProjectsList.Items[0].ToolTipText = ofd.FileName;
                    ProjectsList.Items[0].Tag = 0;
                }
                catch (Exception)
                {
                    MessageBox.Show("文件错误");
                    File.AppendAllText(Path.GetTempPath() + "\\未被加载的工程.txt", "[" + DateTime.Now.ToString("yyyyMMddHHmmss") + "] " + ofd.FileName + "\n");
                }
            }
        }

        private void TabControl_RightClickMenu(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    TabPage tp = tabControl1.TabPages[i];
                    if (tabControl1.GetTabRect(i).Contains(new Point(e.X, e.Y)))
                    {
                        tabControl1.SelectedTab = tp;

                        break;
                    }
                }
                this.tabControl1.ContextMenuStrip = this.contextMenuStrip;
            }
        }

        private void TabControl_RightClickMenu_Dispose(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text != "首页")
            {
                int index = (int)tabControl1.SelectedTab.Tag;
                ProjectsList.Items[index].Selected = true;
                ProjectsList.Items[index].ForeColor = Color.Black;
                ProjectsList.Items[index].Font = new Font("微软雅黑", 9, FontStyle.Regular);
                ProjectsList.EnsureVisible(index);

                for (int i = tabControl1.SelectedIndex; i < TableUserUI.Length - 1; i++)
                {
                    TableUserUI[i] = TableUserUI[i + 1];
                }

                tabControl1.SelectedTab.Dispose();
            }
            else
            {
                MessageBox.Show("首页不能被关闭");
            }
        }

        private void ProjectListView_RightClickMenu_Attribute(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(ProjectsList.SelectedItems[0].ToolTipText))
                {
                    attribute.projectFileName = ProjectsList.SelectedItems[0].Text.ToString();
                    attribute.projectFilePath = ProjectsList.SelectedItems[0].ToolTipText.ToString();
                    attribute.ShowDialog();
                }
            }
            catch (Exception)
            {
            }
        }

        private void ProjectListView_RightClickMenu_Open(object sender, EventArgs e)
        {
            ProjectListView_MouseDoubleClick_Open(this, null);
        }

        private void TabControl_Menu_DisposeAll(object sender, EventArgs e)
        {
            foreach (var item in tabControl1.TabPages)
            {
                if (tabControl1.TabPages.Count != 1)
                {
                    tabControl1.TabPages[1].Dispose();
                    for (int i = 0; i < ProjectsList.Items.Count; i++)
                    {
                        ProjectsList.Items[i].ForeColor = Color.Black;
                        ProjectsList.Items[i].Font = new Font("微软雅黑", 9, FontStyle.Regular);
                    }
                }
            }
        }

        private void ProjectListView_MouseDoubleClick_Open(object sender, MouseEventArgs e)
        {
            if (ProjectsList.Items[0].Text == "空空如也")
            {
                LoadMIProgram_Menu(this, null);
            }
            else
            {
                try
                {
                    string projectJson = File.ReadAllText(ProjectsList.SelectedItems[0].ToolTipText);
                    JObject json = JObject.Parse(projectJson);

                    int a = 0;
                    for (int i = 0; i < tabControl1.TabPages.Count - a; i++)
                    {
                        if (ProjectsList.SelectedItems[0].Tag != tabControl1.TabPages[i].Tag && i == tabControl1.TabPages.Count - a - 1)
                        {
                            tabControl1.TabPages.Add(ProjectsList.SelectedItems[0].Text);
                            tabControl1.TabPages[i + 1].Tag = ProjectsList.SelectedItems[0].Tag;
                            tabControl1.TabPages[i + 1].ToolTipText = ProjectsList.SelectedItems[0].ToolTipText;
                            TableUserUI[i + 1] = new UserUI();
                            if (File.Exists(Path.GetDirectoryName(ProjectsList.SelectedItems[0].ToolTipText.ToString()) + "\\" + "thumbnail.png"))
                            {
                                TableUserUI[i + 1].Thumbnail.Image = Image.FromFile(Path.GetDirectoryName(ProjectsList.SelectedItems[0].ToolTipText.ToString()) + "\\" + "thumbnail.png");
                            }
                            TableUserUI[i + 1].projectNameText.Text = (string)json["project"]["name"];
                            TableUserUI[i + 1].projectAuthorText.Text = (string)json["project"]["author"];
                            TableUserUI[i + 1].projectDescriptionText.Text = (string)json["project"]["description"];
                            TableUserUI[i + 1].projectVideo_widthText.Text = (string)json["project"]["video_width"];
                            TableUserUI[i + 1].projectVideo_heightText.Text = (string)json["project"]["video_height"];
                            TableUserUI[i + 1].projectTempoText.Text = (string)json["project"]["tempo"];

                            Panel panel = new Panel();
                            panel.Dock = DockStyle.Fill;
                            panel.AutoScroll = true;
                            TableUserUI[i + 1].Dock = DockStyle.Top;
                            TableUserUI[i + 1].OpenProjectFolder.Click += OpenProjectFolder;
                            TableUserUI[i + 1].OpenTex.Click += OpenSelectTexFile;
                            TableUserUI[i + 1].OpenVido.Click += OpenSelectSequenceFile;
                            panel.Controls.Add(TableUserUI[i + 1]);
                            tabControl1.TabPages[i + 1].Controls.Add(panel);
                            ProjectsList.SelectedItems[0].Selected = true;
                            ProjectsList.SelectedItems[0].ForeColor = Color.LightBlue;
                            ProjectsList.SelectedItems[0].Font = new Font("微软雅黑", 10, FontStyle.Underline);
                            tabControl1.SelectedIndex = i + 1;

                            a++;
                        }
                        if (ProjectsList.SelectedItems[0].Tag == tabControl1.TabPages[i].Tag)
                        {
                            tabControl1.SelectedIndex = i;
                            break;
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        private void ProjectBarPosition_RightClickMenu_Position(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text != "首页")
            {
                int index = (int)tabControl1.SelectedTab.Tag;
                ProjectsList.Items[index].Selected = true;
                ProjectsList.Items[index].ForeColor = Color.LightBlue;
                ProjectsList.Items[index].Font = new Font("微软雅黑", 10, FontStyle.Underline);
                ProjectsList.EnsureVisible(index);
                ProjectsList.Focus();
            }
        }

        private void Minecraft_Assets_Menu_Open(object sender, EventArgs e)
        {
            byte[] fileBytes = MineImator_Import_Resources.ExecutablePrograms.Minecraft_Assets;

            string tempPath = Path.GetTempPath();
            if (tempPath.EndsWith("\\"))
            {
                tempPath = tempPath + "Minecraft_Assets.exe";
            }
            else
            {
                tempPath = tempPath + "\\Minecraft_Assets.exe";
            }
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(tempPath, FileMode.Create));
            binaryWriter.Write(fileBytes);
            binaryWriter.Flush();
            binaryWriter.Dispose();
            Process sequenceProcess = Process.Start(tempPath);
            sequenceProcess.WaitForExit();
        }

        private void TabControl_SelectedTabPage_Generate(object sender, EventArgs e)
        {
            string fileType = "";
            if (TableUserUI[tabControl1.SelectedIndex].comboBox1.Text == "图片")
            {
                fileType = "texture";
            }
            else if (TableUserUI[tabControl1.SelectedIndex].comboBox1.Text == "皮肤")
            {
                fileType = "skin";
            }
            else if (TableUserUI[tabControl1.SelectedIndex].comboBox1.Text == "音频")
            {
                fileType = "sound";
            }
            if (tabControl1.SelectedIndex == 0)
            {
            }
            else
            {
                //MessageBox.Show(TableUserUI[tabControl1.SelectedIndex].projectNameText.Text);
                string projectJson = File.ReadAllText(tabControl1.SelectedTab.ToolTipText);
                JObject json = JObject.Parse(projectJson);
                json["project"]["name"] = TableUserUI[tabControl1.SelectedIndex].projectNameText.Text;
                json["project"]["author"] = TableUserUI[tabControl1.SelectedIndex].projectAuthorText.Text;
                json["project"]["description"] = TableUserUI[tabControl1.SelectedIndex].projectDescriptionText.Text;
                json["project"]["video_width"] = TableUserUI[tabControl1.SelectedIndex].projectVideo_widthText.Text;
                json["project"]["video_height"] = TableUserUI[tabControl1.SelectedIndex].projectVideo_heightText.Text;
                json["project"]["tempo"] = TableUserUI[tabControl1.SelectedIndex].projectTempoText.Text;
                try
                {
                    for (int i = 0; i < TableUserUI[tabControl1.SelectedIndex].BatchFiles1.Items.Count; i++)
                    {
                        new FileInfo(TableUserUI[tabControl1.SelectedIndex].BatchFiles1.Items[i].ToString()).CopyTo(Path.GetDirectoryName(tabControl1.SelectedTab.ToolTipText) + "\\" + Path.GetFileName(TableUserUI[tabControl1.SelectedIndex].BatchFiles1.Items[i].ToString()));
                        projectJson = resource.AddResource(projectJson, fileType, conversion.RandomString(), Path.GetFileName(TableUserUI[tabControl1.SelectedIndex].BatchFiles1.Items[i].ToString()));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                File.WriteAllText(tabControl1.SelectedTab.ToolTipText, projectJson);
            }
        }

        private void TabControl_AllTabPage_Generate(object sender, EventArgs e)
        {
            for (int i = 1; i < tabControl1.TabCount; i++)
            {
                MessageBox.Show(TableUserUI[i].projectNameText.Text);
                string projectJson = File.ReadAllText(tabControl1.TabPages[i].ToolTipText);
                JObject json = JObject.Parse(projectJson);
                json["project"]["name"] = TableUserUI[i].projectNameText.Text;
                json["project"]["author"] = TableUserUI[i].projectAuthorText.Text;
                json["project"]["description"] = TableUserUI[i].projectDescriptionText.Text;
                json["project"]["video_width"] = TableUserUI[i].projectVideo_widthText.Text;
                json["project"]["video_height"] = TableUserUI[i].projectVideo_heightText.Text;
                json["project"]["tempo"] = TableUserUI[i].projectTempoText.Text;
                Convert.ToString(json);
                File.WriteAllText(tabControl1.TabPages[i].ToolTipText, json.ToString());
            }
        }

        private void LinkFilePath(object sender, EventArgs e)
        {
        }

        private void OpenProjectFolder(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(tabControl1.SelectedTab.ToolTipText));
        }

        private void OpenSelectTexFile(object sender, EventArgs e)
        {
            string filetype = "";
            if (TableUserUI[tabControl1.SelectedIndex].comboBox1.Text == "图片" | TableUserUI[tabControl1.SelectedIndex].comboBox1.Text == "皮肤")
            {
                filetype = "(图片文件)|*.png;*.jpg;*.jpeg;*.bmp";
            }
            else if (TableUserUI[tabControl1.SelectedIndex].comboBox1.Text == "音频")
            {
                filetype = "(音频文件)|*.wav;*.mp3;*.ogg;*.flac;*.wma;*.m4a";
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = filetype;
            ofd.Title = "选择工程文件";
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TableUserUI[tabControl1.SelectedIndex].BatchFiles1.Items.Clear();
                foreach (string filePath in ofd.FileNames)
                {
                    Debug.WriteLine(filePath.ToString());
                    TableUserUI[tabControl1.SelectedIndex].BatchFiles1.Items.Add(filePath);
                }
            }
        }

        private void OpenSelectSequenceFile(object sender, EventArgs e)
        {
            string filetype = "";
            if (TableUserUI[tabControl1.SelectedIndex].comboBox2.Text == "图片序列")
            {
                filetype = "(图片文件)|*.png;*.jpg;*.jpeg;*.bmp";
            }
            else if (TableUserUI[tabControl1.SelectedIndex].comboBox2.Text == "视频序列")
            {
                filetype = "(视频文件)|*.mp4;*.mkv;*.avi;*.mov";
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = filetype;
            ofd.Title = "选择工程文件";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void AddLink(object sender, EventArgs e)
        {
            string ProjectPath = File.ReadAllText(ProjectsList.SelectedItems[0].ToolTipText);
            JObject fileProjectjson = JObject.Parse(ProjectPath);
            string fileProjectName = (string)fileProjectjson["project"]["name"];
            string fileProjectAuthor = (string)fileProjectjson["project"]["author"];
            for (int i = 0; i < miConfig.ProjectLinkView.Items.Count; i++)
            {
                if (miConfig.ProjectLinkView.Items[i].ToolTipText != ProjectsList.SelectedItems[0].ToolTipText.Replace('\\', '/') && i == miConfig.ProjectLinkView.Items.Count - 2)
                {
                    MessageBox.Show(miConfig.ProjectLinkView.Items[i].ToolTipText + " " + i + "\n" + ProjectsList.SelectedItems[0].ToolTipText.Replace('\\', '/'));
                    imageListLink.Images.Add(Image.FromFile(Path.GetDirectoryName(ProjectsList.SelectedItems[0].ToolTipText.Replace('\\', '/')) + "\\" + "thumbnail.png"));
                    miConfig.ProjectLinkView.Items.Add(ProjectsList.SelectedItems[0].Text);
                    miConfig.ProjectLinkView.Items[miConfig.ProjectLinkView.Items.Count - 1].ToolTipText = ProjectsList.SelectedItems[0].ToolTipText.Replace('\\', '/');
                    miConfig.ProjectLinkView.Items[miConfig.ProjectLinkView.Items.Count - 1].ImageIndex = imageListLink.Images.Count - 1;
                    break;
                }
            }
        }

        private void DelLink(object sender, EventArgs e)
        {
            if (miConfig.ProjectLinkView.SelectedItems.Count > 0)
            {
                miConfig.ProjectLinkView.Items.Remove(miConfig.ProjectLinkView.SelectedItems[0]);   //按项移除
            }
        }
    }
}