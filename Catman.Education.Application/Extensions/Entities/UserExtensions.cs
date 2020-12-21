namespace Catman.Education.Application.Extensions.Entities
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;

    internal static class UserExtensions
    {
        public static Task<bool> ExistsWithUsernameAsync(this IQueryable<User> users, string username) =>
            users.AnyAsync(user => user.Username == username);

        public static Task<User> WithUsernameAsync(this IQueryable<User> users, string username) =>
            users.SingleAsync(user => user.Username == username);

        public static Task<bool> ExistsWithIdAsync(this IQueryable<User> users, Guid id) =>
            users.AnyAsync(user => user.Id == id);

        public static Task<User> WithIdAsync(this IQueryable<User> users, Guid id) =>
            users.SingleAsync(user => user.Id == id);

        public static IQueryable<User> OtherThan(this IQueryable<User> users, Guid userId) =>
            users.Where(user => user.Id != userId);
    }
}
