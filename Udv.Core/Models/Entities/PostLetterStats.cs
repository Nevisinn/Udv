namespace Udv.Core.Models.Entities;

public class PostLetterStats
{
    public PostLetterStats(int postId)
    {
        PostId = postId;
        Id = Guid.NewGuid();
        Letters = [];
    }

    public Guid Id { get; init; }
    public int PostId { get; init; }
    public List<LetterStat> Letters { get; set; }
}