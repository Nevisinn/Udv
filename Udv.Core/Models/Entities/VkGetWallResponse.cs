using System.Text.Json.Serialization;

namespace Udv.Core.Models.Entities;

public class VkGetWallResponse
{
    [JsonPropertyName("response")]
    public VkResponseItems Response { get; set; }
}