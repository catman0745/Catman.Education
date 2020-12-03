namespace Catman.Education.Application.PipelineBehaviors
{
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.Extensions.Logging;

    internal class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

        public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken _,
            RequestHandlerDelegate<TResponse> next)
        {
            var stopwatch = Stopwatch.StartNew();
            
            var response = await next();
            
            stopwatch.Stop();
            var requestName = request.GetType().Name;
            var elapsed = stopwatch.ElapsedMilliseconds;
            _logger.LogInformation($"Request {requestName} responded in {elapsed} ms");

            return response;
        }
    }
}
