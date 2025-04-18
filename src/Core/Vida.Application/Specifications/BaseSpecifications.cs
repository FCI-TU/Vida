using System.Linq.Expressions;
using Vida.Application.Interfaces.Specifications;
using Vida.Domain.Common;

namespace Vida.Application.Specifications;

public class BaseSpecifications<T> : ISpecifications<T> where T : BaseEntity
{
	public Expression<Func<T, bool>> WhereCriteria { get; set; } = null!;
	public List<Expression<Func<T, object>>> IncludesCriteria { get; set; } = [];
	public Expression<Func<T, object>> OrderBy { get; set; } = null!;
	public Expression<Func<T, object>> OrderByDesc { get; set; } = null!;
}