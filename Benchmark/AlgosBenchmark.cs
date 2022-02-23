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

		[Benchmark]
		public void TestPartsSumsSlow()
		{
			var testCaseSlow1 = PartsSumsSlow(arrCase1);
			var testCaseSlow2 = PartsSumsSlow(arrCase2);
		}

		[Benchmark]
		public void TestPartsSumsFast()
		{
			var testCaseFast1 = PartsSumsFast(arrCase1);
			var testCaseFast2 = PartsSumsFast(arrCase2);
		}




	}
}
