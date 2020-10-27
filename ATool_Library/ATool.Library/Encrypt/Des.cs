using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ATool
{
    /// <summary>
    /// DES 加解密
    /// </summary>
    public static class Des
    {
        /// <summary>
        /// DES 加密
        /// </summary>
        /// <param name="str">明文</param>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public static string Encrypt(string str, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(str);
            des.Key = Encoding.ASCII.GetBytes(sKey); // 密匙
            des.IV = Encoding.ASCII.GetBytes(sKey); // 初始化向量
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            var retB = Convert.ToBase64String(ms.ToArray());
            return retB;
        }

        /// <summary>
        /// DES 解密
        /// </summary>
        /// <param name="str">密文</param>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public static string Decrypt(string str, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Convert.FromBase64String(str);
            des.Key = Encoding.ASCII.GetBytes(sKey);
            des.IV = Encoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            // 如果两次密匙不一样，这一步可能会引发异常
            cs.FlushFinalBlock();
            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
    }
}