namespace Catman.Education.Localization
{
    using System;
    using Catman.Education.Localization.Extensions;

    public partial class Localizer
    {
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
    }
}
