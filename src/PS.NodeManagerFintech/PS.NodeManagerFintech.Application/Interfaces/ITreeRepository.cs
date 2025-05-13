using PS.NodeManagerFintech.Domain.Entities;

namespace PS.NodeManagerFintech.Application.Interfaces
{
    public interface ITreeRepository
    {
        Task<Tree?> GetByIdAsync(Guid id, bool asNoTracking = false);
        Task<IEnumerable<Tree>> GetAllAsync();
        Task AddAsync(Tree tree);
        Task RemoveAsync(Tree tree);
    }
}
