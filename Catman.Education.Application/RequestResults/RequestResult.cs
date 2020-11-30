namespace Catman.Education.Application.RequestResults
{
    /// <summary> Request result </summary>
    /// <remarks> Either monad implementation </remarks>
    public abstract record RequestResult
    {
        private RequestResult() { }

        public sealed record Success : RequestResult;

        public sealed record Failure(Error Error) : RequestResult;
    }
}
