using System.Text.Json.Serialization;

namespace Udv.Core.Models.Entities;

public class Post
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("text")]
    public string? Text { get; set; }
    
}