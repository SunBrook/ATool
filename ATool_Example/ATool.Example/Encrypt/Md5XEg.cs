using System;

namespace ATool.Example
{
    /// <summary>
    /// Md5加密 示例
    /// </summary>
    public static class Md5XEg
    {
        private static string _testStr = "ATool for C#.";
        
        public static void Encrypt16()
        {
            //小写
            var resultLow = Md5X.Encrypt16(_testStr);
            Console.WriteLine(resultLow);
            
            //大写
            var resultUp = Md5X.Encrypt16(_testStr, true);
            Console.WriteLine(resultUp);
        }

        /// <summary>
        /// MD5 加密 32 位
        /// </summary>
        public static void Encrypt32()
        {
            //小写
            var resultLow = Md5X.Encrypt32(_testStr);
            Console.WriteLine(resultLow);
            
            //大写
            var resultUp = Md5X.Encrypt32(_testStr, true);
            Console.WriteLine(resultUp);
        }
    }
}