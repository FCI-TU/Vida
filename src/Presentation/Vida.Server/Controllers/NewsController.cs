using Microsoft.AspNetCore.Mvc;
using Vida.Application.Interfaces.Services;
using Vida.Server.Extensions;

namespace Vida.Server.Controllers;

public class NewsController(INewsService newsService) : BaseController
{
    [HttpGet]
    public async Task<ActionResult> GetLatestNews([FromQuery] int count = 3)
    {
        var result = await newsService.GetLatestNewsAsync(count);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetNewsById(int id)
    {
        var result = await newsService.GetNewsByIdAsync(id);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }
}