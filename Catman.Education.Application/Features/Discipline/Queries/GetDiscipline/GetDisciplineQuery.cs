namespace Catman.Education.Application.Features.Discipline.Queries.GetDiscipline
{
    using System;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Results.Common;
    using MediatR;

    public class GetDisciplineQuery : IRequest<ResourceRequestResult<Discipline>>
    {
        public Guid Id { get; }

        public GetDisciplineQuery(Guid id)
        {
            Id = id;
        }
    }
}
