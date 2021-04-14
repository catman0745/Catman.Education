namespace Catman.Education.Application.Features.Questions.Order.Commands.UpdateOrderQuestion
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;
    using Microsoft.EntityFrameworkCore;

    internal class UpdateOrderQuestionCommandHandler : RequestHandlerBase<UpdateOrderQuestionCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public UpdateOrderQuestionCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<RequestResult> HandleAsync(UpdateOrderQuestionCommand updateCommand)
        {
            if (!await _store.Tests.ExistsWithIdAsync(updateCommand.TestId))
            {
                return NotFound(_localizer.TestNotFound(updateCommand.TestId));
            }
            
            if (!await _store.OrderQuestions.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound(_localizer.QuestionNotFound(updateCommand.Id));
            }
            var question = await _store.OrderQuestions.WithIdAsync(updateCommand.Id);

            var oldItems = await _store.OrderQuestionItems.Where(item => item.QuestionId == question.Id).ToListAsync();
            _store.OrderQuestionItems.RemoveRange(oldItems);

            _mapper.Map(updateCommand, question);
            await _store.SaveChangesAsync();

            return Success(_localizer.QuestionUpdated(question.Id));
        }
    }
}
