using Vida.Application.Dtos.NewsDtos;
using Vida.Domain.ErrorHandling;

namespace Vida.Application.Interfaces.Services;

public interface INewsService
{
    Task<Result<IReadOnlyList<NewsResponse>>> GetLatestNewsAsync(int count = 5);
    Task<Result<NewsResponse>> GetNewsByIdAsync(int id);
}
