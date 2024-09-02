using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.HelpTool
{
    public class BaiduApiResultPack
    {
        public string log_id { get; set; }
        public string words_result_num { get; set; }
        public BaiduApiResultPackDetail words_result { get; set; }
    }
    public class BaiduApiResultPackDetail
    {
        public string words { get; set; }
        public WordsLocation location { get; set; }
    }
    public class WordsLocation
    {
        public int left { get; set; }
        public int top { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
