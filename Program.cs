// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Xml.Linq;
int[] Arrnum = new int[] { 3, 4, 5, 1, 2 };
int[] ArrNumSum = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
Solution sol = new Solution();
sol.FindMin(Arrnum);
//Console.WriteLine("Hello, World!2");
// Console.WriteLine(isUniqueChar("human"));
if (arePermutation("aaca", "aca"))
    Console.WriteLine("Yes");
else
    Console.WriteLine("No");
compressedString("aaca");


/*string ReverseWords(string s)
  {
  var sb = new List<string>();
}*/

Boolean isUniqueChar(String str)
{ if (str.Length >128)
        return false;
    Boolean[] char_set = new Boolean[128];
    for (int i = 0; i < str.Length; i++)
    {
        if (char_set[str[i]] == true)
        {
            return false;
           

        }
        Console.WriteLine(Convert.ToChar(65));

        char_set[str[i]] = true;
    }
    return true;
}   

bool arePermutation( string str1, string str2)
{
    // Create two count arrays and set the values to zero
    int max_char = 256;
    int[] count1 = new int[max_char];
    int[] count2 = new int[max_char];
    int i;
    for(i=0;i<str1.Length && i<str2.Length;i++)
    {
        count1[str1[i]]++;
        count2[str2[i]]++; 

    }
    if(str1.Length!=str2.Length)
    { return false; }
    for(i=0;i<max_char;i++)
    {
        if (count1[i] != count2[i])
        {
            return false;
        }

    }
    return true;
}

string compressedString(string str)
{
    int[] charArray = new int[256];
    for (int i = 0; i < str.Length; i++)
    {
        charArray[str[i]]++;
    }
    StringBuilder strCompressed = new StringBuilder();
    for (int i = 0; i < str.Length; i++)
    {
        if (charArray[str[i]] >= 0 && !strCompressed.ToString().Contains(str[i]))
        {
            strCompressed.Append(str[i] + charArray[str[i]].ToString());
        }
    }
    Console.WriteLine(strCompressed);

    return strCompressed.ToString();
}


//PracticeLeetcode.LinkedList.linkedlist();
//PracticeLeetcode.ReverseLinkedList.createlinkedlist();
//PracticeLeetcode._StackArray.mainMethod();
//PracticeLeetcode.BinaryTree.main();
//int[] sum = new int[] { -1, 0, 1, 2, -1, -4 };
//int[] sum1 = new int[] { 5, 2, 3, 1 };
//PracticeLeetcode.ArraySum.ThreeSum(sum);
//PracticeLeetcode.quickSort.SortArray(sum1);
int[] heights = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
List<int> prefix = new List<int>() { 5, 1, 4, 2 };
PracticeLeetcode.ArraySum.getPrefixScores(prefix);
PracticeLeetcode.ArraySum.main();
PracticeLeetcode.Matrix.main();
PracticeLeetcode.ArraySum.MaxSubArray(ArrNumSum);
PracticeLeetcode.ArraySum.maxArea(heights);
PracticeLeetcode.Matrix.makeSpiralMatrix();
PracticeLeetcode.MergeOverlappingIntervals.mainMerge();
int[] nums = new int[] { 1, 1,1};
int target = 1;
int output =PracticeLeetcode.DynamicProgramming.findTargetSumWays(nums, target);
Console.WriteLine("There is" + output + " ways for target" + target);

string longestSubString = "pwwkew";
PracticeLeetcode.StringManipulation.LengthOfLongestSubstringOther(longestSubString);
string[] str = new string[]{"eat","tea","tan","ate","nat","bat"};
PracticeLeetcode.StringManipulation.groupAnagram(str);
PracticeLeetcode.IntegerManipulation.Main();
int[] candidates = new int[] { 2, 5, 2, 1, 2 };
PracticeLeetcode.DynamicProgramming.CombinationSum2(candidates, 5);
PracticeLeetcode.DynamicProgramming.CombinationSumTwo(candidates, 5);
PracticeLeetcode.ArraySum.MaxSubArrayBruteForce(Arrnum);
string strdeletion = "aaabbbcc";
PracticeLeetcode.StringManipulation.minDeletion(strdeletion);
string strWordBreak = "code";
List<string> listWordBreak = new List<string>() { "c","od","e","x"};
PracticeLeetcode.DynamicProgramming.wordBreakDP(strWordBreak, listWordBreak);
PracticeLeetcode.StringManipulation.Main();
int[] numsLIS = new int[] { 1,2 };
PracticeLeetcode.DynamicProgramming.longestlenSubsequence(numsLIS);
PracticeLeetcode.Recursion.main();
PracticeLeetcode.DynamicProgramming.main();
PracticeLeetcode.ArraySum.subArrayPrint(candidates);
PracticeLeetcode.StringManipulation.LengthOfLongestSubstring1(longestSubString);
PracticeLeetcode.tiktok.main();








public class Solution
{
    public int FindMin(int[] nums)
    {
        int i = 0;
        int j = nums.Length - 1;
        if (nums[i] > nums[j])
        {
            while (i < j)
            {
                int mid = i + (j - i) / 2;
                if (nums[mid] > nums[j])
                    i = mid + 1;
                else
                    j = mid;
            }
        }
        return nums[i];
    }
    
   
}

