using Udv.Core.Models;

namespace Udv.Core.Interfaces;

public interface ILetterCounter
{
    public Result<SortedDictionary<char, int>> GetSimilarLettersCount(string text);
}