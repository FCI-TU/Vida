using Vida.Domain.Common;

namespace Vida.Application.Interfaces.Repositories;
public interface IUnitOfWork : IDisposable
{
	public IGenericRepository<T> Repository<T>() where T : BaseEntity;
	public Task<int> CompleteAsync();
}