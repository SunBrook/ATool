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

        /* 加盐思路：
         * 1. salt值每个字符串向前加1，得到新的salt值
         * 2. salt值字符串顺序逆转，得到新的salt值
         * 3. 计算salt值中的数字个数A，然后用salt值总长度 - A = B
         * 4. 按照 B 和 A的长度，将salt值线割成2部分。得到saltB saltA两部分
         * 5. 拼接 新字符串 M1 = saltB + 原密码 + saltA
         * 6. md5 步骤4中的M1，得到散列值M2
         * 7. 拼接 M2 + M1, 得到拼接值M3
         * 8. md5 M3，得到最终结果
         */

        /// <summary>
        /// 加盐核心计算
        /// </summary>
        /// <param name="password">原始密码</param>
        /// <param name="salt">盐值</param>
        /// <returns></returns>
        private static string GetTargetPassword(string password, string salt)
        {
            //salt值进1
            salt = new string(salt.Select(c =>
            {
                if (c == 'z') return 'a';
                if (c == 'Z') return 'A';
                if (c == '9') return '0';
                return (char)(c + 1);
            }).ToArray());

            //salt值逆转
            salt = salt.Reverse();

            //字母
            //计算长度
            var saltTotalCount = salt.Length;
            int numberCount = 0;
            for (int i = 0; i < saltTotalCount; i++)
            {
                if (char.IsDigit(salt[i]))
                {
                    numberCount++;
                }
            }
            int letterCount = saltTotalCount - numberCount;

            //拆分salt值
            string saltB = salt.Substring(0, letterCount);
            string saltA = salt.Substring(letterCount, numberCount);

            //合并得到M1
            string m1 = $"{saltB}{password}{saltA}";

            //Md5 M1
            string m2 = Encrypt16(m1);

            //拼接得到M3
            string m3 = $"{m2}{m1}";

            //散列M3，得到最终结果
            return Encrypt16(m3);
        }

        /// <summary>
        /// 密码加盐加密
        /// </summary>
        /// <param name="password">原始密码</param>
        /// <param name="salt">盐值，只允许数字和字母</param>
        /// <returns>最终密码</returns>
        public static string Encrypt(string password, string salt)
            => GetTargetPassword(password, salt);


        /// <summary>
        /// 验证密码是否正确
        /// </summary>
        /// <param name="password">原始密码</param>
        /// <param name="salt">盐值，只允许数字和字母</param>
        /// <param name="targetPassword">最终密码</param>
        /// <returns></returns>
        public static bool Check(string password, string salt, string targetPassword)
            => GetTargetPassword(password, salt) == targetPassword;
    }
}