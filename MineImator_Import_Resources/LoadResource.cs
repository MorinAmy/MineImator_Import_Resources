using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace MineImator_Import_Resources
{
    internal class LoadResource
    {
        public Task task;

        /// <summary>
        /// 转换unicode
        /// </summary>
        /// <param name="text">输入文字</param>
        /// <returns></returns>
        public static string GetUnicode(string text)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if ((int)text[i] > 32 && (int)text[i] < 127)
                {
                    result += text[i].ToString();
                }
                else
                    result += string.Format("\\u{0:x4}", (int)text[i]);
            }
            return result;
        }

        /// <summary>
        /// 随机字符串
        /// </summary>
        /// <param name="codeLength"></param>
        /// <returns></returns>
        public string RandomString(int codeLength)
        {
            string chars = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,P,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] charArray = chars.Split(new Char[] { ',' });
            string code = "";
            int temp = -1;
            Random random = new Random();
            for (int i = 1; i < codeLength + 1; i++)
            {
                if (temp != -1)
                {
                    random = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }
                int t = random.Next(36);
                if (temp == t)
                {
                    return RandomString(codeLength);
                }
                temp = t;
                code += charArray[t];
            }
            return code;
        }

        /// <summary>
        /// 添加资源
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Type"></param>
        /// <param name="Filename"></param>
        /// <param name="code"></param>
        public void AddResources(string Path, string Type, string Filename, string code)
        {
            string JsonPath = Path;
            string JsonString = File.ReadAllText(JsonPath, Encoding.UTF8);
            JObject jobject = JObject.Parse(JsonString);
            JObject resources = new JObject(
                new JProperty("id", code),
                new JProperty("type", Type),
                new JProperty("filename", Filename)
                );
            JArray item = (JArray)jobject["resources"];
            item.Add(resources);
            string convertString = Convert.ToString(jobject);
            File.WriteAllText(JsonPath, convertString);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="JsonPath"></param>
        /// <returns></returns>
        public object[] LinkType(string JsonPath)
        {
            string type = "";
            string name = "";
            int a = 0;
            string JsonString = File.ReadAllText(JsonPath, Encoding.UTF8);
            JObject jObject = JObject.Parse(JsonString);
            JArray items = (JArray)jObject["timelines"];
            string[] typename = new string[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                type = jObject["timelines"][i]["type"].ToString();
                name = jObject["timelines"][i]["name"].ToString();
                if (type == "surface")
                {
                    typename[a] = "[" + i + "]" + type + " | " + name;
                    a++;
                }
            }
            typename = typename.Where(s => !string.IsNullOrEmpty(s)).ToArray();
            return typename;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="JsonPath"></param>
        /// <param name="frame"></param>
        /// <param name="index"></param>
        /// <param name="code"></param>
        /// <param name="Filename"></param>
        public void AddFrames(string JsonPath, int frame, int index, string code, string Filename)
        {
            AddResources(JsonPath, "texture", Filename, code);

            string JsonString = File.ReadAllText(JsonPath, Encoding.UTF8);

            JObject jObject = JObject.Parse(JsonString);
            JArray timelines = (JArray)jObject["timelines"];
            JObject Arrayindex = (JObject)timelines[index];
            JObject keyframes = (JObject)Arrayindex["keyframes"];
            keyframes.Add(frame.ToString(), JToken.FromObject(new
            {
                TEXTURE_OBJ = code
            }));
            string convertString = Convert.ToString(jObject);
            File.WriteAllText(JsonPath, convertString);
        }

        /// <summary>
        /// 将视频转为图片序列 将图片依次打上关键帧
        /// </summary>
        /// <param name="ffmpeg"></param>
        /// <param name="videoPath"></param>
        /// <param name="imgOut"></param>
        /// <param name="Mp3Out"></param>
        /// <param name="frame"></param>
        public void VideoFrame(string ffmpeg, string videoPath, string imgOut, string Mp3Out, string frame, bool audioonoff)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(ffmpeg);
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = " -i " + "\"" + videoPath + "\"" + frame + " -f image2 " + "\"" + imgOut + "\"";  //输出的图片文件名，路径前必须有空格
            Process processVideo = Process.Start(startInfo);
            processVideo.WaitForExit();

            if (audioonoff)
            {
                startInfo.Arguments = "-i " + "\"" + videoPath + "\"" + " -f mp3 " + "\"" + Mp3Out + "\"";
                Process processAudio = Process.Start(startInfo);
                processAudio.WaitForExit();
            }
            task.Start();
        }

        /// <summary>
        /// 添加声音到时间线,并引用音频
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <param name="code"></param>
        /// <param name="fileName"></param>
        /// <param name="frame"></param>
        public void AddAudio(string jsonPath, string code, string fileName, int frame)
        {
            AddResources(jsonPath, "sound", fileName + ".mp3", code);

            string JsonString = File.ReadAllText(jsonPath, Encoding.UTF8);
            JObject jobject = JObject.Parse(JsonString);
            JArray items = (JArray)jobject["timelines"];

            JObject resources = new JObject(
                new JProperty("id", RandomString(16)),
                new JProperty("type", "audio"),
                new JProperty("name", fileName),
                new JProperty("temp", "null"),
                new JProperty("color", "#FF0000"),
                new JProperty("hide", "false"),
                new JProperty("lock", "false"),
                new JProperty("depth", 0),
                new JProperty("default_values", new JObject()),
                new JProperty("keyframes", new JObject(
                    new JProperty(frame.ToString(), new JObject(
                        new JProperty("SOUND_OBJ", code)
                        ))
                    )),
                new JProperty("parent", "root"),
                new JProperty("parent_tree_index", items.Count + 1)
                );
            JArray item = (JArray)jobject["timelines"];
            item.Add(resources);
            string convertString = Convert.ToString(jobject);
            File.WriteAllText(jsonPath, convertString);
        }
    }
}