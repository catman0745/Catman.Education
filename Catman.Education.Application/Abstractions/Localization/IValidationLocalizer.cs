namespace Catman.Education.Application.Abstractions.Localization
{
    public partial interface ILocalizer
    {
        string IncorrectPassword();

        string MustBeUnique();

        string ValidationError();

        string UnauthorizedError();

        string AccessViolationError();

        string UsernameRegexValidationErrorMessage();
    }
}
