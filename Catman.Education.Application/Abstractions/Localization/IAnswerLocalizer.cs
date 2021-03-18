namespace Catman.Education.Application.Abstractions.Localization
{
    using System;
    
    public partial interface ILocalizer
    {
        string AnswerCreated(Guid id);
        
        string AnswerRetrieved(Guid id);
        
        string AnswersRetrieved(int count);

        string AnswerUpdated(Guid id);

        string AnswerRemoved(Guid id);

        string AnswerNotFound(Guid id);
    }
}
