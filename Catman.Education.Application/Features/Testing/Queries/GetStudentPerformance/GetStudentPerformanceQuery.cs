namespace Catman.Education.Application.Features.Testing.Queries.GetStudentPerformance
{
    using System;
    using Catman.Education.Application.Models.Result;
    using Catman.Education.Application.Models.Testing;
    using MediatR;

    public class GetStudentPerformanceQuery : IRequest<ResourceRequestResult<StudentPerformance>>
    {
        public Guid StudentId { get; }

        public GetStudentPerformanceQuery(Guid studentId)
        {
            StudentId = studentId;
        }
    }
}
