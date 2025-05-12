using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    internal class ParametroConfiguration : IEntityTypeConfiguration<Parametro>
    {
        public void Configure(EntityTypeBuilder<Parametro> builder)
        {
            builder.ToTable("TB_PARAMETRO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_PARAMETRO")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
               .HasColumnName("NM_PARAMETRO");

            builder.Property(p => p.Aba)
               .HasColumnName("NM_ABA");

            builder.Property(p => p.Descricao)
               .HasColumnName("DS_PARAMETRO_01");

            builder.Property(p => p.ExibirDescricao)
               .HasColumnName("FL_MOSTRAR_DS_PARAMETRO_01");

            builder.Property(p => p.BlocoDescricao)
               .HasColumnName("TX_BLOCO_DS_PARAMETRO_01");

            builder.Property(p => p.Descricao2)
               .HasColumnName("DS_PARAMETRO_02");

            builder.Property(p => p.ExibirDescricao2)
               .HasColumnName("FL_MOSTRAR_DS_PARAMETRO_02");

            builder.Property(p => p.BlocoDescricao2)
               .HasColumnName("TX_BLOCO_DS_PARAMETRO_02");

            builder.Property(p => p.Valor)
               .HasColumnName("VL_VALOR_01");

            builder.Property(p => p.ExibirValor)
               .HasColumnName("FL_MOSTRAR_VL_VALOR_01");

            builder.Property(p => p.BlocoValor)
               .HasColumnName("TX_BLOCO_VL_VALOR_01");

            builder.Property(p => p.Valor2)
               .HasColumnName("VL_VALOR_02");

            builder.Property(p => p.ExibirValor2)
               .HasColumnName("FL_MOSTRAR_VL_VALOR_02");

            builder.Property(p => p.BlocoValor2)
               .HasColumnName("TX_BLOCO_VL_VALOR_02");

            builder.Property(p => p.Verdade)
               .HasColumnName("FL_VERDADE");

            builder.Property(p => p.ExibirVerdade)
               .HasColumnName("FL_MOSTRAR_FL_VERDADE");

            builder.Property(p => p.BlocoVerdade)
               .HasColumnName("TX_BLOCO_FL_VERDADE");

            builder.Property(p => p.CaixaDeTexto)
               .HasColumnName("DS_CAIXA_TEXTO_01");

            builder.Property(p => p.ExibirCaixaDeTexto)
               .HasColumnName("FL_MOSTRAR_DS_CAIXA_TEXTO_01");

            builder.Property(p => p.Criptografado)
               .HasColumnName("FL_DS_CAIXA_TEXTO_CRIPTOGRAFIA_01");

            builder.Property(p => p.BlocoCaixaDeTexto)
               .HasColumnName("TX_BLOCO_DS_CAIXA_TEXTO_01");

            builder.Property(p => p.CaixaDeTexto2)
               .HasColumnName("DS_CAIXA_TEXTO_02");

            builder.Property(p => p.ExibirCaixaDeTexto2)
               .HasColumnName("FL_MOSTRAR_DS_CAIXA_TEXTO_02");

            builder.Property(p => p.Criptografado2)
               .HasColumnName("FL_DS_CAIXA_TEXTO_CRIPTOGRAFIA_02");

            builder.Property(p => p.BlocoCaixaDeTexto2)
               .HasColumnName("TX_BLOCO_DS_CAIXA_TEXTO_02");

            builder.Property(p => p.CaixaDeData)
               .HasColumnName("DT_CAIXA_DATA_01");

            builder.Property(p => p.ExibirCaixaDeData)
               .HasColumnName("FL_MOSTRAR_CAIXA_DATA_01");

            builder.Property(p => p.BlocoCaixaDeData)
               .HasColumnName("TX_BLOCO_DT_CAIXA_DATA_01");

            builder.Property(p => p.CaixaDeData2)
               .HasColumnName("DT_CAIXA_DATA_02");

            builder.Property(p => p.ExibirCaixaDeData2)
               .HasColumnName("FL_MOSTRAR_CAIXA_DATA_02");

            builder.Property(p => p.BlocoCaixaDeData2)
               .HasColumnName("TX_BLOCO_DT_CAIXA_DATA_02");

            builder.Property(p => p.Help)
               .HasColumnName("TX_HELP_TEXTO");

            builder.Property(p => p.ExibirHelp)
               .HasColumnName("FL_MOSTRAR_TX_HELP_TEXTO");

            builder.Property(p => p.BlocoHelp)
               .HasColumnName("TX_BLOCO_TX_HELP_TEXTO");

            builder.HasQueryFilter(p => !p.Removed);
        }
    }
}
