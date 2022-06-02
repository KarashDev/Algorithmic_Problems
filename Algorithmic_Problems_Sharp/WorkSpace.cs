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
            
            int DuplicateCount(string str)
            {
                return str.ToLower().GroupBy(i => i).Where(c => c.Count() > 1).Count();
            }

            Console.WriteLine(DuplicateCount("Indivisibilities"));

            Assert.AreEqual(0, DuplicateCount(""));
            Assert.AreEqual(0, DuplicateCount("abcde"));
            Assert.AreEqual(2, DuplicateCount("aabbcde"));
            Assert.AreEqual(2, DuplicateCount("aabBcde"), "should ignore case");
            Assert.AreEqual(1, DuplicateCount("Indivisibility"));
            Assert.AreEqual(2, DuplicateCount("Indivisibilities"), "characters may not be adjacent");


        }




    }
}
