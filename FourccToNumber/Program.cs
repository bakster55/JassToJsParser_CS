using System;
using System.Text;
using System.Text.RegularExpressions;

namespace FourccToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter: ");
                string line = Console.ReadLine();
                Console.WriteLine(GetResult(line));
            }
        }

        static string GetResult(string line)
        {
            int num;
            if (int.TryParse(line, out num))
            {
                return NumToFourcc(num);
            }
            else
            {
                return FourccToNum(line).ToString();
            }
        }

        static int FourccToNum(string fourcc)
        {
            fourcc = Regex.Unescape(fourcc);
            int num = (sbyte)fourcc[0] * 256 * 256 * 256 + (sbyte)fourcc[1] * 256 * 256 + (sbyte)fourcc[2] * 256 + (sbyte)fourcc[3];

            return num;
        }

        static string NumToFourcc(int num)
        {
            // 945821957-256^3*56-256^2*96-256*25-5
            int difference = num;
            byte x = GetPositiveFuncMinimum(difference, 256 * 256 * 256);
            difference -= 256 * 256 * 256 * x;
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

            return Encoding.Default.GetString(new byte[4] { x, y, z, d });
        }

        /// <summary>
        /// MIN(a - bx) > 0
        /// </summary>
        static byte GetPositiveFuncMinimum(int minuend, int subtrahend)
        {
            byte left = byte.MinValue;
            byte right = byte.MaxValue;

            while (right - left > 1)
            {
                byte middle = (byte)((left + right) / 2);

                if (minuend - subtrahend * middle >= 0)
                {
                    left = middle;
                }
                else
                {
                    right = middle;
                }
            }

            return left;
        }
    }
}
