namespace Catman.Education.Application.Features.Questions.Order.Commands.CreateOrderQuestion
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;

    internal class CreateOrderQuestionCommandHandler
        : ResourceRequestHandlerBase<CreateOrderQuestionCommand, OrderQuestion>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public CreateOrderQuestionCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<OrderQuestion>> HandleAsync(
            CreateOrderQuestionCommand createCommand)
        {
            if (!await _store.Tests.ExistsWithIdAsync(createCommand.TestId))
            {
                return NotFound(_localizer.TestNotFound(createCommand.TestId));
            }

            var question = _mapper.Map<OrderQuestion>(createCommand);
            _store.OrderQuestions.Add(question);
            await _store.SaveChangesAsync();

            return Success(_localizer.QuestionCreated(question.Id), question);
        }
    }
}
