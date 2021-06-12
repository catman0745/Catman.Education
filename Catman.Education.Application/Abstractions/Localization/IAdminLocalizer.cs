namespace Catman.Education.Application.Abstractions.Localization
{
    using System;

    public partial interface ILocalizer
    {
        string AdminRegistered(Guid id);

        string AdminsRetrieved(int count);

        string AdminUpdated(Guid id);
        
        string AdminNotFound(Guid id);
    }
}
