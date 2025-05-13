using Microsoft.EntityFrameworkCore;
using PS.NodeManagerFintech.Application.Interfaces;
using PS.NodeManagerFintech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.NodeManagerFintech.Infrastructure.Persistence.Repositories
{
    public class TreeNodeRepository : ITreeNodeRepository
    {
        private readonly AppDbContext _context;

        public TreeNodeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TreeNode?> GetByIdAsync(Guid id, bool asNoTracking = false)
        {
            IQueryable<TreeNode> treeNodex = _context.TreeNodes.Include(n => n.Children);

            if (asNoTracking)
            {
                treeNodex = treeNodex.AsNoTracking();
            }

            return await treeNodex.FirstOrDefaultAsync(n => n.Id == id);

        }

        public async Task AddAsync(TreeNode node)
        {
            await _context.TreeNodes.AddAsync(node);
            await _context.SaveChangesAsync();
        }

        public void Remove(TreeNode node)
        {
            _context.TreeNodes.Remove(node);
            _context.SaveChanges();
        }
    }
}
