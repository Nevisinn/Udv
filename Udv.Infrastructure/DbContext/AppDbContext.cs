using Microsoft.EntityFrameworkCore;
using Udv.Core.Models.Entities;

namespace Udv.Infrastructure.DbContext;

public sealed class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<PostLetterStats> PostLetterStats { get; set; }
    public DbSet<LetterStat> LetterStats { get; set; }

    public AppDbContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql($"{Environment.GetEnvironmentVariable("DB_HOST")}");
    }
}
