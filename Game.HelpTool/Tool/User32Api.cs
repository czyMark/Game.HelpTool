using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace Game.HelpTool
{
    //User32 封装
    public static class User32Api
    {
        #region 模拟鼠标触发
        [DllImport("user32")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        //移动鼠标 
        public static int MOUSEEVENTF_MOVE = 0x0001;
        //模拟鼠标左键按下 
        public static int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //模拟鼠标左键抬起 
        public static int MOUSEEVENTF_LEFTUP = 0x0004;
        //模拟鼠标右键按下 
        public static int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //模拟鼠标右键抬起 
        public static int MOUSEEVENTF_RIGHTUP = 0x0010;
        //模拟鼠标中键按下 
        public static int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //模拟鼠标中键抬起 
        public static int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //标示是否采用绝对坐标 
        public static int MOUSEEVENTF_ABSOLUTE = 0x8000;
        //模拟鼠标滚轮滚动操作，必须配合dwData参数
        public static int MOUSEEVENTF_WHEEL = 0x0800;
        #endregion


        #region 获取鼠标位置

        [DllImport("user32.dll")]
        // GetCursorPos() makes everything possible
        public static extern bool GetCursorPos(ref Point lpPoint);
        // Variable we will need to count the traveled pixels
        public static long totalPixels = 0;
        public static int currX;
        public static int currY;
        public static int diffX;
        public static int diffY;
        #endregion

        [DllImport("user32")]
        private static extern IntPtr LoadCursorFromFile(string fileName);

        [DllImport("User32.DLL")]
        public static extern bool SetSystemCursor(IntPtr hcur, uint id);
        public const uint OCR_NORMAL = 32512;

        [DllImport("User32.DLL")]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

        public const uint SPI_SETCURSORS = 87;
        public const uint SPIF_SENDWININICHANGE = 2;

        public static void SetMuoseCursor(string path)
        {
            //设置
            IntPtr iP = LoadCursorFromFile(path);
            SetSystemCursor(iP, OCR_NORMAL);
        }

        public static void DefaultMuoseCursor()
        {
            SystemParametersInfo(SPI_SETCURSORS, 0, IntPtr.Zero, SPIF_SENDWININICHANGE);
        }

        [DllImport("User32.dll")]
        public extern static System.IntPtr GetDC(System.IntPtr hWnd);
    }
}
