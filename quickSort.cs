using System;
namespace PracticeLeetcode
{
	public class quickSort
	{
        public quickSort()
        {
        }
            public static int[] SortArray(int[] nums)
            {
                QuickSort(nums, 0, nums.Length - 1);
                return nums;
            }

            public static void QuickSort(int[] nums, int startIndex, int endIndex)
            {
                //baseCase array with zero or 1 element
                if (startIndex >= endIndex)
                { return; }
                //divide the array into two smaller arrays
                int pivotIndex = partition(nums, startIndex, endIndex);

                //recursively sort each sub array
                QuickSort(nums, startIndex, pivotIndex - 1);
                QuickSort(nums, pivotIndex + 1, endIndex);

            }

            private static int partition(int[] nums, int startIndex, int endIndex)
            {
                int pivot = nums[endIndex];
                int l = startIndex;
                int r = endIndex - 1;

                while (l<r)
                {
                while(l<r && nums[l]<pivot)
                {
                    l++;
                }
                while(l<r&& nums[r]>pivot)
                { r--;
                }
                 if(nums[l]>nums[r])
                {
                    swap(nums, l, r);
                        }


                }
            if (nums[l] > pivot)
            {
                swap(nums, l, endIndex);
            }

                return l;
            }
            private static void swap(int[] nums, int l, int r)
            {
                int temp = nums[r];
                nums[r] = nums[l];
                nums[l] = temp;
            }
        }
	}


