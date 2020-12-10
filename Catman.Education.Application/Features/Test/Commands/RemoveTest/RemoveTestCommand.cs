namespace Catman.Education.Application.Features.Test.Commands.RemoveTest
{
    using System;
    using Catman.Education.Application.RequestRestrictions;
    using Catman.Education.Application.Results;
    using MediatR;

    public class RemoveTestCommand : IRequest<RequestResult>, IRequestorRoleRestriction
    {
        public Guid Id { get; }

        public Guid RequestorId { get; }

        public string RequiredRequestorRole => nameof(Admin);

        public RemoveTestCommand(Guid id, Guid requestorId)
        {
            Id = id;
            RequestorId = requestorId;
        }
    }
}
