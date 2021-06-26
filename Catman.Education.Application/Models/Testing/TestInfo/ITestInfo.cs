namespace Catman.Education.Application.Models.Testing.TestInfo
{
    using System;

    public interface ITestInfo
    {
        Guid Id { get; }
        
        string Title { get; }
        
        bool IsTaken { get; }
    }
}
