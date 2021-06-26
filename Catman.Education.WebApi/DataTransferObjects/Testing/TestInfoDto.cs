namespace Catman.Education.WebApi.DataTransferObjects.Testing
{
    using System;

    public class TestInfoDto
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public bool IsTaken { get; set; }
        
        public int? MaxScore { get; set; }
        
        public double? ActualScore { get; set; }
    }
}
