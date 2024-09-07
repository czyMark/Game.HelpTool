using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.HelpTool
{
    public static class BaiduApiHelp
    {
        public static BaiduApiResultPack ImageResult(Image tmpimg)
        {
            //过期了，需要收费
            var API_KEY = "tumMXhQ1Y6mlBVu0jgC8Tp9b";
            var SECRET_KEY = "ogjFzI72SQk1Bb3YDxr7kAzB3DI0Ue6G";
            var client = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY);
            client.Timeout = 60000;  // 修改超时时间
            //截取图片
            tmpimg.Save(System.Windows.Forms.Application.StartupPath + @"\img\test.png");
            var image = File.ReadAllBytes(System.Windows.Forms.Application.StartupPath + @"\img\test.png");

            // 如果有可选参数
            var options = new Dictionary<string, object>{
        {"vertexes_location", "true"}, {"language_type", "CHN_ENG"},{"detect_direction", "true"},{"detect_language", "true"},{"probability", "true"}
    };
            var result = client.GeneralBasic(image, options);        //图图片
            //文件识别结果
            return JsonConvert.DeserializeObject<BaiduApiResultPack>(result.ToString());
        }
    }
}
