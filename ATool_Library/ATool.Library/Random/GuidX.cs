using System;

namespace ATool
{
    /// <summary>
    /// GUID 生成器
    /// </summary>
    public static class GuidX
    {
        /// <summary>
        /// 获取Guid
        /// </summary>
        /// <param name="len">长度 默认全长, 无符号最大32 有符号最大 28</param>
        /// <param name="symbol">符号 默认有符号</param>
        /// <returns></returns>
        public static string Get(int len = -1, bool symbol = true)
        {
            var guid = Guid.NewGuid();
            if (len == -1)
            {
                //不截取长度
                return symbol ? guid.ToString() : guid.ToString("N");
            }
            else
            {
                //截取长度
                return symbol ? guid.ToString().Substring(0, len) : guid.ToString("N").Substring(0, len);
            }
        }
    }
}