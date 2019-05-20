using System;

namespace ParallelMergeSort
{
	public static class MergeSort<T> where T : IComparable
	{
		public static void Sort(T[] arr)
		{
			Sort(arr, 0, arr.Length - 1);
		}

		private static void Sort(T[] arr, int startIndex, int endIndex)
		{
			if (startIndex >= endIndex)
			{
				return;
			}

			//Get index of the middle element
			int middleIndex = (startIndex + endIndex) / 2;

			//Sort left portion of the array
			Sort(arr, startIndex, middleIndex);

			//Sort right portion of the array
			Sort(arr, middleIndex + 1, endIndex);

			//Merge left and right portion of the array
			Merge(arr, startIndex, middleIndex, endIndex);
		}

		private static void Merge(T[] arr, int startIndex, int middleIndex, int endIndex)
		{
			if (middleIndex < 0 || middleIndex + 1 >= arr.Length || arr[middleIndex].CompareTo(arr[middleIndex + 1]) <= 0)
			{
				return;
			}

			T[] helperArray = new T[arr.Length];

			for (int i = startIndex; i <= endIndex; i++)
			{
				helperArray[i] = arr[i];
			}

			//Start index of the first portion of the array
			int leftIndex = startIndex;
			//Start index of the second portion of the array
			int rightIndex = middleIndex + 1;

			for (int i = startIndex; i <= endIndex; i++)
			{
				if (leftIndex > middleIndex)
				{
					arr[i] = helperArray[rightIndex++];
				}
				else if (rightIndex > endIndex)
				{
					arr[i] = helperArray[leftIndex++];
				}
				else if (helperArray[leftIndex].CompareTo(helperArray[rightIndex]) <= 0)
				{
					arr[i] = helperArray[leftIndex++];
				}
				else
				{
					arr[i] = helperArray[rightIndex++];
				}
			}
		}
	}
}
