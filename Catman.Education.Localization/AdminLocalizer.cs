namespace Catman.Education.Localization
{
    using System;
    using Catman.Education.Localization.Extensions;

    public partial class Localizer
    {
        public string AdminRegistered(Guid id) =>
            _localizer["Admin with id registered"].InjectId(id);

        public string AdminRetrieved(Guid id) =>
            _localizer["Admin with id retrieved"].InjectId(id);

        public string AdminUpdated(Guid id) =>
            _localizer["Admin with id updated"].InjectId(id);
        
        public string AdminNotFound(Guid id) =>
            _localizer["Admin with id not found"].InjectId(id);
    }
}
