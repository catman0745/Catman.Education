namespace Catman.Education.Application.Features.Teacher.Queries.GetTaughtDisciplinesIds
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.Application.Models.Result;
    using MediatR;

    public class GetTaughtDisciplinesIdsQuery : IRequest<ResourceRequestResult<ICollection<Guid>>>
    {
        public Guid TeacherId { get; }

        public GetTaughtDisciplinesIdsQuery(Guid teacherId)
        {
            TeacherId = teacherId;
        }
    }
}
