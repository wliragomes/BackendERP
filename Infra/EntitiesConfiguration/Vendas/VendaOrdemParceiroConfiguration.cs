using Domain.Entities.Vendas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration.Vendas
{
    public class VendaOrdemParceiroConfiguration : IEntityTypeConfiguration<VendaOrdemParceiro>
    {
        public void Configure(EntityTypeBuilder<VendaOrdemParceiro> builder)
        {
            builder.ToTable("TB_VENDA_ORDEM_PARCEIRO");
            builder.HasKey(rpe => new { rpe.IdVenda, rpe.IdCliente });

            builder.Property(vi => vi.IdVenda)
                .HasColumnName("CD_VENDA")
                .IsRequired();

            builder.Property(vi => vi.CaixilheiroObra)
                .HasColumnName("NR_CAIXILHEIRO_OBRA");

            builder.Property(vi => vi.IdCliente)
                .HasColumnName("CD_CLIENTE");

            builder.Property(vi => vi.IdEndereco)
                .HasColumnName("CD_ENDERECO");

            builder.Property(vi => vi.Observacao)
                .HasColumnName("TX_OBSERVACAO");

            //Relationships
            builder.HasOne(vi => vi.Venda)
                .WithMany(v => v.VendaOrdem)
                .HasForeignKey(vi => vi.IdVenda);

            builder.HasOne(v => v.Endereco)
                .WithMany()
                .HasForeignKey(v => v.IdEndereco)
                .OnDelete(DeleteBehavior.Cascade); // Cascade: deletar encadeado

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
