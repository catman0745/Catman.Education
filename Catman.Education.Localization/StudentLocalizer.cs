namespace Catman.Education.Localization
{
    using System;
    using Catman.Education.Localization.Extensions;

    public partial class Localizer
    {
        public string StudentRegistered(Guid id) =>
            _localizer["Student with id registered"].InjectId(id);
        
        public string StudentsRetrieved(int count) =>
            _localizer["Students retrieved"].InjectCount(count);

        public string StudentUpdated(Guid id) =>
            _localizer["Student with id updated"].InjectId(id);

        public string StudentNotFound(Guid id) =>
            _localizer["Student with id not found"].InjectId(id);
    }
}
