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

    //public class ListNode
    //{
    //    public int val;
    //    public ListNode next;

    //    public ListNode(int val = 0, ListNode next = null)
    //    {
    //        this.val = val;
    //        this.next = next;
    //    }
    //}


    /* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

    class WorkSpace
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello Algos!");
            // Задача:
            // Мое решение:
            // Хорошее решение:


            //======================================================================
            //======================================================================
            // Задача: Установить, является ли вторая строка окончанием первой строки

            //// Мое решение:
            //bool Solution(string str, string ending)
            //{
            //	//ДОПОЛНИТЕЛЬНО: можно сначала перевернуть строки, чтобы было легче в цикле
            //	//если второй аргумент длиннее первого - сразу вернуть фалс
            //	//перебор первого на длину второго
            //	//если все совпадает - тру, "все" проверяется счетчиком

            //	if (ending.Length > str.Length)
            //		return false;

            //	var cnt = 0;
            //	for (int i = 1; i <= ending.Length; i++)
            //	{
            //		if (str[str.Length - i] == ending[ending.Length - i])
            //			cnt++;
            //	}

            //	if (cnt == ending.Length)
            //		return true;

            //	return false;
            //}

            //// Хорошее решение:
            //bool Solution(string str, string ending)
            //{
            //	if (str.EndsWith(ending))
            //		return true;
            //	else return false;
            //}

            //Console.WriteLine(Solution("abc", "bc"));  // returns true
            //Console.WriteLine(Solution("abc", "d")); // returns false
            //Console.WriteLine(Solution("ninja", "j")); //  returns true

            //======================================================================
            //======================================================================
            // Задача: во входящей строке заменить каждую букву на ее позицию в алфавите

            // Мое решение:
            //static string AlphabetPosition(string text)
            //{
            //	var preString = text.ToLower().Split(" ");
            //	var charsPre = string.Join("", preString);

            //	var cleanString = new string(charsPre.Where(Char.IsLetter).ToArray());

            //	var inputLetters = cleanString.ToCharArray();

            //	var alphabetLetters = new char[26];
            //	for (int i = 0, j = 97;  i < alphabetLetters.Length && j <= 122; i++, j++)
            //	{
            //		alphabetLetters[i] = Convert.ToChar(j);
            //	}

            //	var sequentialNumbers = new int[inputLetters.Length];
            //	for (int i = 0; i < inputLetters.Length; i++)
            //	{
            //		for (int j = 0; j < alphabetLetters.Length; j++)
            //		{
            //			if (inputLetters[i] == alphabetLetters[j])
            //				sequentialNumbers[i] = j + 1;
            //		}
            //	}

            //	sequentialNumbers = sequentialNumbers.Where(i => i != 0).ToArray();

            //	string result = string.Join(" ", sequentialNumbers);
            //	return result;
            //}

            //// Хорошее решение: ПРЕОБРАЗОВАТЬ ОДНО В ДРУГОЕ МОЖНО С ПОМОЩЬЮ SELECT, НЕ НАДО НИЧЕГО ВЫДУМЫВАТЬ;
            //// Также можно было решить через Dictionary
            //static string AlphabetPosition(string text)
            //{
            //	return string.Join(" ", text.ToLower().Where(c => char.IsLetter(c))
            //										  .Select(c => "abcdefghijklmnopqrstuvwxyz".IndexOf(c) + 1)
            //										  .ToArray());
            //	//или
            //	return string.Join(" ", text.ToLower().Where(c => char.IsLetter(c)).Select(c => c - 'a' + 1));

            //}

            //Assert.AreEqual("20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11", 
            //	AlphabetPosition("The sunset sets at twelve o' clock."));

            //======================================================================
            //======================================================================

            //string BreakCamelCase(string str)
            //{
            //	string inputString = str;

            //	for (int i = 0; i < inputString.Length; i++)
            //	{
            //		if (Char.IsUpper(inputString[i]) && i != 0)
            //		{

            //			inputString = inputString.Insert(i, " ");
            //			i++;
            //		}
            //	}

            //	return inputString;
            //}

            //         Console.WriteLine(BreakCamelCase("CamelCaseZaz"));

            ////======================================================================
            ////======================================================================
            //// Задача: Все нули в массиве перебросить в правую часть, сохраняя порядок остальных элементов
            //int[] MoveZeroes(int[] arr)
            //{
            //    // Мое решение:
            //    List<int> newList = new List<int>();
            //    int howMuchZeroes = 0;
            //    for (int i = 0; i < arr.Length; i++)
            //    {
            //        if (arr[i] != 0)
            //            newList.Add(arr[i]);
            //        else howMuchZeroes++;
            //    }

            //    for (int i = 0; i < howMuchZeroes; i++)
            //    {
            //        newList.Add(0);
            //    }
            //    return newList.ToArray();

            //    // Хорошее решение:
            //    return arr.OrderBy(x => x == 0).ToArray();
            //}

            //var arr = MoveZeroes(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 });
            //foreach (var item in arr)
            //{
            //    Console.Write(item + " ");
            //}


            ////======================================================================
            ////======================================================================
            //// Задача: входящая строка состоит из набора букв, всего есть только 4 типа букв;
            //// В зависимости от команд, "вшитых" во входную строку, нужно вывести соответствующий массив целых чисел

            ////i increments the value(initially 0)
            ////d decrements the value
            ////s squares the value
            ////o outputs the value into the return array

            //// Мое решение:
            //// Хорошее решение:
            //int[] Parse(string data)
            //{
            //    List<int> digitsForOutput = new List<int>();
            //    double digitForOperations = 0;

            //    for (int i = 0; i < data.Length; i++)
            //    {
            //        switch(data[i])
            //        {
            //            case 'i': digitForOperations++; break;
            //            case 'd': digitForOperations--; break;
            //            case 's': digitForOperations = Math.Pow(digitForOperations, 2); break;
            //            case 'o': digitsForOutput.Add((int)digitForOperations); break;
            //        }
            //    }

            //    return digitsForOutput.ToArray();
            //}

            //var x = Parse("iiisdoso");
            //var y = Parse("iiisdosodddddiso");

            //foreach (int item in y)
            //{
            //    Console.Write(item + " ");
            //}


            ////======================================================================
            ////======================================================================
            //// Задача: на вход две строки, при нахождении в первой строке слов из второй строки, эти
            //// слова должны быть прописаны в нижнем регистре (кроме самого первого слова в строке); 
            //// все остальные слова должны начинаться с большой буквы и продолжаться маленькими буквами
            //// Мое решение:
            //string TitleCase(string title, string minorWords = "")
            //{
            //    var words = title.ToLower().Split(' ');
            //    if (!String.IsNullOrEmpty(minorWords))
            //    {
            //        var minors = minorWords.Split(' ');
            //        words[0] = Char.ToUpper(words[0][0]) + words[0].Substring(1);

            //        for (int i = 1; i < words.Length; i++)
            //        {
            //            words[i] = Char.ToUpper(words[i][0]) + words[i].Substring(1);

            //            for (int j = 0; j < minors.Length; j++)
            //            {
            //                if (words[i].ToLower() == minors[j].ToLower())
            //                {
            //                    words[i] = minors[j].ToLower();
            //                }
            //            }
            //        }

            //        return string.Join(" ", words);
            //    }
            //    else if (title != "")
            //    {
            //        for (int i = 0; i < words.Length; i++)
            //        {
            //            words[i] = Char.ToUpper(words[i][0]) + words[i].Substring(1);
            //        }
            //        return string.Join(" ", words);
            //    }
            //    else return string.Empty;
            //}

            //Console.WriteLine(TitleCase("a clash of KINGS", "a an the of"));
            //Console.WriteLine(TitleCase("THE WIND IN THE WILLOWS", "The In"));
            //Console.WriteLine(TitleCase("the quick brown fox"));
            //Console.WriteLine(TitleCase("", null));
            //Console.WriteLine(TitleCase("", ""));



            // Задача на оптимизацию: установить, является ли входящее число простым. Сложность алгоритма 
            // должна быть меньше чем O(n) и меньше чем O(n/2)
            //bool IsNumberPrime(long n)
            //{
            //bool isDigitPrime(int digit)
            //{
            //    if (n <= 0 || n == 1)
            //        return false;

            //    for (int i = 2; i < digit; i++)
            //    {
            //        if (digit % i == 0)
            //            return false;
            //    }
            //    return true;
            //}

            //if (n <= 0 || n == 1)
            //    return false;

            //var rightDigit = 0;
            //rightDigit = n % 10;

            //while(rightDigit != 0)
            //{
            //    if (isDigitPrime(rightDigit))
            //        return true;

            //}


            //    // Оптимизация №1: увеличиваем шаг перечисления в 2 раза, разделив вход на два цикла 
            //    // в зависимости от четности/нечетности входящего числа
            //    if (n <= 0 || n == 1)
            //        return false;
            //    else if (n % 2 == 0)
            //    {
            //        for (int i = 2; i < n / 2; i += 2)
            //        {
            //            if (n % i == 0)
            //            {
            //                return false;
            //            }
            //        }
            //    }
            //    else if (n % 2 != 0)
            //    {
            //        for (int i = 3; i < n / 2; i += 2)
            //        {
            //            if (n % i == 0)
            //            {
            //                return false;
            //            }
            //        }
            //    }

            //    return false;
            //}


            //Console.WriteLine((int)Math.Floor(Math.Sqrt(2123)));


            //IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
            //{
            //	List<T> inputCollection = new List<T>();
            //	foreach (var item in iterable)
            //	{
            //		inputCollection.Add(item);
            //	}

            //	for (int i = 0; i < inputCollection.Count - 1; i++)
            //	{
            //		if (inputCollection[i + 1].Equals(inputCollection[i]))
            //		{
            //			inputCollection.RemoveAt(i + 1);
            //			i--;
            //		}
            //	}
            //	return inputCollection;
            //}

            ////Assert.AreEqual("ABCDAB", UniqueInOrder("AAAABBBCCDAABBB"));
            ////Assert.AreEqual("ABBCcAD", UniqueInOrder("ABBCcAD"));
            ////Assert.AreEqual("ABCDAB", UniqueInOrder("AAAABBBCCDAABBB"));
            ////Assert.AreEqual(new int[] { 1, 2, 3 }, UniqueInOrder(new int[] { 1, 2, 2, 3, 3 }));

            //var x = UniqueInOrder("ABBCcAD");
            //foreach (var item in x)
            //{
            //	Console.Write(item + " ");
            //}




            //string Encrypt(string inputStr, int n)
            //{
            //    if (String.IsNullOrEmpty(inputStr) || n <= 0)
            //        return inputStr;

            //    string encryptedStr = "";

            //    for (int repeats = 0; repeats < n; repeats++)
            //    {
            //        if (repeats >= 1)
            //        {
            //            inputStr = encryptedStr;
            //            encryptedStr = "";
            //        }

            //        for (int i = 1; i < inputStr.Length; i += 2)
            //        {
            //            encryptedStr += inputStr[i];
            //        }

            //        for (int i = 0; i < inputStr.Length; i += 2)
            //        {
            //            encryptedStr += inputStr[i];
            //        }
            //    }

            //    return encryptedStr;
            //}

            //string Decrypt(string encryptedText, int n)
            //{
            //    if (String.IsNullOrEmpty(encryptedText) || n <= 0)
            //        return encryptedText;

            //    List<char> finalSymbols = new List<char>();

            //    for (int repeats = 0; repeats < n; repeats++)
            //    {
            //        if (repeats >= 1)
            //        {
            //            encryptedText = String.Join("", finalSymbols.ToArray());
            //            finalSymbols.Clear();
            //        }

            //        string oddIndexedChars = "";
            //        string evenIndexedChars = "";

            //        for (int i = 0; i < encryptedText.Length/2; i++)
            //        {
            //            oddIndexedChars += encryptedText[i];
            //        }
            //        for (int i = encryptedText.Length/2; i < encryptedText.Length; i++)
            //        {
            //            evenIndexedChars += encryptedText[i];
            //        }

            //        int totalCharsToIterate;

            //        if (oddIndexedChars.Length >= evenIndexedChars.Length)
            //            totalCharsToIterate = oddIndexedChars.Length;
            //        else totalCharsToIterate = evenIndexedChars.Length;

            //        for (int i = 0; i < totalCharsToIterate; i++)
            //        {
            //            if (i < evenIndexedChars.Length)
            //                finalSymbols.Add(evenIndexedChars[i]);
            //            if (i < oddIndexedChars.Length)
            //                finalSymbols.Add(oddIndexedChars[i]);
            //        }
            //    }

            //    return String.Join("", finalSymbols.ToArray());
            //}

            ////Console.WriteLine(Encrypt("This is a test!", 0));
            ////Console.WriteLine(Encrypt("This is a test!", 1));
            ////Console.WriteLine(Encrypt("This is a test!", 2));
            ////Console.WriteLine(Encrypt("This is a test!", 3));
            ////Console.WriteLine();
            ////Console.WriteLine(Decrypt("This is a test!", 0));
            //Console.WriteLine(Decrypt("hsi  etTi sats!", 1));
            //Console.WriteLine(Decrypt("s eT ashi tist!", 2));
            //Console.WriteLine(Decrypt(" Tah itse sits!", 3));
            //Console.WriteLine(Decrypt("hskt svr neetn!Ti aai eyitrsig", 1));



            //string Add(string a, string b)
            //{
            //    var bigA = BigInteger.Parse(a, CultureInfo.InvariantCulture); 
            //    var bigB = BigInteger.Parse(b, CultureInfo.InvariantCulture); 

            //    var output = BigInteger.Add(bigA, bigB);

            //    return Convert.ToString(output);
            //}

            //Console.WriteLine(Add("123456789", "987654322"));
            //Console.WriteLine(Add("999999999", "1"));
            //Console.WriteLine(Add("1000000000000000000000000", "1"));
            ////9223372036854775807


            // 0 - empty
            // 1 - X
            // 2 - O

            // return 1 - X won
            // return 2 - O won
            // return 0 - draw

            //int IsSolved(int[,] board)
            //{
            //	var height = board.GetLength(0);
            //	var wight = board.GetLength(1);
            //	var zeroesCnt = 0;
            //	var Xcnt = 0;
            //	var Ocnt = 0;


            //	for (int i = 0; i < height; i++)
            //	{
            //		for (int j = 0; j < wight; j++)
            //		{
            //			if (board[i, j] == 1)
            //				Xcnt++;
            //			if (board[i, j] == 2)
            //				Ocnt++;
            //			if (board[i, j] == 0)
            //				zeroesCnt++;
            //		}
            //	}

            //	for (int i = 0; i < height - 2; i++)
            //	{
            //		for (int j = 0; j < wight - 2; j++)
            //		{
            //			bool isThereXLine = false;
            //			bool isThereOLine = false;

            //			if (board[i, j] == board[i, j + 1]
            //				&& board[i, j + 1] == board[i, j + 2]
            //				|| board[i + 1, j] == board[i + 1, j + 1]
            //				&& board[i + 1, j + 1] == board[i + 1, j + 2]
            //				|| board[i + 2, j] == board[i + 2, j + 1]
            //				&& board[i + 2, j + 1] == board[i + 2, j + 2])
            //			{
            //				if (board[i, j] == 1)
            //				{
            //					isThereXLine = true;
            //				}
            //				else if (board[i, j] == 2)
            //				{
            //					isThereOLine = true;
            //				}
            //			}

            //			if (board[i, j] == board[i + 1, j]
            //			  && board[i + 1, j] == board[i + 2, j]
            //			  ||board[i, j + 1] == board[i + 1, j + 1]
            //			  && board[i + 1, j + 1] == board[i + 2, j + 1]
            //			   ||board[i, j + 2] == board[i + 1, j + 2]
            //			  && board[i + 1, j + 2] == board[i + 2, j + 2]
            //			  )
            //			{
            //				if (board[i, j] == 1)
            //				{
            //					isThereXLine = true;
            //				}
            //				else if (board[i, j] == 2)
            //				{
            //					isThereOLine = true;
            //				}
            //			}

            //			if (board[i, j] == board[i + 1, j + 1]
            //				&& board[i, j] == board[i + 2, j + 2]
            //				)
            //			{
            //				if (board[i, j] == 1)
            //				{
            //					isThereXLine = true;
            //				}
            //				else if (board[i, j] == 2)
            //				{
            //					isThereOLine = true;
            //				}
            //			}

            //			if (board[i, j + 2] == board[i + 1, j + 1]
            //				&& board[i + 1, j + 1] == board[i + 2, j]
            //				)
            //			{
            //				if (board[i, j] == 1)
            //				{
            //					isThereXLine = true;
            //				}
            //				else if (board[i, j + 2] == 2)
            //				{
            //					isThereOLine = true;
            //				}
            //			}

            //			if (isThereXLine && !isThereOLine)
            //				return 1;
            //			else if (isThereOLine && !isThereXLine)
            //				return 2;
            //			else if (!isThereOLine && !isThereXLine && zeroesCnt == 0)
            //			{
            //				return 0;
            //			}
            //			else if (!isThereOLine && !isThereXLine && zeroesCnt > 0)
            //			{
            //				return -1;
            //			}
            //		}
            //	}

            //	return 0;
            //}

            //int[] Snail(int[][] array)
            //{
            //    bool isArrayFilled = false;

            //    int[] IterateCircle(int[][] array)
            //    {

            //    }

            //    List<int> nums = new List<int>();
            //    if (array.Length == 1 && array[0].Length == 1)
            //    {
            //        nums.Add(array[0][0]);
            //        return nums.ToArray();
            //    }
            //    else if (array.Length == 1 && array[0].Length == 0)
            //    {
            //        return new int[] { };
            //    }

            //    var upperArr = array[0];
            //    foreach (var num in upperArr)
            //    {
            //        nums.Add(num);
            //    }
            //    array = array.Where(val => val != array[0]).ToArray();


            //    for (int i = 0; i < array.Length - 1; i++)
            //    {
            //        var subArrLength = array[i].Length;
            //        nums.Add(array[i][subArrLength - 1]);

            //        array[i] = array[i].Take(subArrLength - 1).ToArray();
            //        //ИЛИ
            //        //Array.Resize(ref array[i], subArrLength - 1);
            //    }

            //    var bottomArr = array[array.Length - 1];
            //    Array.Reverse(bottomArr);
            //    foreach (var num in bottomArr)
            //    {
            //        nums.Add(num);
            //    }
            //    Array.Reverse(bottomArr);
            //    array = array.Where(val => val != array[array.Length - 1]).ToArray();

            //    for (int i = array.Length - 1; i >= 0; i--)
            //    {
            //        nums.Add(array[i][0]);

            //        array[i] = array[i].Skip(1).ToArray();
            //        //ИЛИ
            //        //array[i] = array[i].Where(val => val != array[i][0]).ToArray();
            //    }

            //    foreach (var arr in array)
            //    {
            //        if (arr != null && array.Length != 0)
            //            isArrayFilled = true;
            //    }

            //    while (isArrayFilled)
            //    {
            //        var x = Snail(array);
            //        nums.AddRange(x);

            //        if (x.Length <= 4)
            //            isArrayFilled = false;
            //    }

            //    return nums.ToArray();
            //}

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

            //int[,] board7 = new int[,] { { 2, 1, 1 }, { 0, 1, 1 }, { 2, 2, 2 } };
            //Console.WriteLine(IsSolved(board7));


            //int[] Snail(int[][] array)
            //{
            //    int inputTotalLength = 0;
            //    foreach (var arr in array)
            //    {
            //        inputTotalLength += arr.Length;
            //    }

            //    List<int> nums = new List<int>();

            //    IterateCircle(array);

            //    int[] IterateCircle(int[][] array)
            //    {
            //        if (array.Length == 1 && array[0].Length == 1)
            //        {
            //            nums.Add(array[0][0]);
            //            return nums.ToArray();
            //        }
            //        else if (array.Length == 1 && array[0].Length == 0)
            //        {
            //            return new int[] { };
            //        }

            //        var upperArr = array[0];
            //        foreach (var num in upperArr)
            //        {
            //            nums.Add(num);
            //        }
            //        array = array.Where(val => val != array[0]).ToArray();

            //        for (int i = 0; i < array.Length - 1; i++)
            //        {
            //            var subArrLength = array[i].Length;
            //            nums.Add(array[i][subArrLength - 1]);

            //            array[i] = array[i].Take(subArrLength - 1).ToArray();
            //            //ИЛИ
            //            //Array.Resize(ref array[i], subArrLength - 1);
            //        }

            //        var bottomArr = array[array.Length - 1];
            //        Array.Reverse(bottomArr);
            //        foreach (var num in bottomArr)
            //        {
            //            nums.Add(num);
            //        }
            //        Array.Reverse(bottomArr);
            //        array = array.Where(val => val != array[array.Length - 1]).ToArray();

            //        for (int i = array.Length - 1; i >= 0; i--)
            //        {
            //            nums.Add(array[i][0]);

            //            array[i] = array[i].Skip(1).ToArray();
            //            //ИЛИ
            //            //array[i] = array[i].Where(val => val != array[i][0]).ToArray();
            //        }

            //        while (nums.Count != inputTotalLength)
            //        {
            //            var x = IterateCircle(array);

            //            if (nums.Count == inputTotalLength)
            //            {
            //                return nums.ToArray();
            //            }
            //            nums.AddRange(x);
            //        }

            //        return nums.ToArray();
            //    }
            //    return nums.ToArray();
            //}

            //int[][] array1 =
            //{
            //new []{1, 2, 3},
            //new []{4, 5, 6},
            //new []{7, 8, 9}
            //};

            //int[][] array2 =
            //{
            //new[]{1, 2, 3},
            //new[]{8, 9, 4},
            //new[]{7, 6, 5}
            //};

            //int[][] array3 =
            //{
            //new[]{1, 2, 3, 1},
            //new[]{8, 9, 4, 6},
            //new[]{2, 4, 1, 7},
            //new[]{9, 8, 3, 2}
            //};

            //int[][] array4 =
            //{
            //new[]{2, 3},
            //new[]{9, 4}
            //};

            //int[][] array5 =
            //{
            //new[]{1, 2, 3, 9},
            //new[]{4, 5, 6, 4},
            //new[]{7, 8, 9, 1},
            //new[]{1, 2, 3, 4}
            //};

            //int[][] array6 =
            //{
            //new int[]{}
            //};

            //int[][] array7 =
            //{
            //new[]{1, 2, 3, 9, 1},
            //new[]{4, 5, 6, 4, 5},
            //new[]{7, 8, 9, 1, 8},
            //new[]{1, 2, 3, 4, 3},
            //new[]{1, 2, 3, 4, 2}
            //};

            //var x = Snail(array1);
            //var y = Snail(array2);
            //var z = Snail(array3);
            //var q = Snail(array4);
            //var b = Snail(array5);
            //var n = Snail(array6);
            //var j = Snail(array7);

            //foreach (var item in x)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in y)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in z)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in q)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in b)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in n)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in j)
            //{
            //    Console.Write(item + " ");
            //}


            //static string[] dirReduc(string[] arr)
            //{
            //    List<string> arrList = new List<string>();
            //    arrList.AddRange(arr);

            //    arrList = Reduc(arrList);

            //    return arrList.ToArray();
            //}

            //static List<string> Reduc(List<string> arrList)
            //{
            //    bool isAnyMatchFound = false;

            //    for (int i = 0; i < arrList.Count - 1; i++)
            //    {
            //        if (arrList[i] == "NORTH" && arrList[i + 1] == "SOUTH"
            //            || arrList[i] == "SOUTH" && arrList[i + 1] == "NORTH")
            //        {
            //            arrList.Remove(arrList[i]);
            //            i--;
            //            arrList.Remove(arrList[i + 1]);

            //            isAnyMatchFound = true;
            //        }
            //        else if (arrList[i] == "EAST" && arrList[i + 1] == "WEST"
            //            || arrList[i] == "WEST" && arrList[i + 1] == "EAST")
            //        {
            //            arrList.Remove(arrList[i]);
            //            i--;
            //            arrList.Remove(arrList[i + 1]);

            //            isAnyMatchFound = true;
            //        }
            //    }

            //    if (isAnyMatchFound)
            //        Reduc(arrList);

            //    return arrList;
            //}



            //string[] a = new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };
            //var aa = dirReduc(a);
            //foreach (var item in aa)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();


            //string[] b = new string[] { "NORTH", "EAST", "WEST", "SOUTH", "WEST", "WEST" };
            //var bb = dirReduc(b);
            //foreach (var item in bb)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();


            //string[] c = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
            //var cc = dirReduc(c);
            //foreach (var item in cc)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();


            //string[] d = new string[] { "NORTH", "NORTH", "EAST", "SOUTH", "EAST", "EAST", "SOUTH", "SOUTH" };
            //var dd = dirReduc(d);
            //foreach (var item in dd)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();

            //List<long> GetDivisors(long num)
            //{
            //    List<long> divisors = new List<long>();
            //    for (int i = 1; i <= num; i++)
            //    {
            //        if (num % i == 0)
            //            divisors.Add(i);
            //    }
            //    return divisors;
            //}


            //string listSquared(long m, long n)
            //{
            //    // В рендже m-n найти каждое число, у которого сумма всех его делителей возведенных в квадрат
            //    // сама является целочисленным квадратом
            //    // Вывести string в виде [[x, y], [x, y]], где x - найденное число; y - сумма квадратов делителей этого числа

            //    // Найти все делители; возвести их в квадрат; сложить их; результат проверить на целочисленный корень

            //    //List<long> nums = new List<long>();
            //    //for (long i = m; i <= n; i++)
            //    //{
            //    //    nums.Add(i);
            //    //}

            //    List<long> divisors = new List<long>();
            //    List<double> divisorsSquared = new List<double>();

            //    long[][] outputArrays = new long[0][]; 

            //for (long i = m; i <= n; i++)
            //{
            //    divisors = GetDivisors(i);

            //    if (divisors.Count != 2)
            //    {
            //        divisorsSquared = divisors.Select(d => Math.Pow(d, 2)).ToList();
            //        double sumOfDivisors = divisorsSquared.Sum();

            //        if (Math.Sqrt(sumOfDivisors) % 1 == 0)
            //        {
            //            long[] outputArr = new long[] { i, (long)sumOfDivisors };

            //            Array.Resize(ref outputArrays, outputArrays.Length + 1);
            //            outputArrays[outputArrays.Length - 1] = outputArr;
            //        }
            //    }
            //}

            //    string outputString = "[";

            //    for(int i = 0; i < outputArrays.Length; i++)
            //    {
            //        if (i != outputArrays.Length - 1)
            //        {
            //            outputString += $"[{outputArrays[i][0]}, {outputArrays[i][1]}], ";
            //        }
            //        else outputString += $"[{outputArrays[i][0]}, {outputArrays[i][1]}]";
            //    }
            //    outputString += "]";
            //    return outputString;
            //}


            //Console.WriteLine(listSquared(1, 250));//"[[1, 1], [42, 2500], [246, 84100]]",

            //Console.WriteLine(listSquared(42, 250));//"[[42, 2500], [246, 84100]]",

            //Console.WriteLine(listSquared(250, 500));//"[[287, 84100]]", 


            //Dictionary<string, List<int>> GetPeaks(int[] arr)
            //{
            //	List<int> poses = new List<int>();
            //	List<int> peaks = new List<int>();

            //	bool isTherePeak = false;

            //	for (int i = 1; i < arr.Length - 1; i++)
            //	{
            //		if (arr[i - 1] < arr[i] && arr[i] > arr[i + 1])
            //		{
            //			poses.Add(i);
            //			peaks.Add(arr[i]);
            //			isTherePeak = true;
            //		}

            //		if (arr[i - 1] < arr[i] && arr[i] == arr[i + 1])
            //		{
            //			int[] sequenceAfterPlato = new int[arr.Length - (i + 1)];
            //			Array.Copy(arr, i + 1, sequenceAfterPlato, 0, arr.Length - (i + 1));


            //			for (int j = 0; j < sequenceAfterPlato.Length; j++)
            //			{
            //				if (sequenceAfterPlato[j] < arr[i])
            //				{
            //					poses.Add(i);
            //					peaks.Add(arr[i]);
            //					isTherePeak = true;
            //					break;
            //				}
            //				else if (sequenceAfterPlato[j] > arr[i])
            //					break;
            //			}
            //		}
            //	}

            //	if (!isTherePeak)
            //	{
            //		return new Dictionary<string, List<int>>()
            //		{
            //			["pos"] = new List<int>(),
            //			["peaks"] = new List<int>()
            //		};
            //	}
            //	else
            //	{
            //		return new Dictionary<string, List<int>>()
            //		{
            //			["pos"] = poses,
            //			["peaks"] = peaks
            //		};
            //	}
            //}

            ////int[] arr = new int[] { 1, 2, 3, 6, 4, 1, 2, 3, 2, 1 };
            ////int[] arr = new int[] { 1, 2, 2, 2, 1 };
            ////int[] arr = new int[] { 8, 18, 10, 0, 8, 9, 5, 19, 11, 18, 13, -3, -2, 5, 18, 18, -4, 12, 6, 4, 8, 7, -3, 0, 0, 11, -5, 8 };
            ////int[] arr = new int[] { 18, 16, 2, 15, -1, 4, 4, -3, 17, 11, 17, 16, 18, -4, 5, 8 };
            //int[] arr = new int[] { -4, 10, 18, 7, -5, 17, 17, 16, 7, 2, 1, -2, -5, 10, 19, 1, 7, 19, 1 };

            //List<int> expectedPos = new List<int> { 3, 7 };
            //List<int> expectedPeak = new List<int> { 6, 3 };

            //var result = GetPeaks(arr);
            //var pos = result["pos"];
            //var peaks = result["peaks"];

            //foreach (var item in pos)
            //{
            //	Console.Write(item + " ");
            //}
            //Console.WriteLine();

            //foreach (var item in peaks)
            //{
            //	Console.Write(item + " ");
            //}
            //Console.WriteLine();


            //long NextSmaller(long n)
            //{
            //    // -1 если нет такого позитивного числа И если есть но первая цифра 0

            //    // каждую цифру в лист
            //    // найти справа-налево первое число X, для которого справа есть меньшее число Y
            //    // поменять местами X-Y
            //    // все числа справа от Y отсортировать по убыванию

            //    //1262347  // 1
            //    //1242367  // 2
            //    //1247632  // 3
            //    long nums = 0;
            //    nums = n;

            //    List<long> digits = new List<long>();
            //    List<long> partToSort = new List<long>();

            //    while (nums != 0)
            //    {
            //        digits.Add(nums % 10);
            //        nums /= 10;
            //    }
            //    digits.Reverse();


            //    bool isFirstObjectFound = false;

            //    for (int i = digits.Count - 1; i >= 0 ; i--)
            //    {
            //        for (int j = digits.Count - 1; j > i && !isFirstObjectFound; j--)
            //        {
            //            if (digits[j] < digits[i])
            //            {
            //                isFirstObjectFound = true;

            //                var temp = digits[i];
            //                digits[i] = digits[j];
            //                digits[j] = temp;

            //                partToSort = digits.GetRange(i + 1, digits.Count - (i + 1));
            //                digits.RemoveRange(i + 1, digits.Count - (i + 1));

            //                partToSort.Sort((a, b) => b.CompareTo(a));
            //                digits.AddRange(partToSort);
            //            }
            //        }
            //    }

            //    if (digits[0] == 0)
            //        return -1;
            //    else
            //    {
            //        long total = 0;
            //        foreach (int entry in digits)
            //        {
            //            total = 10 * total + entry;
            //        }

            //        if (total == n)
            //            return -1;
            //        else
            //            return total;
            //    }
            //}


            ////Console.WriteLine(NextSmaller(21));//Assert.AreEqual(12

            ////Console.WriteLine(NextSmaller(907));//Assert.AreEqual(790
            //Console.WriteLine(NextSmaller(531));//Assert.AreEqual(513
            ////Console.WriteLine(NextSmaller(1027));//Assert.AreEqual(-1
            ////Console.WriteLine(NextSmaller(441));//Assert.AreEqual(414

            ////Console.WriteLine(NextSmaller(135));//Assert.AreEqual(-1
            ////Console.WriteLine(NextSmaller(9));//Assert.AreEqual(-1
            ////Console.WriteLine(NextSmaller(123456798));//Assert.AreEqual(123456789
            ////Console.WriteLine(NextSmaller(1262347));//Assert.AreEqual(1247632


            //Dictionary<int, char> GetSerNumbersToChars(string str)
            //{
            //    char[] keyChars = str.ToCharArray();
            //    char[] keyCharsSorted = new char[keyChars.Length];
            //    Array.Copy(keyChars, 0, keyCharsSorted, 0, keyChars.Length);

            //    Array.Sort(keyCharsSorted);

            //    Dictionary<int, char> charsToSerNumbers = new Dictionary<int, char>();
            //    for (int i = 0; i < keyCharsSorted.Length; i++)
            //    {
            //        charsToSerNumbers.Add(i + 1, keyCharsSorted[i]);
            //    }

            //    return charsToSerNumbers;
            //}

            //string Nico(string key, string message)
            //{
            //    char[] keyChars = key.ToCharArray();
            //    char[] keyCharsSorted = new char[keyChars.Length];
            //    Array.Copy(keyChars, 0, keyCharsSorted, 0, keyChars.Length);

            //    Array.Sort(keyCharsSorted);

            //    Dictionary<char, int> charsToSerNumbers = new Dictionary<char, int>();
            //    for (int i = 0; i < keyCharsSorted.Length; i++)
            //    {
            //        charsToSerNumbers.Add(keyCharsSorted[i], i + 1);
            //    }

            //    int[] readyKey = new int[keyCharsSorted.Length];
            //    for (int i = 0; i < charsToSerNumbers.Count; i++)
            //    {
            //        readyKey[i] = charsToSerNumbers[keyChars[i]];
            //    }


            //    string readyChunk = "";
            //    string subStringOnKey = "";

            //    while (message != "")
            //    {
            //        if (message.Length > readyKey.Length)
            //            subStringOnKey = message.Substring(0, readyKey.Length);
            //        else if (message.Length <= readyKey.Length)
            //            subStringOnKey = message;

            //        Dictionary<int, char> subStringCharsToKey = new Dictionary<int, char>();
            //        for (int i = 0; i < subStringOnKey.Length; i++)
            //        {
            //            subStringCharsToKey.Add(readyKey[i], subStringOnKey[i]);
            //        }

            //        for (int i = 0; i < readyKey.Length; i++)
            //        {
            //            try
            //            {
            //                readyChunk += subStringCharsToKey[i + 1];
            //            }
            //            catch (KeyNotFoundException)
            //            {
            //                readyChunk += " ";
            //            }
            //        }

            //        message = message.Substring(subStringOnKey.Length, message.Length - subStringOnKey.Length);
            //    }

            //    return readyChunk;
            //}

            ////Assert.AreEqual("cseerntiofarmit on  ", Nico("crazy", "secretinformation"));
            ////Assert.AreEqual("abcd  ", Nico("abc", "abcd"));
            ////Assert.AreEqual("2143658709", Nico("ba", "1234567890"));
            ////Assert.AreEqual("message", Nico("a", "message"));
            ////Assert.AreEqual("eky", Nico("key", "key"));

            ////Console.WriteLine(Nico("crazy", "secretinformation"));//"cseerntiofarmit on  "
            ////Console.WriteLine(Nico("abc", "abcd"));//"abcd  "
            //Console.WriteLine(Nico("ba", "1234567890"));//"2143658709"
            //Console.WriteLine(Nico("a", "message"));//"message"
            //Console.WriteLine(Nico("key", "key"));//"eky"

            //long GetSumOfDigits(long num)
            //{
            //    long sum = 0;
            //    while (num != 0)
            //    {
            //        sum += num % 10;
            //        num /= 10;
            //    }
            //    return sum;
            //}

            //long[] MaxSumDig(long nmax, int maxsm)
            //{
            //    // найти все числа <= nmax, у которых сумма цифр числа <= maxsm

            //    // вывод [(1), (2), (3)], где 1 - количество найденных чисел; 2 - число из найденных, которое для 
            //    // среднего арифметического всех чисел является самым ближним
            //    // 3 - сумма найденных чисел

            //    List<long> matchedNums = new List<long>();

            //    for (int i = 1000; i <= nmax; i++)
            //    {
            //        if (GetSumOfDigits(i) <= maxsm)
            //            matchedNums.Add(i);
            //    }

            //    var matchedNumsCount = matchedNums.Count;

            //    var matchedNumsMean = matchedNums.Sum() / matchedNums.Count;

            //    var closestNumToMean = matchedNums.OrderBy(item => Math.Abs(matchedNumsMean - item)).First();
            //    //ИЛИ
            //    //var closestNumToMean = matchedNums.Aggregate((x, y) => Math.Abs(x-matchedNumsMean) < Math.Abs(y-matchedNumsMean) ? x : y);

            //    var matchedNumsSum = matchedNums.Sum();

            //    return new long[] { matchedNumsCount, closestNumToMean, matchedNumsSum };
            //}


            //var a = MaxSumDig(2000, 3); //new long[] { 11, 1110, 12555 });
            //var b = MaxSumDig(2000, 4); //new long[] { 21, 1120, 23665 });
            //var c = MaxSumDig(2000, 7); //new long[] { 85, 1200, 99986 });
            //var d = MaxSumDig(3000, 7); //new long[] { 141, 1600, 220756 });

            //foreach (var item in a)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in b)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in c)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();
            //foreach (var item in d)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();


            //string SumStrings(string a, string b)
            //{
            //    if (string.IsNullOrEmpty(a))
            //        return b;
            //    else if (string.IsNullOrEmpty(b))
            //        return a;

            //    BigInteger numA = BigInteger.Parse(a);
            //    BigInteger numB = BigInteger.Parse(b);
            //    return Convert.ToString(BigInteger.Add(numA, numB));
            //}


            //int[] Sort(int[] array)
            //{
            //    //There may be duplicates
            //    //The array may be empty

            //    // Перевести массив в строковый
            //    // Разбить на отдельные слова - массив строк; сортировка по названию по возрастанию
            //    // по первой букве или первым буквам если число записывается в несколько слов
            //    if (array == null || array.Length == 0)
            //        return array;

            //    string[] arr = array.Select(num => num.ToString()).ToArray();

            //    for (int i = 0; i < array.Length; i++)
            //    {
            //        switch (arr[i])
            //        {
            //            case "0": arr[i] = "zero"; break;
            //            case "1": arr[i] = "one"; break;
            //            case "2": arr[i] = "two"; break;
            //            case "3": arr[i] = "three"; break;
            //            case "4": arr[i] = "four"; break;
            //            case "5": arr[i] = "five"; break;
            //            case "6": arr[i] = "six"; break;
            //            case "7": arr[i] = "seven"; break;
            //            case "8": arr[i] = "eight"; break;
            //            case "9": arr[i] = "nine"; break;
            //            case "10": arr[i] = "ten"; break;
            //            case "11": arr[i] = "eleven"; break;
            //            case "12": arr[i] = "twelve"; break;
            //            case "13": arr[i] = "thirteen"; break;
            //            case "14": arr[i] = "fourteen"; break;
            //            case "15": arr[i] = "fifteen"; break;
            //            case "16": arr[i] = "sixteen"; break;
            //            case "17": arr[i] = "seventeen"; break;
            //            case "18": arr[i] = "eighteen"; break;
            //            case "19": arr[i] = "nineteen"; break;
            //            case "20": arr[i] = "twenty"; break;
            //            case "30": arr[i] = "thirty"; break;
            //            case "40": arr[i] = "forty"; break;
            //            case "50": arr[i] = "fifty"; break;
            //            case "60": arr[i] = "sixty"; break;
            //            case "70": arr[i] = "seventy"; break;
            //            case "80": arr[i] = "eighty"; break;
            //            case "90": arr[i] = "ninety"; break;
            //        }

            //        if (arr[i].Length >= 2)
            //        {
            //            switch (arr[i][0])
            //            {
            //                case '2': arr[i] = "one"; break;
            //            }
            //            switch (arr[i].Substring(1, 1))
            //            {
            //                case "1": arr[i] = "one"; break;
            //                case "2": arr[i] = "two"; break;
            //                case "3": arr[i] = "three"; break;
            //                case "4": arr[i] = "four"; break;
            //                case "5": arr[i] = "five"; break;
            //                case "6": arr[i] = "six"; break;
            //                case "7": arr[i] = "seven"; break;
            //                case "8": arr[i] = "eight"; break;
            //                case "9": arr[i] = "nine"; break;
            //            }
            //        }

            //    }

            //    return new[] { 5 };

            //}

            //var a = Sort(new[] { 8, 8, 9, 9, 10, 10 });
            //var b = Sort(new[] { 1, 2, 3, 4 });
            //var c = Sort(new[] { 9, 99, 999 });

            //foreach (var x in a)
            //{
            //    Console.Write(x + " ");
            //}
            //Console.WriteLine();
            //foreach (var x in b)
            //{
            //    Console.Write(x + " ");
            //}
            //Console.WriteLine();
            //foreach (var x in c)
            //{
            //    Console.Write(x + " ");
            //}
            //Console.WriteLine();



            //string AlphabetWar(string b)
            //{
            //    // Ни одного # - вывести все символы без скобок

            //    // Один # вокруг [x] : [x] остается, все остальные буквы уничтожаются: необходимо проводить
            //    // проверку в зоне до следующего [x] : логика выделения зоны
            //    // Два и более # вокруг [x] : [x] уничтожается вместе со всеми буквами вокруг
            //    // Метки # никуда не деваются при уничтожении [x] (актуальны и для следующего [x])

            //    if (!b.Contains('#'))
            //    {
            //        var fetch = b.Where(c => c != '[' && c != ']').ToArray();
            //        return String.Join("", fetch);
            //    }

            //    // Пересчет символов в строке
            //    for (int i = 0; i < b.Length; i++)
            //    {
            //        // найти [x] 

            //        // найти всю актуальную область вокруг [x] до след [x] (или до конца строки)
            //        // проверять актуальную область на # и ##
            //        // если справа больше нет [x] и один # на область - удалить все но оставить область без скобок; 
            //        // если справа есть [x] и один # на область - удалить все но оставить область без скобок, и далее
            //        //      перейти к следующему [x] и актуальной области вокруг него; 

            //        // Нахождение [x]
            //        string shelter = "";


            //        if (b[i] == '[')
            //        {
            //            var rawShelter = b.Substring(i);

            //            for (int j = 0; j < rawShelter.Length; j++)
            //            {
            //                if (rawShelter[j] == ']')
            //                {
            //                    shelter = rawShelter.Substring(0, j + 1);

            //                    b = b.Remove(i, j + 1);

            //                    // убрать из строки shelter
            //                    // область: субстринг от начала до [ (если нету - до конца строки)

            //                    if (b.Contains('['))
            //                    {
            //                        var actualArea = b.Substring(0, b.IndexOf('['));
            //                    }
            //                }
            //            }
            //        }

            //        // находим кусок до ] => выделяем  [x] ==>
            //    }

            //    return null;
            //}


            ////Console.WriteLine(AlphabetWar("abde[fgh]ijk"));
            ////Console.WriteLine(AlphabetWar("ab#de[fgh]ijk"));
            ////Console.WriteLine(AlphabetWar("ab#de[fgh]ij#k"));
            ////Console.WriteLine(AlphabetWar("##abde[fgh]ijk"));
            ////Console.WriteLine(AlphabetWar("##abde[fgh]"));
            ////Console.WriteLine(AlphabetWar("abde[fgh]"));
            //Console.WriteLine(AlphabetWar("#abde[fgh]i#jk[mn]op"));

            ////##abde[fgh]ijk[mn]op => "mn" (letters from the second shelter survive, there is no # close)
            ////#ab#de[fgh]ijk[mn]op => "mn" (letters from the second shelter survive, there is no # close)
            ////#abde[fgh]i#jk[mn]op => "mn" (letters from the second shelter survive, there is only 1 # close)
            ////[a]#[b]#[c]  => "ac"
            ////[a]#b#[c][d] => "d"
            ////[a][b][c]    => "abc"
            ////##a[a]b[c]#  => "c"

            ////Assert.AreEqual("abdefghijk", AlphabetWar("abde[fgh]ijk"));
            ////Assert.AreEqual("fgh", AlphabetWar("ab#de[fgh]ijk"));
            ////Assert.AreEqual("", AlphabetWar("ab#de[fgh]ij#k"));
            ////Assert.AreEqual("", AlphabetWar("##abde[fgh]ijk"));
            ////Assert.AreEqual("", AlphabetWar("##abde[fgh]"));
            ////Assert.AreEqual("abdefgh", AlphabetWar("abde[fgh]"));
            ////Assert.AreEqual("mn", AlphabetWar("##abde[fgh]ijk[mn]op"));
            ////Assert.AreEqual("mn", AlphabetWar("#abde[fgh]i#jk[mn]op"));
            ////Assert.AreEqual("abijk", AlphabetWar("[ab]adfd[dd]##[abe]dedf[ijk]d#d[h]#"));









            //Console.WriteLine("Ввод:");
            //string[] input = Console.ReadLine().Split(' ');
            //int[] numbers = input.Select(n => Convert.ToInt32(n)).ToArray();


            //using (FileStream file = new FileStream(Directory.GetCurrentDirectory(), FileMode.Append))
            //{
            //    using (StreamWriter sw = new StreamWriter(file))
            //    {
            //        foreach (int number in numbers)
            //            sw.Write(number);
            //    }
            //    using (StreamReader sr = new StreamReader(file))
            //    {
            //        Console.WriteLine("Числа в файле:");
            //        Console.WriteLine(sr.ReadToEnd());
            //    }
            //}


            //string a = "asdfgdg vasya qwe fd";
            //string torem = "fg";
            //if (a.Contains(torem))
            //{
            //    a = a.Remove(a.IndexOf(torem), torem.Length);
            //}
            //Console.WriteLine(a);

            //// Если на конце ноль - переворачивает убирая ноль, число выходит неправильное
            //int FlipNumber(int num)
            //{
            //    string digits = "";
            //    while (num != 0)
            //    {
            //        digits += num % 10;
            //        num /= 10;
            //    }

            //    //return Convert.ToInt32(digits);
            //    return String.IsNullOrEmpty(digits) ? 0 : int.Parse(digits);
            //}


            //bool isPalindrome(int num)
            //{
            //    List<int> digits = new List<int>();
            //    while (num != 0)
            //    {
            //        digits.Add(num % 10);
            //        num /= 10;
            //    }

            //    for (int i = 0; i < digits.Count/2; i++)
            //    {
            //        if (digits[i] != digits[(digits.Count - 1) - i])
            //            return false;
            //    }

            //    return true;
            //}


            //List<int> GetFactors(int num)
            //{
            //    List<int> factors = new List<int>();

            //    for (int i = 2; i <= num; i++)
            //    {
            //        if (num % i == 0)
            //        {
            //            factors.Add(i);
            //            num /= i;

            //            i--;
            //        }
            //    }

            //    return factors.Distinct().OrderBy(x => x).ToList();
            //}


            //int[] SameFactRev(int nMax)
            //{
            //    // 1. Пересчет с проверкой на палиндром: если палиндром - не рассматриваем
            //    // 2. Находим для числа по факторизации; в список 1, сортируем его
            //    // 3. Переворачиваем число, повторяем 2. внося в список 2 
            //    // 4. Сверяем список 1 и 2, если совпал - добавляем число в финальный массив

            //    List<int> output = new List<int>();

            //    for (int i = 1; i < nMax; i++)
            //    {
            //        if (isPalindrome(i))
            //            continue;

            //        List<int> factorsForStraight = GetFactors(i);
            //        int iReversed = FlipNumber(i);
            //        List<int> factorsForFlipped = GetFactors(iReversed);


            //        if (factorsForStraight.Count > 0 && Enumerable.SequenceEqual(factorsForStraight.OrderBy(x => x), factorsForFlipped.OrderBy(x => x)))
            //            output.Add(i);
            //    }

            //    return output.ToArray();
            //}


            //var test = SameFactRev(3000);
            //foreach (var item in test)
            //{
            //    Console.WriteLine(item + " ");
            //}

            //var tes2 = SameFactRev(5089);
            //foreach (var item in tes2)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();

            //var test3 = SameFactRev(7801);
            //foreach (var item in test3)
            //{
            //    Console.Write(item + " ");
            //}

            //Console.WriteLine();
            //var test4 = SameFactRev(9000);
            //foreach (var item in test4)
            //{
            //    Console.Write(item + " ");
            //}

            ////Console.WriteLine();
            ////Console.WriteLine(isPalindrome(123213));

            ////Console.WriteLine();
            ////Console.WriteLine(FlipNumber(10));



            // TODO linq выдает ошибку попытки обработать пустую коллекцию, однако программа работает почти всегда; на усмотрение
            // DRY не соблюден
            bool isCapacityFull(int currentCapacity, int fullCapacity, int[] weights)
            {
                //пока capacity не станет равно требуемому или пока не останутся приоритеты только со слишком большим весом
                if (currentCapacity == fullCapacity || !weights.Any())
                    return true;
                else if (weights.All(w => (currentCapacity + w) > fullCapacity))
                    return true;
                else
                    return false;
            }

            int PackBagpack(int[] scores, int[] weights, int capacity)
            {
                // Нужно максимально заполнить capacity таким образом, чтобы получилась самая бОльшая сумма чисел из weights; НЕ ДУБЛИРУЮТСЯ

                // Поиск наибольшего приоритетного с наименьшим связанным весом + в конце добавляем что помещяется в остаточный вес
                // чем больше число (Приоритет - Вес) тем приоритетнее к добавлению

                // Перебор; отнимаем от каждого приоритета его вес и переносим в новый массив XXX; перебирая XXX добавляем в 
                // результат все связанные значения из scores от большему к меньшему (сразу удаляя их; важно: если в XXX   
                // будут одинаковые числа, добавляем сначала то где меньше связанный вес) суммируя capacity до тех пор
                // пока capacity не станет равно требуемому или пока не останутся приоритеты только со слишком большим весом

                var currentCapacity = 0;
                var prioritiesForAdd = scores.ToList<int>();
                var outputSum = 0;

                for (int i = 0; i < scores.Length; i++)
                {
                    prioritiesForAdd[i] = scores[i] - weights[i];
                }

                List<int> repeatedNumbers = prioritiesForAdd.GroupBy(x => x)
                                                      .Where(g => g.Count() > 1)
                                                      .Select(y => y.Key)
                                                      .ToList();


                // Суммируем capacity до тех пор
                // пока capacity не станет равно требуемому или пока не останутся приоритеты только со слишком большим весом
                while (!isCapacityFull(currentCapacity, capacity, weights))
                {

                    // Проверка на наличие одинаковых чисел; при наличии забираем только то, где вес меньше
                    // Вход в этот блок только если есть повторяющиеся числа и при этом нет никаких чисел больше минимального повторяющегося
                    if (prioritiesForAdd.Count != prioritiesForAdd.Distinct().Count() && repeatedNumbers.Max() == prioritiesForAdd.Max())
                    {
                        // Проходимся по списку: если число списка = наибольшее число
                        // в prioritiesForAdd: совершаем операции по поиску и добавлению экземпляра повтора с минимальным весом;

                        var currentRepeatedNumber = repeatedNumbers.Max();

                        //var x = prioritiesForAdd.Max();
                        //var w = prioritiesForAdd.IndexOf(currentRepeatedNumber);
                        //var v = prioritiesForAdd.IndexOf(prioritiesForAdd.Max());

                        // Забираем только то, где вес меньше
                        if (prioritiesForAdd.IndexOf(currentRepeatedNumber) == prioritiesForAdd.IndexOf(prioritiesForAdd.Max()))
                        {
                            int minWeightValue = 0;
                            int minWeightIndex = 0;

                            for (int i = 0; i < weights.Length; i++)
                            {
                                if (prioritiesForAdd[i] == currentRepeatedNumber)
                                {
                                    // Если это первое повторяющееся - записываем значение
                                    if (minWeightValue == 0)
                                    {
                                        minWeightValue = weights[i];
                                        minWeightIndex = i;
                                    }
                                    // Если второе+ повторяющееся и оно меньше предыдущего замеченного - обновляем минимум
                                    else if (weights[i] < minWeightValue)
                                    {
                                        minWeightValue = weights[i];
                                        minWeightIndex = i;
                                    }
                                }
                            }

                            int numberOnMinWeight = scores[minWeightIndex];
                            currentCapacity += weights[minWeightIndex];

                            // Если currentCapacity > Capacity && weights не пустой - пропускаем,  удаляем все записи по текущему indexOfMax, пробуем снова
                            if (currentCapacity > capacity)
                            {
                                currentCapacity -= weights[minWeightIndex];

                                scores = scores.Where((item, index) => index != minWeightIndex).ToArray();
                                weights = weights.Where((item, index) => index != minWeightIndex).ToArray();
                                prioritiesForAdd.RemoveAt(minWeightIndex);
                                repeatedNumbers.Remove(currentRepeatedNumber);

                                if (!weights.Any())
                                    break;
                                else
                                    continue;
                            }
                            else
                            {
                                outputSum += scores[minWeightIndex];

                                // Удаление значения по индексу из всех массивов
                                scores = scores.Where((item, index) => index != minWeightIndex).ToArray();
                                weights = weights.Where((item, index) => index != minWeightIndex).ToArray();
                                prioritiesForAdd.RemoveAt(minWeightIndex);
                                repeatedNumbers.Remove(currentRepeatedNumber);
                            }
                        }
                    }
                    else
                    {
                        var indexOfMax = prioritiesForAdd.IndexOf(prioritiesForAdd.Max());
                        currentCapacity += weights[indexOfMax];

                        // Если currentCapacity > Capacity && weights не пустой - пропускаем,  удаляем все записи по текущему indexOfMax, пробуем снова
                        if (currentCapacity > capacity)
                        {
                            currentCapacity -= weights[indexOfMax];

                            scores = scores.Where((item, index) => index != indexOfMax).ToArray();
                            weights = weights.Where((item, index) => index != indexOfMax).ToArray();
                            prioritiesForAdd.RemoveAt(indexOfMax);

                            if (!weights.Any())
                                break;
                            else
                                continue;
                        }
                        else
                        {
                            outputSum += scores[indexOfMax];

                            // Удаление значения по индексу из всех массивов; ЕСЛИ ЕСТЬ ОДИНАКОВЫЕ - УДАЛЯЕТ ОБА
                            //scores = scores.Where(val => Array.IndexOf(scores, val) != indexOfMax).ToArray();
                            scores = scores.Where((item, index) => index != indexOfMax).ToArray();
                            weights = weights.Where((item, index) => index != indexOfMax).ToArray();
                            prioritiesForAdd.RemoveAt(indexOfMax);
                        }

                    }

                }

                return outputSum;
            }



            ////Console.WriteLine(PackBagpack(new int[] { 15, 10, 9, 5 }, new int[] { 1, 5, 3, 4 }, 8)); //29
            ////{ 1,  5,  3, 4 }

            //Console.WriteLine(PackBagpack(new int[] { 20, 15, 5, 10, 40, 10, 15, 25, 40 }, new int[] { 1, 8, 2, 3, 8, 3, 7, 6, 21 }, 10)); //60
            //                                                                                                                               //{ 1,  2, 3,  8,  7,  4 }
            //                                                                                                                               //scores:[ 4, 11, 3, 6, 2, 1 ]
            //                                                                                                                               //weights:[ 1, 1, 3, 3, 5, 4 ]
            //                                                                                                                               //capacity: 54
            //TODO не все тесты проходят (неизвестно что именно не так)
            //int GetFurthestNumber(List<int> cave)
            //{
            //    // Нужен индекс того элемента, проходя с которого до элемента -1 потребуется больше всего steps
            //    // steps++ это если следующий элемент массива отличается от текущего
            //    // Необходимо делать в обе стороны; длинный путь только один

            //    var currentSteps = 0;

            //    var maxStepsFromLeft = 0;
            //    var maxStepsFromRight = 0;

            //    int indexOfSearchedNum = 0;

            //    var indexOfStop = cave.IndexOf(-1);

            //    // Пересчет с левой стороны
            //    for (int i = 0; i <= indexOfStop; i++)
            //    {
            //        currentSteps = 0;
            //        for (int j = i; j <= indexOfStop - 1; j++)
            //        {
            //            if (j != (j + 1))
            //            {
            //                currentSteps++;
            //                if (currentSteps > maxStepsFromLeft)
            //                {
            //                    maxStepsFromLeft = currentSteps;
            //                    indexOfSearchedNum = i;
            //                }
            //            }
            //        }
            //    }

            //    // Пересчет с правой стороны
            //    for (int i = cave.Count - 1; i >= indexOfStop; i--)
            //    {
            //        currentSteps = 0;
            //        for (int j = i; j >= indexOfStop + 1; j--)
            //        {
            //            if (j != (j - 1))
            //            {
            //                currentSteps++;

            //                if (currentSteps > maxStepsFromRight)
            //                {
            //                    maxStepsFromRight = currentSteps;

            //                    if (maxStepsFromRight > maxStepsFromLeft)
            //                    {
            //                        indexOfSearchedNum = i;
            //                    }
            //                }
            //            }
            //        }
            //    }

            //    return indexOfSearchedNum;
            //}

            ////Аргумент
            ////[1, -1, 1, 2]

            ////Ожидаемое значение
            ////3


            ////Дан массив пещерных ходов cave.Значения в массиве указывают номер пещеры, куда из текущей пещеры можно пройти.
            ////Например, cave[2, 2, 1] означает, что пещеры с индексом 0 и 1 пути ведут в пещеру с индексом 2.А из cave[2] можно попасть в cave[1].
            ////Определите индекс пещеры, из которой будет самый длинный путь до элемента массива со значением -1.
            ////Гарантируется, что максимально длинный путь только один.

            //Console.WriteLine(GetFurthestNumber(new List<int> { 1, 2, -1 }));//0
            //Console.WriteLine(GetFurthestNumber(new List<int> { 1, -1, 1, 2 }));//3
            //Console.WriteLine(GetFurthestNumber(new List<int> { -1, 1 }));//1
            //                                                              //Console.WriteLine(GetResult(new List<int> { 1, -1 }));//1



            //TODO не все тесты проходят (неизвестно что именно не так)
            int GetDominantSymbolLength(string s, string symbol)
            {
                var я = "aaa bbb aaaabb aaab ab aaaa bb";

                if (String.IsNullOrEmpty(s))
                    return 0;

                s = Regex.Replace(s, @"\s+", " ");

                string finalString = "";
                string partWithSymbol = "";
                int symbolsCount = 0;

                List<string> allStrings = s.Split(" ").ToList();

                while (allStrings.Any())
                {
                    if (allStrings.Count >= 2)
                    {
                        partWithSymbol = allStrings[0] + symbol + allStrings[1];
                        allStrings.Remove(allStrings[0]);
                        allStrings.Remove(allStrings[0]);
                    }
                    else if (allStrings.Count == 1)
                    {
                        partWithSymbol = symbol + allStrings[0];
                        allStrings.Remove(allStrings[0]);
                    }

                    var countA = 0;
                    var countB = 0;
                    foreach (char c in partWithSymbol)
                    {
                        if (c == 'a')
                            countA++;
                        else if (c == 'b')
                            countB++;
                    }

                    if (countA > countB)
                        partWithSymbol = new string(partWithSymbol.Select(c => c = 'a').ToArray());
                    else if (countB > countA)
                        partWithSymbol = new string(partWithSymbol.Select(c => c = 'b').ToArray());

                    finalString += partWithSymbol;
                }

                symbolsCount = finalString.Count();

                return symbolsCount;
            }


            //var s = "aaa bbb";
            //var symbol = "a";
            //Console.WriteLine(GetResult(s, symbol)); //7

            //var q = "bbbb cc aa";
            //var symbolq = "b";
            //Console.WriteLine(GetDominantSymbolLength(q, symbolq)); //10

            //var stringarr = new char[] { 'a', 'c' };
            //var z = new string(stringarr.Select(c => c = 'a').ToArray());

            //int GetTreasures(List<int> chests, int t)
            //{
            //    // Проассоциировать числа с их индексами
            //    // Упорядочить числа по убыванию
            //    // Для каждого числа: отнять от числа его индекс; разности необходимо проассоциировать 
            //    // Получается 3 ассоциированных массива: найти способ сделать это
            //    // В массиве индексов все числа увеличить на 1, получится массив шагов
            //    // Убрать отовсюду все значения, у которых количество шагов больше чем входящее t
            //    // По убыванию: брать число за бенчмарк; перебирать сложение всех вариаций 
            //    // между меньшими числами И если найдется хоть одна вариация где сумма чисел > бенчмарка И
            //    // сумма шагов этих чисел < шагов бенчмарка - добавляем сумму эти чисел, убираем из массивов 
            //    // эти числа, проверяем есть ли еще такие суммы влезающие в размер t, далее проверяем шаги бенчмарка
            //    // позволяют ли забрать его тоже (если нет - убираем бенчмарк); далее делаем
            //    // бенчмарком меньшее число по сравнению с предыдущим;
            //    // Под конец пишем обработку любых вариаций: одно число, пустой массив и т.д.
            //    //  
            //    // 
            //    //
            //}


            int Search(int[] nums, int target)
            {
                if (!nums.Contains(target))
                    return -1;
                else
                {
                    var x = Array.BinarySearch(nums, target);
                    return x;
                }
            }


            //var left = 0;
            //var right = array.Length - 1;

            //while (left != right)
            //{
            //    var middle = (left + right) / 2;
            //    if (element <= array[middle])
            //    {
            //        right = middle;
            //    }
            //    else
            //    {
            //        left = middle + 1;
            //    }
            //}
            //if (array[right] == element) return right;
            //else return -1;





            //int[] arr = new int[] { -1, 0, 3, 5, 9, 12 }; //target = 9, output 4
            //Console.WriteLine(Search(arr, 9));


            ////================БИНАРНЫЙ ПОИСК=====================
            ////Представляет из себя поиск элемента В ОТСОРТИРОВАННОМ массиве методом сужения
            ////области поиска через разделение текущей области на 2 части, вплоть до "зажатия" 
            ////нужного элемента. Возвращает первое совпадение с левой стороны (со стороны убывания).
            ////Не работает с неотсортированными массивами, поскольку по логике "если меньше среднего - ищем слева" 
            ////мы уйдем влево даже если меньшее число на самом деле правее среднего
            ////Сложность: логарифмическая O(log n)

            //static int BinarySearch(int[] nums, int target)
            //{
            //    //1. Определить крайние точки (индексы) массива для определения есть ли что-либо между ними или искомое уже "зажато"
            //    var left = 0;
            //    var right = nums.Length - 1;

            //    //2. До тех пор пока левая и правая часть не равны (пока есть более одного значения)
            //    while (left <= right)
            //    {
            //        //3. Находим средний индекс в текущем отрезке
            //        var middle = (left + right) / 2;

            //        //4. Если искомое число не равно среднему числу в отрезке - определяем больше или меньше оно среднего
            //        //   Если меньше - текущее среднее число принимает роль правой границы отрезка
            //        //   Если больше - текущее среднее число принимает роль левой границы отрезка
            //        //   При этом граница сдвигается на +/-1, так как с самой границей(т.е. со средним ранее) уже было проведено сравнение
            //        if (target == nums[middle])
            //        {
            //            return middle;
            //        }
            //        else if (target < nums[middle])
            //        {
            //            right = middle - 1;
            //        }
            //        else if (target > nums[middle])
            //        {
            //            left = middle + 1;
            //        }
            //    }

            //    return -1;
            //}
            //var array = new[] { -1, 0, 3, 5, 8, 9, 12 };
            //Console.WriteLine(BinarySearch(array, 9)); //4


            //Dictionary<string, int> substrToLength = new Dictionary<string, int>();

            int LengthOfLongestSubstring(string s)
            {
                // Неоптимизированный но рабочий
                bool IsAllCharsUnique(string s) => s.Distinct().Count() == s.Length;

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

                //for (int i = 0; i < size - 1; i++)
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


            ////================СОРТИРОВКА ПУЗЫРЬКОМ=====================
            ////Алгоритм сортирует массив от меньшего в большему. Проход по массиву совершается несколько раз,
            ////на каждом этапе происходит перемещениев в конец массива самого большого из неотсортированных значений.
            ////На первой итерации мы вытягиваем самое большое число в массиве и ставим его в правый предел
            ////Далее движемся справа налево по массиву:
            ////каждое число "всплывает" перемещаясь в правую сторону до тех пор, пока не упрется в число больше
            ////Сложность: квадратичная O(n^2)
            static void BubbleSort(int[] array)
            {
                ////1. Движемся по массиву справа налево, устанавливая границу:
                //for (int i = array.Length - 1; i > 0; i--)
                //    //2. Слева направо от (текущего числа + 1)  до границы. 
                //    for (int j = 1; j <= i; j++)
                //        //3. Если число левее текущего меньше текущего - меняем их местами
                //        if (array[j - 1] > array[j])
                //        {
                //            int temp = array[j - 1];
                //            array[j - 1] = array[j];
                //            array[j] = temp;
                //        }

                for (int i = array.Length - 1; i > 0; i--)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        if (array[j - 1] > array[j])
                            (array[j - 1], array[j]) = (array[j], array[j - 1]);
                    }
                }
            }
            var array2 = new[] { 54, 24, 3, 7, 7, 5, 21, 6 };
            BubbleSort(array2);
            foreach (var item in array2)
            {
                Console.Write(item + " "); //3 5 6 7 7 21 24 54
            }















        }
    }
}

