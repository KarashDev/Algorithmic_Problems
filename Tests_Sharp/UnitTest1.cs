using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests_Sharp
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            string AlphabetPosition(string text)
            {
                //return string.Join(" ", text.ToLower().Where(c => char.IsLetter(c))
                //.Select(c => "abcdefghijklmnopqrstuvwxyz".IndexOf(c) + 1)
                //.ToArray());
                //или
                return string.Join(" ", text.ToLower().Where(c => char.IsLetter(c)).Select(c => c - 'a' + 1));

            }

            Assert.AreEqual("20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11",
                AlphabetPosition("The sunset sets at twelve o' clock."));
        }

        [Test]
        public void AreTheySame()
        {
            bool comp(int[] a, int[] b)
            {
                if (a.Length == 0 || b.Length == 0 || b.Length > a.Length)
                {
                    return false;
                }
                else
                {
                    List<int> notUsed = a.OfType<int>().ToList();
                    int cnt = 0;
                    foreach (var num in b)
                    {
                        if (a.Any(n => notUsed.Contains(n) && n == Math.Sqrt(num)))
                        {
                            cnt++;
                            notUsed.Remove((int)Math.Sqrt(num));
                        }
                    }

                    if (cnt == b.Length) return true;
                    else return false;
                }
            }

            int[] a = new int[] { 121, 144, 19, 161, 19, 144, 19, 11 };
            int[] b = new int[] { 11 * 11, 121 * 121, 144 * 144, 19 * 19, 161 * 161, 19 * 19, 144 * 144, 19 * 19 };

            int[] c = new int[] { 121, 144, 19, 161, 19, 144, 19, 11 };
            int[] d = new int[] { 121, 14641, 20736, 361, 25921, 361, 20736, 361 };

            bool r = comp(a, b); // True
            Assert.AreEqual(true, r);
        }


        [Test]
        public void Converter()
        {
            string dnaToRna(string dna)
            {
                return dna.Replace("T", "U");
            }

            Assert.AreEqual("UUUU", dnaToRna("TTTT"));
        }

        [Test]
        public void CountXY()
        {
            bool XO(string input)
            {
                // Мое решение:
                var inputStr = input.ToLower();
                var cntX = 0;
                var cntY = 0;
                foreach (var letter in inputStr)
                {
                    if (letter == 'x')
                        cntX++;
                    if (letter == 'o')
                        cntY++;
                }
                if (cntX == cntY)
                    return true;
                else return false;

                // Хорошее решение:
                return input.ToLower().Count(c => c == 'x') == input.ToLower().Count(c => c == 'o');
            }
            Assert.AreEqual(true, XO("xo"));
            Assert.AreEqual(true, XO("xxOo"));
            Assert.AreEqual(false, XO("xxxm"));
            Assert.AreEqual(false, XO("Oo"));
            Assert.AreEqual(false, XO("ooom"));
        }


        [Test]
        public void CamelCase()
        {
            string BreakCamelCase(string str)
            {
                string inputString = str;
                for (int i = 0; i < inputString.Length; i++)
                {
                    if (Char.IsUpper(inputString[i]) && i != 0)
                    {
                        // Если после вставки пробела не сместить i на символ вправо, программа
                        // будет бесконечно вставлять пробел перед выбранной буквой
                        inputString = inputString.Insert(i, " ");
                        i++;
                    }
                }

                return inputString;
            }
            Assert.AreEqual("Camel Case", BreakCamelCase("CamelCase"));
            Assert.AreEqual("xxio", BreakCamelCase("xxio"));
            Assert.AreEqual("Hello World", BreakCamelCase("HelloWorld"));
            Assert.AreEqual("Helloworld", BreakCamelCase("Helloworld"));
            Assert.AreEqual("camel Case Caaase", BreakCamelCase("camelCaseCaaase"));
        }


        [Test]
        public void MoveZeroesInArray()
        {
            int[] MoveZeroes(int[] arr)
            {
                // Мое решение:
                List<int> newList = new List<int>();
                int howMuchZeroes = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != 0)
                        newList.Add(arr[i]);
                    else howMuchZeroes++;
                }

                for (int i = 0; i < howMuchZeroes; i++)
                {
                    newList.Add(0);
                }
                return newList.ToArray();

                // Хорошее решение:
                return arr.OrderBy(x => x == 0).ToArray();
            }

            Assert.AreEqual(new int[] { 1, 2, 1, 1, 3, 1, 0, 0, 0, 0 }, MoveZeroes(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 }));
        }










    }
}