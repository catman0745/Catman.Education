namespace Catman.Education.Application.Models.Result
{
    /// <summary> Resource request result </summary>
    /// <remarks> Either monad implementation </remarks>
    public abstract class ResourceRequestResult<TResource>
    {
        private ResourceRequestResult() { }
        
        public abstract string Message { get; }

        public sealed class Success : ResourceRequestResult<TResource>
        {
            public override string Message { get; }
            
            public TResource Resource { get; }

            public Success(string message, TResource resource)
            {
                Message = message;
                Resource = resource;
            }
        }

        public sealed class Failure : ResourceRequestResult<TResource>
        {
            public override string Message { get; }

            public Error Error { get; }

            public Failure(string message, Error error)
            {
                Message = message;
                Error = error;
            }
        }
    }
}
