namespace Catman.Education.Application.Extensions
{
    using System;
    using System.Linq;

    internal static class FilteringExtensions
    {
        public static IQueryable<TResource> ApplyFilter<TResource, TOptions>(
            this IQueryable<TResource> resources,
            Func<IQueryable<TResource>, TOptions, IQueryable<TResource>> filter,
            TOptions filteringOptions)
        {
            return filter(resources, filteringOptions);
        }
    }
}
