using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.HelpTool
{
    public class ScriptModel
    {
        public string ID { get; set; }
        public string ScriptName { get; set; }
        public int ScriptState { get; set; }
        public string ScriptPath { get; set; }
        public double ScriptOrder { get; set; }
        public int ScreenX { get; set; }
        public int ScreenY { get; set; }
    }
}
