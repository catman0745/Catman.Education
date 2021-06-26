namespace Catman.Education.Application.Models.Testing.TestInfo
{
    using System;
    using Catman.Education.Application.Entities.Testing;

    public class TakenTestInfo : ITestInfo
    {
        public Guid Id { get; }
        
        public string Title { get; }

        public bool IsTaken => true;
        
        public int MaxScore { get; }
        
        public double ActualScore { get; }

        public TakenTestInfo(Test test, TestingResult testingResult)
        {
            Id = test.Id;
            Title = test.Title;
            MaxScore = testingResult.MaxScore;
            ActualScore = testingResult.ActualScore;
        }
    }
}
