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

        public async Task<Tree?> GetByIdAsync(Guid id, bool asNoTracking = false)
        {
            IQueryable<Tree> tree = _context.Trees.Include(t => t.Nodes);

            if (asNoTracking)
            {
                tree = tree.AsNoTracking();
            }

            return await tree.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Tree>> GetAllAsync()
        {
            return await _context.Trees
                .AsNoTracking()
                .Include(t => t.Nodes)
                .ToListAsync();
        }

        public async Task AddAsync(Tree tree)
        {
            await _context.Trees.AddAsync(tree);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Tree tree)
        {
            _context.Trees.Remove(tree);
            await _context.SaveChangesAsync();
        }
    }
}
