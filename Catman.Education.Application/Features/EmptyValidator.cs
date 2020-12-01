namespace Catman.Education.Application.Features
{
    using FluentValidation;

    /// <summary> Performs no validation </summary>
    internal class EmptyValidator<TValidated> : AbstractValidator<TValidated>
    {
    }
}
