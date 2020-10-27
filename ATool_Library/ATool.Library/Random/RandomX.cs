using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace ATool
{
    /// <summary>
    /// 随机工具类
    /// </summary>
    public static class RandomX
    {
        /// <summary>
        /// 生成一个指定范围的随机数
        /// </summary>
        /// <param name="minNum">最大值</param>
        /// <param name="maxNum">最小值</param>
        /// <returns></returns>
        public static int GetNumber(int minNum, int maxNum)
        {
            byte[] bytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            var seed = BitConverter.ToInt32(bytes, 0);
            return new Random(seed).Next(minNum, maxNum);
        }

        /// <summary>
        /// 生成一个 指定位数 的不重复的随机数列表，数值长度一致
        /// 基本规则：
        /// 数量为 10 对应数值长度 3位，100 4位，1000 5位，依次类推，效率最高。
        /// 数量超出10，有一定几率重复，会增加循环次数，数量超过位数，会无限循环
        /// </summary>
        /// <param name="len">随机数长度</param>
        /// <param name="count">数组长度</param>
        /// <returns></returns>
        public static List<int> GetArray1(int len, int count)
        {
            Random ro = new Random();
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int) (tick & 0xffffffffL) | (int) (tick >> 32));

            int iDown = Convert.ToInt32(Math.Pow(10, len - 1));
            int iUp = iDown * 10 - 1;

            //Hashset 不插重复的值
            HashSet<int> result = new HashSet<int>();
            while (result.Count < count)
            {
                var needCount = count - result.Count;
                for (int i = 0; i < needCount; i++)
                {
                    try
                    {
                        result.Add(ro.Next(iDown, iUp));
                    }
                    finally
                    {
                        //插入重复的值会异常
                    }
                }
            }

            return result.ToList();
        }

        /// <summary>
        /// 生成指定 范围 的不重复的随机数列表，数值长度不固定
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        public static List<int> GetArray2(int min, int max)
        {
            HashSet<int> result = new HashSet<int>();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    result.Add(rnd.Next(min, max));
                }
                finally
                {
                    //插入重复的值会异常
                }
            }

            return result.ToList();
        }


        /// <summary>
        /// 将列表打乱顺序，随机排列
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> ArraySort<T>(List<T> list)
        {
            List<T> resultList = new List<T>(list.Count);
            int min = 0;
            int max = list.Count;
            while (list.Count > 0)
            {
                var randomIndex = GetNumber(min, max);
                resultList.Add(list[randomIndex]);
                list.RemoveAt(randomIndex);
                max--;
            }

            return resultList;
        }
    }
}