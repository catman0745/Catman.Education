namespace Catman.Education.Application.Features.Testing.Queries.GetTestsInfo
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Models.Testing.TestInfo;
    using MediatR;

    public class GetTestsInfoQuery : IRequest<ResourceRequestResult<ICollection<ITestInfo>>>
    {
        public Guid DisciplineId { get; }
        
        public Guid StudentId { get; }

        public GetTestsInfoQuery(Guid disciplineId, Guid studentId)
        {
            DisciplineId = disciplineId;
            StudentId = studentId;
        }
    }
}
