namespace Catman.Education.Localization
{
    using System;
    using Catman.Education.Localization.Extensions;

    public partial class Localizer
    {
        public string DisciplineCreated(Guid id) =>
            _localizer["Discipline with id created"].InjectId(id);
        
        public string DisciplineRetrieved(Guid id) =>
            _localizer["Discipline with id retrieved"].InjectId(id);
        
        public string DisciplinesRetrieved(int count) =>
            _localizer["Disciplines retrieved"].InjectCount(count);

        public string DisciplineUpdated(Guid id) =>
            _localizer["Discipline with id updated"].InjectId(id);

        public string DisciplineRemoved(Guid id) =>
            _localizer["Discipline with id removed"].InjectId(id);

        public string DisciplineNotFound(Guid id) =>
            _localizer["Discipline with id not found"].InjectId(id);
    }
}
