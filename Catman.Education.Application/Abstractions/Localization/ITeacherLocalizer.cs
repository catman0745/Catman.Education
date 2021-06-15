namespace Catman.Education.Application.Abstractions.Localization
{
    using System;

    public partial interface ILocalizer
    {
        string TeacherNotFound(Guid id);

        string TeacherUpdated(Guid id);
        
        string TeacherRegistered(Guid id);
        
        string TeachersRetrieved(int count);

        string TeacherDisciplinesRetrieved(Guid teacherId);

        string TeacherHasNoAccessToDiscipline(Guid disciplineId);
    }
}
