namespace Catman.Education.Application.Extensions.Entities
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;

    internal static class AdminExtensions
    {
        public static Task<bool> ExistsWithIdAsync(this IQueryable<Admin> admins, Guid id) =>
            admins.AnyAsync(admin => admin.Id == id);

        public static Task<Admin> WithIdAsync(this IQueryable<Admin> admins, Guid id) =>
            admins.SingleAsync(admin => admin.Id == id);
    }
}
