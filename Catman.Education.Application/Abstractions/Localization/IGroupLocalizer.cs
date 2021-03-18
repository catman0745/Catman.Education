namespace Catman.Education.Application.Abstractions.Localization
{
    using System;
    
    public partial interface ILocalizer
    {
        string GroupCreated(Guid id);
        
        string GroupRetrieved(Guid id);
        
        string GroupsRetrieved(int count);

        string GroupUpdated(Guid id);

        string GroupRemoved(Guid id);

        string GroupNotFound(Guid id);
    }
}
