using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.HelpTool
{
    public class OperationScriptInfo
    {
        //id
        public string ID { get; set; }
        //脚本名称
        public string ScriptName { get; set; }
        ///脚本状态
        ///0是不重复执行
        ///1是可重复执行
        ///2是条件脚本没通过就回退执行前N个脚本
        ///3是条件脚本没通过就等待重新判断
        public ScriptTypeData ScriptState { get; set; }
        /// <summary>
        /// 脚本状态判断数值
        /// </summary>
        public int ScriptStateExecValue { get; set; }
        //屏幕分辩率X
        public int ScreenX { get; set; }
        //屏幕分辩率Y
        public int ScreenY { get; set; }
        //脚本顺序
        public double ScriptOrder { get; set; }
        //脚本内容
        public List<OperationScript> Detail { get; set; }
    }
}
