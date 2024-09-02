using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game.HelpTool
{
    public class OperationScript
    {
        public string RunTime { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
        public string K { get; set; }
        /// <summary>
        /// 默认是0
        /// 0不启动键盘工具
        /// 1启动键盘工具输入Guid值
        /// 2启动键盘工具输入位数计数器
        /// </summary>
        public int KeyState { get; set; }
        /// <summary>
        ///  默认是0 
        ///  0是左键
        ///  1是右键
        ///  2是滚动键
        /// </summary>
        public int MouseState { get; set; }
        /// <summary>
        /// 默认是0
        /// 0是鼠标
        /// 1是键盘
        /// </summary>
        public int OperationState { get; set; }
    }
}
