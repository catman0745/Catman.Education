namespace Catman.Education.Application.Abstractions.Localization
{
    using System;
    
    public partial interface ILocalizer
    {
        string StudentRegistered(Guid id);
        
        string StudentRetrieved(Guid id);
        
        string StudentsRetrieved(int count);

        string StudentUpdated(Guid id);

        string StudentNotFound(Guid id);
    }
}
