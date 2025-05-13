using PS.NodeManagerFintech.Application.Interfaces;
using PS.NodeManagerFintech.Domain.Entities;

namespace PS.NodeManagerFintech.Infrastructure.Persistence.Repositories
{
    public class ExceptionLogRepository : IExceptionLogRepository
    {
        private readonly AppDbContext _context;

        public ExceptionLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ExceptionLog log)
        {
            await _context.ExceptionLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}
