using System;
namespace PracticeLeetcode
{
    public static class StringManipulation
    {
        //without any repeating character
        public static int LengthOfLongestSubstring(string s)
        {
            HashSet<char> countChar = new HashSet<char>();
            int result = 0;
            int l = 0;
            for (int r = 0; r < s.Length; r++)
            {

                if (!countChar.Contains(s[r]))
                {
                    countChar.Add(s[r]);
                    result = Math.Max(result, r - l + 1);
                }
                else
                {
                    while (countChar.Contains(s[r]))
                    {
                        countChar.Remove(s[l]);
                        l++;
                    }
                    countChar.Add(s[r]);


                }



            }
            return result;

        }

        //Other way to find the longest substring
        public static int LengthOfLongestSubstringOther(string s)
        {
            var charSet = new HashSet<char>();
            int left = 0, right = 0, maxLength = 0;
            while (right < s.Length)
            {
                if (!charSet.Contains(s[right]))
                {
                    charSet.Add(s[right]);
                    right++;
                    maxLength = Math.Max(maxLength, charSet.Count);
                }
                else
                {
                    charSet.Remove(s[left]);
                    left++;
                }
            }
            return maxLength;
        }
        //string "abcabcbb"
        public static int LengthOfLongestSubstring1(string s)
        {
            HashSet<char> hash = new HashSet<char>();
            int l = 0;
            int r = 0;
            int count = 0;
            while (r < s.Length)
            {
                if (!hash.Contains(s[r]))
                {
                    hash.Add(s[r]);

                    count = Math.Max(count, r - l + 1);
                    r++;
                }
                else
                {
                    while (hash.Contains(s[r]))
                    {
                        hash.Remove(s[l]);
                        l++;
                    }
                    hash.Add(s[r]);
                    r++;
                }

            }
            return count;
        }

        public static IList<IList<string>> groupAnagram(string[] str)
        {
            Dictionary<string, IList<string>> dict = new();
            foreach (string s in str)
            {
                var charArray = s.ToCharArray();
                Array.Sort(charArray);
                String newstr = new string(charArray);
                if (!dict.ContainsKey(newstr))
                {
                    dict.Add(newstr, new List<string>());
                }
                dict[newstr].Add(s);

            }
            return new List<IList<string>>(dict.Values);
        }

        public static void PrintAllSubstring(string s)
        {


            string newString = String.Empty;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    //Print All subarrays   
                    // Console.WriteLine(s.Substring(i,j-i+1));
                    for (int k = i; k <= j; k++)
                    {
                        Console.Write(s[k]);

                    }
                    Console.WriteLine();

                }


            }



        }

        // Minimum Deletions to Make Character Frequencies Unique Problem
        public static int minDeletion(string s)
        {
            int deletion = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();
             HashSet<int> used_freq = new HashSet<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]]++;

                }
                else
                {
                    dict.Add(s[i], 1);
                }
            }
            foreach (int freqReadOnly in dict.Values)
            {
                int freq = freqReadOnly;
                while (freq > 0 && used_freq.Contains(freq))
                {
                    freq--;
                    deletion++;
                }
                used_freq.Add(freq);
            }
            return deletion;
        }
        //Print subsequence of a string
        static void printSubsequence(string input, string output)
        {
            //BaseCase
            if (input.Length == 0)
            {
                Console.WriteLine(output);
                return;

            }
            //include character
            printSubsequence(input.Substring(1), output + input[0]);
            //not include character
            printSubsequence(input.Substring(1), output);

        }

        //Driver Code

        public static void Main()
        {
            string output = "";
            string input = "abc";
            printSubsequence(input, output);
            // string minWindowString =  MinWindow("ADOBECODEBANC", "ABC");
            string minWindowString = MinWindow("aa", "aa");
            IsAnagram("rat", "car");
            minTime("zjpc");
            CountVowelStrings(2);
        }

        //76. Minimum Window Substring

        public static string MinWindow(string s, string t)
        {
            if (t == "")
                return string.Empty;
            if (t == s)
            { return t; }
            Dictionary<char, int> sDict = new Dictionary<char, int>();
            Dictionary<char, int> tDict = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                AddToDictionary(tDict, t[i]);
            }
            int have = 0;
            int need = t.Length;
            int l = 0;
            int[] res = new[] { -1, -1 };
            int minResLength = int.MaxValue;
            for (int r = 0; r < s.Length; r++)
            {

                char c = s[r];
                AddToDictionary(sDict, c);
                if (tDict.ContainsKey(c) && tDict[c] == sDict[c])
                {
                    have++;
                }
                while (have == need)
                {
                    if (r - l + 1 < minResLength)
                    {
                        res = new[] { l, r };
                        minResLength = r - l + 1;
                    }

                    //pop characters from start now as we got our first solution
                    sDict[s[l]]--;
                    if (tDict.ContainsKey(s[l]) && sDict[s[l]] < tDict[s[l]])
                    {
                        have--;
                    }
                    l++;
                }




            }

            return (minResLength == int.MaxValue) ? string.Empty : s.Substring(res[0], res[1] - res[0] + 1);

        }

        static void AddToDictionary(Dictionary<char, int> dict, char c)
        {
            if (dict.ContainsKey(c))
            {
                dict[c]++;
            }
            else
                dict.Add(c, 1);
        }

        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            Dictionary<char, int> sDict = new Dictionary<char, int>();
            Dictionary<char, int> tDict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                AddToDictionary(sDict, s[i]);
                AddToDictionary(tDict, t[i]);
            }
            foreach (var keyValue in sDict)
            {
                if (tDict.ContainsKey(keyValue.Key))
                {
                    if (tDict[keyValue.Key] != keyValue.Value)
                        return false;

                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        // Function to calculate minimum time to
        // print all the circular characters in the string https://www.geeksforgeeks.org/minimum-time-required-to-print-given-string-from-a-circular-container-based-on-given-conditions/
        static void minTime(string word)
        {

            int ans = 0;
            //current element where pointer is pointing
            int curr = 0;
            for (int i = 0; i < word.Length; i++)
            {
                //Find index of word elements 
                int k = word[i] - 97;  //if caps letter then minus with 65
                //calculate difference between pointer index and current index
                int a = Math.Abs(k - curr);
                // calculate counterclock wise distance .For example z is 1 index apart from a as this this circular and z is in clockwise distance is 25
                //so we take counterclockwise diff
                int b = 26 - Math.Abs(curr - k);
                //take min
                ans += Math.Min(a, b);
                //set the pointer
                curr = k;


            }
            Console.Write(ans);

        }



        //Vowel Count
        public static int CountVowelStrings(int n)
        {
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            return dfs(2, 0);
            int dfs(int n, int last)
            {
                if (n == 0)
                { return 1; }
                else
                {
                    int ans = 0;
                    foreach (char vowel in vowels)
                    {
                        if (last <= vowel)
                        {
                            ans += dfs(n - 1, vowel);

                        }
                    }

                    return ans;
                }
            }
        }

    }
}



