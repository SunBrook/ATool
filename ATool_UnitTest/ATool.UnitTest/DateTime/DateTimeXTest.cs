using System;
using NUnit.Framework;

namespace ATool.UnitTest
{
    /// <summary>
    /// 测试 时间管理类
    /// </summary>
    [TestFixture]
    public class DateTimeXTest
    {
        private DateTime _oneDay;
        private string _timeStampStr;
        private long _timeStampLong;

        /// <summary>
        /// 准备
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _oneDay = new DateTime(2020, 10, 1);
            _timeStampStr = "1601481600";
            _timeStampLong = 1601481600;
        }


        /// <summary>
        /// 获取时间戳，字符串 类型
        /// </summary>
        [Test]
        public void GetTimeStampStr()
        {
            //执行 act
            var testResult = DateTimeX.GetTimeStampStr(_oneDay);
            //断言
            Assert.AreEqual(_timeStampStr, testResult);
        }

        /// <summary>
        /// 获取时间戳，Long 类型
        /// </summary>
        [Test]
        public void GetTimeStampLong()
        {
            //执行
            var testResult = DateTimeX.GetTimeStampLong(_oneDay);
            //断言
            Assert.AreEqual(_timeStampLong, testResult);
        }
    }
}