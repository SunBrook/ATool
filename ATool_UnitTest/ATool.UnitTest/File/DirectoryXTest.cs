using System;
using NUnit.Framework;

namespace ATool.UnitTest
{
    /// <summary>
    /// 文件夹路径操作 测试
    /// </summary>
    [TestFixture]
    public class DirectoryXTest
    {
        //当前文件夹的路径
        private string _directoryPath;
        
        /// <summary>
        /// 准备
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _directoryPath = $"{Environment.CurrentDirectory}"; //取得或设置当前工作目录的完整限定路径
        }

        /// <summary>
        /// 判断路径是否存在
        /// </summary>
        [Test]
        public void Exist()
        {
            bool result = DirectoryX.Exist(_directoryPath);
        }

        /// <summary>
        /// 创建路径
        /// </summary>
        [Test]
        public void Create()
        {
            
        }

        /// <summary>
        /// 检查路径是否存在，不存在则创建
        /// </summary>
        [Test]
        public void CheckCreate()
        {
            
        }
    }
}