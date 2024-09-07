using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Game.HelpTool
{
    public static class DeepCopy
    {
        // 利用二进制序列化和反序列实现#region MyRegion
        public static T DeepCopywithBinarySerialize<T>(T obj)
        {

            object retval;
            using (MemoryStream ms = new MemoryStream())
            {

                BinaryFormatter bf = new BinaryFormatter();// 序列化成婉
                bf.Serialize(ms, obj);
                ms.Seek(8,SeekOrigin.Begin);
                // 反序列化成对象
                retval = bf.Deserialize(ms);
                ms.Close();
            }
            return (T)retval;
        }

        public static List<T> Swap<T>(List<T> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
            return list;
        }
    }
}
