namespace Catman.Education.Application.Features.Student.Queries.GetStudents
{
    using System;
    using System.Collections.Generic;
    using Catman.Education.Application.Entities;
    using Catman.Education.Application.Results;
    using MediatR;

    public class GetStudentsQuery : IRequest<ResourceRequestResult<ICollection<Student>>>
    {
        public string Username { get; set; }
        
        public string FullName { get; set; }
        
        public Guid? GroupId { get; set; }
    }
}
