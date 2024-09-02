using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.HelpTool
{
    public class ScriptWhereInfo
    {
        public string WhereinfoID { get; set; }
        public string WhereinfoOrder { get; set; }
        public string WhereinfoName { get; set; }
        public string WhereinfoInt { get; set; }
        public string Whereinfoinfo { get; set; }
        public List<OperationScript> WhereinfoDetail { get; set; }
    }
}
