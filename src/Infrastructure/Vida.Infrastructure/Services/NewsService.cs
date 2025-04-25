using AutoMapper;
using Vida.Application.Dtos.NewsDtos;
using Vida.Application.Interfaces.Repositories;
using Vida.Application.Interfaces.Services;
using Vida.Application.Specifications;
using Vida.Domain.Entities.News;
using Vida.Domain.ErrorHandling;

namespace Vida.Infrastructure.Services;

public class NewsService(IUnitOfWork unitOfWork, IMapper mapper) : INewsService
{
    public async Task<Result<IReadOnlyList<NewsResponse>>> GetLatestNewsAsync(int count = 3)
    {
        var spec = new BaseSpecifications<News>
        {
            WhereCriteria = n => n.IsActive,
            OrderByDesc = n => n.PublishDate
        };

        var news = await unitOfWork.Repository<News>().GetAllAsync(spec);

        var latestNews = news.Take(count).ToList();

        var newsDto = mapper.Map<IReadOnlyList<News>, IReadOnlyList<NewsResponse>>(latestNews);

        return Result.Success(newsDto);
    }

    public async Task<Result<NewsResponse>> GetNewsByIdAsync(int id)
    {
        var news = await unitOfWork.Repository<News>().GetEntityAsync(id);

        if (news == null)
            return Result.Failure<NewsResponse>(new Error(404, $"News with id {id} not found"));

        var newsDto = mapper.Map<News, NewsResponse>(news);

        return Result.Success(newsDto);
    }
}