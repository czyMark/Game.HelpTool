using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.HelpTool
{
    public static class CaptureScreenImage
    {
        /// <summary>
        /// 截取屏幕
        /// </summary>
        /// <param name="x">起点X坐标</param>
        /// <param name="y">起点Y坐标</param>
        /// <param name="width">截取宽度</param>
        /// <param name="height">截取高度</param>
        /// <returns></returns>
        public static System.Drawing.Bitmap CaptureScreen(double x, double y, double width, double height)
        {
            int ix = Convert.ToInt32(x);
            int iy = Convert.ToInt32(y);
            int iw = Convert.ToInt32(width);
            int ih = Convert.ToInt32(height);

            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(iw, ih);
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(ix, iy, 0, 0, new System.Drawing.Size(iw, ih));
            graphics.Dispose();
            return bitmap;
        }

    }
}
