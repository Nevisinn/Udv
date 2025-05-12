using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Udv.Core.Interfaces;
using Udv.Core.Models.DTO;
using Udv.Core.Models.Entities;

namespace Udv.Controllers;

[Route("api/[controller]")]
[Controller]
public class PostsController : ControllerBase
{
    private readonly IPostLetterFrequencyService postLetterFrequencyService;
    private readonly IPostLetterStatsRepository postLetterStatsRepository;
    private readonly ILogger<PostsController> logger;

    public PostsController(IPostLetterFrequencyService postLetterFrequencyService,
        IPostLetterStatsRepository postLetterStatsRepository, ILogger<PostsController> logger)
    {
        this.postLetterFrequencyService = postLetterFrequencyService;
        this.postLetterStatsRepository = postLetterStatsRepository;
        this.logger = logger;
    }

    /// <summary>
    /// Получить 5 постов и посчитать в этих постах вхождение одинаковых букв
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetSimilarLettersInFivePost")]
    public async Task<ActionResult<GetSimilarLettersInFivePostResponse>> GetSimilarLettersInFivePost()
    {
        logger.LogInformation($"Запуск подсчета: {DateTime.Now}");
        var response = await postLetterFrequencyService.CountLetterFrequencyInPost(5);
        logger.LogInformation($"Конец подсчета: {DateTime.Now}");
        return ApiMapper.Map(response);
    }

    /// <summary>
    /// Получить посты из БД с подсчитанным вхождением одинаковых букв в постах
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAllPostStats")]
    public async Task<ActionResult<PostLetterStats>> GetAllPostStats()
        => Ok(await postLetterStatsRepository.GetAllPostLetterStats());

}