using NUnit.Framework;

namespace ATool.UnitTest
{
    /// <summary>
    /// AES加密 测试
    /// </summary>
    [TestFixture]
    public class AesTest
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
            _key = "70FAFC54FEA5E52DB46AF021A8A35BC4";
            _enStr = "f3CPqqS0TsxCCauBzSWx+Q==";
        }

        /// <summary>
        /// AES加密
        /// </summary>
        [Test]
        public void Encrypt()
        {
            string result = Aes.Encrypt(_testStr, _key);
            Assert.AreEqual(_enStr,result);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        [Test]
        public void Decrypt()
        {
            string result = Aes.Decrypt(_enStr, _key);
            Assert.AreEqual(result,_testStr);
        }
    }
}