using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

internal class OrdemFabricacaoItemTemporariaConfiguration : IEntityTypeConfiguration<OrdemFabricacaoItemTemporaria>
{
    public void Configure(EntityTypeBuilder<OrdemFabricacaoItemTemporaria> builder)
    {
        builder.ToTable("TB_TMP_ORDEM_FABRICACAO_ITEM_RESUMO");

        // Remova a definição de chave primária no campo Id
        // builder.HasKey(p => p.Id); - remover esta linha

        // Remova o índice único
        // builder.HasIndex(p => p.Id).IsUnique(); - remover esta linha

        // Adicione uma chave primária composta ou outra coluna como identidade
        builder.HasKey(p => new { p.Id, p.IdVenda, p.SqVendaItem }); // Exemplo de chave composta

        builder.Property(p => p.Id)
            .HasColumnName("CD_ORDEM_TMP")
            .IsRequired()
            .ValueGeneratedNever(); // Remova o ValueGeneratedOnAdd() para permitir IDs duplicados

        // Restante da configuração permanece igual
        builder.Property(p => p.IdVenda)
           .HasColumnName("CD_VENDA");
        builder.Property(p => p.SqVendaItem)
           .HasColumnName("SQ_VENDA_ITEM");
        builder.Property(p => p.Altura)
           .HasColumnName("NR_ALTURA");
        builder.Property(p => p.Largura)
           .HasColumnName("NR_LARGURA");
        builder.Property(p => p.ValorM2)
           .HasColumnName("VL_M2");
        builder.Property(p => p.Quantidade)
           .HasColumnName("QT_PECA");
        builder.Property(p => p.ValorPeso)
           .HasColumnName("VL_PESO");
        builder.Property(p => p.ValorMLinearReal)
           .HasColumnName("VL_M_LINEAR_REAL");
        builder.Property(p => p.ValorMLinear)
           .HasColumnName("VL_M_LINEAR");
        builder.HasQueryFilter(p => !p.Removed);
    }
}