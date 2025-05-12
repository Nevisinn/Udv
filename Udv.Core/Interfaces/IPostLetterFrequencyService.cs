using Udv.Core.Models;
using Udv.Core.Models.DTO;

namespace Udv.Core.Interfaces;

public interface IPostLetterFrequencyService
{
    public Task<Result<GetSimilarLettersInFivePostResponse>> CountLetterFrequencyInPost(int postCount);
}