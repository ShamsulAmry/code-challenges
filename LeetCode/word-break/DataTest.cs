namespace word_break;

public class DataTest
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
}