using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.HelpTool
{
    public static class ColorConvertHelper
    {
        /// <summary>
        /// color 转换hex
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ColorToHex(Color color)
        {
            return String.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B); ;
        }

        /// <summary>
        /// hex转换到color
        /// </summary>
        /// <param name="hex">#EEEEEE</param>
        /// <returns></returns>
        public static Color HexToColor(string hex)
        { 
            return System.Drawing.ColorTranslator.FromHtml(hex);
        }
    }
}
