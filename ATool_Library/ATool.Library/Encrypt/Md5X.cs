using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ATool
{
    /// <summary>
    /// Md5 加密
    /// </summary>
    public static class Md5X
    {
        /// <summary>
        /// Md5 加密 16 位
        /// </summary>
        /// <param name="str">文本</param>
        /// <param name="toUpper">是否大写</param>
        /// <returns></returns>
        public static string Encrypt16(string str, bool toUpper = false)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //字符串装换成字节数组
            byte[] buffer = Encoding.Default.GetBytes(str);
            string md5Str = BitConverter.ToString(md5.ComputeHash(buffer), 4, 8);
            string result = md5Str.Replace("-", "");
            return toUpper ? result : result.ToLower();
        }

        /// <summary>
        /// Md5 加密 32 位
        /// </summary>
        /// <param name="str">文本</param>
        /// <param name="toUpper">是否大写，默认小写</param>
        /// <returns></returns>
        public static string Encrypt32(string str, bool toUpper = false)
        {
            MD5 md5 = MD5.Create();
            //字符串转换成字节数组
            byte[] buffer = Encoding.Default.GetBytes(str);
            //加密后是一个字节类型数组
            byte[] md5Bytes = md5.ComputeHash(buffer);
            var fmt = toUpper ? "X2" : "x2";
            string md5Str = string.Join("", md5Bytes.Select(c => c.ToString(fmt)).ToList());
            return md5Str;
        }

        //TODO 获取文件MD5

        //TODO　其他类型加密方式2
    }
}