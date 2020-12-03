namespace Catman.Education.Application.Exceptions
{
    using System;
    using Catman.Education.Application.Results;

    /// <summary> Request validation exception </summary>
    /// <remarks> Thrown if validation failed and failure result cannot be returned as response </remarks>
    public class ValidationException : Exception
    {
        public override string Message => "Validation error has occured"; 
        
        public Error ValidationError { get; }

        public ValidationException(Error error)
        {
            ValidationError = error;
        }
    }
}
