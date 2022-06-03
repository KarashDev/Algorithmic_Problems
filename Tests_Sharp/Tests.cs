﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;

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


        [Test]
        public void UniqueOnecInOrder()
        {
            IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
            {
                List<T> inputCollection = new List<T>();
                foreach (var item in iterable)
                {
                    inputCollection.Add(item);
                }

                for (int i = 0; i < inputCollection.Count - 1; i++)
                {
                    if (inputCollection[i + 1].Equals(inputCollection[i]))
                    {
                        inputCollection.RemoveAt(i + 1);
                        i--;
                    }
                }
                return inputCollection;

                //// Дополнительное неплохое решение:
                //T previous = default(T);
                //foreach (T current in iterable)
                //{
                //	if (!current.Equals(previous))
                //	{
                //		previous = current;
                //		yield return current;
                //	}
                //}
            }

            Assert.AreEqual("ABCDAB", UniqueInOrder("AAAABBBCCDAABBB"));
            Assert.AreEqual("ABCcAD", UniqueInOrder("ABBCcAD"));
            Assert.AreEqual("ABCDAB", UniqueInOrder("AAAABBBCCDAABBB"));
            Assert.AreEqual(new int[] { 1, 2, 3 }, UniqueInOrder(new int[] { 1, 2, 2, 3, 3 }));
        }


        [Test]
        public void SimpleEncryption()
        {
            string Encrypt(string text, int n)
            {
                if (String.IsNullOrEmpty(text) || n <= 0)
                    return text;

                string encryptedStr = "";

                for (int repeats = 0; repeats < n; repeats++)
                {
                    if (repeats >= 1)
                    {
                        text = encryptedStr;
                        encryptedStr = "";
                    }

                    for (int i = 1; i < text.Length; i += 2)
                    {
                        encryptedStr += text[i];
                    }

                    for (int i = 0; i < text.Length; i += 2)
                    {
                        encryptedStr += text[i];
                    }
                }

                return encryptedStr;

                // ПОЛЕЗНО:
                //while (n != 0)
                //{
                //	text = string.Concat(text.Where((c, i) => i % 2 == 1).Concat(text.Where((c, i) => i % 2 == 0)));

                //	n--;
                //}
            }

            string Decrypt(string encryptedText, int n)
            {
                if (String.IsNullOrEmpty(encryptedText) || n <= 0)
                    return encryptedText;

                List<char> finalSymbols = new List<char>();

                for (int repeats = 0; repeats < n; repeats++)
                {
                    if (repeats >= 1)
                    {
                        encryptedText = String.Join("", finalSymbols.ToArray());
                        finalSymbols.Clear();
                    }

                    string oddIndexedChars = "";
                    string evenIndexedChars = "";

                    for (int i = 0; i < encryptedText.Length / 2; i++)
                    {
                        oddIndexedChars += encryptedText[i];
                    }
                    for (int i = encryptedText.Length / 2; i < encryptedText.Length; i++)
                    {
                        evenIndexedChars += encryptedText[i];
                    }

                    int totalCharsToIterate;

                    if (oddIndexedChars.Length >= evenIndexedChars.Length)
                        totalCharsToIterate = oddIndexedChars.Length;
                    else totalCharsToIterate = evenIndexedChars.Length;

                    for (int i = 0; i < totalCharsToIterate; i++)
                    {
                        if (i < evenIndexedChars.Length)
                            finalSymbols.Add(evenIndexedChars[i]);
                        if (i < oddIndexedChars.Length)
                            finalSymbols.Add(oddIndexedChars[i]);
                    }
                }

                return String.Join("", finalSymbols.ToArray());

                // ПОЛЕЗНО:
                //while (n != 0)
                //{
                //	string leftPart = string.Concat(text.Take(text.Length/2));
                //	string rightPart = string.Concat(text.Skip(text.Length/2));

                //	text = string.Concat(Enumerable.Range(0, text.Length).Select(i => i % 2 == 0 ? rightPart[i/2] : leftPart[i/2]));

                //	n--;
                //}
            }

            Assert.AreEqual("This is a test!", Encrypt("This is a test!", 0));
            Assert.AreEqual("hsi  etTi sats!", Encrypt("This is a test!", 1));
            Assert.AreEqual("s eT ashi tist!", Encrypt("This is a test!", 2));
            Assert.AreEqual(" Tah itse sits!", Encrypt("This is a test!", 3));
            Assert.AreEqual("This is a test!", Encrypt("This is a test!", 4));
            Assert.AreEqual("This is a test!", Encrypt("This is a test!", -1));
            Assert.AreEqual("hskt svr neetn!Ti aai eyitrsig", Encrypt("This kata is very interesting!", 1));

            Assert.AreEqual("This is a test!", Decrypt("This is a test!", 0));
            Assert.AreEqual("This is a test!", Decrypt("hsi  etTi sats!", 1));
            Assert.AreEqual("This is a test!", Decrypt("s eT ashi tist!", 2));
            Assert.AreEqual("This is a test!", Decrypt(" Tah itse sits!", 3));
            Assert.AreEqual("This is a test!", Decrypt("This is a test!", 4));
            Assert.AreEqual("This is a test!", Decrypt("This is a test!", -1));
            Assert.AreEqual("This kata is very interesting!", Decrypt("hskt svr neetn!Ti aai eyitrsig", 1));
        }


        [Test]
        public void AddTooBigNumbers()
        {
            string Add(string a, string b)
            {
                var bigA = BigInteger.Parse(a, CultureInfo.InvariantCulture);
                var bigB = BigInteger.Parse(b, CultureInfo.InvariantCulture);

                var output = BigInteger.Add(bigA, bigB);

                return Convert.ToString(output);
            }

            Assert.AreEqual("1111111111", Add("123456789", "987654322"));
            Assert.AreEqual("1000000000", Add("999999999", "1"));
            Assert.AreEqual("1000000000000000000000001", Add("1000000000000000000000000", "1"));
        }


        // TODO не завершено
        //      [Test]
        //      public void Permutations()
        //      {
        //	List<string> SinglePermutations(string s)
        //	{

        //	}

        //	Assert.AreEqual(new List<string> { "a" }, SinglePermutations("a").OrderBy(x => x).ToList());
        //	Assert.AreEqual(new List<string> { "aabb", "abab", "abba", "baab", "baba", "bbaa" }, SinglePermutations("aabb").OrderBy(x => x).ToList());
        //	Assert.AreEqual(new List<string> { "ab", "ba" }, SinglePermutations("ab").OrderBy(x => x).ToList());
        //}
        //var testListA = SinglePermutations("aabb").OrderBy(x => x).ToList();
        ////{ "aabb", "abab", "abba", "baab", "baba", "bbaa" }
        //foreach (var item in testListA)
        //{
        //    Console.Write(item + " ");
        //}

        //Console.WriteLine();

        //var testListB = SinglePermutations("ab").OrderBy(x => x).ToList();
        ////{ "ab", "ba" }
        //foreach (var item in testListB)
        //{
        //    Console.Write(item + " ");
        //}


        [Test]
        public void TicTacToe()
        {
            // 0 - empty
            // 1 - X
            // 2 - O

            // return 1 - X won
            // return 2 - O won
            // return 0 - draw
            int IsSolved(int[,] board)
            {
                var height = board.GetLength(0);
                var wight = board.GetLength(1);
                var zeroesCnt = 0;
                var Xcnt = 0;
                var Ocnt = 0;


                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < wight; j++)
                    {
                        if (board[i, j] == 1)
                            Xcnt++;
                        if (board[i, j] == 2)
                            Ocnt++;
                        if (board[i, j] == 0)
                            zeroesCnt++;
                    }
                }

                for (int i = 0; i < height - 2; i++)
                {
                    for (int j = 0; j < wight - 2; j++)
                    {
                        bool isThereXLine = false;
                        bool isThereOLine = false;

                        if (board[i, j] == board[i, j + 1]
                            && board[i, j + 1] == board[i, j + 2]
                            || board[i + 1, j] == board[i + 1, j + 1]
                            && board[i + 1, j + 1] == board[i + 1, j + 2]
                            || board[i + 2, j] == board[i + 2, j + 1]
                            && board[i + 2, j + 1] == board[i + 2, j + 2])
                        {
                            if (board[i, j] == 1)
                            {
                                isThereXLine = true;
                            }
                            else if (board[i, j] == 2)
                            {
                                isThereOLine = true;
                            }
                        }

                        if (board[i, j] == board[i + 1, j]
                          && board[i + 1, j] == board[i + 2, j]
                          || board[i, j + 1] == board[i + 1, j + 1]
                          && board[i + 1, j + 1] == board[i + 2, j + 1]
                           || board[i, j + 2] == board[i + 1, j + 2]
                          && board[i + 1, j + 2] == board[i + 2, j + 2]
                          )
                        {
                            if (board[i, j] == 1)
                            {
                                isThereXLine = true;
                            }
                            else if (board[i, j] == 2)
                            {
                                isThereOLine = true;
                            }
                        }

                        if (board[i, j] == board[i + 1, j + 1]
                            && board[i, j] == board[i + 2, j + 2]
                            )
                        {
                            if (board[i, j] == 1)
                            {
                                isThereXLine = true;
                            }
                            else if (board[i, j] == 2)
                            {
                                isThereOLine = true;
                            }
                        }

                        if (board[i, j + 2] == board[i + 1, j + 1]
                            && board[i + 1, j + 1] == board[i + 2, j]
                            )
                        {
                            if (board[i, j] == 1)
                            {
                                isThereXLine = true;
                            }
                            else if (board[i, j + 2] == 2)
                            {
                                isThereOLine = true;
                            }
                        }

                        if (isThereXLine && !isThereOLine)
                            return 1;
                        else if (isThereOLine && !isThereXLine)
                            return 2;
                        else if (!isThereOLine && !isThereXLine && zeroesCnt == 0)
                        {
                            return 0;
                        }
                        else if (!isThereOLine && !isThereXLine && zeroesCnt > 0)
                        {
                            return -1;
                        }
                    }
                }

                return 0;
            }

            int[,] board = new int[,] { { 1, 1, 1 }, { 0, 2, 2 }, { 0, 0, 0 } };
            Assert.AreEqual(1, IsSolved(board));

            //int[,] board = new int[,] { { 1, 1, 1 }, { 0, 2, 2 }, { 0, 0, 0 } };
            //Console.WriteLine(IsSolved(board));

            //int[,] board2 = new int[,] { { 1, 1, 0 }, { 1, 2, 2 }, { 1, 0, 0 } };
            //Console.WriteLine(IsSolved(board2));

            //int[,] board3 = new int[,] { { 0, 1, 0 }, { 0, 2, 2 }, { 0, 0, 0 } };
            //Console.WriteLine(IsSolved(board3));

            //int[,] board4 = new int[,] { { 0, 1, 0 }, { 2, 2, 2 }, { 0, 0, 0 } };
            //Console.WriteLine(IsSolved(board4));

            //int[,] board5 = new int[,] { { 2, 1, 0 }, { 2, 2, 1 }, { 2, 0, 0 } };
            //Console.WriteLine(IsSolved(board5));

            //int[,] board6 = new int[,] { { 0, 0, 1 }, { 0, 1, 0 }, { 1, 0, 0 } };
            //Console.WriteLine(IsSolved(board6));
        }


        [Test]
        public void SnailArray()
        {
            int[] Snail(int[][] array)
            {
                int inputTotalLength = 0;
                foreach (var arr in array)
                {
                    inputTotalLength += arr.Length;
                }

                List<int> nums = new List<int>();

                IterateCircle(array);

                int[] IterateCircle(int[][] array)
                {
                    if (array.Length == 1 && array[0].Length == 1)
                    {
                        nums.Add(array[0][0]);
                        return nums.ToArray();
                    }
                    else if (array.Length == 1 && array[0].Length == 0)
                    {
                        return new int[] { };
                    }

                    var upperArr = array[0];
                    foreach (var num in upperArr)
                    {
                        nums.Add(num);
                    }
                    array = array.Where(val => val != array[0]).ToArray();

                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        var subArrLength = array[i].Length;
                        nums.Add(array[i][subArrLength - 1]);

                        array[i] = array[i].Take(subArrLength - 1).ToArray();
                        //ИЛИ
                        //Array.Resize(ref array[i], subArrLength - 1);
                    }

                    var bottomArr = array[array.Length - 1];
                    Array.Reverse(bottomArr);
                    foreach (var num in bottomArr)
                    {
                        nums.Add(num);
                    }
                    Array.Reverse(bottomArr);
                    array = array.Where(val => val != array[array.Length - 1]).ToArray();

                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        nums.Add(array[i][0]);

                        array[i] = array[i].Skip(1).ToArray();
                        //ИЛИ
                        //array[i] = array[i].Where(val => val != array[i][0]).ToArray();
                    }

                    while (nums.Count != inputTotalLength)
                    {
                        var x = IterateCircle(array);

                        if (nums.Count == inputTotalLength)
                        {
                            return nums.ToArray();
                        }
                        nums.AddRange(x);
                    }

                    return nums.ToArray();
                }
                return nums.ToArray();
            }

            int[][] array1 =
            {
            new []{1, 2, 3},
            new []{4, 5, 6},
            new []{7, 8, 9}
            };

            int[][] array2 =
            {
            new[]{1, 2, 3},
            new[]{8, 9, 4},
            new[]{7, 6, 5}
            };

            int[][] array3 =
            {
            new[]{1, 2, 3, 9},
            new[]{4, 5, 6, 4},
            new[]{7, 8, 9, 1},
            new[]{1, 2, 3, 4}
            };

            int[][] array4 =
            {
            new[]{1, 2, 3, 9, 1},
            new[]{4, 5, 6, 4, 5},
            new[]{7, 8, 9, 1, 8},
            new[]{1, 2, 3, 4, 3},
            new[]{1, 2, 3, 4, 2}
            };

            Assert.AreEqual(new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 }, Snail(array1));
            Assert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, Snail(array2));
            Assert.AreEqual(new int[] { 1, 2, 3, 9, 4, 1, 4, 3, 2, 1, 7, 4, 5, 6, 9, 8 }, Snail(array3));
            Assert.AreEqual(new int[] { 1, 2, 3, 9, 1, 5, 8, 3, 2, 4, 3, 2, 1, 1, 7, 4, 5, 6, 4, 1, 4, 3, 2, 8, 9 }, Snail(array4));


        }


        // TODO на сайте не проходят часть решений; тестовые кейсы неизвестны
        [Test]
        public void DirReduction()
        {
            static string[] dirReduc(string[] arr)
            {
                List<string> arrList = new List<string>();
                arrList.AddRange(arr);

                arrList = Reduc(arrList);

                return arrList.ToArray();
            }

            static List<string> Reduc(List<string> arrList)
            {
                bool isAnyMatchFound = false;

                for (int i = 0; i < arrList.Count - 1; i++)
                {
                    if (arrList[i] == "NORTH" && arrList[i + 1] == "SOUTH"
                        || arrList[i] == "SOUTH" && arrList[i + 1] == "NORTH")
                    {
                        arrList.Remove(arrList[i]);
                        i--;
                        arrList.Remove(arrList[i + 1]);

                        isAnyMatchFound = true;
                    }
                    else if (arrList[i] == "EAST" && arrList[i + 1] == "WEST"
                        || arrList[i] == "WEST" && arrList[i + 1] == "EAST")
                    {
                        arrList.Remove(arrList[i]);
                        i--;
                        arrList.Remove(arrList[i + 1]);

                        isAnyMatchFound = true;
                    }
                }

                if (isAnyMatchFound)
                    Reduc(arrList);

                return arrList;
            }

            string[] a = new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };
            string[] b = new string[] { "WEST" };
            Assert.AreEqual(b, dirReduc(a));

            string[] c = new string[] { "NORTH", "EAST", "WEST", "SOUTH", "WEST", "WEST" };
            string[] d = new string[] { "WEST", "WEST" };
            Assert.AreEqual(d, dirReduc(c));

            string[] e = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
            string[] f = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
            Assert.AreEqual(f, dirReduc(e));

        }



        [Test]
        public void SumSquaredDivisors()
        {
            List<long> GetDivisors(long num)
            {
                List<long> divisors = new List<long>();
                for (int i = 1; i <= num; i++)
                {
                    if (num % i == 0)
                        divisors.Add(i);
                }
                return divisors;
            }

            string listSquared(long m, long n)
            {
                // В рендже m-n найти каждое число, у которого сумма всех его делителей возведенных в квадрат
                // сама является целочисленным квадратом
                // Вывести string в виде [[x, y], [x, y]], где x - найденное число; y - сумма квадратов делителей этого числа

                // Найти все делители; возвести их в квадрат; сложить их; результат проверить на целочисленный корень

                List<long> divisors = new List<long>();
                List<double> divisorsSquared = new List<double>();

                long[][] outputArrays = new long[0][];

                for (long i = m; i <= n; i++)
                {
                    divisors = GetDivisors(i);

                    if (divisors.Count != 2)
                    {
                        divisorsSquared = divisors.Select(d => Math.Pow(d, 2)).ToList();
                        double sumOfDivisors = divisorsSquared.Sum();

                        if (Math.Sqrt(sumOfDivisors) % 1 == 0)
                        {
                            long[] outputArr = new long[] { i, (long)sumOfDivisors };

                            Array.Resize(ref outputArrays, outputArrays.Length + 1);
                            outputArrays[outputArrays.Length - 1] = outputArr;
                        }
                    }
                }

                string outputString = "[";

                for (int i = 0; i < outputArrays.Length; i++)
                {
                    if (i != outputArrays.Length - 1)
                    {
                        outputString += $"[{outputArrays[i][0]}, {outputArrays[i][1]}], ";
                    }
                    else outputString += $"[{outputArrays[i][0]}, {outputArrays[i][1]}]";
                }
                outputString += "]";
                return outputString;
            }


            Assert.AreEqual("[[1, 1], [42, 2500], [246, 84100]]", listSquared(1, 250));

            Assert.AreEqual("[[42, 2500], [246, 84100]]", listSquared(42, 250));

            Assert.AreEqual("[[287, 84100]]", listSquared(250, 500));
        }


        [Test]
        public void PickPeaks()
        {
            Dictionary<string, List<int>> GetPeaks(int[] arr)
            {
                List<int> poses = new List<int>();
                List<int> peaks = new List<int>();

                bool isTherePeak = false;

                for (int i = 1; i < arr.Length - 1; i++)
                {
                    if (arr[i - 1] < arr[i] && arr[i] > arr[i + 1])
                    {
                        poses.Add(i);
                        peaks.Add(arr[i]);
                        isTherePeak = true;
                    }

                    if (arr[i - 1] < arr[i] && arr[i] == arr[i + 1])
                    {
                        int[] sequenceAfterPlato = new int[arr.Length - (i + 1)];
                        Array.Copy(arr, i + 1, sequenceAfterPlato, 0, arr.Length - (i + 1));

                        for (int j = 0; j < sequenceAfterPlato.Length; j++)
                        {
                            if (sequenceAfterPlato[j] < arr[i])
                            {
                                poses.Add(i);
                                peaks.Add(arr[i]);

                                isTherePeak = true;
                                break;
                            }
                            else if (sequenceAfterPlato[j] > arr[i])
                                break;
                        }
                    }
                }

                if (!isTherePeak)
                {
                    return new Dictionary<string, List<int>>()
                    {
                        ["pos"] = new List<int>(),
                        ["peaks"] = new List<int>()
                    };
                }
                else
                {
                    return new Dictionary<string, List<int>>()
                    {
                        ["pos"] = poses,
                        ["peaks"] = peaks
                    };
                }
            }

            string[] msg =
            {
                "should support finding peaks",
                "should support finding peaks, but should ignore peaks on the edge of the array",
                "should support finding peaks; if the peak is a plateau, it should only return the position of the first element of the plateau",
                "should support finding peaks; if the peak is a plateau, it should only return the position of the first element of the plateau",
                "should support finding peaks, but should ignore peaks on the edge of the array"
            };

            int[][] array =
            {
                new int[]{1,2,3,6,4,1,2,3,2,1},
                new int[]{3,2,3,6,4,1,2,3,2,1,2,3},
                new int[]{3,2,3,6,4,1,2,3,2,1,2,2,2,1},
                new int[]{2,1,3,1,2,2,2,2,1},
                new int[]{2,1,3,1,2,2,2,2}
            };

            int[][] posS =
             {
                new int[]{3,7},
                new int[]{3,7},
                new int[]{3,7,10},
                new int[]{2,4},
                new int[]{2}
            };

            int[][] peaksS =
            {
                new int[]{6,3},
                new int[]{6,3},
                new int[]{6,3,2},
                new int[]{3,2},
                new int[]{3}
            };


            for (int n = 0; n < msg.Length; n++)
            {
                int[] p1 = posS[n], p2 = peaksS[n];
                var expected = new Dictionary<string, List<int>>()
                {
                    ["pos"] = p1.ToList(),
                    ["peaks"] = p2.ToList()
                };
                var actual = GetPeaks(array[n]);
                Assert.AreEqual(expected, actual, msg[n]);
            }
        }


        [Test]
        public void NextSmallerNumber()
        {
            long NextSmaller(long n)
            {
                long nums = 0;
                nums = n;

                List<long> digits = new List<long>();
                List<long> partToSort = new List<long>();

                while (nums != 0)
                {
                    digits.Add(nums % 10);
                    nums /= 10;
                }
                digits.Reverse();


                bool isFirstObjectFound = false;

                for (int i = digits.Count - 1; i >= 0; i--)
                {
                    // Останавливать нужно именно цикл j, поскольку даже после перестановки и сортировки
                    // могут оказаться числа в рейндже j которые при этом меньше чем i; и эти числа снова перестановятся,
                    // из-за чего выходное число будет НЕ первым меньшим числом 
                    for (int j = digits.Count - 1; j > i && !isFirstObjectFound; j--)
                    {
                        if (digits[j] < digits[i])
                        {
                            isFirstObjectFound = true;

                            var temp = digits[i];
                            digits[i] = digits[j];
                            digits[j] = temp;

                            partToSort = digits.GetRange(i + 1, digits.Count - (i + 1));
                            digits.RemoveRange(i + 1, digits.Count - (i + 1));

                            partToSort.Sort((a, b) => b.CompareTo(a));
                            digits.AddRange(partToSort);
                        }
                    }
                }

                if (digits[0] == 0)
                    return -1;
                else
                {
                    long total = 0;
                    foreach (int entry in digits)
                    {
                        total = 10 * total + entry;
                    }

                    if (total == n)
                        return -1;
                    else
                        return total;
                }
            }

            Assert.AreEqual(12, NextSmaller(21));
            Assert.AreEqual(790, NextSmaller(907));
            Assert.AreEqual(513, NextSmaller(531));
            Assert.AreEqual(-1, NextSmaller(1027));
            Assert.AreEqual(414, NextSmaller(441));
            Assert.AreEqual(123456789, NextSmaller(123456798));
            Assert.AreEqual(1247632, NextSmaller(1262347));
        }


        [Test]
        public void NicoSypher()
        {
            string Nico(string key, string message)
            {
                char[] keyChars = key.ToCharArray();
                char[] keyCharsSorted = new char[keyChars.Length];
                Array.Copy(keyChars, 0, keyCharsSorted, 0, keyChars.Length);

                Array.Sort(keyCharsSorted);

                Dictionary<char, int> charsToSerNumbers = new Dictionary<char, int>();
                for (int i = 0; i < keyCharsSorted.Length; i++)
                {
                    charsToSerNumbers.Add(keyCharsSorted[i], i + 1);
                }

                int[] readyKey = new int[keyCharsSorted.Length];
                for (int i = 0; i < charsToSerNumbers.Count; i++)
                {
                    readyKey[i] = charsToSerNumbers[keyChars[i]];
                }


                string readyChunk = "";
                string subStringOnKey = "";

                while (message != "")
                {
                    if (message.Length > readyKey.Length)
                        subStringOnKey = message.Substring(0, readyKey.Length);
                    else if (message.Length <= readyKey.Length)
                        subStringOnKey = message;

                    Dictionary<int, char> subStringCharsToKey = new Dictionary<int, char>();
                    for (int i = 0; i < subStringOnKey.Length; i++)
                    {
                        subStringCharsToKey.Add(readyKey[i], subStringOnKey[i]);
                    }

                    for (int i = 0; i < readyKey.Length; i++)
                    {
                        try
                        {
                            readyChunk += subStringCharsToKey[i + 1];
                        }
                        catch (KeyNotFoundException)
                        {
                            readyChunk += " ";
                        }
                    }

                    message = message.Substring(subStringOnKey.Length, message.Length - subStringOnKey.Length);
                }

                return readyChunk;
            }

            Assert.AreEqual("cseerntiofarmit on  ", Nico("crazy", "secretinformation"));
            Assert.AreEqual("abcd  ", Nico("abc", "abcd"));
            Assert.AreEqual("2143658709", Nico("ba", "1234567890"));
            Assert.AreEqual("message", Nico("a", "message"));
            Assert.AreEqual("eky", Nico("key", "key"));
        }


        [Test]
        public void MaxSumDigits()
        {
            long GetSumOfDigits(long num)
            {
                long sum = 0;
                while (num != 0)
                {
                    sum += num % 10;
                    num /= 10;
                }
                return sum;
            }

            long[] MaxSumDig(long nmax, int maxsm)
            {
                List<long> matchedNums = new List<long>();

                for (int i = 1000; i <= nmax; i++)
                {
                    if (GetSumOfDigits(i) <= maxsm)
                        matchedNums.Add(i);
                }

                var matchedNumsCount = matchedNums.Count;

                // Ближайшее число к нужному нам (X) находим путем сортировки по ключу и последующего "вынимания" самого первого числа
                // с отсортированного списка. Сортировка производится по минимальной разнице между X (средним арифметическим) и любым 
                // другим числом из нашей коллекции.
                var matchedNumsMean = matchedNums.Sum() / matchedNums.Count;
                var closestNumToMean = matchedNums.OrderBy(item => Math.Abs(matchedNumsMean - item)).First();
                //ИЛИ
                //var closestNumToMean = matchedNums.Aggregate((x, y) => Math.Abs(x-matchedNumsMean) < Math.Abs(y-matchedNumsMean) ? x : y);

                var matchedNumsSum = matchedNums.Sum();

                return new long[] { matchedNumsCount, closestNumToMean, matchedNumsSum };
            }

            Assert.AreEqual(new long[] { 11, 1110, 12555 }, MaxSumDig(2000, 3));
            Assert.AreEqual(new long[] { 21, 1120, 23665 }, MaxSumDig(2000, 4));
            Assert.AreEqual(new long[] { 85, 1200, 99986 }, MaxSumDig(2000, 7));
            Assert.AreEqual(new long[] { 141, 1600, 220756 }, MaxSumDig(3000, 7));
        }


        [Test]
        public void SumOfStrings()
        {
            string SumStrings(string a, string b)
            {
                //if (string.IsNullOrEmpty(a))
                //	return b;
                //else if (string.IsNullOrEmpty(b))
                //	return a;

                //BigInteger numA = BigInteger.Parse(a);
                //BigInteger numB = BigInteger.Parse(b);

                //ИЛИ без проверки на пустые строки (значения останутся пустыми, если парсинг не удастся)
                BigInteger numA;
                BigInteger numB;
                BigInteger.TryParse(a, out numA);
                BigInteger.TryParse(b, out numB);

                return Convert.ToString(BigInteger.Add(numA, numB));
            }

            Assert.AreEqual("579", SumStrings("123", "456"));
            Assert.AreEqual("456", SumStrings("", "456"));
        }


        [Test]
        public void BigFactorialWithRef()
        {
            string BigFactorial(long num, out BigInteger factorial)
            {
                factorial = new BigInteger(1);

                for (int i = 1; i <= num; i++)
                {
                    factorial *= i;
                    //ИЛИ
                    //factorial = BigInteger.Multiply(i, factorial);
                }

                return factorial.ToString();
            }

            BigInteger factorial;
            BigFactorial(32, out factorial);
            Assert.AreEqual("263130836933693530167218012160000000", factorial.ToString());
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

        ////TODO не знаю как решать. ссылка: https://www.codewars.com/kata/56f4ff45af5b1f8cd100067d/train/csharp
        //[Test]
        //public void Dinglemouse()
        //{
        //    int[] Sort(int[] array)
        //    {
        //        // Your code here
        //        return new int[0];
        //    }

        //    Assert.AreEqual(new[] { 8, 8, 9, 9, 10, 10 }, Sort(new[] { 8, 8, 9, 9, 10, 10 }));
        //    Assert.AreEqual(new[] { 4, 1, 3, 2 }, Sort(new[] { 1, 2, 3, 4 }));
        //    Assert.AreEqual(new[] { 9, 999, 99 }, Sort(new[] { 9, 99, 999 }));
        //}


        [Test]
        public void FloodFillKata()
        {
            void ReplaceNum(int[,] array, int i, int j, int y, int x, int entryNum, int newValue)
            {
                var height = array.GetLength(0);
                var width = array.GetLength(1);

                if (array[i, j] == entryNum)
                {
                    int numToReplace = entryNum;
                    bool isFirstReplaceInCluster = false;

                    // Если замена самая первая - необходимо проверять окружающие числа 
                    // не на newValue а на самого себя (array[y, x]).
                    // Если замена НЕ первая - необходимо проверять окружающие числа на newValue (на уже замененное число)

                    if (i == y && j == x)
                    {
                        isFirstReplaceInCluster = true;
                    }

                    if (!isFirstReplaceInCluster)
                        numToReplace = newValue;

                    // Верхний левый угол
                    if (i == 0 && j == 0)
                    {
                        if (array[i + 1, j] == numToReplace || array[i, j + 1] == numToReplace || isFirstReplaceInCluster)
                        {
                            array[i, j] = newValue;
                        }
                    }
                    // Верхний правый угол
                    else if (i == 0 && j == width - 1)
                    {
                        if (array[i + 1, j] == numToReplace || array[i, j - 1] == numToReplace || isFirstReplaceInCluster)
                        {
                            array[i, j] = newValue;
                        }
                    }
                    // Нижний левый угол
                    else if (i == height - 1 && j == 0)
                    {
                        if (array[i - 1, j] == numToReplace || array[i, j + 1] == numToReplace || isFirstReplaceInCluster)
                        {
                            array[i, j] = newValue;
                        }
                    }
                    // Нижний правый угол
                    else if (i == height - 1 && j == width - 1)
                    {
                        if (array[i - 1, j] == numToReplace || array[i, j - 1] == numToReplace || isFirstReplaceInCluster)
                        {
                            array[i, j] = newValue;
                        }
                    }
                    // Из самого верхнего массива кроме углов
                    else if (i == 0)
                    {
                        if (array[i + 1, j] == numToReplace || array[i, j + 1] == numToReplace || array[i, j - 1] == numToReplace
                            || isFirstReplaceInCluster)
                        {
                            array[i, j] = newValue;
                        }
                    }
                    // Из самого левого массива кроме углов
                    else if (j == 0)
                    {
                        if (array[i - 1, j] == numToReplace || array[i + 1, j] == numToReplace || array[i, j + 1] == numToReplace
                            || isFirstReplaceInCluster)
                        {
                            array[i, j] = newValue;
                        }
                    }
                    // Из самого нижнего массива кроме углов
                    else if (i == height - 1)
                    {
                        if (array[i - 1, j] == numToReplace || array[i, j + 1] == numToReplace || array[i, j - 1] == numToReplace
                            || isFirstReplaceInCluster)
                        {
                            array[i, j] = newValue;
                        }
                    }
                    // Из самого правого массива кроме углов
                    else if (j == width - 1)
                    {
                        if (array[i - 1, j] == numToReplace || array[i + 1, j] == numToReplace || array[i, j - 1] == numToReplace
                            || isFirstReplaceInCluster)
                        {
                            array[i, j] = newValue;
                        }
                    }
                    // Откуда угодно кроме углов и крайних массивов
                    else
                    {
                        if (array[i - 1, j] == numToReplace || array[i + 1, j] == numToReplace || array[i, j - 1] == numToReplace
                            || array[i, j + 1] == numToReplace || isFirstReplaceInCluster)
                        {
                            array[i, j] = newValue;
                        }
                    }
                }
            }

            int[,] FloodFill(int[,] array, int y, int x, int newValue)
            {
                var height = array.GetLength(0);
                var width = array.GetLength(1);

                int entryNum = default;

                // Запись в переменную числа, которое нужно заменять
                try
                {
                    entryNum = array[y, x];
                }
                catch (Exception)
                {
                    return array;
                }

                if (height == 0 || width == 0)
                    return array;
                else if (height == 1 && width == 1)
                {
                    if (array[0, 0] == entryNum)
                    {
                        array[0, 0] = newValue;
                        return array;
                    }
                    else return array;
                }

                for (int i = 0; i <= height - 1; i++)
                {
                    for (int j = 0; j <= width - 1; j++)
                    {
                        ReplaceNum(array, i, j, y, x, entryNum, newValue);
                    }
                }

                for (int i = height - 1; i >= 0; i--)
                {
                    for (int j = width - 1; j >= 0; j--)
                    {
                        ReplaceNum(array, i, j, y, x, entryNum, newValue);
                    }
                }

                for (int j = 0; j <= height - 1; j++)
                {
                    for (int i = 0; i <= height - 1; i++)
                    {
                        ReplaceNum(array, i, j, y, x, entryNum, newValue);
                    }
                }

                for (int j = width - 1; j >= 0; j--)
                {
                    for (int i = height - 1; i >= 0; i--)
                    {
                        ReplaceNum(array, i, j, y, x, entryNum, newValue);
                    }
                }

                for (int i = 0; i <= height - 1; i++)
                {
                    for (int j = width - 1; j >= 0; j--)
                    {
                        ReplaceNum(array, i, j, y, x, entryNum, newValue);
                    }
                }

                for (int i = height - 1; i >= 0; i--)
                {
                    for (int j = 0; j <= width - 1; j++)
                    {
                        ReplaceNum(array, i, j, y, x, entryNum, newValue);
                    }
                }

                return array;
            }

            var expected = new int[,]
            {{1,4,3},
            {1,4,4},
            {2,3,4}};

            var actual = new int[,]
            {{1,2,3},
            {1,2,2},
            {2,3,2}};

            CollectionAssert.AreEqual(expected, FloodFill(actual, 0, 1, 4));

            //// Более правильные варианты
            //public static int[,] FloodFill(int[,] array, int x, int y, int newValue)
            //{
            //    var areaValue = array[x, y];
            //    var s = new Stack<Tuple<int, int>>();
            //    s.Push(new Tuple<int, int>(x, y));

            //    while (s.Count > 0)
            //    {
            //        var point = s.Pop();
            //        var p_x = point.Item1;
            //        var p_y = point.Item2;
            //        if (array[p_x, p_y] != areaValue || array[p_x, p_y] == newValue)
            //            continue;

            //        array[p_x, p_y] = newValue;
            //        if (p_x > 0)
            //            s.Push(new Tuple<int, int>(p_x - 1, p_y));
            //        if (p_x < array.GetUpperBound(0))
            //            s.Push(new Tuple<int, int>(p_x + 1, p_y));
            //        if (p_y > 0)
            //            s.Push(new Tuple<int, int>(p_x, p_y - 1));
            //        if (p_y < array.GetUpperBound(1))
            //            s.Push(new Tuple<int, int>(p_x, p_y + 1));
            //    }

            //    return array;
            //}

            //public static int[,] FloodFill(int[,] array, int startY, int startX, int newValue)
            //{
            //    var stack = new Stack<(int startY, int startX)>();

            //    var refVal = array[startY, startX];
            //    var maxY = array.GetLength(0);
            //    var maxX = array.GetLength(1);
            //    stack.Push((startY, startX));

            //    while (stack.Count != 0)
            //    {
            //        (int y, int x) = stack.Pop();

            //        if (y >= 0 && y < maxY
            //            && x >= 0 && x < maxX
            //            && array[y, x] == refVal)
            //        {
            //            array[y, x] = newValue;
            //            stack.Push((y-1, x));
            //            stack.Push((y+1, x));
            //            stack.Push((y, x-1));
            //            stack.Push((y, x+1));
            //        }

            //    }

            //    return array;
            //}

            //public static int[,] FloodFill(int[,] array, int y, int x, int newValue)
            //{
            //    if (y < 0 || x < 0 || y >= array.GetLength(0) || x >= array.GetLength(1))
            //        return null;

            //    var coords = new Stack<(int, int)>();
            //    int oldValue = array[y, x];
            //    coords.Push((x, y));

            //    while (coords.Count != 0)
            //    {
            //        (x, y) = coords.Pop();

            //        if (array[y, x] == oldValue)
            //        {
            //            array[y, x] = newValue;
            //            if (x > 0)
            //                coords.Push((x - 1, y));
            //            if (y > 0)
            //                coords.Push((x, y - 1));
            //            if (x < array.GetLength(1) - 1)
            //                coords.Push((x + 1, y));
            //            if (y < array.GetLength(0) - 1)
            //                coords.Push((x, y + 1));
            //        }
            //        else if (array[y, x] == newValue)
            //            continue;
            //        else
            //            continue;
            //    }

            //    return array;
            //}
        }


        // TODO решение не принимается компилятором на сайте, здесь работает нормально
        [Test]
        public void SamePrimeFactors()
        {
            int FlipNumber(int num)
            {
                string digits = "";
                while (num != 0)
                {
                    digits += num % 10;
                    num /= 10;
                }

                //return Convert.ToInt32(digits);
                return String.IsNullOrEmpty(digits) ? 0 : int.Parse(digits);
            }

            bool isPalindrome(int num)
            {
                List<int> digits = new List<int>();
                while (num != 0)
                {
                    digits.Add(num % 10);
                    num /= 10;
                }

                for (int i = 0; i < digits.Count / 2; i++)
                {
                    if (digits[i] != digits[(digits.Count - 1) - i])
                        return false;
                }

                return true;
            }

            List<int> GetFactors(int num)
            {
                List<int> factors = new List<int>();

                for (int i = 2; i <= num; i++)
                {
                    if (num % i == 0)
                    {
                        factors.Add(i);
                        num /= i;

                        i--;
                    }
                }

                return factors.Distinct().OrderBy(x => x).ToList();
            }

            int[] SameFactRev(int nMax)
            {
                // 1. Пересчет с проверкой на палиндром: если палиндром - не рассматриваем
                // 2. Находим для числа по факторизации; в список 1, сортируем его
                // 3. Переворачиваем число, повторяем 2. внося в список 2 
                // 4. Сверяем список 1 и 2, если совпал - добавляем число в финальный массив

                List<int> output = new List<int>();

                for (int i = 1; i < nMax; i++)
                {
                    if (isPalindrome(i))
                        continue;

                    List<int> factorsForStraight = GetFactors(i);
                    int iReversed = FlipNumber(i);
                    List<int> factorsForFlipped = GetFactors(iReversed);


                    if (factorsForStraight.Count > 0 && Enumerable.SequenceEqual(factorsForStraight.OrderBy(x => x), factorsForFlipped.OrderBy(x => x)))
                        output.Add(i);
                }

                return output.ToArray();
            }

            Assert.AreEqual(new int[] { }, SameFactRev(1000));
            Assert.AreEqual(new int[] { 1089 }, SameFactRev(2000));
            Assert.AreEqual(new int[] { 1089, 2178 }, SameFactRev(3000));
            Assert.AreEqual(new int[] { 1089, 2178 }, SameFactRev(4000));
            Assert.AreEqual(new int[] { 1089, 2178, 4356 }, SameFactRev(5000));
            Assert.AreEqual(new int[] { 1089, 2178, 4356 }, SameFactRev(6000));
            Assert.AreEqual(new int[] { 1089, 2178, 4356, 6534 }, SameFactRev(7000));
            Assert.AreEqual(new int[] { 1089, 2178, 4356, 6534 }, SameFactRev(8000));
            Assert.AreEqual(new int[] { 1089, 2178, 4356, 6534, 8712 }, SameFactRev(9000));
            Assert.AreEqual(new int[] { 1089, 2178, 4356, 6534, 8712, 9801 }, SameFactRev(10000));
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


        //[Test]
        //public void BabyShark()
        //{
        //    static string BabySharkLyrics()
        //    {
        //        var pr =new string[]{"Baby","Mommy","Daddy","Grandma","Grandpa","Let's go hunt"}; var song ="";
        //        for(int i=0;i<=5;i++){var doo=", doo doo doo doo doo doo";var s=" shark";for(int j=1;j<=4;j++){
        //        if(j==4){doo="!";}if(i==5){s="";if(j==4){s="!\nRun away,…";}}
        //        song+=$"{pr[i]}{s}{doo}\n";}}return song;
        //    }

        //    Assert.AreEqual(string.Join("\n", new string[] {
        //        "Baby shark, doo doo doo doo doo doo",
        //        "Baby shark, doo doo doo doo doo doo",
        //        "Baby shark, doo doo doo doo doo doo",
        //        "Baby shark!",
        //        "Mommy shark, doo doo doo doo doo doo",
        //        "Mommy shark, doo doo doo doo doo doo",
        //        "Mommy shark, doo doo doo doo doo doo",
        //        "Mommy shark!",
        //        "Daddy shark, doo doo doo doo doo doo",
        //        "Daddy shark, doo doo doo doo doo doo",
        //        "Daddy shark, doo doo doo doo doo doo",
        //        "Daddy shark!",
        //        "Grandma shark, doo doo doo doo doo doo",
        //        "Grandma shark, doo doo doo doo doo doo",
        //        "Grandma shark, doo doo doo doo doo doo",
        //        "Grandma shark!",
        //        "Grandpa shark, doo doo doo doo doo doo",
        //        "Grandpa shark, doo doo doo doo doo doo",
        //        "Grandpa shark, doo doo doo doo doo doo",
        //        "Grandpa shark!",
        //        "Let's go hunt, doo doo doo doo doo doo",
        //        "Let's go hunt, doo doo doo doo doo doo",
        //        "Let's go hunt, doo doo doo doo doo doo",
        //        "Let's go hunt!",
        //        "Run away,…",
        //        ""
        //    }), BabySharkLyrics());

        //    var ln = File.ReadAllText(@"/workspace/solution.txt").Length;
        //    Assert.That(ln, Is.LessThan(300));
        //}


        [Test]
        public void WaveSortAlgo()
        {
            static void WaveSort(int[] arr)
            {
                if (arr != null && arr.Length != 0)
                {
                    if (arr[0] >= arr[1])
                    {
                        arr = arr.OrderByDescending(x => x).ToArray();

                        bool isNeedLowerNum = true;

                        var sortedArr = arr.OrderBy(x => x).Distinct().ToArray();

                        for (int i = 0; i < arr.Length - 1; i++)
                        {
                            if (!isNeedLowerNum)
                            {
                                if (arr[i + 1] >= arr[i])
                                {
                                    isNeedLowerNum = true;
                                    continue;
                                }
                                else
                                {
                                    var nearBigger = sortedArr[Array.IndexOf(sortedArr, arr[i + 1]) + 1];
                                    (arr[i + 1], arr[Array.IndexOf(arr, nearBigger)]) = (arr[Array.IndexOf(arr, nearBigger)], arr[i + 1]);

                                    i--;
                                }
                            }
                            else if (isNeedLowerNum)
                            {
                                if (arr[i + 1] <= arr[i])
                                {
                                    isNeedLowerNum = false;
                                    continue;
                                }
                                else
                                {
                                    var nearLower = sortedArr[Array.IndexOf(sortedArr, arr[i + 1]) - 1];
                                    (arr[i + 1], arr[Array.IndexOf(arr, nearLower)]) = (arr[Array.IndexOf(arr, nearLower)], arr[i + 1]);

                                    i--;
                                }
                            }
                        }
                    }
                }

                //АЛГОРИТМ ВСЕГО 2 ШАГА:
                //1. СОРТИРОВКА ПО УБЫВАНИЮ
                //2. РАЗБИВ МАССИВ ПО ПАРАМ, ПРОСТО ПЕРЕСТАВИТЬ ЧИСЛА В КАЖДОЙ ПАРЕ МЕСТАМИ: КАЖДОЕ МЕНЬШЕЕ ВСТАНЕТ ПЕРЕД КАЖДЫМ БОЛЬШИМ

                //Нормальное решение
                Array.Sort(arr);

                for (int x = 1; x < arr.Length; x += 2)
                {
                    (arr[x], arr[x - 1]) = (arr[x - 1], arr[x]);
                }
            }

            //Тестов нет
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

        [Test]
        public void FindTriangularNum()
        {
            int Triangular(int n)
            {
                if (n > 0)
                {
                    int triangleRows = n;

                    for (int i = triangleRows; i > 0; i--)
                    {
                        for (int j = i - 1; j > 0; j--)
                        {
                            n++;
                        }
                    }

                    return n;
                }
                else return 0;
            }

            Assert.AreEqual(3, Triangular(2));
            Assert.AreEqual(10, Triangular(4));
            Assert.AreEqual(15, Triangular(5));
        }


        [Test]
        public void GetBagpack()
        {
            int PackBagpack(int[] scores, int[] weights, int capacity)
            {
                return 0;
            }

            Assert.AreEqual(29, PackBagpack(new int[] { 15, 10, 9, 5 }, new int[] { 1, 5, 3, 4 }, 8));
            Assert.AreEqual(60, PackBagpack(new int[] { 20, 5, 10, 40, 15, 25 }, new int[] { 1, 2, 3, 8, 7, 4 }, 10));
        }

        [Test]
        public void WhichAreIn()
        {
            List<int> MaxSumSubarray(List<int> numb)
            {
                // Перебор каждого числа
                // С каждой итерацией забираем кусок с i до j в коллекцию currentNumChunk;
                // Обновляю сумму с каждого этого куска; если сумма больше максимальной - сохраняю в в коллекцию numChunkWithMaxSum
                // currentNumChunk и currentSum обнулять с обновлением i

                if (numb.Count <= 1)
                    return numb;

                List<int> numChunkWithMaxSum = new List<int>();
                List<int> currentNumChunk = new List<int>();

                int currentSum = 0;
                int maxSum = 0;

                for (int i = 0; i < numb.Count; i++)
                {
                    currentSum = 0;
                    currentNumChunk.Clear();

                    for (int j = i; j < numb.Count; j++)
                    {
                        currentNumChunk.Add(numb[j]);
                        currentSum += numb[j];

                        if (currentSum > maxSum)
                        {
                            numChunkWithMaxSum = new List<int>(currentNumChunk);
                            maxSum = currentSum;
                        }
                    }
                }

                return numChunkWithMaxSum;
            }

            Assert.AreEqual(new List<int> { 2, 4, -5, 3, 3 }, MaxSumSubarray(new List<int> { 2, 4, -5, 3, 3, -7, 5, 1 }));
            Assert.AreEqual(new List<int> { 4, 2, 8 }, MaxSumSubarray(new List<int> { 4, 2, 8, -5, 2 }));
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

        [Test]
        public void SumsOfParts()
        {
            // Решение ПОСЛЕ оптимизации (время отработки 940 ns)
            int[] PartsSumsFast(int[] ls)
            {
                List<int> nums = new List<int>(ls);
                List<int> outputList = new List<int>();

                bool isOperationFirst = true;
                int firstFromNums = 0;

                while (nums.Any())
                {
                    if (isOperationFirst)
                    {
                        outputList.Add(nums.Sum());
                        firstFromNums = nums[0];
                        nums.RemoveAt(0);

                        isOperationFirst = false;
                    }
                    else
                    {
                        outputList.Add((outputList[outputList.Count - 1]) - firstFromNums);

                        firstFromNums = nums[0];
                        nums.RemoveAt(0);
                    }
                }

                outputList.Add(0);
                return outputList.ToArray();
            }

            // Решение ДО оптимизации (время отработки 1.640 ns)
            int[] PartsSumsSlow(int[] ls)
            {
                List<int> nums = new List<int>(ls);
                List<int> outputList = new List<int>();

                while (nums.Any())
                {
                    outputList.Add(nums.Sum());
                    nums.RemoveAt(0);
                }

                outputList.Add(0);
                return outputList.ToArray();
            }

            Assert.AreEqual(new int[] { 20, 20, 19, 16, 10, 0 }, PartsSumsFast(new int[] { 0, 1, 3, 6, 10 }));
            Assert.AreEqual(new int[] { 21, 20, 18, 15, 11, 6, 0 }, PartsSumsFast(new int[] { 1, 2, 3, 4, 5, 6 }));
            Assert.AreEqual(new int[] { 10037855, 9293730, 9292795, 9292388, 9291934, 9291504, 9291414, 9291270, 2581057, 2580168, 2579358, 0 },
                PartsSumsFast(new int[] { 10037855, 9293730, 9292795, 9292388, 9291934, 9291504, 9291414, 9291270, 2581057, 2580168, 2579358, 0 }));

        }


        [Test]
        public void UpArrayKata()
        {
            bool IsSingleDigitInteger(int num)
            {
                if (num == 0)
                    return true;

                var numWithoutZeroes = num.ToString().Where(c => c != '0');

                List<char> charsWithousZeroes = new List<char>(numWithoutZeroes);

                if (charsWithousZeroes.Distinct().Count() != 1)
                    return false;

                return true;
            }

            int[] UpArray(int[] num)
            {
                if (num == null || !num.Any() || num.Any(c => c.ToString().Length > 1 && c.ToString() != "10" && c.ToString() != "11")
                    || num.Any(c => c < 0))
                    return null;

                foreach (var number in num)
                {
                    if (!IsSingleDigitInteger(number))
                        return null;
                }

                string numberStr = "";

                foreach (int i in num)
                {
                    numberStr += Convert.ToString(i);
                }

                var leadingZeroesInStr = numberStr.TakeWhile(c => c == '0');

                numberStr = (Convert.ToInt32(numberStr) + 1).ToString();

                if (leadingZeroesInStr.Any())
                {
                    string zeroesStr = string.Join("", leadingZeroesInStr.ToArray());
                    numberStr = numberStr.Insert(0, zeroesStr);
                }

                var output = new List<int>();
                foreach (char i in numberStr)
                {
                    output.Add(Convert.ToInt32(Convert.ToString(i)));
                }

                return output.ToArray();
            }

            //// Более хорошее решение без лишних приведений:
            //// Вариант 1:
            //int[] UpArray(int[] num)
            //{
            //	if (num.Length == 0 || num.Any(a => a < 0 || a > 9))
            //		return null;

            //	for (var i = num.Length - 1; i >= 0; i--)
            //	{
            //		if (num[i] == 9)
            //		{
            //			num[i] = 0;
            //		}
            //		else
            //		{
            //			num[i]++;
            //			return num;
            //		}
            //	}
            //	return new[] { 1 }.Concat(num).ToArray();
            //}

            //// Вариант 2:
            //public static int[] UpArray(int[] num)
            //{
            //	if (num.Count() == 0 || num.Any(x => x < 0 || x > 9)) return null;

            //	for (int i = num.Length - 1; i >= 0; i--)
            //	{
            //		num[i] += 1;
            //		if (num[i] < 10) return num;
            //		else num[i] %= 10;
            //	}

            //	return new[] { 1 }.Concat(num).ToArray();
            //}

            var num1 = new int[] { 2, 3, 9 };
            var newNum1 = new int[] { 2, 4, 0 };
            Assert.AreEqual(newNum1, UpArray(num1));

            var num2 = new int[] { 4, 3, 2, 5 };
            var newNum2 = new int[] { 4, 3, 2, 6 };
            Assert.AreEqual(newNum2, UpArray(num2));

            var num3 = new int[] { 0, 0, 0, 2, 3, 9, 0, 0 };
            var newNum3 = new int[] { 0, 0, 0, 2, 3, 9, 0, 1 };
            Assert.AreEqual(newNum3, UpArray(num3));
        }


        [Test]
        public void GetTriangleOddRow()
        {
            //			1
            //		  3   5
            // 	    7   9  11
            //    13  15  17  19
            //  21  23  25  27  29
            //31  33  35  37  39  41

            long[] OddRow(int n)
            {
                int cnt = n;
                long numForLeftPart = 0;
                long numForRightPart = 0;

                List<long> nums = new List<long>(n);

                if (n % 2 != 0)
                {
                    n *= n;
                    nums.Add(n);

                    numForLeftPart = n - 2;
                    numForRightPart = n + 2;

                    for (int i = 0; i < (cnt-1)/2; i++, numForLeftPart-=2)
                    {
                        nums.Insert(0, numForLeftPart);
                    }

                    for (int i = 0; i < (cnt-1)/2; i++, numForRightPart+=2)
                    {
                        nums.Add(numForRightPart);
                    }

                }
                else if (n % 2 == 0)
                {
                    n = n * n - 1;
                    nums.Add(n);

                    numForLeftPart = n - 2;
                    numForRightPart = n + 2;

                    for (int i = 0; i < (cnt-1)/2; i++, numForLeftPart-=2)
                    {
                        nums.Insert(0, numForLeftPart);
                    }

                    for (int i = 0; i < (cnt-1)/2+1; i++, numForRightPart+=2)
                    {
                        nums.Add(numForRightPart);
                    }
                }

                return nums.ToArray();
            }

            Assert.AreEqual(OddRow(2), new long[] { 3, 5 });
            Assert.AreEqual(OddRow(3), new long[] { 7, 9, 11 });
            Assert.AreEqual(OddRow(5), new long[] { 21, 23, 25, 27, 29 });
            Assert.AreEqual(OddRow(6), new long[] { 31, 33, 35, 37, 39, 41 });
            Assert.AreEqual(OddRow(13), new long[] { 157, 159, 161, 163, 165, 167, 169, 171, 173, 175, 177, 179, 181 });
            Assert.AreEqual(OddRow(19), new long[] { 343, 345, 347, 349, 351, 353, 355, 357, 359, 361, 363, 365, 367, 369, 371, 373, 375, 377, 379 });
        }


        [Test]
        public void IsNiceArray()
        {
            bool isThereMatches(int[] arr, int n)
            {
                return arr.Any(i => n == i + 1 || n == i - 1);
            }

            bool IsNice(int[] arr)
            {
                if (arr == null || !arr.Any())
                    return false;

                if (arr.All(n => isThereMatches(arr, n)))
                    return true;
                else return false;
            }

            // Более лаконичное:
            bool IsNice2(int[] arr) => arr.Any() && arr.All(n => arr.Contains(n + 1) || arr.Contains(n - 1));

            Assert.AreEqual(true, new int[] { 2, 10, 9, 3 });
            Assert.AreEqual(false, new int[] { 2, 10, 9, 5 });
        }


        [Test]
        public void BuddyPairs()
        {
            long GetSumOfDivisors(long num)
            {
                //long sum = 0;

                //for (int i = 1; i < num; ++i)
                //{
                //    if (num % i == 0)
                //        sum += i;
                //}

                //return sum;

                // ПОСЛЕ ОПТИМИЗАЦИИ
                // Final result of summation of divisors
                long result = 0;

                // find all divisors which divides 'num'
                for (long i = 2; i <= Math.Sqrt(num); i++)
                {

                    // if 'i' is divisor of 'num'
                    if (num % i == 0)
                    {
                        // if both divisors are same then
                        // add it only once else add both
                        if (i == (num / i))
                            result += i;
                        else
                            result += (i + num / i);
                    }
                }

                // Add 1 to the result as 1
                // is also a divisor
                return (result + 1);
            }


            string FindBuddyNum(long start, long limit)
            {
                // делители для n от 1 до n НЕ ВКЛЮЧАЯ n
                // s - сумма всех делителей числа
                // (n, m) are a pair of buddy if s(m) = n + 1 and s(n) = m + 1
                // для n = 48, s = 76 = 75 + 1
                // для n = 75, s = 49 = 48 + 1

                // для A = 48, s = 76 = B + 1
                // для B = 75, s = 49 = A + 1

                // Найти первую пару (A, B) где A между числами start и limit включительно
                // Число B НЕ ОБЯЗАТЕЛЬНО должен быть между start и limit; оно должно быть > A оно может иметь значение больше чем limit
                // Вернуть "Nothing" если не найдено, если найдено строка "(A B)"

                // Перебрать все числа от start до limit добавляя в словарь пару n-s только в случае если S > N
                // Проверить каждую пару: взять s(A)-1, он становится B, найти для него его s(B), сверить s(B)-1 c A;
                // подходит - забираем и выходим, не подходит - переходим к следующей паре

                // ДО ОПТИМИЗАЦИИ
                //=============================================================================
                //Dictionary<long?, long> numberToDivSum = new Dictionary<long?, long>();
                //long firstBuddy = 0, secondBuddy = 0;

                //for (long i = start; i <= limit; i++)
                //{
                //    var sumOfDivForCurrentI = GetSumOfDivisors(i);

                //    if (sumOfDivForCurrentI > i)
                //        numberToDivSum.Add(i, GetSumOfDivisors(i));
                //}

                //for (int i = 0; i < numberToDivSum.Count; i++)
                //{
                //    var currentPair = numberToDivSum.ElementAt(i);

                //    var supposedBuddy = currentPair.Value - 1;
                //    var sumOfDivForSupposedBuddy = GetSumOfDivisors(supposedBuddy);

                //    if (sumOfDivForSupposedBuddy - 1 == currentPair.Key)
                //    {
                //        firstBuddy = (long)currentPair.Key;
                //        secondBuddy = (long)supposedBuddy;
                //        break;
                //    }
                //}
                //=============================================================================

                // ПОСЛЕ ОПТИМИЗАЦИИ
                long firstBuddy = 0, secondBuddy = 0;

                for (long i = start; i <= limit; i++)
                {
                    var sumOfDivForCurrentI = GetSumOfDivisors(i);

                    if (sumOfDivForCurrentI > i)
                    {
                        var supposedBuddy = sumOfDivForCurrentI - 1;
                        var sumOfDivForSupposedBuddy = GetSumOfDivisors(supposedBuddy);

                        if (sumOfDivForSupposedBuddy - 1 == i)
                        {
                            firstBuddy = (long)i;
                            secondBuddy = (long)supposedBuddy;
                            break;
                        }
                    }
                }

                if (firstBuddy != 0 && secondBuddy != 0)
                    return $"({firstBuddy} {secondBuddy})";
                else return "Nothing";
            }

            Assert.AreEqual("(1081184 1331967)", FindBuddyNum(1071625, 1103735));
            Assert.AreEqual("Nothing", FindBuddyNum(2382, 3679));
            Assert.AreEqual("(9504 20735)", FindBuddyNum(8983, 13355));
        }


        [Test]
        public void CheckDateTimeDay()
        {
            // Громоздкая версия
            bool IsCurrentDayInRange(DateTime dateTime)
            {
                //// ПЛОХОЙ ВАРИАНТ
                //var currentDay = dateTime.ToString("dd", CultureInfo.InvariantCulture);

                //if ((currentDay == "01" || currentDay == "02" || currentDay == "03" || currentDay == "04" || currentDay == "05"))
                //    return true;
                //else
                //    return false;


                //// ВАРИАНТ С СУЩНОСТЬЮ - ПОСРЕДНИКОМ
                //var year = dateTime.Year;
                //var month = dateTime.Month;
                //var day = dateTime.Day;

                //var currentDateTime = new DateTime(year, month, day);

                //if (currentDateTime.Day >= 01 && currentDateTime.Day <= 05)
                //    return true;
                //else
                //    return false;


                // ВАРИАНТ БЕЗ СУЩНОСТЕЙ - ПОСРЕДНИКОВ
                if (dateTime.Day >= 01 && dateTime.Day <= 05)
                    return true;
                else
                    return false;
            }

            Assert.AreEqual(true, IsCurrentDayInRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 03)));
            Assert.AreEqual(false, IsCurrentDayInRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 12)));
            Assert.AreEqual(false, IsCurrentDayInRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 06)));
        }



        //[Test]
        //public void IsStrPangram()
        //{
        //    // Громоздкая версия
        //    bool IsPangram(string str)
        //    {
        //        char[] alphabetLetters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        //        char[] strLetters = str.ToLower().ToCharArray();

        //        if (alphabetLetters.All(l => strLetters.Contains(l)))
        //            return true;
        //        else return false;
        //    }

        //    // Сжатая версия
        //    //char[] alphabetLetters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        //    bool IsPangram(string str) => "abcdefghijklmnopqrstuvwxyz".All(l => str.ToLower().ToCharArray().Contains(l));

        //    Assert.AreEqual(true, IsPangram("The quick brown fox jumps over the lazy dog."));
        //    Assert.AreEqual(false, IsPangram("The qick brown fox jmps over the lazy dog."));
        //}


        [Test]
        public void ReversedArrOfSum()
        {
            long[] GetReversedArrOfSum(int[] l1, int[] l2)
            {
                Array.Reverse(l1); Array.Reverse(l2);

                string l1Num = "", l2Num = "";
                Array.ForEach(l1, l => l1Num += l);
                Array.ForEach(l2, l => l2Num += l);

                long sum = Convert.ToInt64(l1Num) + Convert.ToInt64(l2Num);
                char[] sumInChars = sum.ToString().ToCharArray();

                Array.Reverse(sumInChars);

                return sumInChars.Select(c => (long)Char.GetNumericValue(c)).ToArray();
            }

            Assert.AreEqual(new int[] { 7, 0, 8 }, GetReversedArrOfSum(new int[] { 2, 4, 3 }, new int[] { 5, 6, 4 }));
            Assert.AreEqual(new int[] { 8, 9, 9, 9, 0, 0, 0, 1 }, GetReversedArrOfSum(new int[] { 9, 9, 9, 9, 9, 9, 9 }, new int[] { 9, 9, 9, 9 }));
        }


        [Test]
        public void FindFirstIndecesOfSumDigits()
        {
            int[] TwoSum(int[] nums, int target)
            {
                // Optimized version
                int[] indeces = new int[2];

                Dictionary<int, int> IndecesToNums = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    IndecesToNums.Add(i, nums[i]);
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    int remainder = target - nums[i];

                    if (IndecesToNums.ContainsValue(remainder))
                    {
                        var indexOfReminder = IndecesToNums.FirstOrDefault(p => p.Value == remainder).Key;
                        if (indexOfReminder != i)
                        {
                            indeces[0] = indexOfReminder;
                            indeces[1] = i;
                            break;
                        }
                    }
                }

                return indeces;
            }

            Assert.AreEqual(new int[] { 1, 0 }, TwoSum(new int[] { 2, 7, 11, 15 }, 9));
            Assert.AreEqual(new int[] { 2, 1 }, TwoSum(new int[] { 3, 2, 4 }, 6));
        }


        [Test]
        public void BinarySearchVariation()
        {
            static int BinarySearch(int[] nums, int target)
            {
                //1. Определить крайние точки (индексы) массива для определения есть ли что-либо между ними или искомое уже "зажато"
                var left = 0;
                var right = nums.Length - 1;

                //2. До тех пор пока левая и правая часть не равны (пока есть более одного значения)
                while (left <= right)
                {
                    //3. Находим средний индекс в текущем отрезке
                    var middle = (left + right) / 2;

                    //4. Если искомое число не равно среднему числу в отрезке - определяем больше или меньше оно среднего
                    //   Если меньше - текущее среднее число принимает роль правой границы отрезка
                    //   Если больше - текущее среднее число принимает роль левой границы отрезка
                    //   При этом граница сдвигается на +/-1, так как с самой границей(т.е. со средним ранее) уже было проведено сравнение
                    if (target == nums[middle])
                    {
                        return middle;
                    }
                    else if (target < nums[middle])
                    {
                        right = middle - 1;
                    }
                    else if (target > nums[middle])
                    {
                        left = middle + 1;
                    }
                }

                return -1;
            }

            var array = new[] { -1, 0, 3, 5, 8, 9, 12 };
            Assert.AreEqual(4, BinarySearch(array, 9));
        }


        [Test]
        public void LengthOfLongestUniqueSubstring()
        {
            int LengthOfLongestSubstring(string s)
            {
                // Неоптимизированный но рабочий
                bool IsAllCharsUnique(string s)
                {
                    return s.Distinct().Count() == s.Length;
                }

                if (string.IsNullOrEmpty(s))
                    return 0;
                else if (s.Length == 1)
                    return s.Length;

                var maxSubstring = "";

                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = s.Length - i; j > 0; j--)
                    {
                        var curSubstring = s.Substring(i, j);

                        if (IsAllCharsUnique(curSubstring) && curSubstring.Length > maxSubstring.Length)
                            maxSubstring = curSubstring;
                    }
                }
                return maxSubstring.Length;

                //// Оптимизированный (еще не изучен)
                //int size = s.Length;
                //int max = 1;
                //if (size == 0)
                //    return 0;

                //for (int i = 0; i <size - 1; i++)
                //{
                //    for (int j = i + 1; j <= size - 1; j++)
                //    {
                //        string s1 = s.Substring(i, j-i);
                //        string s2 = s.Substring(j, 1);

                //        if (!s1.Contains(s2))
                //            max = Math.Max(max, (j-i)+1);
                //        else
                //            break;
                //    }
                //}
                //return max;

            }

            Assert.AreEqual(3, LengthOfLongestSubstring("abcabcbb"));
            Assert.AreEqual(1, LengthOfLongestSubstring("bbbbb"));
            Assert.AreEqual(3, LengthOfLongestSubstring("pwwkew"));
            Assert.AreEqual(1, LengthOfLongestSubstring(" "));
            Assert.AreEqual(2, LengthOfLongestSubstring("au"));
            Assert.AreEqual(3, LengthOfLongestSubstring("dvdf"));
            Assert.AreEqual(3, LengthOfLongestSubstring("aabaab!bb"));
        }



        [Test]
        public void StringPermutations()
        {
            //perm(ab) →
            //a + perm(b) → ab
            //b + perm(a) → ba

            //perm(abc) →
            //a + perm(bc) → abc, acb
            //b + perm(ac) → bac, bca
            //c + perm(ab) → cab, cba

            //perm(sagi) →
            //s + perm(agi) → agi, aig, gia, gai, iag, iga (a + perm(gi), g + perm(ai), i + perm(ag))
            //a + perm(sgi) → sgi, sig, gis, gsi, isg, igs (s + perm(gi), g + perm(si), i + perm(gi))
            //g + perm(sai) → sai, sia, ais, asi, isa, ias (s + perm(ai), a + perm(si), i + perm(sa))
            //i + perm(sag) → sag, sga, ags, asg, gsa, gas (s + perm(ag), a + perm(sg), g + perm(sa))

            List<string> SinglePermutations(string s)
            {
                List<string> variations = new List<string>();
                var chars = s.ToCharArray();

                GetPer(chars, 0, chars.Length - 1);

                void GetPer(char[] list, int start, int end)
                {
                    if (start == end)
                    {
                        if (!variations.Contains(new string(list)))
                            variations.Add(new string(list));
                    }
                    else
                        for (int i = start; i <= end; i++)
                        {
                            (list[start], list[i]) = (list[i], list[start]);
                            GetPer(list, start + 1, end);
                            (list[start], list[i]) = (list[i], list[start]);
                        }
                }

                return variations;
            }

            Assert.AreEqual(new List<string>
            {
                "sadi", "said", "sdai", "sdia","sida","siad", "asdi",
                "asid","adsi","adis","aids","aisd","dasi","dais","dsai",
                "dsia","disa", "dias", "iads", "iasd","idas", "idsa","isda", "isad",
            }, SinglePermutations("sadi"));

            Assert.AreEqual(new List<string>
            {
               "aabb", "abab", "abba", "baab", "baba","bbaa",
            }, SinglePermutations("aabb"));
        }


        [Test]
        public void FindNextBiggerNumber()
        {
            long NextBiggerNumber(long n)
            {
                // === Решение основанное на нахождении всех перестановок символов в строке. Работает,
                // но ОЧЕНЬ медленно, так как перед поиском нужного варианта сначала вычисляются ВСЕ варианты.
                // Пытался написать оптимизированный вариант, останавливающий поиск при нахождении первого варианта 
                // больше искомого, но такой алгоритм не работает для всех случаев + слишком сложный. Проще взять
                // за основу принципиально другой алгоритм, чем пытаться переделать под задачу алгоритм перестановок

                //List<long> variations = new List<long>();
                //var chars = n.ToString().ToCharArray();

                //GetPer(chars, 0, chars.Length - 1);

                //void GetPer(char[] list, int start, int end)
                //{
                //    if (start == end)
                //    {
                //        if (!variations.Contains(Convert.ToInt64(new string(chars))))
                //            variations.Add(Convert.ToInt64(new string(chars)));
                //    }
                //    else
                //        for (int i = start; i <= end; i++)
                //        {
                //            (list[start], list[i]) = (list[i], list[start]);
                //            GetPer(list, start + 1, end);
                //            (list[start], list[i]) = (list[i], list[start]);
                //        }
                //}

                //return variations.OrderBy(num => num).ToList().FirstOrDefault(num => num > n);

                // === Хорошее решение через отдельный алгоритм
                void Swap(char[] ar, int i, int j)
                {
                    char temp = ar[i];
                    ar[i] = ar[j];
                    ar[j] = temp;
                }

                var chars = n.ToString().ToCharArray();

                int i;

                // Обнаружить первое число, которое меньше правого соседа
                for (i = chars.Length - 1; i > 0; i--)
                {
                    if (chars[i] > chars[i - 1])
                    {
                        break;
                    }
                }

                // Если такое число не найдено - это значит что массив отсортирован 
                // по убыванию. Для него нельзя найти число больше текущего
                if (i == 0)
                {
                    return -1;
                }
                else
                {
                    int x = chars[i - 1], minForI = i;

                    // В правой части от числа i нужно найти первое число, больше чем i
                    // число назовем minForI
                    for (int j = i + 1; j < chars.Length; j++)
                    {
                        if (chars[j] > x && chars[j] < chars[minForI])
                        {
                            minForI = j;
                        }
                    }

                    // i нужно поменять местами с найденным числом
                    Swap(chars, i - 1, minForI);

                    // Отсортировать кусок от i до конца массива
                    // по возрастанию
                    Array.Sort(chars, i, chars.Length - i);

                    return Convert.ToInt64(new string(chars));


                    //// Еще вариант
                    //public static long NextBiggerNumber(long n)
                    //{
                    //    String str = GetNumbers(n);
                    //    for (long i = n+1; i <= long.Parse(str); i++)
                    //    {
                    //        if (GetNumbers(n)==GetNumbers(i))
                    //        {
                    //            return i;
                    //        }
                    //    }
                    //    return -1;
                    //}
                    //public static string GetNumbers(long number)
                    //{
                    //    return string.Join("", number.ToString().ToCharArray().OrderByDescending(x => x));
                    //}
                }
            }

            Assert.AreEqual(21, NextBiggerNumber(12));
            Assert.AreEqual(414, NextBiggerNumber(144));
            Assert.AreEqual(531, NextBiggerNumber(513));
            Assert.AreEqual(2071, NextBiggerNumber(2017));
            Assert.AreEqual(-1, NextBiggerNumber(531));
            Assert.AreEqual(-1, NextBiggerNumber(111));
            Assert.AreEqual(13404, NextBiggerNumber(13044));
            Assert.AreEqual(1234567908, NextBiggerNumber(1234567890));
            Assert.AreEqual(536479, NextBiggerNumber(534976));
        }

        [Test]
        public void HighAndLowNumbers()
        {
            string HighAndLow(string numbers)
            {
                var nums = numbers.Split(' ').Select(c => Convert.ToInt32(c));
                return new string(nums.Max() + " " + nums.Min());
            }

            Assert.AreEqual("42 -9", HighAndLow("8 3 -5 42 -1 0 0 -9 4 7 4 -4"));
            Assert.AreEqual("3 1", HighAndLow("1 2 3"));
        }

        [Test]
        public void NarcissisticNumbers()
        {
            bool IsNarcissistic(int value)
            {
                var digits = value.ToString().Select(c => char.GetNumericValue(c)).ToArray();
                var sum = 0d;

                foreach (var digit in digits)
                {
                    sum += Math.Pow(digit, digits.Length);
                }

                return value == sum;
            }

            Assert.AreEqual(true, IsNarcissistic(153));
            Assert.AreEqual(false, IsNarcissistic(1652));
        }


        [Test]
        public void FindTheParityOutlier()
        {
            int Find(int[] integers)
            {
                var firstThree = integers.Take(3);
                bool isArrayEven = firstThree.Where(n => n % 2 == 0).Count() > firstThree.Where(n => n % 2 != 0).Count();
                int outlier = -1;

                if (isArrayEven)
                    outlier = integers.FirstOrDefault(n => n % 2 != 0);
                else
                    outlier = integers.FirstOrDefault(n => n % 2 == 0);

                return outlier;
            }

            Assert.AreEqual(11, Find(new int[] { 2, 4, 0, 100, 4, 11, 2602, 36 }));
            Assert.AreEqual(160, Find(new int[] { 160, 3, 1719, 19, 11, 13, -21 }));
        }

        [Test]
        public void GetUnique()
        {
            int GetUniqueNumber(IEnumerable<int> numbers)
            {
                // Нельзя через Distinct: он уберет дубликаты но дублирующийся экземпляр оставит
                // Когда надо убрать все дубликаты, нужна группировка по количеству объектов:
                // Создаем группы по всем числам, получается 2 группы с ключами 11 и 14 => среди групп ищем ту,
                // где количество чисел == 1 => возвращаем ключ этой группы (который является самим числом)

                return numbers.GroupBy(i => i).Where(g => g.Count() == 1).Select(g => g.Key).FirstOrDefault();
            }

            Assert.AreEqual(2, GetUniqueNumber(new int[] { 1, 1, 1, 2, 1, 1 }));
            //Assert.AreEqual(0.55, GetUniqueNumber(new int[] { 0, 0, 0.55, 0, 0 }));
            Assert.AreEqual(14, GetUniqueNumber(new int[] { 11, 11, 14, 11, 11 }));
        }

        [Test]
        public void DuplicateCharsCount()
        {
            int DuplicateCount(string str)
            {
                return str.ToLower().GroupBy(i => i).Where(c => c.Count() > 1).Count();
            }

            Assert.AreEqual(0, DuplicateCount(""));
            Assert.AreEqual(0, DuplicateCount("abcde"));
            Assert.AreEqual(2, DuplicateCount("aabbcde"));
            Assert.AreEqual(2, DuplicateCount("aabBcde"), "should ignore case");
            Assert.AreEqual(1, DuplicateCount("Indivisibility"));
            Assert.AreEqual(2, DuplicateCount("Indivisibilities"), "characters may not be adjacent");
        }

        [Test]
        public void TopWordsOccurrences()
        {
            // По неизвестной причине компилятор сайта не принимает решение на случайных кейсах, в угадайку играть тоже не стану
            List<string> Top3(string s)
            {
                var words = s.ToLower().Split(new char[] { ' ', ',', '\n' });

                for (int i = 0; i < words.Length; i++)
                {
                    foreach (var symbol in words[i])
                    {
                        if (!char.IsLetter(symbol) && symbol != '\'')
                            words[i] = words[i].Replace(symbol.ToString(), String.Empty);
                        else if (!char.IsLetter(symbol) && symbol == '\'')
                        {
                            if (!words[i].StartsWith('\'') && !words[i].EndsWith('\'')
                                && words[i][words[i].Length - 2] != '\'')
                            {
                                words[i] = words[i].Replace(symbol.ToString(), String.Empty);
                            }
                            else if (symbol == '\'' && words[i].All(c => c == '\''))
                                return new List<string>();
                        }
                    }
                }

                var mostFrequentWords = words.GroupBy(w => w).OrderByDescending(w => w.Count()).Select(g => g.Key).ToList();

                var output = mostFrequentWords.Where(w => !string.IsNullOrEmpty(w)).ToList();

                if (output.Any())
                    if (output.Count() >= 3)
                        return output.Take(3).ToList();
                    else return output;
                else
                    return new List<string>();
            }

            Assert.AreEqual(new List<string> { "e", "d", "a" }, Top3("a a a  b  c c  d d d d  e e e e e"));
            Assert.AreEqual(new List<string> { "e", "ddd", "aa" }, Top3("e e e e DDD ddd DdD: ddd ddd aa aA Aa, bb cc cC e e e"));
            Assert.AreEqual(new List<string> { "won't", "wont" }, Top3("  //wont won't won't "));
            Assert.AreEqual(new List<string> { "e" }, Top3("  , e   .. "));
            Assert.AreEqual(new List<string> { }, Top3("  ...  "));
            Assert.AreEqual(new List<string> { }, Top3("  '  "));
            Assert.AreEqual(new List<string> { }, Top3("  '''  "));
            Assert.AreEqual(new List<string> { "a", "of", "on" }, Top3(
                string.Join("\n", new string[]{"In a village of La Mancha, the name of which I have no desire to call to",
                  "mind, there lived not long since one of those gentlemen that keep a lance",
                  "in the lance-rack, an old buckler, a lean hack, and a greyhound for",
                  "coursing. An olla of rather more beef than mutton, a salad on most",
                  "nights, scraps on Saturdays, lentils on Fridays, and a pigeon or so extra",
                  "on Sundays, made away with three-quarters of his income." })));

        }


        [Test]
        public void TrailingZerosInFactorial()
        {
            // Алгоритм: количество нулей в конце факториала можно определить, разбив факториал
            // на его простые множители, и среди них посчитав количество цифр 5
            // Trailing 0s in n! = Count of 5s in prime factors of n!
            //      = floor(n/5) + floor(n/25) + floor(n/125) + ....
            int TrailingZeros(int n)
            {
                if (n < 0)
                    return -1;

                int cnt = 0;

                for (int i = 5; n / i >= 1; i *= 5)
                    cnt += n / i;

                return cnt;
            }

            Assert.AreEqual(1, TrailingZeros(5));
            Assert.AreEqual(6, TrailingZeros(25));
            Assert.AreEqual(131, TrailingZeros(531));
        }


        //[Test]
        //public void IsStrPangram()
        //{
        //    // Громоздкая версия
        //    bool IsPangram(string str)
        //    {
        //        char[] alphabetLetters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        //        char[] strLetters = str.ToLower().ToCharArray();

        //        if (alphabetLetters.All(l => strLetters.Contains(l)))
        //            return true;
        //        else return false;
        //    }

        //    // Сжатая версия
        //    //char[] alphabetLetters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        //    bool IsPangram(string str) => "abcdefghijklmnopqrstuvwxyz".All(l => str.ToLower().ToCharArray().Contains(l));

        //    Assert.AreEqual(true, IsPangram("The quick brown fox jumps over the lazy dog."));
        //    Assert.AreEqual(false, IsPangram("The qick brown fox jmps over the lazy dog."));
        //}













    }
}
