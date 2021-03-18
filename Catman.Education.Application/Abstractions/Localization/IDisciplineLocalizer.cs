namespace Catman.Education.Application.Abstractions.Localization
{
    using System;
    
    public partial interface ILocalizer
    {
        string DisciplineCreated(Guid id);
        
        string DisciplineRetrieved(Guid id);
        
        string DisciplinesRetrieved(int count);

        string DisciplineUpdated(Guid id);

        string DisciplineRemoved(Guid id);

        string DisciplineNotFound(Guid id);
    }
}
