using System;
using System.Text;

namespace JassToCsMain
{
    public static class NumberConvertHelper
    {
        public static int HexToDecimal(string jassHex)
        {
            string hex = jassHex;
            if (jassHex[0] == '$')
            {
                hex = jassHex.Replace("$", "0x");
            }
            ;
            return Convert.ToInt32(hex, 16);
        }

        public static string GetDecimalOrFourcc(string number)
        {
            return GetDecimalOrFourcc(long.Parse(number));
        }

        public static string GetDecimalOrFourcc(long number)
        {
            if (number >= 256 * 256 * 256)
            {
                return NumToFourcc(number);
            }

            return number.ToString();
        }

        public static int FourccToNum(string fourcc)
        {
            int num = (sbyte)fourcc[0] * 256 * 256 * 256 + (sbyte)fourcc[1] * 256 * 256 + (sbyte)fourcc[2] * 256 + (sbyte)fourcc[3];

            return num;
        }

        public static string NumToFourcc(long num)
        {
            // 945821957-256^3*56-256^2*96-256*25-5
            long difference = num;
            byte x = GetPositiveFuncMinimum(difference, 256 * 256 * 256);
            difference -= (long)256 * 256 * 256 * x;
            byte y = GetPositiveFuncMinimum(difference, 256 * 256);
            difference -= 256 * 256 * y;
            byte z = GetPositiveFuncMinimum(difference, 256);
            difference -= 256 * z;
            byte d = GetPositiveFuncMinimum(difference, 1);
            difference -= d;

            if (difference != 0)
            {
                throw new Exception();
            }

            return $"\"{Encoding.Default.GetString(new byte[4] { x, y, z, d })}\"";
        }

        /// <summary>
        /// MIN(a - bx) > 0
        /// </summary>
        public static byte GetPositiveFuncMinimum(long minuend, long subtrahend)
        {
            long left = byte.MinValue - 1;
            long right = byte.MaxValue + 1;

            while (right - left > 1)
            {
                long middle = (left + right) / 2;

                long result = minuend - subtrahend * middle;
                if (result >= 0)
                {
                    left = middle;
                }
                else
                {
                    right = middle;
                }
            }

            return (byte)left;
        }
    }
}
