namespace Catman.Education.Application.Abstractions.Localization
{
    using System;

    public partial interface ILocalizer
    {
        string AdminRegistered(Guid id);

        string AdminRetrieved(Guid id);

        string AdminUpdated(Guid id);
        
        string AdminNotFound(Guid id);
    }
}
