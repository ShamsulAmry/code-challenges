namespace word_break;

public class UnitTests
{
    [Theory]
    [InlineData("leetcode", new[] { "leet", "code" }, true)]
    [InlineData("applepenapple", new[] { "apple", "pen" }, true)]
    [InlineData("catsandog", new[] { "cats", "dog", "sand", "and", "cat" }, false)]
    public void Given_Input_ReturnsOutput(string s, IList<string> wordDict, bool output)
    {
        var solution = new Solution();
        var result = solution.WordBreak(s, wordDict);
        Assert.Equal(output, result);
    }

    [Fact]
    public void TestCase36_ShouldNotExceedTimeLimit()
    {
        var solution = new Solution();
        var s = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab";
        var wordDict = new[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" };

        bool? result = null;
        var thread = new Thread(() => result = solution.WordBreak(s, wordDict));
        thread.Start();
        thread.Join(2000);
        
        if (thread.ThreadState == ThreadState.Running) {
            throw new Exception("Time Limit Exceeded");
        }
        
        Assert.False(result);
    }

    [Fact]
    public void Given_RepeatingCharactersInWordDict_ReturnsOptimized()
    {
        var solution = new Solution();
        var wordDict = new[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" };

        var optimizedWordDict = solution.OptimizeWordDict(wordDict);

        Assert.Equal(new[] { "a" }, optimizedWordDict);
    }
}