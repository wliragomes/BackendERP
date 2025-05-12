using Domain.Entities.Faturas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Faturas
{
    public class RelacionaFaturaVendaRecebimentoTipoConfiguration : IEntityTypeConfiguration<RelacionaFaturaVendaRecebimentoTipo>
    {
        public void Configure(EntityTypeBuilder<RelacionaFaturaVendaRecebimentoTipo> builder)
        {
            builder.ToTable("TB_RELACIONA_FATURA_VENDA_RECEBIMENTO_TIPO");

            // Definição da chave primária
            builder.HasKey(f => f.IdVendaRecebimentoTipo);

            builder.HasIndex(f => f.IdVendaRecebimentoTipo).IsUnique();

            // Mapeamento das colunas
            builder.Property(f => f.IdVendaRecebimentoTipo)
                .HasColumnName("CD_VENDA_RECEBIMENTO_TIPO")
                .IsRequired();

            builder.Property(f => f.IdVenda)
                .HasColumnName("CD_VENDA")
                .IsRequired(false); 

            builder.Property(f => f.IdFatura)
                .HasColumnName("CD_FATURA")
                .IsRequired(false); 

            // Relacionamento com TB_VENDA
            builder.HasOne(f => f.Venda)
                .WithMany() // Sem navegação reversa em Venda
                .HasForeignKey(f => f.IdVenda)
                .OnDelete(DeleteBehavior.Restrict); // Evita deleção em cascata

            // Relacionamento com TB_FATURA
            builder.HasOne(f => f.Fatura)
                .WithOne(f => f.RelacionaFaturaVendaRecebimentoTipo) // Relacionamento 1:1
                .HasForeignKey<RelacionaFaturaVendaRecebimentoTipo>(f => f.IdFatura)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.VendaRecebimentoTipo)
                .WithOne(v => v.RelacionaFaturaVendaRecebimentoTipo)
                .HasForeignKey<RelacionaFaturaVendaRecebimentoTipo>(f => f.IdVendaRecebimentoTipo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(e => !e.Removed);
        }
    }
}
