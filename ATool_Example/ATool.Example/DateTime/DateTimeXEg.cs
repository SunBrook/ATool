using System;

namespace ATool.Example
{
    /// <summary>
    /// 时间戳 示例
    /// </summary>
    public static class DateTimeXEg
    {
        //需要转换的日期
        private static readonly DateTime Dt = new DateTime(2020, 10, 1);

        /// <summary>
        /// 例子：获取时间戳 字符串
        /// </summary>
        public static void GetTimeStampStr()
        {
            string result = DateTimeX.GetTimeStampStr(Dt);
            Console.WriteLine(result);
        }

        /// <summary>
        /// 例子：获取时间戳 Long
        /// </summary>
        public static void GetTimeStampLong()
        {
            long result = DateTimeX.GetTimeStampLong(Dt);
            Console.WriteLine(result);
        }
    }
}