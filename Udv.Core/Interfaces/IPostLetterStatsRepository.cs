using Udv.Core.Models.Entities;

namespace Udv.Core.Interfaces;

public interface IPostLetterStatsRepository
{
    public Task<List<PostLetterStats>> GetAllPostLetterStats();
    public Task Create(PostLetterStats stats);
    public Task Save();
}