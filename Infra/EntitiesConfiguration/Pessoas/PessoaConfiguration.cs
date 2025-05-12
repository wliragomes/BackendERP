using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Pessoas;
using Domain.Entities.Usuarios;
using Domain.Entities.Faturas;

namespace Infra.EntitiesConfiguration.Pessoas
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("TB_PESSOA");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_PESSOA")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.IdUsuario)
                .HasColumnName("CD_USUARIO");

            builder.Property(p => p.Ativo)
                .HasColumnName("FL_ATIVO");

            builder.Property(p => p.Cliente)
                .HasColumnName("FL_CLIENTE");

            builder.Property(p => p.Fornecedor)
                .HasColumnName("FL_FORNECEDOR");

            builder.Property(p => p.Juridica)
                .HasColumnName("FL_JURIDICA");

            builder.Property(p => p.Vendedor)
                .HasColumnName("FL_VENDEDOR");

            builder.Property(p => p.Estrangeiro)
                .HasColumnName("FL_ESTRANGEIRO");

            builder.Property(p => p.Nacional)
                .HasColumnName("FL_NACIONAL");

            builder.Property(p => p.Usuario)
                .HasColumnName("FL_USUARIO");

            builder.Property(p => p.Motorista)
                .HasColumnName("FL_MOTORISTA");

            builder.Property(p => p.CnpjCpf)
                .HasColumnName("CD_CNPJ_CPF");

            builder.Property(p => p.RazaoSocial)
                .HasColumnName("NM_RAZAO_SOCIAL");

            builder.Property(p => p.Fantasia)
                .HasColumnName("NM_FANTASIA");

            builder.Property(p => p.IdRegiao)
                .HasColumnName("CD_REGIAO");

            builder.Property(p => p.IdVendedor)
                .HasColumnName("CD_VENDEDOR");

            builder.Property(p => p.InscricaoSuframa)
                .HasColumnName("CD_INSCRICAO_SUFRAMA");

            builder.Property(p => p.EnviarEmail)
                .HasColumnName("FL_ENVIAR_EMAIL");

            builder.Property(p => p.EtiquetaUnit)
                .HasColumnName("FL_ETIQUETA_UNIT");

            builder.Property(p => p.ImprimeEtiqueta)
                .HasColumnName("FL_IMPRIME_ETIQUETA");

            builder.Property(p => p.EtiquetaPorLote)
                .HasColumnName("FL_ETIQUETA_POR_LOTE");

            builder.Property(p => p.IdOrigem)
                .HasColumnName("CD_ORIGEM");

            builder.Property(p => p.IdSegmentoCliente)
                .HasColumnName("CD_SEGMENTO_CLIENTE");

            builder.Property(p => p.IdSegmentoEstrategico)
                .HasColumnName("CD_SEGMENTO_ESTRATEGICO");

            builder.Property(p => p.InscricaoMunicipal)
                .HasColumnName("CD_INSCRICAO_MUNICIPAL");

            builder.Property(p => p.InscricaoEstadual)
                .HasColumnName("CD_INSCRICAO_ESTADUAL");

            builder.Property(p => p.Cei)
                .HasColumnName("CD_CEI");

            builder.Property(p => p.NaoContribuinte)
                .HasColumnName("FL_NAO_CONTRIBUINTE");

            builder.Property(p => p.EtiquetaEspecialGuardian)
                .HasColumnName("FL_ETIQUETA_ESPECIAL_GUARDIAN");

            builder.Property(p => p.IdTipoConsumidor)
                .HasColumnName("CD_TIPO_CONSUMIDOR");
            
            builder.Property(p => p.IncideSubstituicaoIcms)
                .HasColumnName("FL_INCIDE_SUBSTITUICAO_ICMS");
            
            builder.Property(p => p.ConsumidorFinal)
                .HasColumnName("FL_CONSUMIDOR_FINAL");
            
            builder.Property(p => p.Industria)
                .HasColumnName("FL_INDUSTRIA");
            
            builder.Property(p => p.DigitarIcms)
                .HasColumnName("FL_DIGITAR_ICMS");

            builder.Property(p => p.ClienteEspecial)
                .HasColumnName("FL_CLIENTE_ESPECIAL");

            builder.Property(p => p.DescontoEspecial)
                .HasColumnName("VL_DESCONTO_ESPECIAL");

            builder.Property(p => p.PraticarLimiteCredito)
                .HasColumnName("FL_PRATICAR_LIMITE_CREDITO");

            builder.Property(p => p.LimiteCredito)
                .HasColumnName("VL_LIMITE_CREDITO");

            builder.Property(p => p.PraticarInadimplencia)
                .HasColumnName("FL_PRATICAR_INADIMPLENCIA");

            builder.Property(p => p.DiasTolerancia)
                .HasColumnName("NR_DIAS_TOLERANCIA");

            builder.Property(p => p.ClienteBloqueado)
                .HasColumnName("FL_CLIENTE_BLOQUEADO");

            builder.Property(p => p.JustificativaBloqueado)
                .HasColumnName("TX_JUSTIFICATIVA_BLOQUEADO");

            builder.Property(p => p.ClienteSuspenso)
                .HasColumnName("FL_CLIENTE_SUSPENSO");

            builder.Property(p => p.JustificativaSuspenso)
                .HasColumnName("TX_JUSTIFICATIVA_SUSPENSO");

            builder.Property(p => p.ComissaoRepresentante)
                .HasColumnName("PR_COMISSAO_REPRESENTANTE");

            builder.Property(p => p.ClienteNaoFlutuante)
                .HasColumnName("FL_CLIENTE_NAO_FLUTUANTE");

            builder.Property(p => p.ExigeInspecaoAgucada)
                .HasColumnName("FL_EXIGE_INSPECAO_AGUCADA");

            builder.Property(p => p.NaoExigirNumeroPedido)
                .HasColumnName("FL_NAO_EXIGIR_NUMERO_PEDIDO");

            builder.HasOne(e => e.Regiao)
                .WithMany()
                .HasForeignKey(e => e.IdRegiao);

            builder.HasOne(e => e.Origem)
                .WithMany()
                .HasForeignKey(e => e.IdOrigem);

            builder.HasOne(e => e.SegmentoCliente)
                .WithMany()
                .HasForeignKey(e => e.IdSegmentoCliente);

            builder.HasOne(e => e.SegmentoEstrategico)
                .WithMany()
                .HasForeignKey(e => e.IdSegmentoEstrategico);
            
            builder.HasOne(e => e.Vendedores)
                .WithMany()
                .HasForeignKey(e => e.IdVendedor);
           
            builder.HasOne(p => p.Usuarios)     // Uma pessoa pode ter um usuário
                .WithOne(u => u.Pessoa)        // Um usuário pertence a uma pessoa
                .HasForeignKey<Users>(u => u.IdPessoa)  // CD_PESSOA é a chave estrangeira em TB_USUARIO
                //.HasConstraintName("FK_Usuario_Pessoa") // Nome da constraint (opcional)
                .IsRequired(false);            // A relação é opcional, então não é obrigatória

            // Relacionamento 1:N - Pessoa cadastrada por um Usuário
            builder.HasOne(p => p.UsuarioCadastro)  // Uma Pessoa foi cadastrada por um Usuário
                .WithMany()                         // Um Usuário pode cadastrar várias Pessoas
                .HasForeignKey(p => p.IdUsuario)    // FK está em Pessoa (CD_USUARIO)
                .IsRequired(true)                    // Obrigatório, precisa registrar quem fez o cadastro
                .OnDelete(DeleteBehavior.Restrict);  // Restrição para não deletar usuários vinculados

            builder.HasQueryFilter(p => !p.Removed);

            

            //builder.HasMany(p => p.DadosCobranca)
            //   .WithOne(dc => dc.Pessoa)
            //   .HasForeignKey(dc => dc.IdPessoa)
            //   .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne<Origem>(p => p.Origem)
            //   .WithMany()
            //   .HasForeignKey(p => p.CD_ORIGEM)
            //   .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne<Regiao>(p => p.Regiao)
            //       .WithMany()
            //       .HasForeignKey(p => p.CD_REGIAO)
            //       .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne<SegmentoCliente>(p => p.SegmentoCliente)
            //       .WithMany()
            //       .HasForeignKey(p => p.CD_SEGMENTO_CLIENTE)
            //       .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne<SegmentoEstrategico>(p => p.SegmentoEstrategico)
            //       .WithMany()
            //       .HasForeignKey(p => p.CD_SEGMENTO_ESTRATEGICO)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
