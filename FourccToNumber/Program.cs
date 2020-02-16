using System;
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
                string fourcc = Console.ReadLine();
                fourcc = Regex.Unescape(fourcc);
                int num1 = (sbyte)fourcc[0] * 256 * 256 * 256 + (sbyte)fourcc[1] * 256 * 256 + (sbyte)fourcc[2] * 256 + (sbyte)fourcc[3];
                Console.WriteLine(num1);
            }
        }
    }
}
