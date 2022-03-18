using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using Tests_Sharp;

namespace Benchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    public class AlgosBenchmark
    {
        private readonly int[] arrCase1 = new int[] { 20, 20, 19, 16, 10, 0 };
        private readonly int[] arrCase2 = new int[] { 21, 20, 18, 15, 11, 6, 0 };

        

        Tests tests = new Tests();

        public int[] PartsSumsSlow(int[] ls)
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

        public int[] PartsSumsFast(int[] ls)
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


        private long long1 = 48, long2 = 50;
        private long long3 = 8983, long4 = 13355;
        private long long5 = 2382, long6 = 3679;

        public long GetSumOfDivisors(long num)
        {
            // SLOW VARIANT
            //long sum = 0;

            //for (int i = 1; i < num; i++)
            //{
            //    if (num % i == 0)
            //        sum += i;
            //}

            //return sum;

            // FAST VARIANT
            long result = 0;

            for (long i = 2; i <= Math.Sqrt(num); i++)
            {

                if (num % i == 0)
                {

                    
                    if (i == (num / i))
                        result += i;
                    else
                        result += (i + num / i);
                }
            }
            
            return (result + 1);
        }

        public string BuddyPairsSlow(long start, long limit)
        {
            Dictionary<long?, long> numberToDivSum = new Dictionary<long?, long>();
            long firstBuddy = 0, secondBuddy = 0;

            for (long i = start; i <= limit; i++)
            {
                var sumOfDivForCurrentI = GetSumOfDivisors(i);

                if (sumOfDivForCurrentI > i)
                    numberToDivSum.Add(i, GetSumOfDivisors(i));
            }

            for (int i = 0; i < numberToDivSum.Count; i++)
            {
                var currentPair = numberToDivSum.ElementAt(i);

                var supposedBuddy = currentPair.Value - 1;
                var sumOfDivForSupposedBuddy = GetSumOfDivisors(supposedBuddy);

                if (sumOfDivForSupposedBuddy - 1 == currentPair.Key)
                {
                    firstBuddy = (long)currentPair.Key;
                    secondBuddy = (long)supposedBuddy;
                    break;
                }
            }

            if (firstBuddy != 0 && secondBuddy != 0)
                return $"({firstBuddy} {secondBuddy})";
            else return "Nothing";
        }

        public string BuddyPairsFaster(long start, long limit)
        {
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


        //[Benchmark]
        //public void TestPartsSumsSlow()
        //{
        //    var testCaseSlow1 = PartsSumsSlow(arrCase1);
        //    var testCaseSlow2 = PartsSumsSlow(arrCase2);
        //}

        //[Benchmark]
        //public void TestPartsSumsFast()
        //{
        //    var testCaseFast1 = PartsSumsFast(arrCase1);
        //    var testCaseFast2 = PartsSumsFast(arrCase2);
        //}

        [Benchmark]
        public void TestBuddyPairsSlow1()
        {
            var testCaseSlow1 = BuddyPairsSlow(long1, long2);
            //var testCaseSlow2 = BuddyPairsSlow(long3, long4);
            //var testCaseSlow3 = BuddyPairsSlow(long5, long6);
        }

        [Benchmark]
        public void TestBuddyPairsFaster1()
        {
            var testCaseFast1 = BuddyPairsFaster(long1, long2);
            //var testCaseFast2 = BuddyPairsFaster(long3, long4);
            //var testCaseFast3 = BuddyPairsFaster(long5, long6);
        }

        [Benchmark]
        public void TestBuddyPairsSlow2()
        {
            //var testCaseSlow1 = BuddyPairsSlow(long1, long2);
            var testCaseSlow2 = BuddyPairsSlow(long3, long4);
            //var testCaseSlow3 = BuddyPairsSlow(long5, long6);
        }
        
        [Benchmark]
        public void TestBuddyPairsFaster2()
        {
            //var testCaseFast1 = BuddyPairsFaster(long1, long2);
            var testCaseFast2 = BuddyPairsFaster(long3, long4);
            //var testCaseFast3 = BuddyPairsFaster(long5, long6);
        }



    }
}
