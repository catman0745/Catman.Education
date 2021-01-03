namespace Catman.Education.WebApi.DataTransferObjects.Discipline
{
    using Microsoft.AspNetCore.Mvc;

    public class GetDisciplinesDto
    {
        [FromQuery(Name = "title")]
        public string Title { get; set; }
        
        [FromQuery(Name = "grade")]
        public int? Grade { get; set; }
    }
}
