using System;

namespace ATool.Example
{
    /// <summary>
    /// DES 加解密 示例
    /// </summary>
    public static class DesEg
    {
        //明文
        private static string _testStr = "ATool for C#."; 
        //密文
        private static string _enStr = "cmJfD7UrWKhiEYMUiH4Dsg==";
        //密钥
        private static string _key= "2D655B74";
        
        /// <summary>
        /// DES 加密
        /// </summary>
        public static void Encrypt()
        {
            string result = Des.Encrypt(_testStr, _key);
            Console.WriteLine(result);
        }

        /// <summary>
        /// DES 解密
        /// </summary>
        public static void Decrypt()
        {
            string result = Des.Decrypt(_enStr, _key);
            Console.WriteLine(result);
        } 
    }
}