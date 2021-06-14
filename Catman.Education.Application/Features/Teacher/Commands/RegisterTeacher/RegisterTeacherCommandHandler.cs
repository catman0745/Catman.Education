namespace Catman.Education.Application.Features.Teacher.Commands.RegisterTeacher
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Catman.Education.Application.Abstractions;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using Microsoft.EntityFrameworkCore;

    internal class RegisterTeacherCommandHandler : ResourceRequestHandlerBase<RegisterTeacherCommand, Teacher>
    {
        private readonly IApplicationStore _store;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;

        public RegisterTeacherCommandHandler(IApplicationStore store, IMapper mapper, ILocalizer localizer)
        {
            _store = store;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        protected override async Task<ResourceRequestResult<Teacher>> HandleAsync(
            RegisterTeacherCommand registerCommand)
        {
            var teacher = _mapper.Map<Teacher>(registerCommand);
            teacher.TaughtDisciplines = await _store.Disciplines
                .Where(discipline => registerCommand.TaughtDisciplinesIds.Contains(discipline.Id))
                .ToListAsync();
            
            _store.Teachers.Add(teacher);            
            await _store.SaveChangesAsync();

            return Success(_localizer.TeacherRegistered(teacher.Id), teacher);
        }
    }
}
