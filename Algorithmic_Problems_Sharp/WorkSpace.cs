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
            ////var colors = new string[] { "brown", "grey", "black", "red" };
            ////var x = colors.Max(c => c.Length);
            ////var z = colors.Count(c => c.Length > 3);
            ////var y = colors.Count(c => c.Contains('e'));


            ////Console.WriteLine(x);
            ////Console.WriteLine(z);
            ////Console.WriteLine(y);


            ////// Найти самое длинное слово содержащее хотя бы одну букву "e"
            ////var words = new string[] { "brown", "grey", "black", "red", "redmond", "error", "adbcdtrdgqsfd", "advantage" };
            ////var target = words.Aggregate((target, i) => i.Length > target.Length && i.Contains('e') ? target = i : target);
            ////Console.WriteLine(target);

            ////Console.WriteLine(new string(words[0].ToCharArray().Reverse().ToArray()));

            //string GetName(string str)
            //{
            //    // Не написано: greetingStr если не перед именем - имя не надо выводить
            //    var names = new List<string>() { "Rod", "Stewart", "Carter", "Dixon", "Marshall", "Smith", "Walker" };
            //    var greetingStr = new List<string> { "Im", "I'm", "I am", "My name is" };

            //    if (greetingStr.Any(gr => str.ToLower().Contains(gr.ToLower())) && names.Any(n => str.ToLower().Contains(n.ToLower())))
            //    {
            //        var foundNames = names.Where(n => str.ToLower().Contains(n.ToLower()));
            //        var outputName = "";

            //        foreach (var name in foundNames)
            //        {
            //            outputName += name + " ";
            //        }
            //        return outputName;
            //    }

            //    return null;
            //}


            //string[] lines = {
            //"Hi, I'm Carter",
            //"My name is rod Stewart",
            //"Nice to meet you, im dixon...",
            //"I am smith walker it's nice to meet you",
            //"i'm Carter Stewart Smith, how are you doing?",
            //"There's no name here",
            //"Hi I'm late for an interview",
            //"I am a retail manager",
            //"Im Dixon marshall and I have a question.",
            //"Where is Rod Stewart and his dog?",
            //"Hi my name is Dixon Walker, where can I buy these shoes?",
            //"I am hungry but I want to see Marshall first."
            //};

            //foreach (string s in lines)
            //{
            //    Console.WriteLine(string.Format("{0} => {1}", s, GetName(s)));
            //}



            //bool Scramble(string str1, string str2)
            //{
            //    var matches = 0;

            //    foreach(var ch in str2)
            //    {
            //        if (str1.Contains(ch))
            //        {
            //            matches++;
            //            str1 = str1.Remove(str1.IndexOf(ch), 1);
            //        }
            //        else return false;
            //    }

            //    return str2.Length == matches;
            //}

            //Console.WriteLine(Scramble("rkqodlw", "world")); //true
            //Console.WriteLine(Scramble("cedewaraaossoqqyt", "codewars"));//true
            //Console.WriteLine(Scramble("katas", "steak"));//false
            //Console.WriteLine(Scramble("scriptjavx", "javascript"));//false


            ////"scriptjavx", "javascript"
            ////"scriptavx", "javascript"1
            ////"scriptvx", "javascript" 2
            ////"scriptvx", "javascript" 3

            ////"scriptavx", "javascript"
            ////"scriptavx", "javascript"
            ////"scriptavx", "javascript"
            ////"scriptavx", "javascript"


            //double Solution(int[] firstArray, int[] secondArray)
            //{
            //    // Разница каждой пары чисел по одному индексу - в массив 
            //    // Каждое такое значение разницы в массиве возвести в квадрат
            //    // Найти среднее значение для всех получившихся чисел в массиве
            //    List<double> squaredDiffs = new List<double>();

            //    for (int i = 0; i < firstArray.Length; i++)
            //    {
            //        var rowDiff = (double)Math.Abs(firstArray[i] - secondArray[i]);
            //        squaredDiffs.Add(Math.Pow(rowDiff, 2));
            //    }

            //    return squaredDiffs.Average();
            //}


            ////// АЛЬТЕРНАТИВА 
            ////double Solution(int[] firstArray, int[] secondArray)
            ////{
            ////    return firstArray.Zip(secondArray, (f, s) => Math.Pow(s - f, 2)).Average();
            ////}

            ////[1, 2, 3], [4, 5, 6]               -->   9   because(9 + 9 + 9) / 3
            ////[10, 20, 10, 2], [10, 25, 5, -2]   -->  16.5 because(0 + 25 + 25 + 16) / 4
            ////[-1, 0], [0, -1]                   -->   1   because(1 + 1) / 2
            //Console.WriteLine(Solution(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }));
            //Console.WriteLine(Solution(new int[] { 10, 20, 10, 2 }, new int[] { 10, 25, 5, -2 }));
            //Console.WriteLine(Solution(new int[] { 0, -1 }, new int[] { -1, 0 }));


            //var arr1 = new int[] { 5, 2, 1 };
            //var arr2 = new int[] { 4, 2, 3 };

            //var arr3 = arr1.Zip(arr2, (n1, n2) => n1 - n2);
            //foreach (var num in arr3)
            //{
            //    Console.WriteLine();
            //    Console.WriteLine(num);
            //}




            //#nullable enable
            //            string GetUpperText(string? text)
            //            {
            //                return text.ToUpper();
            //            }

            //            string? arg = null;


            //            Console.WriteLine(GetUpperText(arg));


            string[] ModifyEvenIndexes(string[] strings)
            {
                var output = strings.Select(s => Array.IndexOf(strings, s) % 2 == 0 ? s += " even" : s);
                return output.ToArray();
            }

            var output = ModifyEvenIndexes(new string[] { "a", "b", "c", "d" });

            foreach (var str in output)
            {
                Console.WriteLine(str);
            }




        }
    }
}
