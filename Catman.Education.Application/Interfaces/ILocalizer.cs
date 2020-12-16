namespace Catman.Education.Application.Interfaces
{
    using System;

    public interface ILocalizer
    {
        string this[string name] { get; }
        
        #region Validation

        string IncorrectPassword();

        string MustBeUnique();

        string ValidationError();

        string UnauthorizedError();

        string AccessViolationError();

        string AccessViolationError(string requiredRole);

        string UsernameRegexValidationErrorMessage();
        
        #endregion
        
        #region Admin

        string AdminRegistered(Guid id);

        string AdminRetrieved(Guid id);

        string AdminUpdated(Guid id);
        
        string AdminNotFound(Guid id);

        #endregion
        
        #region Answer

        string AnswerCreated(Guid id);
        
        string AnswerRetrieved(Guid id);
        
        string AnswersRetrieved(int count);

        string AnswerUpdated(Guid id);

        string AnswerRemoved(Guid id);

        string AnswerNotFound(Guid id);

        #endregion
        
        #region Discipline
        
        string DisciplineCreated(Guid id);
        
        string DisciplineRetrieved(Guid id);
        
        string DisciplinesRetrieved(int count);

        string DisciplineUpdated(Guid id);

        string DisciplineRemoved(Guid id);

        string DisciplineNotFound(Guid id);
        
        #endregion
        
        #region Group
        
        string GroupCreated(Guid id);
        
        string GroupRetrieved(Guid id);
        
        string GroupsRetrieved(int count);

        string GroupUpdated(Guid id);

        string GroupRemoved(Guid id);

        string GroupNotFound(Guid id);
        
        #endregion
        
        #region Question
        
        string QuestionCreated(Guid id);
        
        string QuestionRetrieved(Guid id);
        
        string QuestionsRetrieved(int count);

        string QuestionUpdated(Guid id);

        string QuestionRemoved(Guid id);

        string QuestionNotFound(Guid id);
        
        #endregion
        
        #region Student
        
        string StudentRegistered(Guid id);
        
        string StudentRetrieved(Guid id);
        
        string StudentsRetrieved(int count);

        string StudentUpdated(Guid id);

        string StudentNotFound(Guid id);
        
        #endregion
        
        #region Test
        
        string TestCreated(Guid id);
        
        string TestRetrieved(Guid id);
        
        string TestsRetrieved(int count);

        string TestUpdated(Guid id);

        string TestRemoved(Guid id);

        string TestNotFound(Guid id);

        string TestChecked(Guid id);
        
        #endregion
        
        #region User

        string UserRetrieved(Guid id);
        
        string UsersRetrieved(int count);
        
        string UserRemoved(Guid id);
        
        string TokenGenerated(string username);

        string UserNotFound(Guid id);
        
        string UserNotFound(string username);

        #endregion
    }
}
