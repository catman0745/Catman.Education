namespace Catman.Education.Application.Abstractions.Localization
{
    using System;
    
    public partial interface ILocalizer
    {
        string QuestionCreated(Guid id);
        
        string QuestionRetrieved(Guid id);
        
        string QuestionsRetrieved(int count);

        string QuestionUpdated(Guid id);

        string QuestionRemoved(Guid id);

        string QuestionNotFound(Guid id);
    }
}
