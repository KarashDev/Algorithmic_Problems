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

            Person person;

            try
            {
                person = new Person("", 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                person = new Person("Boba", 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            person = new Person("Ivan", 28);

            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);


        }
    }
}
