using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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




            string Encrypt(string inputStr, int n)
            {
                if (String.IsNullOrEmpty(inputStr) || n <= 0)
                    return inputStr;

                string encryptedStr = "";

                for (int repeats = 0; repeats < n; repeats++)
                {
                    if (repeats >= 1)
                    {
                        inputStr = encryptedStr;
                        encryptedStr = "";
                    }

                    for (int i = 1; i < inputStr.Length; i += 2)
                    {
                        encryptedStr += inputStr[i];
                    }

                    for (int i = 0; i < inputStr.Length; i += 2)
                    {
                        encryptedStr += inputStr[i];
                    }
                }

                return encryptedStr;
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

                    for (int i = 0; i < encryptedText.Length/2; i++)
                    {
                        oddIndexedChars += encryptedText[i];
                    }
                    for (int i = encryptedText.Length/2; i < encryptedText.Length; i++)
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
            }

            //Console.WriteLine(Encrypt("This is a test!", 0));
            //Console.WriteLine(Encrypt("This is a test!", 1));
            //Console.WriteLine(Encrypt("This is a test!", 2));
            //Console.WriteLine(Encrypt("This is a test!", 3));
            //Console.WriteLine();
            //Console.WriteLine(Decrypt("This is a test!", 0));
            Console.WriteLine(Decrypt("hsi  etTi sats!", 1));
            Console.WriteLine(Decrypt("s eT ashi tist!", 2));
            Console.WriteLine(Decrypt(" Tah itse sits!", 3));
            Console.WriteLine(Decrypt("hskt svr neetn!Ti aai eyitrsig", 1));










        }
    }
}

