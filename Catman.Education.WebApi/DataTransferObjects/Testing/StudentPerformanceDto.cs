namespace Catman.Education.WebApi.DataTransferObjects.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class StudentPerformanceDto
    {
        public class DisciplinePerformanceDto
        {
            public double? TestCoverage { get; set; }
            
            public double? AverageAccuracy { get; set; }
        }
        
        [JsonPropertyName("studentId")]
        public Guid StudentId { get; set; }
        
        [JsonPropertyName("disciplinesPerformance")]
        public IDictionary<Guid, DisciplinePerformanceDto> DisciplinesPerformance { get; set; }
    }
}
