namespace Catman.Education.Application.Entities
{
    using System;

    public class TestingResult
    {
        public Guid StudentId { get; set; }
        
        public Guid TestId { get; set; }
        
        public int MaxScore { get; set; }
        
        public double ActualScore { get; set; }
        
        public Student Student { get; set; }
        
        public Test Test { get; set; }
    }
}
