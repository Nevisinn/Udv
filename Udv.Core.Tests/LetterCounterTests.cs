using Udv.Core.Services;

namespace Udv.Core.Tests;

public class LetterCounterTests
{
    private readonly LetterCounter counter = new();
    
    [Fact]
    public void SymbolsAndDigits()
    {
        var result = counter.GetSimilarLettersCount("123!@#");
        Assert.True(result.IsSuccess);
        Assert.Empty(result.Value);
    }
    
    [Fact]
    public void EmptyInputData()
    {
        var result = counter.GetSimilarLettersCount("");
        Assert.True(result.IsSuccess);
        Assert.Empty(result.Value);
    }
    
    [Fact]
    public void UpperAndLowerLetters()
    {
        var result = counter.GetSimilarLettersCount("BbBb");
        Assert.True(result.IsSuccess);
        Assert.Equal(4, result.Value['b']);
    }
    
    [Fact]
    public void AllUniqLetters()
    {
        var result = counter.GetSimilarLettersCount("abcD");
        Assert.True(result.IsSuccess);
        Assert.Equal(1, result.Value['a']);
        Assert.Equal(1, result.Value['b']);
        Assert.Equal(1, result.Value['c']);
        Assert.Equal(1, result.Value['d']);
    }
    
    [Fact]
    public void SortOnlyRussianLetters()
    {
        var result = counter.GetSimilarLettersCount("яюа");
        Assert.True(result.IsSuccess);
        var expectedOrder = new List<char> { 'а', 'ю', 'я' };
        var actualOrder = new List<char>(result.Value.Keys);
        Assert.Equal(expectedOrder, actualOrder);
    }
    
    [Fact]
    public void SortOnlyEnglishLetters()
    {
        var result = counter.GetSimilarLettersCount("zya");
        Assert.True(result.IsSuccess);
        var expectedOrder = new List<char> { 'a', 'y', 'z'};
        var actualOrder = new List<char>(result.Value.Keys);
        Assert.Equal(expectedOrder, actualOrder);
    }
}