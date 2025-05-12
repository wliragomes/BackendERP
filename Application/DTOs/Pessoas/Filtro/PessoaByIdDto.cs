using Application.DTOs.Funcionalidades;

namespace Application.DTOs.Pessoas.Filtro
{
    public class PessoaByIdDto
    {
        public Guid? Id { get; set; }
        public string? NomeUsuario { get; set; }
        public bool? Ativo { get; set; }
        public bool? Cliente { get; set; }
        public bool? Fornecedor { get; set; }
        public bool? Motorista { get; set; }
        public bool? Vendedor { get; set; }
        public bool? Juridica { get; set; }
        public bool? Estrangeiro { get; set; }
        public bool? Nacional { get; set; }
        public bool? Usuario { get; set; }
        public string? CnpjCpf { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Fantasia { get; set; }
        public PadraoIdDescricaoFilterDto? Regiao { get; set; }
        public Guid? IdVendedor { get; set; }
        public string? InscricaoSuframa { get; set; }
        public bool? EnviarEmail { get; set; }
        public bool? EtiquetaUnit { get; set; }
        public bool? ImprimeEtiqueta { get; set; }
        public bool? EtiquetaPorLote { get; set; }
        public PadraoIdDescricaoFilterDto? Origem { get; set; }
        public PadraoIdDescricaoFilterDto? SegmentoCliente { get; set; }
        public PadraoIdDescricaoFilterDto? SegmentoEstrategico { get; set; }
        public string? InscricaoMunicipal { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? Cei { get; set; }

        public bool? NaoContribuinte { get; set; }
        public bool? EtiquetaEspecialGuardian { get; set; }
        public Guid? IdTipoConsumidor { get; set; }
        public bool? IncideSubstituicaoIcms { get; set; }
        public bool? ConsumidorFinal { get; set; }
        public bool? Industria { get; set; }
        public bool? DigitarIcms { get; set; }

        public List<EnderecoFilterDto>? Enderecos { get; set; }
        public List<TelefoneFilterDto>? Telefones { get; set; }
        public List<EmailFilterDto>? Emails { get; set; }
        public List<ContatoFilterDto>? Contatos { get; set; }
        public List<DadosCobrancaFilterDto>? DadosDaCobranca { get; set; }
        //public CreditoComissaoDto? CreditoComissao { get; set; }
        public List<AnaliseCreditoFilterDto>? AnaliseCredito { get; set; }
        public UsuarioPessoaDto? UserName { get; set; }
        public List<PessoaFuncionalidadeDto>? Permissao { get; set; }

        public bool? ClienteEspecial { get; set; }
        public decimal? DescontoEspecial { get; set; }
        public bool? PraticarLimiteCredito { get; set; }
        public decimal? LimiteCredito { get; set; }
        public bool? PraticarInadimplencia { get; set; }
        public int? DiasTolerancia { get; set; }
        public bool? ClienteBloqueado { get; set; }
        public string? JustificativaBloqueado { get; set; }
        public bool? ClienteSuspenso { get; set; }
        public string? JustificativaSuspenso { get; set; }
        public decimal? ComissaoRepresentante { get; set; }
        public bool? ClienteNaoFlutuante { get; set; }
        public bool? ExigeInspecaoAgucada { get; set; }
        public bool? NaoExigirNumeroPedido { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
