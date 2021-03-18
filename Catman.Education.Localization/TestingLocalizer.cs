namespace Catman.Education.Localization
{
    using System;
    using Catman.Education.Localization.Extensions;

    public partial class Localizer
    {
        public string TestChecked(Guid id) =>
            _localizer["Test with id checked"].InjectId(id);

        public string TestingResultRetrieved(Guid testId, Guid studentId) =>
            _localizer["Testing result with testId and studentId retrieved"]
                .InjectTestId(testId)
                .InjectStudentId(studentId);
        
        public string TestingResultsRetrieved(int count) =>
            _localizer["Testing results retrieved"]
                .InjectCount(count);

        public string TestRetake(Guid testId, Guid studentId) =>
            _localizer["Test with id already passed by student with id"]
                .InjectTestId(testId)
                .InjectStudentId(studentId);

        public string TestingResultNotFound(Guid testId, Guid studentId) =>
            _localizer["Testing result with testId and studentId not found"]
                .InjectTestId(testId)
                .InjectStudentId(studentId);
    }
}
