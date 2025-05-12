using Udv.Core.Interfaces;
using Udv.Core.Models;

namespace Udv.Core.Services;

public class LetterCounter : ILetterCounter
{
    public Result<SortedDictionary<char, int>> GetSimilarLettersCount(string text)
    {
        var lettersCounter = new SortedDictionary<char, int>();
        text = text.ToLower();
        foreach (var c in text)
        {
            if (!char.IsLetter(c))
                continue;

            lettersCounter.TryAdd(c, 0);
            lettersCounter[c] += 1;
        }
        
        return Result.Ok(lettersCounter);
    }
}