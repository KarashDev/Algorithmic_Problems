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


			// Хорошее решение: ПРЕОБРАЗОВАТЬ ОДНО В ДРУГОЕ МОЖНО С ПОМОЩЬЮ SELECT, НЕ НАДО НИЧЕГО ВЫДУМЫВАТЬ;
			// Также можно было решить через Dictionary
			static string AlphabetPosition(string text)
			{
				return string.Join(" ", text.ToLower().Where(c => char.IsLetter(c))
													  .Select(c => "abcdefghijklmnopqrstuvwxyz".IndexOf(c) + 1)
													  .ToArray());
				//или
				return string.Join(" ", text.ToLower().Where(c => char.IsLetter(c)).Select(c => c - 'a' + 1));

			}

			Assert.AreEqual("20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11", 
				AlphabetPosition("The sunset sets at twelve o' clock."));












		}
	}
}
