namespace Catman.Education.Application.Features.Questions.YesNo.Commands.CreateYesNoQuestion
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Testing.Questioning;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;

    internal class CreateYesNoQuestionCommandHandler
        : ResourceRequestHandlerBase<CreateYesNoQuestionCommand, YesNoQuestion>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public CreateYesNoQuestionCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<YesNoQuestion>> HandleAsync(
            CreateYesNoQuestionCommand createCommand)
        {
            if (!await _store.Tests.ExistsWithIdAsync(createCommand.TestId))
            {
                return NotFound(_localizer.TestNotFound(createCommand.TestId));
            }

            var question = _mapper.Map<YesNoQuestion>(createCommand);
            _store.YesNoQuestions.Add(question);
            await _store.SaveChangesAsync();

            return Success(_localizer.QuestionCreated(question.Id), question);
        }
    }
}
