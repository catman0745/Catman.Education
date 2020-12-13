namespace Catman.Education.Localization
{
    using System;
    using Catman.Education.Application.Interfaces;
    using Catman.Education.Localization.Extensions;
    using Microsoft.Extensions.Localization;

    internal class ApplicationLocalization : ILocalizer
    {
        public string this[string name] => _localizer[name];
        
        private readonly IStringLocalizer<ApplicationLocalization> _localizer;

        public ApplicationLocalization(IStringLocalizer<ApplicationLocalization> localizer)
        {
            _localizer = localizer;
        }
        
        #region Validation

        public string IncorrectPassword() =>
            _localizer["Incorrect password"];

        public string MustBeUnique() =>
            _localizer["Must be unique"];

        public string ValidationError() =>
            _localizer["Validation error"];

        public string UnauthorizedError() =>
            _localizer["Unauthorized error"];

        public string AccessViolationError() =>
            _localizer["Access violation error"];

        public string AccessViolationError(string requiredRole) =>
            _localizer["Access violation role error"].InjectRole(requiredRole);

        public string UsernameRegexValidationErrorMessage() =>
            _localizer["Username regex validation error message"];
        
        #endregion
        
        #region Admin

        public string AdminRegistered(Guid id) =>
            _localizer["Admin with id registered"].InjectId(id);

        public string AdminRetrieved(Guid id) =>
            _localizer["Admin with id retrieved"].InjectId(id);

        public string AdminUpdated(Guid id) =>
            _localizer["Admin with id updated"].InjectId(id);
        
        public string AdminNotFound(Guid id) =>
            _localizer["Admin with id not found"].InjectId(id);

        #endregion
        
        #region Answer

        public string AnswerCreated(Guid id) =>
            _localizer["Answer with id created"].InjectId(id);
        
        public string AnswerRetrieved(Guid id) =>
            _localizer["Answer with id retrieved"].InjectId(id);
        
        public string AnswersRetrieved(int count) =>
            _localizer["Answers retrieved"].InjectCount(count);

        public string AnswerUpdated(Guid id) =>
            _localizer["Answer with id updated"].InjectId(id);

        public string AnswerRemoved(Guid id) =>
            _localizer["Answer with id removed"].InjectId(id);

        public string AnswerNotFound(Guid id) =>
            _localizer["Answer with id not found"].InjectId(id);

        #endregion
        
        #region Discipline
        
        public string DisciplineCreated(Guid id) =>
            _localizer["Discipline with id created"].InjectId(id);
        
        public string DisciplineRetrieved(Guid id) =>
            _localizer["Discipline with id retrieved"].InjectId(id);
        
        public string DisciplinesRetrieved(int count) =>
            _localizer["Disciplines retrieved"].InjectCount(count);

        public string DisciplineUpdated(Guid id) =>
            _localizer["Discipline with id updated"].InjectId(id);

        public string DisciplineRemoved(Guid id) =>
            _localizer["Discipline with id removed"].InjectId(id);

        public string DisciplineNotFound(Guid id) =>
            _localizer["Discipline with id not found"].InjectId(id);
        
        #endregion
        
        #region Group

        public string GroupCreated(Guid id) =>
            _localizer["Group with id created"].InjectId(id);
        
        public string GroupRetrieved(Guid id) =>
            _localizer["Group with id retrieved"].InjectId(id);
        
        public string GroupsRetrieved(int count) =>
            _localizer["Groups retrieved"].InjectCount(count);

        public string GroupUpdated(Guid id) =>
            _localizer["Group with id updated"].InjectId(id);

        public string GroupRemoved(Guid id) =>
            _localizer["Group with id removed"].InjectId(id);

        public string GroupNotFound(Guid id) =>
            _localizer["Group with id not found"].InjectId(id);
        
        #endregion
        
        #region Question
        
        public string QuestionCreated(Guid id) =>
            _localizer["Question with id created"].InjectId(id);
        
        public string QuestionRetrieved(Guid id) =>
            _localizer["Question with id retrieved"].InjectId(id);
        
        public string QuestionsRetrieved(int count) =>
            _localizer["Questions retrieved"].InjectCount(count);

        public string QuestionUpdated(Guid id) =>
            _localizer["Question with id updated"].InjectId(id);

        public string QuestionRemoved(Guid id) =>
            _localizer["Question with id removed"].InjectId(id);

        public string QuestionNotFound(Guid id) =>
            _localizer["Question with id not found"].InjectId(id);
        
        #endregion
        
        #region Student
        
        public string StudentRegistered(Guid id) =>
            _localizer["Student with id registered"].InjectId(id);
        
        public string StudentRetrieved(Guid id) =>
            _localizer["Student with id retrieved"].InjectId(id);
        
        public string StudentsRetrieved(int count) =>
            _localizer["Students retrieved"].InjectCount(count);

        public string StudentUpdated(Guid id) =>
            _localizer["Student with id updated"].InjectId(id);

        public string StudentNotFound(Guid id) =>
            _localizer["Student with id not found"].InjectId(id);
        
        #endregion
        
        #region Test
        
        public string TestCreated(Guid id) =>
            _localizer["Test with id created"].InjectId(id);
        
        public string TestRetrieved(Guid id) =>
            _localizer["Test with id retrieved"].InjectId(id);
        
        public string TestsRetrieved(int count) =>
            _localizer["Tests retrieved"].InjectCount(count);

        public string TestUpdated(Guid id) =>
            _localizer["Test with id updated"].InjectId(id);

        public string TestRemoved(Guid id) =>
            _localizer["Test with id removed"].InjectId(id);

        public string TestNotFound(Guid id) =>
            _localizer["Test with id not found"].InjectId(id);
        
        #endregion
        
        #region User

        public string UserRetrieved(Guid id) =>
            _localizer["User with id retrieved"].InjectId(id);
        
        public string UsersRetrieved(int count) =>
            _localizer["Users retrieved"].InjectCount(count);
        
        public string UserRemoved(Guid id) =>
            _localizer["User with id created"].InjectId(id);
        
        public string TokenGenerated(string username) =>
            _localizer["Token for user with username generated"].InjectUsername(username);

        public string UserNotFound(Guid id) =>
            _localizer["User with id not found"].InjectId(id);
        
        public string UserNotFound(string username) =>
            _localizer["User with username not found"].InjectUsername(username);

        #endregion
    }
}
