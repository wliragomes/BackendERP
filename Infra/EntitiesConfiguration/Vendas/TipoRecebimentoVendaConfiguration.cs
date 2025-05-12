//using Domain.Entities.Vendas;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Infra.EntitiesConfiguration.Vendas
//{
//    public class TipoRecebimentoVendaConfiguration : IEntityTypeConfiguration<TipoRecebimentoVenda>
//    {
//        public void Configure(EntityTypeBuilder<TipoRecebimentoVenda> builder)
//        {
//            builder.ToTable("TB_VENDA_RECEBIMENTO_TIPO");
//            builder.HasKey(p => p.Id);
//            builder.HasIndex(p => p.Id).IsUnique();

//            builder.Property(p => p.Id)
//                .HasColumnName("CD_VENDA_RECEBIMENTO_TIPO")
//                .IsRequired()
//                .ValueGeneratedOnAdd();

//            builder.Property(p => p.Nome)
//               .HasColumnName("NM_VENDA_RECEBIMENTO_TIPO_RESUMIDO")
//               .IsRequired();
//        }
//    }
//}
