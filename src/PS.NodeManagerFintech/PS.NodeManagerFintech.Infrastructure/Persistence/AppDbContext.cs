using Microsoft.EntityFrameworkCore;
using PS.NodeManagerFintech.Domain.Entities;

namespace PS.NodeManagerFintech.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Tree> Trees => Set<Tree>();
        public DbSet<TreeNode> TreeNodes => Set<TreeNode>();
        public DbSet<ExceptionLog> ExceptionLogs => Set<ExceptionLog>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
