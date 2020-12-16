namespace Catman.Education.Application.Results.Common
{
    /// <summary> Request result </summary>
    /// <remarks> Either monad implementation </remarks>
    public abstract class RequestResult
    {
        private RequestResult() { }
        
        public abstract string Message { get; }

        public sealed class Success : RequestResult
        {
            public override string Message { get; }

            public Success(string message)
            {
                Message = message;
            }
        }

        public sealed class Failure : RequestResult
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
