using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.NodeManagerFintech.Domain.Entities;

namespace PS.NodeManagerFintech.Infrastructure.Persistence.Configurations
{
    public class TreeConfiguration : IEntityTypeConfiguration<Tree>
    {
        public void Configure(EntityTypeBuilder<Tree> builder)
        {
            builder.ToTable("Trees");

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                   .HasMaxLength(200);

            builder.HasMany(t => t.Nodes)
                   .WithOne(n => n.Tree)
                   .HasForeignKey(n => n.TreeId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
