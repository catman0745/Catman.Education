namespace Catman.Education.Application.Exceptions
{
    using System;
    using Catman.Education.Application.Models.Result;

    /// <summary> Request validation exception </summary>
    /// <remarks> Thrown if validation failed and failure result cannot be returned as response </remarks>
    public class ValidationException : Exception
    {
        public Error ValidationError { get; }

        public ValidationException(Error error, string message)
            : base(message)
        {
            ValidationError = error;
        }
    }
}
