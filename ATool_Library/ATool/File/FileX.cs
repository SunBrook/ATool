using System;
using System.IO;
using System.Text;

namespace ATool
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public static class FileX
    {
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static string Read(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    StringBuilder sb = new StringBuilder();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        sb.AppendLine(line);
                    }

                    return sb.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="content">文件内容</param>
        public static void Write(string filePath, string content)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.Write(content);
                }
            }
            catch
            {
                //ignore
            }
        }

        /// <summary>
        /// 判断路径是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool Exist(string path)
        {
            return File.Exists(path);
        }
    }
}