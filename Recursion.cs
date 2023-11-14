using System;
namespace PracticeLeetcode
{
	public class Recursion
	{
		public static void main()
			{
				List<int> order = new List<int>()
				{ 2,10,30};
				int widgetNo = 40;
			    int count = filledOrder(order, widgetNo);
				Console.WriteLine("No of Maximum order filled", count);
			int[] nums = new int[] { 1, 2, 3 };
			Subsets(nums);
			}
		public	 static int filledOrder(List<int> order, int k)
			{
				int count = 0;
				Array.Sort(order.ToArray());
				int target = k;
				for (int i=0; i<order.Count; i++)
				{
                List<int> list = new List<int>();
                count = Math.Max(count, dfs(i, target,list));
				}

				int dfs(int i, int target,List<int> list)
				{
					
					//base case
					if(target==0)
					{
						return list.Count;
					}
					if(i<order.Count && target >= order[i])
					{
						list.Add(order[i]);
						dfs(i + 1, target - order[i],list);
					}
					else
					{
						while (i<order.Count && target < order[i])
						{
							i++;
						}
						if(i<order.Count)
						{
							list.Add(order[i]);
							dfs(i + 1, target = order[i],list);
						}
						else
						{
							return list.Count;
						}
					}
					return list.Count;
				}
				return count;
			}
        //https://leetcode.com/problems/subsets/
        public static IList<IList<int>> Subsets(int[] nums)
		{
			List<IList<int>> list = new List<IList<int>>();
			List<int> sublist = new List<int>();
			 dfsSubset(nums, list, sublist, 0);
			return list;

		}
		static void dfsSubset(int[] nums, List<IList<int>> list, List<int> sublist, int i)
		{
			// base case
			if(i>=nums.Length)
			{
				List<int> clonedList = new List<int>(sublist);
				list.Add(clonedList);
				return;
			}
			//include nums[i]
			sublist.Add(nums[i]);
			dfsSubset(nums, list, sublist, i + 1);
			//exclude logic
			sublist.RemoveAt(sublist.Count - 1);
			dfsSubset(nums, list, sublist, i + 1);
		}
        }
	}


