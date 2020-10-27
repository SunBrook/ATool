using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ATool
{
    /// <summary>
    /// url 处理类
    /// </summary>
    public static class Url
    {
        /// <summary>
        /// UrlEncode
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="encoding">编码格式，默认utf8</param>
        /// <returns></returns>
        public static string UrlEncode(string url, Encoding encoding = null)
        {
            StringBuilder sb = new StringBuilder();
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            byte[] byStr = encoding.GetBytes(url);
            foreach (var t in byStr)
            {
                sb.Append(@"%" + Convert.ToString(t, 16));
            }

            return sb.ToString();
        }

        /// <summary>
        /// UrlDecode
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="encoding">编码格式，默认utf8</param>
        /// <returns></returns>
        public static string UrlDecode(string url, Encoding encoding = null)
        {
            if (null == url)
                return null;

            if (url.IndexOf('%') == -1 && url.IndexOf('+') == -1)
                return url;

            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            long len = url.Length;
            var bytes = new List<byte>();
            int xchar;
            char ch;

            for (int i = 0; i < len; i++)
            {
                ch = url[i];
                if (ch == '%' && i + 2 < len && url[i + 1] != '%')
                {
                    if (url[i + 1] == 'u' && i + 5 < len)
                    {
                        // unicode hex sequence
                        xchar = GetChar(url, i + 2, 4);
                        if (xchar != -1)
                        {
                            WriteCharBytes(bytes, (char) xchar, encoding);
                            i += 5;
                        }
                        else
                        {
                            WriteCharBytes(bytes, '%', encoding);
                        }
                    }
                    else if ((xchar = GetChar(url, i + 1, 2)) != -1)
                    {
                        WriteCharBytes(bytes, (char) xchar, encoding);
                        i += 2;
                    }
                    else
                    {
                        WriteCharBytes(bytes, '%', encoding);
                    }

                    continue;
                }

                WriteCharBytes(bytes, ch == '+' ? ' ' : ch, encoding);
            }

            byte[] buf = bytes.ToArray();
            bytes = null;
            return encoding.GetString(buf);
        }

        private static void WriteCharBytes(IList buf, char ch, Encoding e)
        {
            if (ch > 255)
            {
                foreach (byte b in e.GetBytes(new char[] {ch}))
                {
                    buf.Add(b);
                }
            }
            else
            {
                buf.Add((byte) ch);
            }
        }

        private static int GetInt(byte b)
        {
            char c = (char) b;
            if (c >= '0' && c <= '9')
                return c - '0';

            if (c >= 'a' && c <= 'f')
                return c - 'a' + 10;

            if (c >= 'A' && c <= 'F')
                return c - 'A' + 10;

            return -1;
        }

        private static int GetChar(string str, int offset, int length)
        {
            int val = 0;
            int end = length + offset;
            for (int i = offset; i < end; i++)
            {
                char c = str[i];
                if (c > 127)
                    return -1;

                int current = GetInt((byte) c);
                if (current == -1)
                    return -1;
                val = (val << 4) + current;
            }

            return val;
        }
    }
}