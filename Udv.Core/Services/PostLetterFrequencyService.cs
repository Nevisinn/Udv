using Udv.Core.Interfaces;
using Udv.Core.Models;
using Udv.Core.Models.DTO;
using Udv.Core.Models.Entities;

namespace Udv.Core.Services;

public class PostLetterFrequencyService : IPostLetterFrequencyService
{   
    private readonly IPostCollector postCollector;
    private readonly ILetterCounter letterCounter;
    private readonly IPostLetterStatsRepository repository;

    public PostLetterFrequencyService(IPostCollector postCollector, ILetterCounter letterCounter, IPostLetterStatsRepository repository)
    {
        this.postCollector = postCollector;
        this.letterCounter = letterCounter;
        this.repository = repository;
    }

    public async Task<Result<GetSimilarLettersInFivePostResponse>> CountLetterFrequencyInPost(int postCount)
    {
        var postCollectorResponse = await postCollector.GetPosts(postCount);
        if (!postCollectorResponse.IsSuccess)
            return Result.InternalServerError<GetSimilarLettersInFivePostResponse>(postCollectorResponse.Error!);
        
        var posts = postCollectorResponse.Value;

        var postLetterStatsList = new List<PostLetterStats>();
        foreach (var post in posts)
        {
            var letterCounts = letterCounter.GetSimilarLettersCount(post.Text!).Value;
            var postLetterStats = new PostLetterStats(post.Id);
            foreach (var kvp in letterCounts)
            {
                var letterStats = new LetterStat
                {
                    Letter = kvp.Key,
                    Count = kvp.Value,
                    PostLetterStats = postLetterStats
                };
                postLetterStats.Letters.Add(letterStats);
            }
            
            await repository.Create(postLetterStats);
            await repository.Save();
            postLetterStatsList.Add(postLetterStats);
        }

        var response = new GetSimilarLettersInFivePostResponse
        {
            PostLetterStatsList = postLetterStatsList
        };

        return Result.Ok(response);
    }
}