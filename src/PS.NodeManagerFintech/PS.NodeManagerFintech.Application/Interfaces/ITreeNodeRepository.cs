using PS.NodeManagerFintech.Domain.Entities;

namespace PS.NodeManagerFintech.Application.Interfaces
{
    public interface ITreeNodeRepository
    {
        Task<TreeNode?> GetByIdAsync(Guid id, CancellationToken cancellationToken, bool asNoTracking = false);
        Task AddAsync(TreeNode node, CancellationToken cancellationToken);
        void Remove(TreeNode node);
    }
}
