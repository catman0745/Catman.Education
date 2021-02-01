namespace Catman.Education.Application.Features.Test.Queries.GetTest
{
    using System;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Models.Result;
    using MediatR;

    public class GetTestQuery : IRequest<ResourceRequestResult<Test>>
    {
        public Guid Id { get; }

        public GetTestQuery(Guid id)
        {
            Id = id;
        }
    }
}
