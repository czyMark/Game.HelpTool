using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game.HelpTool
{
    public class OperationScript
    {
        //运行时间间隔
        public string RunTime { get; set; }
        //开始坐标
        public int StartX { get; set; }
        public int StartY { get; set; }
        //结束坐标
        public int EndX { get; set; }
        public int EndY { get; set; }
        //输入的文字
        public string K { get; set; }
        /// <summary>
        /// 键盘特殊按键使用
        /// 默认是0
        /// 0不启动键盘工具
        /// 1启动键盘工具输入Guid值
        /// 2启动键盘工具输入位数计数器
        /// 3输出缓存内容
        /// </summary>
        public KeyStateData KeyState { get; set; }
        /// <summary>
        ///  默认是0 
        ///  0是左键
        ///  1是右键
        ///  2是滚动键
        /// </summary>
        public MouseStateData MouseState { get; set; }
        /// <summary>
        /// 条件状态
        ///0-不执行判断。对截图的内容做+并缓存
        ///1-开始后判断是否大于N值(数字)
        ///2-开始后判断是否小于N值(数字)
        ///3-开始后判断是否等于N值(数字)
        ///4-每当图中出现XX通过
        ///5-识别内容匹配最开始一个字
        ///6-识别内容匹配最后一个字
        /// </summary>
        public WhereExecStateData WhereState { get; set; }
        /// <summary>
        /// 默认是0
        /// 0是鼠标
        /// 1是键盘
        /// 3是条件执行
        /// </summary>
        public OperationStateData OperationState { get; set; }
         
    }
}
