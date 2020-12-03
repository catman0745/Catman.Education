namespace Catman.Education.Application.Results
{
    /// <summary> Validation result </summary>
    /// <remarks> Should only be used for requests validation </remarks>
    internal class RequestValidationResult
    {
        public static RequestValidationResult Valid() => new (null);

        public static RequestValidationResult Invalid(Error error) => new (error);
        
        public bool IsValid => Error == null;
        
        public Error Error { get; }
            
        private RequestValidationResult(Error error)
        {
            Error = error;
        }
    }
}
