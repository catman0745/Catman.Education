namespace Catman.Education.Application.Features.QuestionItems.Order.Commands.CreateOrderQuestionItem
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;

    internal class CreateOrderQuestionItemCommandHandler
        : ResourceRequestHandlerBase<CreateOrderQuestionItemCommand, OrderQuestionItem>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public CreateOrderQuestionItemCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<OrderQuestionItem>> HandleAsync(
            CreateOrderQuestionItemCommand createCommand)
        {
            if (!await _store.OrderQuestions.ExistsWithIdAsync(createCommand.QuestionId))
            {
                return NotFound(_localizer.QuestionNotFound(createCommand.QuestionId));
            }
        
            var questionItem = _mapper.Map<OrderQuestionItem>(createCommand);
            _store.OrderQuestionItems.Add(questionItem);
            await _store.SaveChangesAsync();

            return Success(_localizer.AnswerCreated(questionItem.Id), questionItem);
        }
    }
}
