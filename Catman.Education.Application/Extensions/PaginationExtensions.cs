namespace Catman.Education.Application.Extensions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Pagination;
    using Microsoft.EntityFrameworkCore;

    internal static class PaginationExtensions
    {
        public static async Task<Paginated<TResource>> PaginateAsync<TResource>(
            this IQueryable<TResource> source,
            PaginationInfo options)
        {
            var total = await source.CountAsync();
            var pagesCount = (int) Math.Ceiling((double) total / options.PageSize);
                
            var items = await source
                .Skip((options.PageNumber - 1) * options.PageSize)
                .Take(options.PageSize)
                .ToListAsync();

            return new Paginated<TResource>(items, pagesCount, options);
        }
    }
}
