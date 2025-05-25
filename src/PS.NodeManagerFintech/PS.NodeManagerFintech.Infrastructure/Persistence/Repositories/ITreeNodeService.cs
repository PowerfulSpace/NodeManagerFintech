using Microsoft.EntityFrameworkCore;
using PS.NodeManagerFintech.Application.Interfaces;
using PS.NodeManagerFintech.Domain.Entities;

namespace PS.NodeManagerFintech.Infrastructure.Persistence.Repositories
{
    public class TreeNodeRepository : ITreeNodeRepository
    {
        private readonly AppDbContext _context;

        public TreeNodeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TreeNode?> GetByIdAsync(Guid id, CancellationToken cancellationToken, bool asNoTracking = false)
        {
            IQueryable<TreeNode> treeNodex = _context.TreeNodes.Include(n => n.Children);

            if (asNoTracking)
            {
                treeNodex = treeNodex.AsNoTracking();
            }

            return await treeNodex.FirstOrDefaultAsync(n => n.Id == id, cancellationToken);

        }

        public async Task AddAsync(TreeNode node, CancellationToken cancellationToken)
        {
            await _context.TreeNodes.AddAsync(node, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Remove(TreeNode node)
        {
            _context.TreeNodes.Remove(node);
            _context.SaveChanges();
        }
    }
}
