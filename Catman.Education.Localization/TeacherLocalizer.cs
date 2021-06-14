namespace Catman.Education.Localization
{
    using System;
    using Catman.Education.Localization.Extensions;

    public partial class Localizer
    {
        public string TeacherRegistered(Guid id) =>
            _localizer["Teacher with id registered"].InjectId(id);

        public string TeachersRetrieved(int count) =>
            _localizer["Teachers retrieved"].InjectCount(count);

        public string TeacherUpdated(Guid id) =>
            _localizer["Teacher with id updated"].InjectId(id);
        
        public string TeacherNotFound(Guid id) =>
            _localizer["Teacher with id not found"].InjectId(id);

        public string TeacherDisciplinesRetrieved(Guid teacherId) =>
            _localizer["Teacher disciplines with teacherId retrieved"].InjectId(teacherId);
    }
}
