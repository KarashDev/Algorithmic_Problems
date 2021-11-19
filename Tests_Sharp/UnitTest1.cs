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

                // Примечание: если бы нужно было вставить нули в начало List,
                // нужно было бы использовать List.Insert(0, num)
            }

            Assert.AreEqual(new int[] { 1, 2, 1, 1, 3, 1, 0, 0, 0, 0 }, MoveZeroes(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 }));
        }


        [Test]
        public void MakeDeadFishSwim()
        {
            int[] Parse(string data)
            {
                List<int> digitsForOutput = new List<int>();
                double digitForOperations = 0;

                for (int i = 0; i < data.Length; i++)
                {
                    switch (data[i])
                    {
                        case 'i': digitForOperations++; break;
                        case 'd': digitForOperations--; break;
                        case 's': digitForOperations = Math.Pow(digitForOperations, 2); break;
                        case 'o': digitsForOutput.Add((int)digitForOperations); break;
                    }
                }

                return digitsForOutput.ToArray();
            }

            Assert.AreEqual(new int[] { 8, 64 }, Parse("iiisdoso"));
            Assert.AreEqual(new int[] { 8, 64, 3600 }, Parse("iiisdosodddddiso"));
        }


        [Test]
        public void ChangeWordCases()
        {
            string TitleCase(string title, string minorWords = "")
            {
                var words = title.ToLower().Split(' ');
                if (!String.IsNullOrEmpty(minorWords))
                {
                    var minors = minorWords.Split(' ');
                    words[0] = Char.ToUpper(words[0][0]) + words[0].Substring(1);

                    for (int i = 1; i < words.Length; i++)
                    {
                        words[i] = Char.ToUpper(words[i][0]) + words[i].Substring(1);

                        for (int j = 0; j < minors.Length; j++)
                        {
                            if (words[i].ToLower() == minors[j].ToLower())
                            {
                                words[i] = minors[j].ToLower();
                            }
                        }
                    }

                    return string.Join(" ", words);
                }
                else if (title != "")
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        words[i] = Char.ToUpper(words[i][0]) + words[i].Substring(1);
                    }
                    return string.Join(" ", words);
                }
                else return string.Empty;
            }

            Assert.AreEqual("A Clash of Kings", TitleCase("a clash of KINGS", "a an the of"));
            Assert.AreEqual("The Wind in the Willows", TitleCase("THE WIND IN THE WILLOWS", "The In"));
            Assert.AreEqual("The Quick Brown Fox", TitleCase("the quick brown fox"));
            Assert.AreEqual(string.Empty, TitleCase("", null));
            Assert.AreEqual(string.Empty, TitleCase("", ""));
        }

        
        // Задача на оптимизацию: установить, является ли входящее число простым. Сложность алгоритма 
        // должна быть меньше чем O(n) и меньше чем O(n/2)
        [Test]
        public void IsNumberPrime()
        {
            bool IsPrime(int n)
            {
                //// Оптимизация №1: увеличиваем шаг перечисления в 2 раза, разделив вход на два цикла 
                //// в зависимости от четности/нечетности входящего числа
                //if (n <= 0 || n == 1)
                //    return false;
                //else if (n % 2 == 0)
                //{
                //    for (int i = 2; i < n / 2; i += 2)
                //    {
                //        if (n % i == 0)
                //        {
                //            return false;
                //        }
                //    }
                //}
                //else if (n % 2 != 0)
                //{
                //    for (int i = 3; i < n / 2; i += 2)
                //    {
                //        if (n % i == 0)
                //        {
                //            return false;
                //        }
                //    }
                //}
                //return false;


                // Оптимизация №2: пересчет ведем не до самого числа, а до корня этого числа; так мы
                // сильно уменьшаем число (и количество итераций), но при этом его проверяемые свойства 
                // не меняются; в догонку можно округлить корень до целого числа
                if (n <= 0 || n == 1 || n % 2 == 0 && n != 2)
                    return false;

                var boundary = (int)Math.Floor(Math.Sqrt(n));
                for (int i = 3; i < boundary; i += 2)
                {
                    if (n % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            Assert.AreEqual(false, IsPrime(1));
            Assert.AreEqual(true, IsPrime(2));
            Assert.AreEqual(false, IsPrime(-1));
            Assert.AreEqual(true, IsPrime(11));
            Assert.AreEqual(false, IsPrime(123032905));
            Assert.AreEqual(false, IsPrime(12536));
            Assert.AreEqual(true, IsPrime(7419161));
        }

        //[Test]
        //public void Xxxxx()
        //{
        //    void(string data)
        //    {

        //    }

        //    Assert.AreEqual(new int[] { 8, 64 }, Parse("iiisdoso"));
        //    Assert.AreEqual(new int[] { 8, 64, 3600 }, Parse("iiisdosodddddiso"));
        //}





    }
}