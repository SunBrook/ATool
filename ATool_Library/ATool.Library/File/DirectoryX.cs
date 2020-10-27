using System.IO;

namespace ATool
{
    /// <summary>
    /// 文件夹路径操作
    /// </summary>
    public static class DirectoryX
    {
        /// <summary>
        /// 判断路径是否存在
        /// </summary>
        /// <param name="path"></param>
        public static bool Exist(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// 创建路径
        /// </summary>
        /// <param name="path"></param>
        public static void Create(string path)
        {
            Directory.CreateDirectory(path);
        }

        /// <summary>
        /// 检查路径是否存在，不存在则创建
        /// </summary>
        public static void CheckCreate(string path)
        {
            if (!Exist(path))
            {
                Create(path);
            }
        }
    }
}