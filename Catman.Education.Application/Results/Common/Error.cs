namespace Catman.Education.Application.Results.Common
{
    using System.Collections.Generic;

    /// <summary> Error result </summary>
    /// <remarks> All error result types </remarks>
    public abstract record Error
    {
        private Error() { }

        public sealed record NotFound : Error;

        public sealed record ValidationError(IDictionary<string, string> Errors) : Error;

        public sealed record Unauthorized : Error;

        public sealed record AccessViolation : Error;
    }
}
