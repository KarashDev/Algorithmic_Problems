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

            long NextBiggerNumber(long n)
            {
                var inputChars = n.ToString().ToCharArray();
                long nextBiggerNum = 0;
                bool isAlreadyFound = false;

                nextBiggerNum = GetPermutations(inputChars, 0, inputChars.Length - 1);

                long GetPermutations(char[] chars, int start, int end)
                {
                    long nextBiggerNum = -1;
                    long nextBiggerNumMin = Convert.ToInt64(new string(chars));

                    if (start == end)
                    {
                        var result = Convert.ToInt64(new string(chars));

                        if (result > n)
                        {
                            if (result < nextBiggerNum)
                                nextBiggerNumMin = result;

                            nextBiggerNum = result;
                            return nextBiggerNum;
                        }
                    }
                    else
                    {
                        // Фиксация первого найденного числа; далее если вдруг окажется меньше - обновить его
                        for (int i = start; i <= end; i++)
                        {
                            (chars[i], chars[start]) = (chars[start], chars[i]);

                            if (nextBiggerNum != -1 && nextBiggerNum > nextBiggerNumMin)
                                isAlreadyFound = true;

                            if (!isAlreadyFound)
                            {
                                nextBiggerNum = GetPermutations(chars, start + 1, end);
                                (chars[start], chars[i]) = (chars[i], chars[start]);
                            }
                        }
                    }
                    return nextBiggerNum;
                }

                return nextBiggerNum;



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
            }


            //12 ==> 21
            //513 ==> 531
            //2017 ==> 2071

            //9 ==> -1
            //111 ==> -1
            //531 ==> -1


            //Console.WriteLine(NextBiggerNumber(12));
            Console.WriteLine(NextBiggerNumber(144)); //должно 414 но выводит 441
            //Console.WriteLine(NextBiggerNumber(513));
            //Console.WriteLine(NextBiggerNumber(2017));
            //Console.WriteLine(NextBiggerNumber(531));
            //Console.WriteLine(NextBiggerNumber(111));
            //Console.WriteLine(NextBiggerNumber(13044));
            //Console.WriteLine(NextBiggerNumber(1234567890)); // 890 -- 809 -- 890 -- 980
            //Console.WriteLine(NextBiggerNumber(1234567890)); // 908

            //  Expected: 1234567908
            //  But was:  1234567980

            //  Expected: 1665162768
            //  But was:  1665162867


            //List<string> SinglePermutations(string s)
            //{
            //    List<string> variations = new List<string>();
            //    var chars = s.ToCharArray();

            //    GetPer(chars, 0, chars.Length - 1);

            //    void GetPer(char[] list, int start, int end)
            //    {
            //        if (start == end)
            //        {
            //            if (!variations.Contains(new string(list)))
            //                variations.Add(new string(list));
            //        }
            //        else
            //            for (int i = start; i <= end; i++)
            //            {
            //                (list[start], list[i]) = (list[i], list[start]);
            //                GetPer(list, start + 1, end);
            //                (list[start], list[i]) = (list[i], list[start]);
            //            }
            //    }

            //    return variations;
            //}


            //var x = SinglePermutations("12345670");

            //foreach (var variation in x)
            //    Console.WriteLine(variation);

        }
    }
}
