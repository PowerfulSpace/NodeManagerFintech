using Microsoft.AspNetCore.Http;

namespace PS.NodeManagerFintech.Application.Services.Interfaces
{
    public interface IExceptionLogger
    {
        Task<Guid> LogAsync(HttpContext context, Exception exception);
    }
}
