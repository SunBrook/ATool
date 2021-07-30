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
        /// <param name="isAppend">是否追加内容，默认覆盖写入</param>
        public static void Write(string filePath, string content, bool isAppend = false)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, isAppend))
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

        /// <summary>
        /// 确保文件存在，如果不存在则创建
        /// </summary>
        /// <param name="path"></param>
        public static void EnsureCreated(string path)
        {
            if (!Exist(path))
            {
                File.Create(path);
            }
        }
    }
}