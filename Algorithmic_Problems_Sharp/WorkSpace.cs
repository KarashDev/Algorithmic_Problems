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
using System.Management;

namespace Algorithmic_Problems_Sharp
{
    class WorkSpace
    {

        public class Person
        {
            private string name;
            public string Name
            {
                get => name;
                set
                {
                    if (value.Length > 2 && value.Length < 20)
                        name = value;
                    else
                        throw new ArgumentException("Impossible name");
                }
            }

            private int age;
            public int Age
            {
                get => age;
                set
                {
                    if (value > 0 && value < 110)
                        age = value;
                    else
                        throw new ArgumentException("Impossible age");
                }
            }


            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }



        }




        static void Main(string[] args)
        {

            //Person person;

            //try
            //{
            //    person = new Person("", 0);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //try
            //{
            //    person = new Person("Boba", 0);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //person = new Person("Ivan", 28);

            //Console.WriteLine(person.Name);
            //Console.WriteLine(person.Age);



            ////В первой строке задается одно натуральное число N, не превосходящее 10001000.
            ////Во второй строке вводятся N целых чисел, каждое из которых по модулю не превосходит 10001000.
            ////В третьей строке содержится одно целое число x, не превосходящее по модулю 10001000.

            //// Линейный поиск через Aggregate
            //var inputCount = Convert.ToInt32(Console.ReadLine());

            //var numbersStrings = Console.ReadLine().Split(" ");
            //var numbers = Array.ConvertAll(numbersStrings, n => Convert.ToInt32(n));

            //var numToFind = Convert.ToInt32(Console.ReadLine());


            //int LinearSearch(int[] numbers, int x) => numbers.Aggregate(0, (cnt, i) => i == x ? cnt + 1 : cnt);

            ////Console.WriteLine(LinearSearch(numbers, numToFind));



            //// То же самое, только надо вывести порядковые номера всех найденных чисел X (i + 1)
            //List<int> FindIndexes(List<int> numbers, int x)
            //{
            //    List<int> matches = new List<int>();

            //    for (int i = 0; i < numbers.Count; i++)
            //    {
            //        if (numbers[i] == x)
            //            matches.Add(i + 1);
            //    }
            //    return matches;
            //}

            //var result = string.Join(" ", FindIndexes(numbers.ToList(), numToFind));

            //Console.WriteLine(result);




            // Если есть элементы больше заданного - нахожу разницу между минимальным бОльшим и заданным
            // Если есть элементы меньше заданного - нахожу разницу между максимальным меньшим и заданным
            // Если истинны оба варианта: сравнить эти две разницы, выбрать элемент с минимальной






            //var inputCount = Convert.ToInt32(Console.ReadLine());

            //var numbersStrings = Console.ReadLine().Split(" ");
            //var numbers = Array.ConvertAll(numbersStrings, n => Convert.ToInt32(n));

            //var numToFind = Convert.ToInt32(Console.ReadLine());



            int FindNearestNumber(int[] numbers, int x)
            {
                var numsOrderedByProximity = numbers.OrderBy(n => Math.Abs(n - x)).ToArray();

                var indexesToPosDiffs = new Dictionary<int, int>();
                for (int i = 0; i < numsOrderedByProximity.Length; i++)
                {
                    indexesToPosDiffs.TryAdd(numbers[i], Math.Abs(numbers[i] - x));
                }

                var smallestValues = indexesToPosDiffs.Where(pair => pair.Value == indexesToPosDiffs.Min(p => p.Value));

                if (smallestValues.Count() > 0)
                    return smallestValues.OrderBy(p => p.Key).Last().Key;
                else
                    return smallestValues.First().Key;
            }

            //Console.WriteLine(FindNearestNumber(numbers, numToFind));
            //Console.WriteLine(FindNearestNumber(new int[] { 2, 10, 5 }, 6));
            //Console.WriteLine(FindNearestNumber(new int[] { 1, 4, 7, 10 }, 1));
            //Console.WriteLine(FindNearestNumber(new int[] { -1000, 1000 }, 0));
            //Console.WriteLine(FindNearestNumber(new int[] { 2, 3, 5, 6 }, 4));
            //Console.WriteLine(FindNearestNumber(new int[] { 1000, -1000 }, 0));
            Console.WriteLine(FindNearestNumber(new int[] { -1000, -1000 }, 0));




    }
}
