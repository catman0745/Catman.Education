namespace Catman.Education.Application.Extensions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;

    public static class UserExtensions
    {
        internal static Task<bool> ExistsWithUsernameAsync(this IQueryable<User> users, string username) =>
            users.AnyAsync(user => user.Username == username);

        internal static Task<User> WithUsernameAsync(this IQueryable<User> users, string username) =>
            users.SingleAsync(user => user.Username == username);

        internal static Task<bool> ExistsWithIdAsync(this IQueryable<User> users, Guid id) =>
            users.AnyAsync(user => user.Id == id);

        internal static Task<User> WithIdAsync(this IQueryable<User> users, Guid id) =>
            users.SingleAsync(user => user.Id == id);

        internal static IQueryable<User> OtherThan(this IQueryable<User> users, User user) =>
            users.Where(u => u.Id != user.Id);

        public static UserRole Role(this User user) =>
            user switch
            {
                Admin => UserRole.Admin,
                Student => UserRole.Student,
                _ => throw new Exception("Cannot determine user role")
            };
    }
}
