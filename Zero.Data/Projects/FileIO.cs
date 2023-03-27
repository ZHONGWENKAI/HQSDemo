


using System;
using System.IO;

namespace Zero.Data.Areas.Projects
{
    public class FileIO
    {
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public byte[] readFile(String path)
        {

            using (FileStream fs = new FileStream(path, FileMode.Open))     //初始化文件流
            {
                byte[] arr = new byte[fs.Length];                           //初始化字节数组
                fs.Read(arr, 0, arr.Length);                                //从流中数据读取到字节数组中
                fs.Close();                                                 //关闭流
                //string str = Encoding.UTF8.GetString(arr);                  //将字节数组转换为字符串
                //Console.WriteLine(str);
                return arr;
            }

            
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool writeFile(String path,byte[] arr)
        {

            bool b = false;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            if (arr != null) { 
                using (FileStream outStream = new FileStream(path, FileMode.CreateNew))  //初始化文件流
                {
                    outStream.Write(arr, 0, arr.Length);
                    b= true;
                    outStream.Close();
                }
            }
            return b;

            //打开一个已有文件
            //FileStream inStream = new FileStream("D:/Code/HQSDemo/UserAvatar/1.jpg", FileMode.Open);
            //新建一个目标文件，如果文件已存在会抛错
            //if (File.Exists(path))
            //{
            //    File.Delete(path);
            //}
            //FileStream outStream = new FileStream(path, FileMode.CreateNew);
            //outStream.Write(arr, 0, arr.Length);

            //Int32 length = 0;
            //循环inStream，将内容写进outStream

            //while (true)
            //{
            //    length = inStream.ReadByte();
            //    if (length != -1)
            //    {
            //        b = true;
            //        outStream.WriteByte((Byte)length);
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            //关闭文件
            //outStream.Close();
            //inStream.Close();  
        }
    }
}
