namespace Catman.Education.Application.Features.Discipline.Queries.GetDisciplines
{
    using System.Collections.Generic;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Results;
    using MediatR;

    public class GetDisciplinesQuery : IRequest<ResourceRequestResult<ICollection<Discipline>>>
    {
    }
}