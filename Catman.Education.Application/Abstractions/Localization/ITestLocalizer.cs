namespace Catman.Education.Application.Abstractions.Localization
{
    using System;
    
    public partial interface ILocalizer
    {
        string TestCreated(Guid id);
        
        string TestRetrieved(Guid id);
        
        string TestsRetrieved(int count);

        string TestUpdated(Guid id);

        string TestRemoved(Guid id);

        string TestNotFound(Guid id);
    }
}
