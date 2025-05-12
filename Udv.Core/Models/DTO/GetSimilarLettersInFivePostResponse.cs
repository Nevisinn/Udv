using Udv.Core.Models.Entities;

namespace Udv.Core.Models.DTO;

public class GetSimilarLettersInFivePostResponse
{
   public List<PostLetterStats> PostLetterStatsList { get; set; } = [];
}