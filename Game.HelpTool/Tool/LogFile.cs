using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Game.HelpTool
{
    public class FindFileInfo
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
    class LogFile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">文件路径包括文件名称</param>
        /// <param name="writestr">要写入的文字</param>
        public void WriteFile(string path, string writestr)
        {
            FileStream fs;
            if (!System.IO.File.Exists(path))
            {
                //没有则创建这个文件
                fs = new FileStream(path, FileMode.Create, FileAccess.Write);//创建写入文件                //设置文件属性为隐藏
            }
            else
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Write);
            }
            System.IO.File.SetAttributes(path, FileAttributes.Hidden);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(writestr);//开始写入值
            sw.Close();
            fs.Close();
        }

        public string ReadFile(string path)
        {
            string filejson = "";
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            System.IO.File.SetAttributes(path, FileAttributes.Hidden);
            StreamReader sr = new StreamReader(fs);
            filejson = sr.ReadToEnd();//开始写入值
            sr.Close();
            fs.Close();
            return filejson;
        }
        public List<FindFileInfo> GetFiles(string path, List<FindFileInfo> FileList)
        {
            string filename;
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fil = dir.GetFiles();
            DirectoryInfo[] dii = dir.GetDirectories();
            foreach (FileInfo f in fil)
            {
                filename = f.FullName;
                // 根据格式查找。
                if (filename.EndsWith("Script"))
                {
                    FileList.Add(new FindFileInfo() { FileName = f.Name, FilePath = f.FullName });
                }
            }
            //获取子文件夹内的文件列表，递归遍历  
            foreach (DirectoryInfo d in dii)
            {
                GetFiles(d.FullName, FileList);
            }
            return FileList;
        }

        public bool DeleteFile(string fileFullPath)
        {
            // 1、首先判断文件或者文件路径是否存在
            if (File.Exists(fileFullPath))
            {
                // 2、根据路径字符串判断是文件还是文件夹
                FileAttributes attr = File.GetAttributes(fileFullPath);
                // 3、根据具体类型进行删除
                if (attr == FileAttributes.Directory)
                {
                    // 3.1、删除文件夹
                    Directory.Delete(fileFullPath, true);
                }
                else
                {
                    // 3.2、删除文件
                    File.Delete(fileFullPath);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
