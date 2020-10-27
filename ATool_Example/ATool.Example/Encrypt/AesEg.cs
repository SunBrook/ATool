using System;

namespace ATool.Example
{
    /// <summary>
    /// AES加密 示例
    /// </summary>
    public static class AesEg
    {
        //明文
        private static string _testStr = "ATool for C#.";

        //密文
        private static string _enStr = "f3CPqqS0TsxCCauBzSWx+Q==";

        //密钥
        private static string _key = "70FAFC54FEA5E52DB46AF021A8A35BC4";

        /// <summary>
        /// AES加密
        /// </summary>
        public static void Encrypt()
        {
            string result = Aes.Encrypt(_testStr, _key);
            Console.WriteLine(result);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        public static void Decrypt()
        {
            string result = Aes.Decrypt(_enStr, _key);
            Console.WriteLine(result);
        }
    }
}