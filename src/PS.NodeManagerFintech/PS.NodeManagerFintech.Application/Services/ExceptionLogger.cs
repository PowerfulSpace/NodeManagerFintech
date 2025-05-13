using Microsoft.AspNetCore.Http;
using PS.NodeManagerFintech.Application.Interfaces;
using PS.NodeManagerFintech.Application.Services.Interfaces;
using PS.NodeManagerFintech.Domain.Entities;
using System.Text;

namespace PS.NodeManagerFintech.Application.Services
{
    public class ExceptionLogger : IExceptionLogger
    {
        private readonly IExceptionLogRepository _repository;

        public ExceptionLogger(IExceptionLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> LogAsync(HttpContext context, Exception exception)
        {
            context.Request.EnableBuffering();

            string requestBody = await ReadRequestBodyAsync(context.Request);
            string queryString = context.Request.QueryString.ToString();

            var log = new ExceptionLog(
                exceptionType: exception.GetType().Name,
                requestPath: context.Request.Path,
                queryString: queryString,
                body: requestBody,
                stackTrace: exception.ToString()
            );

            await _repository.AddAsync(log);
            return log.Id;
        }

        private async Task<string> ReadRequestBodyAsync(HttpRequest request)
        {
            request.Body.Position = 0;
            using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            request.Body.Position = 0;
            return body;
        }
    }
}
