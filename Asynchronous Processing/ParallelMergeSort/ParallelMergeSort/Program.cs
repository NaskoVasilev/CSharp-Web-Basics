using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ParallelMergeSort
{
	class Program
	{
		static void Main(string[] args)
		{
			// Statistics for int[] with 240 000 elementss
			// MergeSort<int>.Sort(arr); -> 00:00:24.9471281
			// new MergeSortHelper<int>().Sort(arr); -> 00:00:00.2677476
			// new MergeSortHelper<int>().SortParallel(arr); -> 00:00:00.1520289

			string numbers = File.ReadAllText("../../../numbers.txt");
			int[] arr = numbers.Split(", ")
				.Select(int.Parse)
				.ToArray();

			Console.WriteLine("Number of elements: " + arr.Length);

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			//MergeSort<int>.Sort(arr);
			//new MergeSortHelper<int>().Sort(arr);
			new MergeSortHelper<int>().SortParallel(arr);
			Console.WriteLine(stopwatch.Elapsed);

			bool isSort = true;

			for (int i = 0; i < arr.Length - 1; i++)
			{
				if(arr[i] > arr[i + 1])
				{
					isSort = false;
				}
			}

			Console.WriteLine(isSort);
		}
	}
}

