using Boilerplate.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Boilerplate.API.Models
{
	public static class IQueryableExtensions
	{
		public static async Task<PagedList<T>> ToPagedListAsync<T>(IQueryable<T> source, PagingQueryParams pagingParams)
		{
			var count = await source.CountAsync();

			if (pagingParams.StartFrom >= count)
				throw new IndexOutOfRangeException("Requested items out of range.");

			var items = await source
				.Skip(pagingParams.StartFrom)
				.Take(pagingParams.PageSize)
				.ToListAsync();

			return new PagedList<T>(items, count, pagingParams.PageNumber, pagingParams.PageSize);
		}
	}
}
