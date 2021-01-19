namespace Catman.Education.Application.Extensions.Entities
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities.Users;
    using Microsoft.EntityFrameworkCore;

    internal static class StudentExtensions
    {
        public static Task<bool> ExistsWithIdAsync(this IQueryable<Student> students, Guid id) =>
            students.AnyAsync(student => student.Id == id);

        public static Task<Student> WithIdAsync(this IQueryable<Student> students, Guid id) =>
            students.SingleAsync(student => student.Id == id);
    }
}
