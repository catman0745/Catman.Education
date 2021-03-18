namespace Catman.Education.Localization
{
    using System;
    using Catman.Education.Localization.Extensions;

    public partial class Localizer
    {
        public string GroupCreated(Guid id) =>
            _localizer["Group with id created"].InjectId(id);
        
        public string GroupRetrieved(Guid id) =>
            _localizer["Group with id retrieved"].InjectId(id);
        
        public string GroupsRetrieved(int count) =>
            _localizer["Groups retrieved"].InjectCount(count);

        public string GroupUpdated(Guid id) =>
            _localizer["Group with id updated"].InjectId(id);

        public string GroupRemoved(Guid id) =>
            _localizer["Group with id removed"].InjectId(id);

        public string GroupNotFound(Guid id) =>
            _localizer["Group with id not found"].InjectId(id);
    }
}
