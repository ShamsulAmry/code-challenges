using FluentAssertions;

namespace word_break;

public class UnitTests
{
    [Theory]
    [InlineData("leetcode", new[] { "leet", "code" }, true)]
    [InlineData("applepenapple", new[] { "apple", "pen" }, true)]
    [InlineData("catsandog", new[] { "cats", "dog", "sand", "and", "cat" }, false)]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", new[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" }, false)]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new[] { "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa", "ba" }, false)]
    public void Given_Input_ReturnsOutput(string s, IList<string> wordDict, bool output)
    {
        var solution = new Solution();
        var result = solution.WordBreak(s, wordDict);
        result.Should().Be(output);
    }

    [Theory]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", new[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" })]
    [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new[] { "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa", "ba" })]
    public void Given_Input_ShouldNotExceedTimeLimit(string s, IList<string> wordDict)
    {
        var solution = new Solution();
        bool? result = null;
        var thread = new Thread(() => result = solution.WordBreak(s, wordDict));
        
        thread.Start();
        thread.Join(2000);

        thread.ThreadState.Should().NotBe(ThreadState.Running);
    }

    [Theory]
    [InlineData(new[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" }, new[] {"a"})]
    [InlineData(new[] { "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa", "ba" }, new[] {"aa", "aaa", "ba"})]
    public void Given_RepeatingCharactersInWordDict_ReturnsOptimized(IList<string> wordDict, IList<string> optimizedWordDict)
    {
        var solution = new Solution();
        var result = solution.OptimizeWordDict(wordDict);
        result.Should().BeEquivalentTo(optimizedWordDict);
    }
}