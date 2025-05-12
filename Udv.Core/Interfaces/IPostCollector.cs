using Udv.Core.Models;
using Udv.Core.Models.Entities;

namespace Udv.Core.Interfaces;

public interface IPostCollector
{
    public Task<Result<Post[]>> GetPosts(int count);
}