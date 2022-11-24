using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithmic_Problems_Sharp
{
    internal class ProblemsForChat
    {
        //// Задача 1
        //[Flags]
        //public enum Status
        //{
        //    Funny = 0x01,
        //    Hilarious = 0x02,
        //    Boring = 0x04,
        //    Cool = 0x08,
        //    Interesting = 0x10,
        //    Informative = 0x20,
        //    Error = 0x40
        //}
        //var code = 24;
        //var q = (Status)code;
        //Console.WriteLine(String.Format("This Quiz is: {0}", (Status)code));


        //// Задача 2
        //var arr1 = Enumerable.Range(0, 100).Select(x => x * 2).ToArray();
        //var arr2 = arr1.TakeWhile(x => x % 2 == 0).Except(arr1).Select(x => x).ToArray();

        //Console.WriteLine(Enumerable.SequenceEqual(arr1, arr2));


        //// Задача 3
        /////static async void IterateAsync(int[] nums)
        //{
        //    await new Task(() => DoIterations(nums));
        //}

        //static void DoIterations(int[] nums)
        //{
        //    foreach (var num in nums)
        //    {
        //        Console.WriteLine(num);
        //    }
        //}

        //static async Task Main(string[] args)
        //{

        //    var nums = new int[500];
        //    for (int i = 0, j = 1; i < nums.Length; i++, j++)
        //    {
        //        nums[i] = j;
        //    }

        //    IterateAsync(nums);

        //    for (int i = 0; i < 500; i++)
        //    {
        //        Console.WriteLine("Main method");
        //    }

        //}



        //// Задача 4
        ////Для каждой строки массива: если у строки четный индекс - к этой строке приписывается "marked"; 
        ////если у строки нечетный индекс - она становится пустой. При выводе увидим только строки четных индексов с припиской "marked".
        
        //string[] strings = new string[] { "a", "b", "c", "d", "e", "f", "g" };
        //var output = strings.Select(s => Array.IndexOf(strings, s) % 2 == 0 ? s += " marked" : "");

        //foreach (var str in output)
        //{
        //    Console.Write(str + " ");
        //}

        //"a marked b c marked d e marked f g marked"
        //"a marked  c marked  e marked  g marked"
        //"a c e g"
        //"b marked  d marked  f marked"




    }
}
