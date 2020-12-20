namespace Catman.Education.Application.Features.Answer.Commands.CreateAnswer
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Results.Common;

    internal class CreateAnswerCommandHandler : ResourceRequestHandlerBase<CreateAnswerCommand, Answer>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public CreateAnswerCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Answer>> HandleAsync(CreateAnswerCommand createCommand)
        {
            if (!await _store.Questions.ExistsWithIdAsync(createCommand.QuestionId))
            {
                return NotFound(_localizer.QuestionNotFound(createCommand.QuestionId));
            }
        
            var answer = _mapper.Map<Answer>(createCommand);
            _store.Answers.Add(answer);
            await _store.SaveChangesAsync();

            return Success(_localizer.AnswerCreated(answer.Id), answer);
        }
    }
}
