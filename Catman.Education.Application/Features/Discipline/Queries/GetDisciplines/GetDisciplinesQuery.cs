namespace Catman.Education.Application.Features.Discipline.Queries.GetDisciplines
{
    using System.Collections.Generic;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Models.Result;
    using MediatR;

    public class GetDisciplinesQuery : IRequest<ResourceRequestResult<ICollection<Discipline>>>
    {
        public string Title { get; set; }
        
        public int? Grade { get; set; }
    }
}
