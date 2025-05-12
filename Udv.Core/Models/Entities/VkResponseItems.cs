using System.Text.Json.Serialization;

namespace Udv.Core.Models.Entities;

public class VkResponseItems
{   
    [JsonPropertyName("items")]
    public Post[] Posts { get; set; }
}