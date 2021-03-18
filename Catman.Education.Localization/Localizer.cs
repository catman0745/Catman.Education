namespace Catman.Education.Localization
{
    using Catman.Education.Application.Abstractions.Localization;
    using Microsoft.Extensions.Localization;

    public partial class Localizer : ILocalizer
    {
        public string this[string name] => _localizer[name];
        
        private readonly IStringLocalizer<Localizer> _localizer;

        public Localizer(IStringLocalizer<Localizer> localizer)
        {
            _localizer = localizer;
        }
    }
}
