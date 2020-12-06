namespace Catman.Education.Application.RequestRestrictions
{
    using System;
    using Catman.Education.Application.Entities;

    internal interface IRequestorRoleRestriction
    {
        Guid RequestorId { get; }
        
        UserRole RequiredRequestorRole { get; }
    }
}
