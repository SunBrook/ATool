using NUnit.Framework;

namespace ATool.UnitTest
{
    /// <summary>
    /// DES 测试
    /// </summary>
    [TestFixture]
    public class DesTest
    {
        //明文
        private string _testStr; 
        //密文
        private string _enStr;
        //密钥
        private string _key;
        
        /// <summary>
        /// 准备
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _testStr = "ATool for C#.";
            _enStr = "cmJfD7UrWKhiEYMUiH4Dsg==";
            _key = "2D655B74";
        }

        /// <summary>
        /// DES 加密
        /// </summary>
        [Test]
        public void Encrypt()
        {
            string result = Des.Encrypt(_testStr, _key);
            Assert.AreEqual(_enStr,result);
        }

        /// <summary>
        /// DES 解密
        /// </summary>
        [Test]
        public void Decrypt()
        {
            string result = Des.Decrypt(_enStr, _key);
            Assert.AreEqual(_testStr,result);
        } 
    }
}