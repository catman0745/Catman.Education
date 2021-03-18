namespace Catman.Education.Application.Abstractions.Localization
{
    using System;
    
    public partial interface ILocalizer
    {
        string UserRetrieved(Guid id);
        
        string UsersRetrieved(int count);
        
        string UserRemoved(Guid id);
        
        string TokenGenerated(string username);

        string UserNotFound(Guid id);
        
        string UserNotFound(string username);
    }
}
