namespace Catman.Education.WebApi.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    internal class NotEmptyAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} field must not be empty";

        public NotEmptyAttribute()
            : base(DefaultErrorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            return value switch
            {
                Guid guid => guid != Guid.Empty,
                _ => true
            };
        }
    }
}
