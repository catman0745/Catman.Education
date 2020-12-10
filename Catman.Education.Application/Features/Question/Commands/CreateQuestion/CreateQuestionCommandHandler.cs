namespace Catman.Education.Application.Features.Question.Commands.CreateQuestion
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Extensions;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Application.Results;

    internal class CreateQuestionCommandHandler : ResourceRequestHandlerBase<CreateQuestionCommand, Question>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;

        public CreateQuestionCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }
        
        protected override async Task<ResourceRequestResult<Question>> HandleAsync(CreateQuestionCommand createCommand)
        {
            if (!await _store.Tests.ExistsWithIdAsync(createCommand.TestId))
            {
                return NotFound($"Test with id \"{createCommand.TestId}\" not found");
            }

            var question = _mapper.Map<Question>(createCommand);
            _store.Questions.Add(question);
            await _store.SaveChangesAsync();

            return Success($"Question with id \"{question.Id}\" created successfully", question);
        }
    }
}
