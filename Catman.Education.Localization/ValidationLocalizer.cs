namespace Catman.Education.Localization
{
    using Catman.Education.Localization.Extensions;

    public partial class Localizer
    {
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
    }
}
