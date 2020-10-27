using System;

namespace ATool.Example
{
    static class Program
    {
        /// <summary>
        /// 全部示例的入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            #region DateTime

            //获取日期的时间戳 字符串
            DateTimeXEg.GetTimeStampStr();

            //获取日期的时间戳 Long
            DateTimeXEg.GetTimeStampLong();

            #endregion

            #region Encrypt

            //AES 加密
            AesEg.Encrypt();
            
            //AES 解密
            AesEg.Decrypt();
            
            //DES 加密
            DesEg.Encrypt();
            
            //DES 解密
            DesEg.Decrypt();
            
            //MD5 加密 16位 大小写
            Md5XEg.Encrypt16();
            
            //MD5 加密 32位 大小写
            Md5XEg.Encrypt32();

            #endregion

            //Encrypt

            //File

            //Http

            //Random

            //Result

            //Text
        }
    }
}