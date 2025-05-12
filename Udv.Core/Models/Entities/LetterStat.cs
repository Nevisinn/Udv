using System.Text.Json.Serialization;

namespace Udv.Core.Models.Entities;

public class LetterStat
{
    public Guid Id { get; set; }
    public char Letter { get; set; }
    public int Count { get; set; }

    [JsonIgnore]
    public Guid PostLetterStatsId { get; set; }
    [JsonIgnore]
    public PostLetterStats PostLetterStats { get; set; }
}