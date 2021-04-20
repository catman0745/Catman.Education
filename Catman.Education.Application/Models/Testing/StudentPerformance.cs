namespace Catman.Education.Application.Models.Testing
{
    using System.Collections.Generic;
    using Catman.Education.Application.Entities.Testing;
    using Catman.Education.Application.Entities.Users;

    public class StudentPerformance
    {
        public class DisciplinePerformance
        {
            public double? TestCoverage { get; set; }
            
            public double? AverageAccuracy { get; set; }
        }
        
        public Student Student { get; set; }
        
        public IDictionary<Discipline, DisciplinePerformance> DisciplinesPerformance { get; set; }
    }
}
