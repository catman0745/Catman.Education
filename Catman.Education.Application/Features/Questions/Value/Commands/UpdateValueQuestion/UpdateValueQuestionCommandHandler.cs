namespace Catman.Education.Application.Features.Questions.Value.Commands.UpdateValueQuestion
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Extensions.Entities;
    using Catman.Education.Application.Models.Result;

    internal class UpdateValueQuestionCommandHandler : RequestHandlerBase<UpdateValueQuestionCommand>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public UpdateValueQuestionCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<RequestResult> HandleAsync(UpdateValueQuestionCommand updateCommand)
        {
            if (!await _store.Tests.ExistsWithIdAsync(updateCommand.TestId))
            {
                return NotFound(_localizer.TestNotFound(updateCommand.TestId));
            }
            
            if (!await _store.ValueQuestions.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound(_localizer.QuestionNotFound(updateCommand.Id));
            }
            var question = await _store.ValueQuestions.WithIdAsync(updateCommand.Id);

            _mapper.Map(updateCommand, question);
            await _store.SaveChangesAsync();

            return Success(_localizer.QuestionUpdated(question.Id));
        }
    }
}
