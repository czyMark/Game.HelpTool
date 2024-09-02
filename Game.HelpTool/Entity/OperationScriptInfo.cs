using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.HelpTool
{
    public class OperationScriptInfo
    {
        public string ID { get; set; }
        public string ScriptName { get; set; }
        public int ScriptState { get; set; }
        public int ScreenX { get; set; }
        public int ScreenY { get; set; }
        public double ScriptOrder { get; set; }
        public List<OperationScript> Detail { get; set; }
    }
}
