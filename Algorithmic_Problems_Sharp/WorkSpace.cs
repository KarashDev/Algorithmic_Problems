using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Threading;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Algorithmic_Problems_Sharp
{

    class WorkSpace
    {

        static void Main(string[] args)
        {

            string HighAndLow(string numbers)
            {
                var nums = numbers.Split(' ').Select(c => Convert.ToInt32(c));
                return new string(nums.Max() + " " + nums.Min());
            }


            var x = HighAndLow("8 3 -5 42 -1 0 0 -9 4 7 4 -4");

            Console.WriteLine(x);


            //For example, take 153(3 digits), which is narcisstic:
            //1^3 + 5^3 + 3^3 = 1 + 125 + 27 = 153

            //and 1652(4 digits), which isn't:
            //1^4 + 6^4 + 5^4 + 2^4 = 1 + 1296 + 625 + 16 = 1938


            bool Narcissistic(int value)
            {
                var digits = value.ToString().Select(c => char.GetNumericValue(c)).ToArray();
                var sum = 0d;

                foreach (var digit in digits)
                {
                    var z = Math.Pow(digit, digits.Length);
                    sum += z;
                }

                return value == sum;
            }

            Console.WriteLine(Narcissistic(153)); 
            Console.WriteLine(Narcissistic(1652)); 









        }
    }
}
