using System;
using System.Collections.Generic;

public class Solution
{
    public IList<string> CommonChars(string[] words)
    {
        List<string> result = new List<string>();

        // Base case: if no words are given, return an empty list
        if (words.Length == 0) return result;

        // Initialize frequency dictionary for the first word
        int[] minFreq = new int[26];
        foreach (char c in words[0])
        {
            minFreq[c - 'a']++;
        }

        // Update the frequency dictionary based on the rest of the words
        for (int i = 1; i < words.Length; i++)
        {
            int[] charCount = new int[26];

            foreach (char c in words[i])
            {
                charCount[c - 'a']++;
            }

            for (int j = 0; j < 26; j++)
            {
                minFreq[j] = Math.Min(minFreq[j], charCount[j]);
            }
        }

        // Create the result list based on the minFreq array
        for (int i = 0; i < 26; i++)
        {
            for (int k = 0; k < minFreq[i]; k++)
            {
                result.Add(((char)(i + 'a')).ToString());
            }
        }

        return result;
    }

    static void Main(string[] args)
    {
        Solution solution = new Solution();

        string[] words1 = { "bella", "label", "roller" };
        IList<string> result1 = solution.CommonChars(words1);
        Console.WriteLine(string.Join(",", result1)); // Output: ["e","l","l"]

        string[] words2 = { "cool", "lock", "cook" };
        IList<string> result2 = solution.CommonChars(words2);
        Console.WriteLine(string.Join(",", result2)); // Output: ["c","o"]
    }
}
