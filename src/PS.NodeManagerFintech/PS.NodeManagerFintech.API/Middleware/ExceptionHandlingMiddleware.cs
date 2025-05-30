﻿using PS.NodeManagerFintech.Application.Services.Interfaces;
using PS.NodeManagerFintech.Domain.Exceptions;
using System.Net;

namespace PS.NodeManagerFintech.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IExceptionLogger exceptionLogger)
        {
            var cancellationToken = context.RequestAborted;
            try
            {
                await _next(context);
            }
            catch (SecureException ex)
            {
                await HandleSecureExceptionAsync(context, ex, exceptionLogger, cancellationToken);
            }
            catch (Exception ex)
            {
                await HandleGenericExceptionAsync(context, ex, exceptionLogger, cancellationToken);
            }
        }

        private async Task HandleSecureExceptionAsync(HttpContext context, SecureException ex, IExceptionLogger exceptionLogger, CancellationToken cancellationToken)
        {
            _logger.LogWarning(ex, "Secure exception occurred");
            var logId = await exceptionLogger.LogAsync(context, ex, cancellationToken);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(new
            {
                type = "Secure",
                id = logId,
                data = new { message = ex.Message }
            }, cancellationToken);
        }

        private async Task HandleGenericExceptionAsync(HttpContext context, Exception ex, IExceptionLogger exceptionLogger, CancellationToken cancellationToken)
        {
            _logger.LogError(ex, "Unhandled exception occurred");
            var logId = await exceptionLogger.LogAsync(context, ex, cancellationToken);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(new
            {
                type = "Exception",
                id = logId,
                data = new { message = $"Internal server error ID = {logId}" }
            }, cancellationToken);
        }
    }
}
