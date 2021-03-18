namespace Catman.Education.Localization
{
    using System;
    using Catman.Education.Localization.Extensions;

    public partial class Localizer
    {
        public string TestCreated(Guid id) =>
            _localizer["Test with id created"].InjectId(id);
        
        public string TestRetrieved(Guid id) =>
            _localizer["Test with id retrieved"].InjectId(id);
        
        public string TestsRetrieved(int count) =>
            _localizer["Tests retrieved"].InjectCount(count);

        public string TestUpdated(Guid id) =>
            _localizer["Test with id updated"].InjectId(id);

        public string TestRemoved(Guid id) =>
            _localizer["Test with id removed"].InjectId(id);

        public string TestNotFound(Guid id) =>
            _localizer["Test with id not found"].InjectId(id);
    }
}
