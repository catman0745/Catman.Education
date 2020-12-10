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

        public UpdateQuestionCommandHandler(IApplicationStore store, IMapper mapper)
        {
            _store = store;
            _mapper = mapper;
        }
        
        protected override async Task<RequestResult> HandleAsync(UpdateQuestionCommand updateCommand)
        {
            if (!await _store.Tests.ExistsWithIdAsync(updateCommand.TestId))
            {
                return NotFound($"Test with id \"{updateCommand.TestId}\" not found");
            }
            
            if (!await _store.Questions.ExistsWithIdAsync(updateCommand.Id))
            {
                return NotFound($"Question with id \"{updateCommand.Id}\" not found");
            }
            var question = await _store.Questions.WithIdAsync(updateCommand.Id);

            _mapper.Map(updateCommand, question);
            await _store.SaveChangesAsync();

            return Success($"Question with id \"{question.Id}\" updated successfully");
        }
    }
}
