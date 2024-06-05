# Intuition
The intuition behind solving this problem is to find the characters that appear in all words of the given array. To do this, we can track the frequency of each character in every word and identify the minimum frequency for each character that appears across all words. This will help us determine the common characters including their duplicates.

# Approach


1. Initialize Frequency Array:

Create an array minFreq to store the minimum frequency of each character across all words. Initialize it based on the first word.

2. Update Frequencies:

For each subsequent word, count the frequency of each character and update minFreq to reflect the minimum frequency found so far.

3. Construct Result:

Convert the minFreq array into a list of characters, including duplicates, and return it as the result.
# Complexity
- Time Complexity:
The time complexity is O(N⋅M) where N is the number of words and M is the average length of the words. This is because we are processing each character of every word.
- Space Complexity:
The space complexity is O(1) because the size of the minFreq array is constant (26 for each letter of the alphabet). Even though we use additional space to store the character counts for each word, this space is proportional to the size of the alphabet, making it constant.

# Code
```
public class Solution {
    public IList<string> CommonChars(string[] words) {
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
}
```
