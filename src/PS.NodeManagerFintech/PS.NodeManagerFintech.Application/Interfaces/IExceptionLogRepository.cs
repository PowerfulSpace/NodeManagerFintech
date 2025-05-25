using PS.NodeManagerFintech.Domain.Entities;

namespace PS.NodeManagerFintech.Application.Interfaces
{
    public interface IExceptionLogRepository
    {
        Task AddAsync(ExceptionLog log, CancellationToken cancellationToken);
    }
}
