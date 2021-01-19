namespace Catman.Education.Application.Features.Admin.Queries.GetAdmin
{
    using System;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class GetAdminQuery : IRequest<ResourceRequestResult<Admin>>
    {
        public Guid Id { get; }

        public GetAdminQuery(Guid id)
        {
            Id = id;
        }
    }
}
