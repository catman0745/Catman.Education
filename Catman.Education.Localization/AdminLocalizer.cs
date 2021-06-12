namespace Catman.Education.Localization
{
    using System;
    using Catman.Education.Localization.Extensions;

    public partial class Localizer
    {
        public string AdminRegistered(Guid id) =>
            _localizer["Admin with id registered"].InjectId(id);

        public string AdminsRetrieved(int count) =>
            _localizer["Admins retrieved"].InjectCount(count);

        public string AdminUpdated(Guid id) =>
            _localizer["Admin with id updated"].InjectId(id);
        
        public string AdminNotFound(Guid id) =>
            _localizer["Admin with id not found"].InjectId(id);
    }
}
