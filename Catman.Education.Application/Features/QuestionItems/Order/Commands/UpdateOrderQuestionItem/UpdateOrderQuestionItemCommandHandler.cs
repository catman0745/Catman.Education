namespace Catman.Education.Application.Features.QuestionItems.Order.Commands.UpdateOrderQuestionItem
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;

    internal class UpdateOrderQuestionItemCommandHandler : RequestHandlerBase<UpdateOrderQuestionItemCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public UpdateOrderQuestionItemCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
            
        protected override async Task<RequestResult> HandleAsync(UpdateOrderQuestionItemCommand updateCommand)
        {
            if (!await _store.OrderQuestions.ExistsWithIdAsync(updateCommand.QuestionId))
            {
                return NotFound(_localizer.QuestionNotFound(updateCommand.QuestionId));
            }
            
            if (!await _store.OrderQuestionItems.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound(_localizer.AnswerNotFound(updateCommand.Id));
            }
            var questionItem = await _store.OrderQuestionItems.WithIdAsync(updateCommand.Id);

            _mapper.Map(updateCommand, questionItem);
            await _store.SaveChangesAsync();

            return Success(_localizer.AnswerUpdated(questionItem.Id));
        }
    }
}
