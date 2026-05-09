using RajMango.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace RajMango.Infrastructure.Services
{
    public class ErrorHandler : IErrorHandler
    {
        private readonly ILogger<ErrorHandler> _logger;
        public ErrorHandler(ILogger<ErrorHandler> logger)
        {
            _logger = logger;
        }
        public void Handle(Exception ex)
        {
            var message = $"Error: {ex.Message} {Environment.NewLine} StackTrace: {ex.StackTrace}";
            _logger.LogError(message);
        }
    }
}
