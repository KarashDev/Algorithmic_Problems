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
            //var colors = new string[] { "brown", "grey", "black", "red" };
            //var x = colors.Max(c => c.Length);
            //var z = colors.Count(c => c.Length > 3);
            //var y = colors.Count(c => c.Contains('e'));


            //Console.WriteLine(x);
            //Console.WriteLine(z);
            //Console.WriteLine(y);


            //// Найти самое длинное слово содержащее хотя бы одну букву "e"
            //var words = new string[] { "brown", "grey", "black", "red", "redmond", "error", "adbcdtrdgqsfd", "advantage" };
            //var target = words.Aggregate((target, i) => i.Length > target.Length && i.Contains('e') ? target = i : target);
            //Console.WriteLine(target);

            //Console.WriteLine(new string(words[0].ToCharArray().Reverse().ToArray()));

            string GetName(string str)
            {
                // Не написано: greetingStr если не перед именем - имя не надо выводить
                var names = new List<string>() { "Rod", "Stewart", "Carter", "Dixon", "Marshall", "Smith", "Walker" };
                var greetingStr = new List<string> { "Im", "I'm", "I am", "My name is" };

                if (greetingStr.Any(gr => str.ToLower().Contains(gr.ToLower())) && names.Any(n => str.ToLower().Contains(n.ToLower())))
                {
                    var foundNames = names.Where(n => str.ToLower().Contains(n.ToLower()));
                    var outputName = "";

                    foreach (var name in foundNames)
                    {
                        outputName += name + " ";
                    }
                    return outputName;
                }

                return null;
            }


            string[] lines = {
            "Hi, I'm Carter",
            "My name is rod Stewart",
            "Nice to meet you, im dixon...",
            "I am smith walker it's nice to meet you",
            "i'm Carter Stewart Smith, how are you doing?",
            "There's no name here",
            "Hi I'm late for an interview",
            "I am a retail manager",
            "Im Dixon marshall and I have a question.",
            "Where is Rod Stewart and his dog?",
            "Hi my name is Dixon Walker, where can I buy these shoes?",
            "I am hungry but I want to see Marshall first."
            };

            foreach (string s in lines)
            {
                Console.WriteLine(string.Format("{0} => {1}", s, GetName(s)));
            }





        }
    }
}
