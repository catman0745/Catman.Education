namespace Catman.Education.Localization
{
    using System;
    using Catman.Education.Localization.Extensions;

    public partial class Localizer
    {
        public string UserRetrieved(Guid id) =>
            _localizer["User with id retrieved"].InjectId(id);
        
        public string UsersRetrieved(int count) =>
            _localizer["Users retrieved"].InjectCount(count);
        
        public string UserRemoved(Guid id) =>
            _localizer["User with id created"].InjectId(id);
        
        public string TokenGenerated(string username) =>
            _localizer["Token for user with username generated"].InjectUsername(username);

        public string UserNotFound(Guid id) =>
            _localizer["User with id not found"].InjectId(id);
        
        public string UserNotFound(string username) =>
            _localizer["User with username not found"].InjectUsername(username);
    }
}
