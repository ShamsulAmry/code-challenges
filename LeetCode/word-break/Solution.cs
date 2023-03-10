/// <summary>
/// <see href="https://leetcode.com/problems/word-break/description/">
///     LeetCode Problem 139: Word Break
/// </see>
/// </summary>
public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        wordDict = OptimizeWordDict(wordDict);
        return TestPhrase(s, wordDict);
    }

    bool TestPhrase(string s, IList<string> wordDict, string phrase = "")
    {
        if (phrase.Length < s.Length) {
            if (!s.StartsWith(phrase)) {
                return false;
            }
        } else if (phrase.Length == s.Length) {
            return phrase == s;
        } else {
            return false;
        }

        foreach (var word in wordDict) {
            var longerPhrase = phrase + word;
            if (TestPhrase(s, wordDict, longerPhrase)) {
                return true;
            }
        }

        return false;
    }

    public IList<string> OptimizeWordDict(IList<string> wordDict)
    {
        var sortedWords = wordDict.OrderBy(x => x.Length).ToList();

        for (var i = sortedWords.Count - 1; i >= 0; i--) {
            var s = sortedWords[i];
            if (TestPhrase(s, sortedWords.Take(i).ToArray())) {
                sortedWords.RemoveAt(i);
            }
        }

        return sortedWords.OrderByDescending(x => x.Length).ToArray();
    }
}