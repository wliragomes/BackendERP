using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class PagarCentroCustoDespesaConfiguration : IEntityTypeConfiguration<PagarCentroCustoDespesa>
    {
        public void Configure(EntityTypeBuilder<PagarCentroCustoDespesa> builder)
        {
            builder.ToTable("TB_CONTA_PAGAR_CENTRO_CUSTO_TIPO_DESPESA");

            builder.HasKey(p => new { p.IdContaAPagar, p.NItem }); 

            // Propriedades
            builder.Property(p => p.IdContaAPagar)
                .HasColumnName("CD_CONTA_PAGAR")
                .IsRequired();  // A chave estrangeira é obrigatória

            builder.Property(p => p.NItem)
                .HasColumnName("NR_ITEM")
                .IsRequired();  // Parte da chave primária composta

            builder.Property(p => p.IdDespesa)
                .HasColumnName("CD_TIPO_DESPESA");

            builder.Property(p => p.IdCentroDeCusto)
                .HasColumnName("CD_CENTRO_CUSTO");

            builder.Property(p => p.ValorDespesa)
                .HasColumnName("VL_DOCUMENTO");

            builder.HasOne(p => p.ContaAPagar)  
                .WithMany(c => c.PagarCentroCustoDespesa) 
                .HasForeignKey(p => p.IdContaAPagar);

            builder.HasQueryFilter(p => !p.Removed);  
        }
    }
}
