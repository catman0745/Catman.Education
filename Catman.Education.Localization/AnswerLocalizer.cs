namespace Catman.Education.Localization
{
    using System;
    using Catman.Education.Localization.Extensions;

    public partial class Localizer
    {
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
    }
}
