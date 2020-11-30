namespace Catman.Education.Application.Extensions
{
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

        public static IQueryable<User> OtherThan(this IQueryable<User> users, User user) =>
            users.Where(u => u.Id != user.Id);
    }
}
