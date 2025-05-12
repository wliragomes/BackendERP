using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ContaPagarLoteItemConfiguration : IEntityTypeConfiguration<ContaPagarLoteItem>
    {
        public void Configure(EntityTypeBuilder<ContaPagarLoteItem> builder)
        {
            // Configurando o nome da tabela
            builder.ToTable("TB_CONTA_PAGAR_LOTE_ITEM");

            // Configurando a chave primária composta
            builder.HasKey(p => new { p.IdContaPagarLote, p.IdContaAPagar }); // Definindo a chave composta com as duas chaves estrangeiras

            // Configurando as propriedades com os nomes das colunas
            builder.Property(p => p.IdContaPagarLote)
                .HasColumnName("CD_CONTA_PAGAR_LOTE");

            builder.Property(p => p.IdContaAPagar)
                .HasColumnName("CD_CONTA_PAGAR");

            builder.HasOne(p => p.ContaAPagarLote)
                .WithMany(p => p.ContaPagarLoteItem)
                .HasForeignKey(p => p.IdContaPagarLote);

            builder.HasOne(p => p.ContaAPagar)
                .WithMany(p => p.ContaPagarLoteItem)
                .HasForeignKey(p => p.IdContaAPagar);


            // Filtro para registros não removidos
            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
