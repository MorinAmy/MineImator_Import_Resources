using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows.Forms;

namespace MineImator_Import_Resources.Forms
{
    public partial class Attribute : Form
    {
        public Attribute()
        {
            InitializeComponent();
        }

        public string projectFileName;
        public string projectFilePath;

        private void Attribute_Load(object sender, EventArgs e)
        {
            Text = projectFileName + "属性";
            string projectJson = File.ReadAllText(projectFilePath);
            JObject json = JObject.Parse(projectJson);

            string projectFormat = json.Value<string>("format");
            string projectCreated_in = json.Value<string>("created_in");
            string projectName = (string)json["project"]["name"];
            string projectAuthor = (string)json["project"]["author"];
            string projectDescription = (string)json["project"]["description"];
            string projectVideo_width = (string)json["project"]["video_width"];
            string projectVideo_height = (string)json["project"]["video_height"];
            string projectTempo = (string)json["project"]["tempo"];
            JArray projectTimelines = (JArray)json["timelines"];
            JArray projectTemplates = (JArray)json["templates"];
            JArray projectResources = (JArray)json["resources"];
            label1.Text = "版本: " + projectFormat + "\n" +
                "创建于: " + projectCreated_in + "\n" +
                "工程名称: " + projectName + "\n" +
                "作者: " + projectAuthor + "\n" +
                "描述: " + projectDescription + "\n" +
                "视频宽度: " + projectVideo_width + "\n" +
                "视频高度: " + projectVideo_height + "\n" +
                "帧率: " + projectTempo + "\n" +
                "时间线物体数量: " + projectTimelines.Count + "\n" +
                "模板数量: " + projectTemplates.Count + "\n" +
                "资源数量: " + projectResources.Count + "\n" +
                "所属文件夹: " + Path.GetFileNameWithoutExtension(Path.GetDirectoryName(projectFilePath));
        }
    }
}