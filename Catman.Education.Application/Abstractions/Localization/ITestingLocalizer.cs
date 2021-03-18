namespace Catman.Education.Application.Abstractions.Localization
{
    using System;
    
    public partial interface ILocalizer
    {
        string TestChecked(Guid id);

        string TestingResultRetrieved(Guid testId, Guid studentId);
        
        string TestingResultsRetrieved(int count);

        string TestRetake(Guid testId, Guid studentId);

        string TestingResultNotFound(Guid testId, Guid studentId);
    }
}
