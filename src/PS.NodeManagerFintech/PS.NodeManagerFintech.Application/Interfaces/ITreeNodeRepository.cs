using PS.NodeManagerFintech.Domain.Entities;

namespace PS.NodeManagerFintech.Application.Interfaces
{
    public interface ITreeNodeRepository
    {
        Task<TreeNode?> GetByIdAsync(Guid id, bool asNoTracking = false);
        Task AddAsync(TreeNode node);
        void Remove(TreeNode node);
    }
}
