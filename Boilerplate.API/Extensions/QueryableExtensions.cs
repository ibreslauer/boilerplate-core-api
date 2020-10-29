using Boilerplate.Common.Models;
using Boilerplate.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Boilerplate.API.Extensions
{
    public static class QueryableExtensions
    {
		public static async Task<PagedList<TResult>> ToPagedListAsync<TResult>(this IQueryable<TResult> source, PagingQueryParams pagingParams)
		{
			var count = await source.CountAsync();

			if (pagingParams.StartFrom > count)
				throw new IndexOutOfRangeException("Requested items out of range.");

			var items = await source
				.Skip(pagingParams.StartFrom)
				.Take(pagingParams.PageSize)
				.ToListAsync();

			return new PagedList<TResult>(items, count, pagingParams.PageNumber, pagingParams.PageSize);
		}

	}
}
