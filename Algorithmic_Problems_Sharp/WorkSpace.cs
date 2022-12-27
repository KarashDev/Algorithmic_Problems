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
using System.Runtime.InteropServices;
using System.CodeDom;

namespace Algorithmic_Problems_Sharp
{
#pragma warning disable 
    class WorkSpace
    {

      

        static void Main(string[] args)
        {



            ////Обрежьте этот текст так, чтобы осталась только часть «Были описаны основные операторы и методы».
            //var str = "Сегодня мы с вами рассмотрели, как работать со строками в C#. Были описаны основные операторы и методы, которые используются для работы со строками";

            //// Решение 1 (границы отрезка по символам)
            //var indexDot = str.IndexOf('.');
            //var indexComma = str.LastIndexOf(",");
            //var outputStr = str.Substring(indexDot + 2, (indexComma - indexDot) - 2);
            //Console.WriteLine(outputStr);

            //// Решение 2 (границы отрезка по словам)
            //var words = str.Split(' ').ToList();
            //var selectedWords = words.SkipWhile(w => !w.Contains("Были")).TakeWhile(w => !w.Contains("которые"));
            //var outputStr = String.Join(" ", selectedWords);
            //outputStr= outputStr.Remove(outputStr.Length - 1);
            //Console.WriteLine(outputStr);


            //var x = 1;
            //Console.WriteLine(x++ + x);
            //Console.WriteLine(x++ + ++x);
            //Console.WriteLine(x);


            // Выражения исполняются слева направо 
            // Будет(x++ + x) = (1++ + x) = (1 + x) = (1 + 2) = 3, x = 2


            //void Method(ref int refArgument)
            //{
            //    refArgument += 10;
            //}
           
            //int number = 1;
            //Method(ref number);
            
            //Console.WriteLine(number);




            
        }


    }

}
