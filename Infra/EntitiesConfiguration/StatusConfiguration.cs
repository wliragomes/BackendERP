using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("TB_STATUS");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_STATUS")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Numero)
                .HasColumnName("NR_CODIGO");

            builder.Property(p => p.Descricao)
                .HasColumnName("DS_STATUS");
            
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
