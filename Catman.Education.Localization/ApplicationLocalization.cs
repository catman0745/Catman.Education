namespace Catman.Education.Localization
{
    using Catman.Education.Application.Interfaces;
    using Microsoft.Extensions.Localization;

    internal class ApplicationLocalization : ILocalizer
    {
        public string this[string name] => _localizer[name];
        
        private readonly IStringLocalizer<ApplicationLocalization> _localizer;

        public ApplicationLocalization(IStringLocalizer<ApplicationLocalization> localizer)
        {
            _localizer = localizer;
        }
    }
}
