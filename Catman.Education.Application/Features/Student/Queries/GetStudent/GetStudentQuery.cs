namespace Catman.Education.Application.Features.Student.Queries.GetStudent
{
    using System;
    using Catman.Education.Application.Entities.Users;
    using Catman.Education.Application.Models.Result;
    using MediatR;

    public class GetStudentQuery : IRequest<ResourceRequestResult<Student>>
    {
        public Guid Id { get; }

        public GetStudentQuery(Guid id)
        {
            Id = id;
        }
    }
}
