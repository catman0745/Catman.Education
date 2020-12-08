namespace Catman.Education.Application.RequestRestrictions
{
    using System;

    internal interface IRequestorRoleRestriction
    {
        Guid RequestorId { get; }
        
        string RequiredRequestorRole { get; }
    }
}
