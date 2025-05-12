using System.Text.Json;
using Udv.Core.Interfaces;
using Udv.Core.Models;
using Udv.Core.Models.Entities;

namespace Udv.Core.Services;

public class PostCollector : IPostCollector
{
    private static HttpClient httpClient = new();
    private const string url = "https://api.vk.ru/method/wall.get";
    private const string userId = "id527703380";

    public async Task<Result<Post[]>> GetPosts(int count)
    {
        var queryParams = new Dictionary<string, string>()
        {
            { "domain", userId },
            { "count", count.ToString() },
            { "v", "5.199" }
        };

        var queryString = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"));
        var getPostsRequest = new HttpRequestMessage(HttpMethod.Get, $"{url}?{queryString}");
        getPostsRequest.Headers.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("ACCESS_TOKEN")}");
        var response = await httpClient.SendAsync(getPostsRequest);
        var jsonPosts = await response.Content.ReadAsStreamAsync();
        var vkResponse = await JsonSerializer.DeserializeAsync<VkGetWallResponse>(jsonPosts);
        var posts = vkResponse?.Response.Posts;
        
        return posts is null ? Result.InternalServerError<Post[]>("Post deserialization error") : Result.Ok(posts);
    }
}