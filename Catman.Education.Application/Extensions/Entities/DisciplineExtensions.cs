namespace Catman.Education.Application.Extensions.Entities
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

        public static IQueryable<Discipline> OfGrade(this IQueryable<Discipline> disciplines, int grade) =>
            disciplines.Where(discipline => discipline.Grade == grade);

        public static IQueryable<Discipline> OtherThan(this IQueryable<Discipline> disciplines, Guid disciplineId) =>
            disciplines.Where(discipline => discipline.Id != disciplineId);
    }
}
