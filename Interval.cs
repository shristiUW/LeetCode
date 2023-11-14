using System;
using System.Linq;

namespace PracticeLeetcode
{
	public class Interval
	{
		public Interval()
		{
		}
			public int start, end;

		public Interval(int start, int end)
		{
			this.start = start;
			this.end = end;
		}

		
	}

	public class MergeOverlappingIntervals
	{
		public static void MergeIntervals(Interval[] arr)
		{
			//sort the interval in increasing order of start time
			arr = arr.OrderBy(x => x.start).ToArray();
			//Traverse all input Intervals
			int index = 0;
			for (int i = 1; i < arr.Length; i++)
			{
				if (arr[index].end >= arr[i].start)
				{
					arr[index].end = Math.Max(arr[i].end, arr[index].end);
				}
				else
				{
					index++;
					arr[index] = arr[i];
				}
			}
			//Merge Intervals
			Console.WriteLine("The Merge Intervals are: ");
			for (int i = 0; i <= index; i++)
			{
				Console.WriteLine("[" + arr[i].start + "," + arr[i].end + "]");
			}

		}
		public static void mainMerge()
		{
			Interval[] arr = new Interval[4];

			arr[0] = new Interval(9, 11);
			arr[1] = new Interval(1, 7);
			arr[2] = new Interval(8, 10);
			arr[3] = new Interval(4, 7);
			MergeIntervals(arr);

			//interval as array
			List<List<int>> listIntervals = new List<List<int>>() { new List<int>() { 1, 3 }, new List<int>() { 6, 9 } };

			List<int> newInterval = new List<int>() { 4, 7 };

			NewInterval(listIntervals, newInterval);
			List<List<int>> mergeList = new() { new List<int>() { 1, 3 }, new List<int>() { 2, 6 }, new List<int>() { 8, 10 }, new List<int>() { 15, 18 } };
			MergeIntervalUsingList(mergeList);
			int[][] eraseInterval = new int[][] { new int[] { 1, 100 }, new int[] { 11, 22 }, new int[] { 1, 11 }, new int[] { 2, 12} };
			EraseOverlapIntervals(eraseInterval);

        }
	

        //Insert new Interval-https://leetcode.com/problems/insert-interval/description/
        static List<List<int>> NewInterval (List<List<int>> intervals, List<int> newInterval)
		{
			List<List<int>> output = new List<List<int>>();
			for(int i=0; i<intervals.Count; i++)
			{
				if (newInterval[1]< intervals[i][0])
				{
					output.Add(newInterval);
					output.AddRange(intervals);
					return output;
				}
				else if (newInterval[0] > intervals	[i][1])
				{
					output.Add(intervals[i]);
				}
				else
				{
					newInterval[0] = Math.Min(intervals[i][0], newInterval[0]);
					newInterval[1]=Math.Max(intervals[i][1],newInterval[1]);
				}
			}
			output.Add(newInterval);
			return output;

		}

        //Merge Interval using List-https://leetcode.com/problems/merge-intervals/
		static List<List<int>> MergeIntervalUsingList(List<List<int>> intervals)
		{
			List<List<int>> output = new List<List<int>>();
			intervals.OrderBy(x => x[0]).ToList();
			
			output.Add(intervals[0]);
			for(int i=1;i<intervals.Count; i++)
			{
				if (output[output.Count-1][1]>intervals[i][0])
				{
					output[output.Count-1][1] = Math.Max(output[output.Count-1][1], intervals[i][1]);
					//output[output.Count-1][0] = Math.Min(output[output.Count-1][0], intervals[i][0]);
				}
				else
				{
					output.Add(intervals[i]);
				}
			}
			return output;

		}

        static public int EraseOverlapIntervals(int[][] intervals)
        {
            intervals = intervals.OrderBy(x => x[0]).ToArray();
            int counter = 0;
            List<int[]> list = new List<int[]>();
            list.Add(intervals[0]);
            for (int i = 1; i < intervals.Length; i++)
            {
                if (list[list.Count - 1][1] > intervals[i][0])
                {
                    counter++;
					if (list[list.Count - 1][1] > intervals[i][1])
					{
						list.Remove(list[list.Count - 1]);
						list.Add(intervals[i]);
					}
                    //list.Add(intervals[i]);
                }
                else
                {
                    list.Add(intervals[i]);
                }
            }
            return counter;
        }
    }

}



