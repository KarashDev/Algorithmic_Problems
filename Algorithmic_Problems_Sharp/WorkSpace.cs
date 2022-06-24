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
            var colors = new string[] { "brown", "grey", "black", "red" };
            var x = colors.Max(c => c.Length);
            var z = colors.Count(c => c.Length > 3);
            var y = colors.Count(c => c.Contains('e'));


            Console.WriteLine(x);
            Console.WriteLine(z);
            Console.WriteLine(y);


            // Найти самое длинное слово содержащее хотя бы одну букву "e"
            var words = new string[] { "brown", "grey", "black", "red", "redmond", "error", "adbcdtrdgqsfd", "advantage" };
            var target = words.Aggregate((target, i) => i.Length > target.Length && i.Contains('e') ? target = i : target);
            Console.WriteLine(target);

            Console.WriteLine(new string(words[0].ToCharArray().Reverse().ToArray()));


        }
    }
}
