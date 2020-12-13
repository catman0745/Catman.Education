namespace Catman.Education.Application.Features.Answer.Commands.UpdateAnswer
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class UpdateAnswerCommandHandler : RequestHandlerBase<UpdateAnswerCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public UpdateAnswerCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
            : base(localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<RequestResult> HandleAsync(UpdateAnswerCommand updateCommand)
        {
            if (!await _store.Questions.ExistsWithIdAsync(updateCommand.QuestionId))
            {
                return NotFound(_localizer.QuestionNotFound(updateCommand.QuestionId));
            }
        
            if (!await _store.Answers.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound(_localizer.AnswerNotFound(updateCommand.Id));
            }
            var answer = await _store.Answers.WithIdAsync(updateCommand.Id);

            _mapper.Map(updateCommand, answer);
            await _store.SaveChangesAsync();

            return Success(_localizer.AnswerUpdated(answer.Id));
        }
    }
}
