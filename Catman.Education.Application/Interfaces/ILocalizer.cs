namespace Catman.Education.Application.Interfaces
{
    public interface ILocalizer
    {
        string this[string name] { get; }
    }
}
