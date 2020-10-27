using System;
using System.Linq;
using System.Text;

namespace ATool
{
    /// <summary>
    /// 字符串 操作类
    /// </summary>
    public static class StringX
    {
        /// <summary>
        /// 生成重复字符组成的字符串
        /// </summary>
        /// <param name="c">需要重复的字符</param>
        /// <param name="count">需要重复的次数</param>
        /// <returns></returns>
        public static string RepeatChar(char c, int count)
        {
            return new string(c, count);
        }

        /// <summary>
        /// 生成重复字符串组成的字符串
        /// </summary>
        /// <param name="str">需要重复的字符串</param>
        /// <param name="count">需要重复的次数</param>
        /// <returns></returns>
        public static string RepeatStr(string str, int count)
        {
            int capacity = str.Length * count;
            StringBuilder sb = new StringBuilder(capacity);
            for (int i = 0; i < count; i++)
            {
                sb.Append(str);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 单个数字字符 转中文 【壹贰叁】
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static char CharNumToCh1Upper(char c)
        {
            if (!char.IsDigit(c)) return c;
            switch (c)
            {
                case '1':
                    return '壹';
                case '2':
                    return '贰';
                case '3':
                    return '叁';
                case '4':
                    return '肆';
                case '5':
                    return '伍';
                case '6':
                    return '陆';
                case '7':
                    return '柒';
                case '8':
                    return '捌';
                case '9':
                    return '玖';
                default:
                    return '零';
            }
        }

        /// <summary>
        /// 单个数字字符 转中文 【一二三】
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static char CharNumToCh1Lower(char c)
        {
            if (!char.IsDigit(c)) return c;
            switch (c)
            {
                case '1':
                    return '一';
                case '2':
                    return '二';
                case '3':
                    return '三';
                case '4':
                    return '四';
                case '5':
                    return '五';
                case '6':
                    return '六';
                case '7':
                    return '七';
                case '8':
                    return '八';
                case '9':
                    return '九';
                default:
                    return '零';
            }
        }

        /// <summary>
        /// 单个整数 转中文 【壹贰叁】
        /// 上限是千亿
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string NumberToCh2Upper(long number)
        {
            StringBuilder cn = new StringBuilder();
            if (number < 0)
            {
                number = Math.Abs(number);
                cn.Append('负');
            }

            string numStr = number.ToString();
            int numLen = numStr.Length;

            //创建数字的单位模版
            string[] template = new string[] {"", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿", "拾", "佰", "仟"};
            string[] numUnits = new string[numLen];
            for (int i = 0; i < numLen; i++)
            {
                numUnits[i] = template[i];
            }

            numUnits = numUnits.Reverse().ToArray();

            //遍历每位的数字，然后拼接
            for (int i = 0; i < numLen; i++)
            {
                char charNumber = numStr[i];
                cn.Append($"{CharNumToCh1Upper(charNumber)}{numUnits[i]}");
            }

            string part0 = cn.ToString();

            //零亿、零万、零仟、零佰、零拾 改为零
            string part1 = part0
                .Replace("零亿", "零")
                .Replace("零万", "零")
                .Replace("零仟", "零")
                .Replace("零佰", "零")
                .Replace("零拾", "零");

            //过滤重复的零
            string part2 = part1;
            while (part2.Contains("零零"))
            {
                part2 = part2.Replace("零零", "零");
            }

            //一拾零 一拾一 一拾二 改为 拾 拾一 拾二
            if (number >= 10 && number <= 19)
            {
                if (number == 10)
                {
                    return "拾";
                }
                else
                {
                    string part3 = part2.Replace("一拾", "拾");
                    return part3;
                }
            }
            else
            {
                return part2;
            }
        }

        /// <summary>
        /// 单个整数 转中文 【一二三】
        /// 上限是千亿
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string NumberToCh2Lower(long number)
        {
            StringBuilder cn = new StringBuilder();
            if (number < 0)
            {
                number = Math.Abs(number);
                cn.Append('负');
            }

            string numStr = number.ToString();
            int numLen = numStr.Length;

            //创建数字的单位模版
            string[] template = new string[] {"", "十", "百", "千", "万", "十", "百", "千", "亿", "十", "百", "千"};
            string[] numUnits = new string[numLen];
            for (int i = 0; i < numLen; i++)
            {
                numUnits[i] = template[i];
            }

            numUnits = numUnits.Reverse().ToArray();

            //遍历每位的数字，然后拼接
            for (int i = 0; i < numLen; i++)
            {
                char charNumber = numStr[i];
                cn.Append($"{CharNumToCh1Lower(charNumber)}{numUnits[i]}");
            }

            string part0 = cn.ToString();

            //零亿、零万、零千、零百、零十 改为零
            string part1 = part0
                .Replace("零亿", "零")
                .Replace("零万", "零")
                .Replace("零千", "零")
                .Replace("零百", "零")
                .Replace("零十", "零");

            //过滤重复的零
            string part2 = part1;
            while (part2.Contains("零零"))
            {
                part2 = part2.Replace("零零", "零");
            }

            //一十零 一十一 一十二 改为 十 十一 十二
            if (number >= 10 && number <= 19)
            {
                if (number == 10)
                {
                    return "十";
                }
                else
                {
                    string part3 = part2.Replace("一十", "十");
                    return part3;
                }
            }
            else
            {
                return part2;
            }
        }


        /// <summary>
        /// 中文字符【壹贰叁】 转 单个数字
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int ChUpperToNumber(char c)
        {
            switch (c)
            {
                case '壹':
                    return 1;
                case '贰':
                    return 2;
                case '叁':
                    return 3;
                case '肆':
                    return 4;
                case '伍':
                    return 5;
                case '陆':
                    return 6;
                case '柒':
                    return 7;
                case '捌':
                    return 8;
                case '玖':
                    return 9;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 中文字符【一二三】 转 单个数字
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int ChLowerToNumber(char c)
        {
            switch (c)
            {
                case '一':
                    return 1;
                case '二':
                    return 2;
                case '三':
                    return 3;
                case '四':
                    return 4;
                case '五':
                    return 5;
                case '六':
                    return 6;
                case '七':
                    return 7;
                case '八':
                    return 8;
                case '九':
                    return 9;
                default:
                    return 0;
            }
        }


        /// <summary>
        /// 中文 【壹贰叁】 转 数字
        /// </summary>
        /// <param name="numStr"></param>
        /// <returns></returns>
        public static long Ch2UpperToNumber(string numStr)
        {
            //拾 拾壹 拾贰
            if (numStr.StartsWith("拾"))
            {
                numStr = $"壹{numStr}";
            }

            //关键字 拾 仟 万 亿

            char[] numChar = numStr.ToCharArray();
            long numYi = 0; //亿部分
            long numWan = 0; //万部分
            long numGe = 0; //个部分

            int index = 0; //循环的索引

            //计算亿部分
            if (numStr.IndexOf('亿') != -1)
            {
                int n1 = 0;
                for (; index < numChar.Length; index++)
                {
                    char inChar = numChar[index];

                    //到达亿后，index++ 并 退出
                    if (inChar == '亿')
                    {
                        if (numChar[index - 1] == '拾')
                        {
                            numYi = numYi * 100000000;
                        }
                        else
                        {
                            numYi = (numYi + n1) * 100000000;
                        }

                        index++;
                        break;
                    }
                    else
                    {
                        switch (inChar)
                        {
                            case '万':
                                numYi += n1 * 10000;
                                break;
                            case '仟':
                                numYi += n1 * 1000;
                                break;
                            case '佰':
                                numYi += n1 * 100;
                                break;
                            case '拾':
                                numYi += n1 * 10;
                                break;
                            default:
                                n1 = ChUpperToNumber(inChar);
                                break;
                        }
                    }
                }
            }

            //计算万部分
            if (numStr.IndexOf('万') != -1)
            {
                int n2 = 0;
                for (; index < numChar.Length; index++)
                {
                    char inChar = numChar[index];
                    //到达万后，index++ 并 退出
                    if (inChar == '万')
                    {
                        if (numChar[index - 1] == '拾')
                        {
                            numWan = numWan * 10000;
                        }
                        else
                        {
                            numWan = (numWan + n2) * 10000;
                        }

                        index++;
                        break;
                    }
                    else
                    {
                        switch (inChar)
                        {
                            case '仟':
                                numWan += n2 * 1000;
                                break;
                            case '佰':
                                numWan += n2 * 100;
                                break;
                            case '拾':
                                numWan += n2 * 10;
                                break;
                            default:
                                n2 = ChUpperToNumber(inChar);
                                break;
                        }
                    }
                }
            }

            //计算个部分
            int n3 = 0;
            for (; index < numChar.Length; index++)
            {
                char inChar = numChar[index];
                //到达万后，index++ 并 退出
                switch (inChar)
                {
                    case '仟':
                        numGe += n3 * 1000;
                        break;
                    case '佰':
                        numGe += n3 * 100;
                        break;
                    case '拾':
                        numGe += n3 * 10;
                        break;
                    default:
                        n3 = ChUpperToNumber(inChar);
                        break;
                }
            }

            //如果最后一位是 仟 佰 拾
            char lastChar = numChar[numChar.Length - 1];
            if (lastChar != '仟' && lastChar != '佰' && lastChar != '拾')
            {
                numGe += n3;
            }


            //计算总和
            return numYi + numWan + numGe;
        }

        /// <summary>
        /// 中文 【一二三】 转 数字
        /// </summary>
        /// <param name="numStr"></param>
        /// <returns></returns>
        public static long Ch2LowerToNumber(string numStr)
        {
            //壹仟零贰拾贰亿叁仟零叁拾肆万叁仟贰佰叁拾肆

            //十 十一 十二
            if (numStr.StartsWith("十"))
            {
                numStr = $"一{numStr}";
            }

            //关键字 十 千 万 亿

            char[] numChar = numStr.ToCharArray();
            long numYi = 0; //亿部分
            long numWan = 0; //万部分
            long numGe = 0; //个部分

            int index = 0; //循环的索引

            //计算亿部分
            if (numStr.IndexOf('亿') != -1)
            {
                int n1 = 0;
                for (; index < numChar.Length; index++)
                {
                    char inChar = numChar[index];

                    //到达亿后，index++ 并 退出
                    if (inChar == '亿')
                    {
                        if (numChar[index - 1] == '十')
                        {
                            numYi = numYi * 100000000;
                        }
                        else
                        {
                            numYi = (numYi + n1) * 100000000;
                        }

                        index++;
                        break;
                    }
                    else
                    {
                        switch (inChar)
                        {
                            case '万':
                                numYi += n1 * 10000;
                                break;
                            case '千':
                                numYi += n1 * 1000;
                                break;
                            case '百':
                                numYi += n1 * 100;
                                break;
                            case '十':
                                numYi += n1 * 10;
                                break;
                            default:
                                n1 = ChLowerToNumber(inChar);
                                break;
                        }
                    }
                }
            }

            //计算万部分
            if (numStr.IndexOf('万') != -1)
            {
                int n2 = 0;
                for (; index < numChar.Length; index++)
                {
                    char inChar = numChar[index];
                    //到达万后，index++ 并 退出
                    if (inChar == '万')
                    {
                        if (numChar[index - 1] == '十')
                        {
                            numWan = numWan * 10000;
                        }
                        else
                        {
                            numWan = (numWan + n2) * 10000;
                        }

                        index++;
                        break;
                    }
                    else
                    {
                        switch (inChar)
                        {
                            case '千':
                                numWan += n2 * 1000;
                                break;
                            case '百':
                                numWan += n2 * 100;
                                break;
                            case '十':
                                numWan += n2 * 10;
                                break;
                            default:
                                n2 = ChLowerToNumber(inChar);
                                break;
                        }
                    }
                }
            }

            //计算个部分
            int n3 = 0;
            for (; index < numChar.Length; index++)
            {
                char inChar = numChar[index];
                //到达万后，index++ 并 退出
                switch (inChar)
                {
                    case '千':
                        numGe += n3 * 1000;
                        break;
                    case '百':
                        numGe += n3 * 100;
                        break;
                    case '十':
                        numGe += n3 * 10;
                        break;
                    default:
                        n3 = ChLowerToNumber(inChar);
                        break;
                }
            }

            //如果最后一位是 千 百 十
            char lastChar = numChar[numChar.Length - 1];
            if (lastChar != '千' && lastChar != '百' && lastChar != '十')
            {
                numGe += n3;
            }


            //计算总和
            return numYi + numWan + numGe;
        }
    }
}