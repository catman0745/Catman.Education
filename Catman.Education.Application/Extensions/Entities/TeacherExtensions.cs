namespace Catman.Education.Application.Extensions.Entities
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities.Users;
    using Microsoft.EntityFrameworkCore;

    internal static class TeacherExtensions
    {
        public static Task<bool> ExistsWithIdAsync(this IQueryable<Teacher> teachers, Guid id) =>
            teachers.AnyAsync(teacher => teacher.Id == id);

        public static Task<Teacher> WithIdAsync(this IQueryable<Teacher> teachers, Guid id) =>
            teachers.SingleAsync(teacher => teacher.Id == id);
    }
}
