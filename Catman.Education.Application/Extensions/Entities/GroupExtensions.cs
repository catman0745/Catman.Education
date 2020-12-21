namespace Catman.Education.Application.Extensions.Entities
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;

    internal static class GroupExtensions
    {
        public static Task<bool> ExistsWithTitleAsync(this IQueryable<Group> groups, string title) =>
            groups.AnyAsync(user => user.Title == title);

        public static Task<bool> ExistsWithIdAsync(this IQueryable<Group> groups, Guid id) =>
            groups.AnyAsync(user => user.Id == id);

        public static Task<Group> WithIdAsync(this IQueryable<Group> groups, Guid id) =>
            groups.SingleAsync(user => user.Id == id);

        public static IQueryable<Group> OtherThan(this IQueryable<Group> groups, Guid groupId) =>
            groups.Where(u => u.Id != groupId);
    }
}
