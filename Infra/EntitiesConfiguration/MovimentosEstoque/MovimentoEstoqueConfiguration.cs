using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class MovimentoEstoqueConfiguration : IEntityTypeConfiguration<MovimentoEstoque>
    {
        public void Configure(EntityTypeBuilder<MovimentoEstoque> builder)
        {
            builder.ToTable("TB_TIPO_MOVIMENTO_ESTOQUE");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_TIPO_MOVIMENTO_ESTOQUE")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_TIPO_MOVIMENTO_ESTOQUE");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
