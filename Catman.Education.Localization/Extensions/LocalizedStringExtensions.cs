namespace Catman.Education.Localization.Extensions
{
    using System;
    using Microsoft.Extensions.Localization;

    internal static class LocalizedStringExtensions
    {
        public static LocalizedString Inject(this LocalizedString localizedString, string key, string value) =>
            new (localizedString.Name, localizedString.Value.Replace($"{{{key}}}", value));
        
        public static LocalizedString InjectId(this LocalizedString localizedString, Guid id) =>
            localizedString.Inject("id", id.ToString());

        public static LocalizedString InjectStudentId(this LocalizedString localizedString, Guid studentId) =>
            localizedString.Inject("studentId", studentId.ToString());

        public static LocalizedString InjectTestId(this LocalizedString localizedString, Guid testId) =>
            localizedString.Inject("testId", testId.ToString());

        public static LocalizedString InjectUsername(this LocalizedString localizedString, string username) =>
            localizedString.Inject("username", username);

        public static LocalizedString InjectCount(this LocalizedString localizedString, int count) =>
            localizedString.Inject("count", count.ToString());
    }
}
