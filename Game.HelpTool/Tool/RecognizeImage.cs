using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace Game.HelpTool
{
    /// <summary>
    /// 图像识别帮助类
    /// </summary>
    public static class RecognizeImage
    {
        [DllImport("AspriseOCR.dll", EntryPoint = "OCR", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr OCR(string file, int type);

        [DllImport("AspriseOCR.dll", EntryPoint = "OCRpart", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr OCRpart(string file, int type, int startX, int startY, int width, int height);

        [DllImport("AspriseOCR.dll", EntryPoint = "OCRBarCodes", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr OCRBarCodes(string file, int type);

        [DllImport("AspriseOCR.dll", EntryPoint = "OCRpartBarCodes", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr OCRpartBarCodes(string file, int type, int startX, int startY, int width, int height);

        /// <summary>
        /// AspriseOCR识别图像  编译成X86才能运行
        /// </summary>
        /// <param name="imgPath">图片路径</param>
        /// <returns></returns>
        public static string Recognize(string imgPath)
        {
            try
            {
                int startX = 0, startY = 0;
                Image image = Image.FromFile(imgPath); 
                return Marshal.PtrToStringAnsi(OCRpart(imgPath, -1, startX, startY, image.Width, image.Height));
            }
            catch (Exception ex)
            {
                Console.WriteLine("识别图像错误:" + ex.Message);
            }
            return "";
        }/// <summary>
         /// AspriseOCR识别图像  编译成X86才能运行
         /// </summary>
         /// <param name="imgPath">图片路径</param>
         /// <returns></returns>
        public static string Recognize(Bitmap img)
        {
            try
            {
                //存储一张图片验证截图识别是否有问题
                img.Save(System.Windows.Forms.Application.StartupPath + @"\Img\test.png");

                int startX = 0, startY = 0;
                Image image = Image.FromFile(System.Windows.Forms.Application.StartupPath + @"\Img\test.png"); 
                return Marshal.PtrToStringAnsi(OCRpart(System.Windows.Forms.Application.StartupPath + @"\Img\test.png", -1, startX, startY, image.Width, image.Height));
            }
            catch (Exception ex)
            {
                Console.WriteLine("识别图像错误:" + ex.Message);
            }
            return "";
        }

        /// <summary>
        /// Tesseract识别图像
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static string TesseractRecognize(Bitmap img)
        {
            //存储一张图片验证截图识别是否有问题
            img.Save(System.Windows.Forms.Application.StartupPath + @"\Img\test.png");
            //使用字符
            var ocr = new TesseractEngine(System.Windows.Forms.Application.StartupPath, "chi_sim", EngineMode.Default);    //使用chi_sim中文语言包做测试
            //图像识别
            var page = ocr.Process(img);
            return page.GetText();
        }

        /// <summary>
        /// Tesseract识别图像
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static string SpireRecognize(Bitmap img)
        {
            //存储一张图片验证截图识别是否有问题
            img.Save(System.Windows.Forms.Application.StartupPath + @"\Img\test.png");
            img.Dispose();
            var temp = new Spire.OCR.OcrScanner();
            temp.Scan(System.Windows.Forms.Application.StartupPath + @"\Img\test.png");
             string t = temp.Text.ToString();

            return t;
        }
    }
}
