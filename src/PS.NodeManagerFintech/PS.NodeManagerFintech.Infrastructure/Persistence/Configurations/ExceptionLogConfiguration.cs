using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.NodeManagerFintech.Domain.Entities;

namespace PS.NodeManagerFintech.Infrastructure.Persistence.Configurations
{
    public class ExceptionLogConfiguration : IEntityTypeConfiguration<ExceptionLog>
    {
        public void Configure(EntityTypeBuilder<ExceptionLog> builder)
        {
            builder.ToTable("ExceptionLogs");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.ExceptionType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.RequestPath)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.QueryString)
                .IsRequired(false);

            builder.Property(e => e.Body)
                .IsRequired(false);

            builder.Property(e => e.StackTrace)
                .IsRequired();

            builder.Property(e => e.Timestamp)
                .IsRequired()
                .HasPrecision(3);

            builder.HasIndex(e => e.Timestamp);
            builder.HasIndex(e => e.ExceptionType);

        }
    }
}
