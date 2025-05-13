using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.NodeManagerFintech.Domain.Entities;

namespace PS.NodeManagerFintech.Infrastructure.Persistence.Configurations
{
    public class TreeNodeConfiguration : IEntityTypeConfiguration<TreeNode>
    {
        public void Configure(EntityTypeBuilder<TreeNode> builder)
        {
            builder.ToTable("TreeNodes");

            builder.Property(n => n.Id)
                .ValueGeneratedOnAdd();

            builder.HasKey(n => n.Id);

            builder.Property(n => n.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasOne(n => n.Parent)
                   .WithMany(p => p.Children)
                   .HasForeignKey(n => n.ParentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(t => t.TreeId);

            builder.HasIndex(t => t.ParentId);
        }
    }
}
