using PS.NodeManagerFintech.Domain.Entities;

namespace PS.NodeManagerFintech.Application.Interfaces
{
    public interface ITreeRepository
    {
        Task<Tree?> GetByIdAsync(Guid id, CancellationToken cancellationToken, bool asNoTracking = false);
        Task<IEnumerable<Tree>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(Tree tree, CancellationToken cancellationToken);
        Task RemoveAsync(Tree tree, CancellationToken cancellationToken);
    }
}
