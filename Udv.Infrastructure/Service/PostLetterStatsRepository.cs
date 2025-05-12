using Microsoft.EntityFrameworkCore;
using Udv.Core.Interfaces;
using Udv.Core.Models.Entities;
using Udv.Infrastructure.DbContext;

namespace Udv.Infrastructure.Service;

public class PostLetterStatsRepository : IPostLetterStatsRepository
{
    private readonly AppDbContext appDbContext;
    
    public PostLetterStatsRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    
    public async Task<List<PostLetterStats>> GetAllPostLetterStats()
        => await appDbContext.PostLetterStats.Include(l=>l.Letters).ToListAsync();

    public async Task Create(PostLetterStats stats)
        => await appDbContext.AddAsync(stats);

    public async Task Save()
        => await appDbContext.SaveChangesAsync();
}