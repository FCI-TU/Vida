﻿using Microsoft.EntityFrameworkCore;
using Vida.Application.Interfaces.Specifications;
using Vida.Domain.Common;

namespace Vida.Persistence;
public class SpecificationsEvaluator<T> where T : BaseEntity
{
	public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecifications<T> spec)
	{
		var query = inputQuery;

		if (spec.WhereCriteria != null)
			query = query.Where(spec.WhereCriteria);

		if (spec.OrderBy != null)
			query = query.OrderBy(spec.OrderBy);

		if (spec.OrderByDesc != null)
			query = query.OrderByDescending(spec.OrderByDesc);

		query = spec.IncludesCriteria.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

		return query;
	}
}