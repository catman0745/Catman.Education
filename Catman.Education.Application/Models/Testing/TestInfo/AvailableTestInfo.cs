namespace Catman.Education.Application.Models.Testing.TestInfo
{
    using System;
    using Catman.Education.Application.Entities.Testing;

    public class AvailableTestInfo : ITestInfo
    {
        public Guid Id { get; }
        
        public string Title { get; }

        public bool IsTaken => false;

        public AvailableTestInfo(Test test)
        {
            Id = test.Id;
            Title = test.Title;
        }
    }
}
