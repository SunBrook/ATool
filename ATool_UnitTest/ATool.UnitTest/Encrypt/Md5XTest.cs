using NUnit.Framework;

namespace ATool.UnitTest
{
    /// <summary>
    /// MD5 加密
    /// </summary>
    [TestFixture]
    public class Md5XTest
    {
        private string _testStr;
        private string _md5Str16Low;
        private string _md5Str16Up;
        private string _md5Str32Low;
        private string _md5Str32Up;


        /// <summary>
        /// 准备
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _testStr = "ATool for C#.";
            _md5Str16Low = "b2cac34182ed746c";
            _md5Str16Up = "B2CAC34182ED746C";
            _md5Str32Low = "df4f9a51b2cac34182ed746c56224e17";
            _md5Str32Up = "DF4F9A51B2CAC34182ED746C56224E17";
        }

        /// <summary>
        /// MD5 加密 16 位
        /// </summary>
        [Test]
        public void Encrypt16()
        {
            //小写
            var resultLow = Md5X.Encrypt16(_testStr);
            Assert.AreEqual(resultLow, _md5Str16Low);
            //大写
            var resultUp = Md5X.Encrypt16(_testStr, true);
            Assert.AreEqual(resultUp, _md5Str16Up);
        }

        /// <summary>
        /// MD5 加密 32 位
        /// </summary>
        [Test]
        public void Encrypt32()
        {
            //小写
            var resultLow = Md5X.Encrypt32(_testStr);
            Assert.AreEqual(resultLow, _md5Str32Low);
            //大写
            var resultUp = Md5X.Encrypt32(_testStr, true);
            Assert.AreEqual(resultUp, _md5Str32Up);
        }
    }
}