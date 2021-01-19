namespace Catman.Education.Application.Extensions.Entities
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Microsoft.EntityFrameworkCore;

    internal static class AnswerExtensions
    {
        public static Task<bool> ExistsWithIdAsync(this IQueryable<Answer> answers, Guid id) =>
            answers.AnyAsync(answer => answer.Id == id);

        public static Task<Answer> WithIdAsync(this IQueryable<Answer> answers, Guid id) =>
            answers.SingleAsync(answer => answer.Id == id);
    }
}
