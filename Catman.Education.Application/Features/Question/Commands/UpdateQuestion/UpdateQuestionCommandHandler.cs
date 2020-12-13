namespace Catman.Education.Application.Features.Question.Commands.UpdateQuestion
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class UpdateQuestionCommandHandler : RequestHandlerBase<UpdateQuestionCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public UpdateQuestionCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<RequestResult> HandleAsync(UpdateQuestionCommand updateCommand)
        {
            if (!await _store.Tests.ExistsWithIdAsync(updateCommand.TestId))
            {
                return NotFound(_localizer["Test with id not found"].Replace("{id}", updateCommand.TestId.ToString()));
            }
            
            if (!await _store.Questions.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound(_localizer["Question with id not found"].Replace("{id}", updateCommand.Id.ToString()));
            }
            var question = await _store.Questions.WithIdAsync(updateCommand.Id);

            _mapper.Map(updateCommand, question);
            await _store.SaveChangesAsync();

            return Success(_localizer["Question with id updated"].Replace("{id}", updateCommand.Id.ToString()));
        }
    }
}
