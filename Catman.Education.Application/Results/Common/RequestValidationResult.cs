namespace Catman.Education.Application.Results.Common
{
    /// <summary> Validation result </summary>
    /// <remarks> Should only be used for requests validation </remarks>
    internal class RequestValidationResult
    {
        public static RequestValidationResult Valid() =>
            new (message: string.Empty, error: null);

        public static RequestValidationResult Invalid(string message, Error error) =>
            new (message, error);
        
        public bool IsValid => Error == null;
        
        public string Message { get; }
        
        public Error Error { get; }
            
        private RequestValidationResult(string message, Error error)
        {
            Message = message;
            Error = error;
        }
    }
}
