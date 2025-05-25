using Microsoft.EntityFrameworkCore;
using PS.NodeManagerFintech.Application.Interfaces;
using PS.NodeManagerFintech.Domain.Entities;

namespace PS.NodeManagerFintech.Infrastructure.Persistence.Repositories
{
    public class TreeRepository : ITreeRepository
    {
        private readonly AppDbContext _context;

        public TreeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tree?> GetByIdAsync(Guid id, CancellationToken cancellationToken, bool asNoTracking = false)
        {
            IQueryable<Tree> tree = _context.Trees.Include(t => t.Nodes);

            if (asNoTracking)
            {
                tree = tree.AsNoTracking();
            }

            return await tree.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Tree>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Trees
                .AsNoTracking()
                .Include(t => t.Nodes)
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Tree tree, CancellationToken cancellationToken)
        {
            await _context.Trees.AddAsync(tree, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveAsync(Tree tree, CancellationToken cancellationToken)
        {
            _context.Trees.Remove(tree);
            await _context.SaveChangesAsync();
        }
    }
}
