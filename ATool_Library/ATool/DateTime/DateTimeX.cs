using System;

namespace ATool
{
    /// <summary>
    /// 时间管理类
    /// </summary>
    public static class DateTimeX
    {
        /// <summary>
        /// 获取时间戳，字符串 类型
        /// </summary>
        /// <param name="dt">时间点，默认当前时间</param>
        /// <returns></returns>
        public static string GetTimeStampStr(DateTime? dt = null)
        {
            DateTime datetime = dt ?? DateTime.UtcNow;
            long ts = (datetime.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            return ts.ToString();
        }

        /// <summary>
        /// 获取时间戳，Long 类型
        /// </summary>
        /// <param name="dt">时间点，默认当前时间</param>
        /// <returns></returns>
        public static long GetTimeStampLong(DateTime? dt = null)
        {
            DateTime datetime = dt ?? DateTime.UtcNow;
            long ts = (datetime.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            return ts;
        }
    }
}