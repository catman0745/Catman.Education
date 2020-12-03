namespace Catman.Education.Application.Results
{
    /// <summary> Resource request result </summary>
    /// <remarks> Either monad implementation </remarks>
    public abstract record ResourceRequestResult<TResource>
    {
        private ResourceRequestResult() { }

        public sealed record Success(TResource Resource) : ResourceRequestResult<TResource>;

        public sealed record Failure(Error Error) : ResourceRequestResult<TResource>;
    }
}
