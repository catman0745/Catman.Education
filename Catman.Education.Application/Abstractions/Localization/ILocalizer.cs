namespace Catman.Education.Application.Abstractions.Localization
{
    public partial interface ILocalizer
    {
        string this[string name] { get; }
    }
}
