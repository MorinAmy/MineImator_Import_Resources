using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace MineImator
{
    /// <summary>
    /// 转换视频,图片,音频到MineImator识别格式
    /// </summary>
    public class Conversion
    {
        /// <summary>
        /// 随机字符串生成
        /// </summary>
        /// <param name="codeLength">随机代码长度,默认16</param>
        /// <returns>返回16位随机字符</returns>
        public string RandomString(int codeLength = 16)
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
        /// 处理视频为图片序列帧,分离视频中的音频
        /// </summary>
        /// <param name="frame">视频每秒截图数量</param>
        /// <param name="inputVideoPath">视频输入路径</param>
        /// <param name="outFilePath">图片和音频文件输出文件夹</param>
        /// <param name="outFileName">图片和音频文件输出名称</param>
        /// <param name="outAudioONOff">分离音频文件,默认开启</param>
        /// <returns>返回包含图片路径的字符串数组</returns>
        public string[] VideoAudioConversion(string inputVideoPath, int frame, string outFilePath, string outFileName, bool extractingAudioONOff = true)
        {
            bool onOff = false;
            string[] imagesNumber = { };

            //处理视频和音频
            Task.Factory.StartNew(() =>
            {
                string[] videoToSequence = new string[] { "-i \"" + inputVideoPath + "\" -vf fps=" + frame + " \"" + outFilePath + "\\" + outFileName + "%3d.png\"" };
                string[] videoToAudio = new string[] { "-i \"" + inputVideoPath + "\" -vn " + "\"" + outFilePath + "\\" + outFileName + ".mp3\"" };
                byte[] fileBytes = MineImator_Import_Resources.ExecutablePrograms.ffmpeg;

                string tempPath = Path.GetTempPath();
                if (tempPath.EndsWith("\\"))
                {
                    tempPath = tempPath + "ffmpeg.exe";
                }
                else
                {
                    tempPath = tempPath + "\\ffmpeg.exe";
                }
                BinaryWriter binaryWriter = new BinaryWriter(new FileStream(tempPath, FileMode.Create));
                binaryWriter.Write(fileBytes);
                binaryWriter.Flush();
                binaryWriter.Dispose();
                Process sequenceProcess = Process.Start(tempPath, videoToSequence[0]);
                sequenceProcess.WaitForExit();
                if (extractingAudioONOff)
                {
                    Process audioProcess = Process.Start(tempPath, videoToAudio[0]);
                    audioProcess.WaitForExit();
                }
                onOff = true;
            }, TaskCreationOptions.LongRunning);

            //遍历输出图片文件数量
            Task.Factory.StartNew(() =>
            {
                string prefixZero = "00";
                for (int i = 1; i > 0; i++)
                {
                    if (i == 10)
                    {
                        prefixZero = "0";
                    }
                    else if (i == 100)
                    {
                        prefixZero = "";
                    }

                    if (File.Exists(outFilePath + "\\" + outFileName + prefixZero + imagesNumber + ".png"))
                    {
                        Debug.WriteLine("检测到的图片:" + imagesNumber);
                        imagesNumber[i - 1] = outFilePath + "\\" + outFileName + prefixZero + imagesNumber + ".png";
                    }
                    else if (onOff)
                    {
                        break;
                    }
                }
            }, TaskCreationOptions.LongRunning).Wait();

            //返回所有图片路径
            return imagesNumber;
        }
    }

    /// <summary>
    /// 为MineImator自动创建关键帧
    /// </summary>
    public class Keyframe
    {
        /// <summary>
        /// 添加音频帧到时间线
        /// </summary>
        /// <param name="JsonString">工程文件内容</param>
        /// <param name="frame">帧</param>
        /// <param name="resourceCode">资源文件ID随机16位字符</param>
        /// <param name="timeLinesCode">时间线物体ID随机61位字符</param>
        /// <param name="fileName">文件名字</param>
        /// <returns>修改的工程文件内容</returns>
        public string AddAudioFrames(string JsonString, int frame, string resourceCode, string timeLinesCode, string fileName = "")
        {
            JObject jobject = JObject.Parse(JsonString);
            JArray items = (JArray)jobject["timelines"];

            JObject resources = new JObject(
                new JProperty("id", timeLinesCode),
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
                        new JProperty("SOUND_OBJ", resourceCode)
                        ))
                    )),
                new JProperty("parent", "root"),
                new JProperty("parent_tree_index", items.Count + 1)
                );
            JArray item = (JArray)jobject["timelines"];
            item.Add(resources);
            string convertString = Convert.ToString(jobject);
            return convertString;
        }

        /// <summary>
        /// 添加图片序列帧到时间线
        /// </summary>
        /// <param name="JsonString">工程文件内容</param>
        /// <param name="index">时间线物体数组索引</param>
        /// <param name="frame">帧</param>
        /// <param name="resourceCode">资源文件16位随机字符串</param>
        /// <returns>修改的工程文件内容</returns>
        public string ImageSequenceFrames(string JsonString, int index, int frame, string resourceCode)
        {
            JObject jObject = JObject.Parse(JsonString);
            JArray timelines = (JArray)jObject["timelines"];
            JObject Arrayindex = (JObject)timelines[index];
            JObject keyframes = (JObject)Arrayindex["keyframes"];
            keyframes.Add(frame.ToString(), JToken.FromObject(new
            {
                TEXTURE_OBJ = resourceCode
            }));
            string convertString = Convert.ToString(jObject);
            return convertString;
        }
    }

    /// <summary>
    /// 添加和修改MineImator资源文件
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// 添加资源文件
        /// </summary>
        /// <param name="JsonString">工程文件内容</param>
        /// <param name="type">文件类型</param>
        /// <param name="resourceCode">资源文件16位随机字符串</param>
        /// <param name="fileName">文件名字</param>
        /// <returns>修改的工程文件内容</returns>
        public string AddResource(string JsonString, string type, string resourceCode, string fileName)
        {
            JObject jobject = JObject.Parse(JsonString);
            JObject resources = new JObject(
                new JProperty("id", resourceCode),
                new JProperty("type", type),
                new JProperty("filename", fileName)
                );
            JArray item = (JArray)jobject["resources"];
            item.Add(resources);
            string convertString = Convert.ToString(jobject);
            return convertString;
        }
    }
}