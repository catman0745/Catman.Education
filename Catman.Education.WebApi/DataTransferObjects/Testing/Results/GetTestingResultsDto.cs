namespace Catman.Education.WebApi.DataTransferObjects.Testing.Results
{
    using System;
    using Catman.Education.Application.Abstractions.Localization;
    using Catman.Education.WebApi.DataTransferObjects.Pagination;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;

    public class GetTestingResultsDto : PaginationInfoDto
    {
        [FromQuery(Name = "disciplineId")]
        public Guid? DisciplineId { get; set; }
    
        [FromQuery(Name = "testId")]
        public Guid? TestId { get; set; }
        
        [FromQuery(Name = "studentId")]
        public Guid? StudentId { get; set; }
    }

    public class GetTestingResultsDtoValidator : AbstractValidator<GetTestingResultsDto>
    {
        public GetTestingResultsDtoValidator(ILocalizer localizer)
        {
            Include(new PaginationInfoDtoValidator(localizer));
        }
    }
}
