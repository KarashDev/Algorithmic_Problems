using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Algorithmic_Problems_Sharp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello Algos!");
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
			int v = 0;


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

			//    for (long i = m; i <= n; i++)
			//    {
			//        divisors = GetDivisors(i);

			//        if (divisors.Count != 2)
			//        {
			//            divisorsSquared = divisors.Select(d => Math.Pow(d, 2)).ToList();
			//            double sumOfDivisors = divisorsSquared.Sum();

			//            if (Math.Sqrt(sumOfDivisors) % 1 == 0)
			//            {
			//                long[] outputArr = new long[] { i, (long)sumOfDivisors };

			//                Array.Resize(ref outputArrays, outputArrays.Length + 1);
			//                outputArrays[outputArrays.Length - 1] = outputArr;
			//            }
			//        }
			//    }

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





		}
	}
}

