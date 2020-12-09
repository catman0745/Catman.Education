namespace Catman.Education.Application.Extensions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;

    internal static class DisciplineExtensions
    {
        public static Task<bool> ExistsWithTitleAsync(this IQueryable<Discipline> disciplines, string title) =>
            disciplines.AnyAsync(discipline => discipline.Title == title);

        public static Task<bool> ExistsWithIdAsync(this IQueryable<Discipline> disciplines, Guid id) =>
            disciplines.AnyAsync(discipline => discipline.Id == id);

        public static Task<Discipline> WithIdAsync(this IQueryable<Discipline> disciplines, Guid id) =>
            disciplines.SingleAsync(discipline => discipline.Id == id);

        public static IQueryable<Discipline> OtherThan(
            this IQueryable<Discipline> disciplines,
            Discipline discipline) =>
            disciplines.Where(d => d.Id != discipline.Id);
    }
}
