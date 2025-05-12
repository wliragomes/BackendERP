using Domain.Entities;
using Domain.Entities.Contatos;
using Domain.Entities.Emails;
using Domain.Entities.Enderecos;
using Domain.Entities.Financeiros;
using Domain.Entities.Pessoas;
using Domain.Entities.Produtos;
using Domain.Entities.Telefones;
using Domain.Entities.Vendas;
using Domain.Entities.Usuarios;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using Domain.Entities.VendasItem;
using Domain.Entities.Faturas;
using Domain.Entities.Impostos;
using Domain.Entities.Cfops;
using Domain.Entities.DashBoards;
using Domain.Entities.Empresas;
using Infra.Repositories;

namespace Infra.Context
{
    public class ApplicationDbContext : BaseDbContext<ApplicationDbContext>, INewUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }

        public DbSet<Users> User { get; set; }
        public DbSet<Funcionalidade> Funcionalidade { get; set; }
        public DbSet<NivelAcesso> NivelAcesso { get; set; }
        public DbSet<RelacionaFuncionalidadeNivelAcesso> RelacionaFuncionalidadeNivelAcesso { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Banco> Banco { get; set; }
        public DbSet<TipoConsumidor> TipoConsumidor { get; set; }
        public DbSet<TipoFechamento> TipoFechamento { get; set; }
        public DbSet<CstIcmsOrigemMaterial> CST_ICMS_Origem_Material { get; set; }
        public DbSet<CST_ICMS> CST_ICMS { get; set; }
        public DbSet<CstIpi> CST_IPI { get; set; }        
        public DbSet<Cofins> Cofins { get; set; }        
        public DbSet<Pis> Pis { get; set; }        
        public DbSet<Feriado> Feriado { get; set; }
        public DbSet<CentroCusto> CentroCusto { get; set; }
        public DbSet<CentroCustoContaAReceber> CentroCustoContaAReceber { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<AnaliseCredito> AnaliseCredito { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<DadosCobranca> DadosCobranca { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<RelacionaPessoaEndereco> RelacionaPessoaEndereco { get; set; }
        public DbSet<RelacionaPessoaTelefone> RelacionaPessoaTelefone { get; set; }
        public DbSet<RelacionaPessoaEmail> RelacionaPessoaEmail { get; set; }
        public DbSet<RelacionaPessoaContatoEndereco> RelacionaPessoaContatoEndereco { get; set; }
        public DbSet<RelacionaPessoaContatoTelefone> RelacionaPessoaContatoTelefone { get; set; }
        public DbSet<RelacionaDadosCobrancaTelefone> RelacionaDadosCobrancaTelefone { get; set; }
        public DbSet<RelacionaDadosCobrancaEndereco> RelacionaDadosCobrancaEndereco { get; set; }
        public DbSet<RelacionaUsuarioFuncionalidadeNivelAcesso> RelacionaUsuarioFuncionalidadeNivelAcesso { get; set; }
        public DbSet<TipoEndereco> TipoEndereco { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<Prateleira> Prateleira { get; set; }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<SetorProduto> SetorProduto { get; set; }
        public DbSet<Familia> Familia { get; set; }
        public DbSet<Subgrupo> Subgrupo { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<CodigoImportacao> CodigoImportacao { get; set; }
        public DbSet<TipoProduto> TipoProduto { get; set; }
        public DbSet<Rua> Rua { get; set; }
        public DbSet<TipoPreco> TipoPreco { get; set; }
        public DbSet<OrigemMaterial> OrigemMaterial { get; set; }
        public DbSet<Ncm> Ncm { get; set; }
        public DbSet<Origem> Origem { get; set; }        
        public DbSet<Regiao> Regiao { get; set; }
        public DbSet<SegmentoCliente> SegmentoCliente { get; set; }
        public DbSet<SegmentoEstrategico> SegmentoEstrategico { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<UnidadeMedida> UnidadeMedida { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<ImpressaoEspecial> ImpressaoEspecial { get; set; }
        public DbSet<VendaOrdemParceiro> VendaOrdemParceiro { get; set; }
        public DbSet<RelacionaFaturaVendaRecebimentoTipo> RelacionaFaturaVendaRecebimentoTipo { get; set; }
        public DbSet<VendaItem> VendaItem { get; set; }
        public DbSet<Cfop> Cfop {  get; set; }
        public DbSet<TipoFrete> TipoFrete {  get; set; }
        public DbSet<Venda> Cliente {  get; set; }
        public DbSet<Fatura> Fatura {  get; set; }
        public DbSet<FaturaItem> FaturaItem {  get; set; }
        public DbSet <PrecosTributacoes> PrecosTributacoes { get; set; }
        public DbSet<Composicao> Composicao { get; set; }
        public DbSet<DesgastePolimento> DesgastePolimento { get;  set; }
        public DbSet<ClasseReajuste> ClasseReajuste { get;  set; }
        public DbSet<RelacionaProdutoFornecedor> FornecedorProduto { get;  set; }
        public DbSet<NormaAbnt> NormaAbnt { get;  set; }      
        public DbSet<RelacionaNormaAbntVenda> RelacionaNormaAbntVenda { get;  set; }      
        public DbSet<VendaRecebimentoTipo> VendaRecebimentoTipo { get;  set; }         
        public DbSet<VendaRecebimentoParcela> VendaRecebimentoParcela { get;  set; }        
        public DbSet<Empresa> Empresa { get;  set; }        
        public DbSet<RegimeTributario> RegimeTributario { get;  set; }        
        public DbSet<FaturaParametro> FaturaParametro { get;  set; }        
        public DbSet<Modalidade> Modalidade { get;  set; }        
        public DbSet<Acabamento> Acabamento { get;  set; }        
        public DbSet<CodigoDDI> CodigoDDI { get;  set; }        
        public DbSet<Moeda> Moeda { get;  set; }        
        public DbSet<Projeto> Projeto { get;  set; }        
        public DbSet<MotivoReposicao> MotivoReposicao { get;  set; }        
        public DbSet<MotivoCancelamento> MotivoCancelamento { get;  set; }        
        public DbSet<ObraFase> ObraFase { get;  set; }        
        public DbSet<ObraOrigem> ObraOrigem { get;  set; }        
        public DbSet<ObraPadrao> ObraPadrao{ get;  set; }        
        public DbSet<ObraProjeto> ObraProjeto { get;  set; }        
        public DbSet<Parametro> Parametro { get;  set; }        
        public DbSet<MedidaJumbo> MedidaJumbo { get;  set; }        
        public DbSet<Classificacao> Classificacao { get;  set; }        
        public DbSet<Despesa> Despesa { get;  set; }        
        public DbSet<Operacao> Operacao{ get;  set; }        
        public DbSet<ContaAPagar> ContaAPagar { get;  set; }        
        public DbSet<PagarCentroCustoDespesa> PagarClassificacao { get;  set; }        
        public DbSet<ContaPagarLote> ContaPagarLote { get;  set; }
        public DbSet<ContaPagarLoteItem> ContaPagarLoteItem { get; set; }
        public DbSet<Cartao> Cartao { get;  set; }        
        public DbSet<ContaAPagarPago> ContaAPagarPago { get;  set; }        
        public DbSet<Caminhao> Caminhao { get;  set; }        
        public DbSet<TipoCarroceria> TipoCarroceria { get;  set; }        
        public DbSet<TipoRodado> TipoRodado { get;  set; }        
        public DbSet<FusoHorario> FusoHorario{ get;  set; }        
        public DbSet<CepBloqueado> CepBloqueado { get;  set; }         
        public DbSet<Chapa> Chapa { get;  set; }         
        public DbSet<ContaBancaria> ContaBancaria{ get;  set; }         
        public DbSet<MovimentoEstoque> MovimentoEstoque { get;  set; }         
        public DbSet<MinimoCobranca> MinimoCobranca { get;  set; }         
        public DbSet<MinimoCobrancaItem> MinimoCobrancaItem { get;  set; }         
        public DbSet<Representante> Representante { get;  set; }         
        public DbSet<ContaAReceber> ContaAReceber { get;  set; }         
        public DbSet<FluxoCaixa> FluxoCaixa { get;  set; }         
        public DbSet<Duplicata> Duplicata { get;  set; }         
        public DbSet<DuplicataParcela> DuplicataParcela { get;  set; }         
        public DbSet<OrdemFabricacao> OrdemFabricacao { get;  set; }         
        public DbSet<OrdemFabricacaoItem> OrdemFabricacaoItem { get;  set; }         
        public DbSet<OrdemFabricacaoArquivo> OrdemFabricacaoArquivo { get;  set; }         
        public DbSet<Status> Status { get;  set; }         
        public DbSet<Romaneio> Romaneio { get;  set; }         
        public DbSet<RomaneioItem> RomaneioItem { get;  set; }         
        public DbSet<Comissao> Comissao { get;  set; }         
        public DbSet<MedidaParametro> MedidaParametro { get;  set; }         
        public DbSet<OrdemFabricacaoItemTemporaria> OrdemFabricacaoItemTemporaria { get;  set; }         
        public DbSet<PlanoDeContas> PlanoDeContas { get;  set; }         
        public DbSet<FaturaTemporaria> FaturaTemporaria { get;  set; }         
        public DbSet<FaturaTemporariaItem> FaturaTemporariaItem { get;  set; }         
        public DbSet<DashBoard> DashBoard { get;  set; }         
        public DbSet<RelacionaEmpresaSocio> RelacionaEmpresaSocio { get;  set; }         
        public DbSet<RelacionaEmpresaFaturaParametro> RelacionaEmpresaFaturaParametro { get;  set; }         
        public DbSet<PlanejamentoProducao> PlanejamentoProducao { get;  set; }         
        public DbSet<ContaAReceberPago> ContaAReceberPago { get;  set; }         

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            builder.UseCollation("SQL_Latin1_General_CP1_CI_AI");
            //builder.RegistrarSeeds();
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
