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
using System.Collections.Immutable;
using Microsoft.VisualBasic;
using CommandLine.Text;
using Microsoft.Diagnostics.Tracing.Parsers.JSDumpHeap;
using Microsoft.Diagnostics.Tracing.Parsers.ApplicationServer;
using System.Net.WebSockets;
using NUnit.Framework.Constraints;
using System.Reflection;
using System.Drawing;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Diagnostics.Tracing.Parsers.Clr;

namespace Algorithmic_Problems_Sharp
{
#pragma warning disable 
    class WorkSpace
    {

        public interface IExample { }
        public struct MyStruct : IExample { }
        

        static void Main(string[] args)
        {

            // Что происходит в данном коде?
            // Только boxing
            // Только unboxing
            // Boxing, затем unboxing 
            // Unboxing, затем boxing
            // Посмотреть результат
            var x = 25;
            var y = 35;

            List<object> digits = new List<object>() { x, y };

            var result = (int)digits[0] + (int)digits[1];


            List<IExample> examples = new List<IExample>();

            var myStruct = new MyStruct();
            examples.Add(myStruct);

            var meNewStruct = (MyStruct)examples[0];

        }


    }
}
