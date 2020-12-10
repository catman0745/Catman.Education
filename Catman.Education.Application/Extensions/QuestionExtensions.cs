namespace Catman.Education.Application.Extensions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities;
    using Microsoft.EntityFrameworkCore;

    internal static class QuestionExtensions
    {
        public static Task<bool> ExistsWithIdAsync(this IQueryable<Question> questions, Guid id) =>
            questions.AnyAsync(question => question.Id == id);

        public static Task<Question> WithIdAsync(this IQueryable<Question> questions, Guid id) =>
            questions.SingleAsync(question => question.Id == id);
    }
}
