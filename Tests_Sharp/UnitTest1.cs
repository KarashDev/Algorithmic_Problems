using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                //���
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
                // ��� �������:
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

                // ������� �������:
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
                        // ���� ����� ������� ������� �� �������� i �� ������ ������, ���������
                        // ����� ���������� ��������� ������ ����� ��������� ������
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
                // ��� �������:
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

                // ������� �������:
                return arr.OrderBy(x => x == 0).ToArray();

                // ����������: ���� �� ����� ���� �������� ���� � ������ List,
                // ����� ���� �� ������������ List.Insert(0, num)
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


        // ������ �� �����������: ����������, �������� �� �������� ����� �������. ��������� ��������� 
        // ������ ���� ������ ��� O(n) � ������ ��� O(n/2)
        [Test]
        public void IsNumberPrime()
        {
            bool IsPrime(int n)
            {
                //// ����������� �1: ����������� ��� ������������ � 2 ����, �������� ���� �� ��� ����� 
                //// � ����������� �� ��������/���������� ��������� �����
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


                // ����������� �2: �������� ����� �� �� ������ �����, � �� ����� ����� �����; ��� ��
                // ������ ��������� ����� (� ���������� ��������), �� ��� ���� ��� ����������� �������� 
                // �� ��������; � ������� ����� ��������� ������ �� ������ �����
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

                //// �������������� �������� �������:
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

                // �������:
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

                // �������:
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


        // TODO �� ���������
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
                          ||board[i, j + 1] == board[i + 1, j + 1]
                          && board[i + 1, j + 1] == board[i + 2, j + 1]
                           ||board[i, j + 2] == board[i + 1, j + 2]
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
        public void SnailArray()
        {
            int[] Snail(int[][] array)
            {
                // enjoy
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

            Assert.AreEqual(new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 }, Snail(array1));
            Assert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, Snail(array2));
        }













    }
}