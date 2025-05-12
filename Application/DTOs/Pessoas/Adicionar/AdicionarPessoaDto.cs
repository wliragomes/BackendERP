namespace Application.DTOs.Pessoas.Adicionar
{
    public class AdicionarPessoaDto 
    {
        public bool? Ativo { get; set; }
        public bool? Cliente { get; set; }
        public bool? Fornecedor { get; set; }
        public bool? Juridica { get; set; }
        public bool? Estrangeiro { get; set; }
        public bool? Nacional { get; set; }
        public bool? Usuario { get; set; }
        public bool? Vendedor { get; set; }
        public string? CnpjCpf { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Fantasia { get; set; }
        public Guid? IdRegiao { get; set; }
        public Guid? IdVendedor { get; set; }
        public string? InscricaoSuframa { get; set; }
        public bool? EnviarEmail { get; set; }
        public bool? EtiquetaUnit { get; set; }
        public bool? ImprimeEtiqueta { get; set; }
        public bool? EtiquetaPorLote { get; set; }
        public Guid? IdOrigem { get; set; }
        public Guid? IdSegmentoCliente { get; set; }
        public Guid? IdSegmentoEstrategico { get; set; }
        public string? InscricaoMunicipal { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? Cei { get; set; }

        public List<EnderecoDto>? Enderecos { get; set; }
        public List<TelefoneDto>? Telefones { get; set; }
        public List<EmailDto>? Emails { get; set; }

        public List<ContatoDto>? Contatos { get; set; }
        public List<DadosCobrancaDto>? DadosCobranca { get; set; }
        public List<AnaliseCreditoDto>? AnaliseCredito { get; set; }
        public UsuarioPessoaDto? UserName { get; set; }
        public List<PermissaoDto>? Permissao { get; set; }       
        //public List<TelefoneDto>? Telefones { get; set; }
        //public List<EmailDto>? Emails { get; set; }
        //public List<ContatoDto>? Contatos { get; set; }
        //public List<DadosCobrancaDto>? DadosDaCobranca { get; set; }
        //public CreditoComissaoDto? CreditoComissao { get; set; }
        public bool? ClienteEspecial { get; set; }
        public decimal? DescontoEspecial { get; set; }
        public bool PraticarLimiteCredito { get; set; }
        public decimal? LimiteCredito { get; set; }
        public bool PraticarInadimplencia { get; set; }
        public int? DiasTolerancia { get; set; }
        public bool ClienteBloqueado { get; set; }
        public string? JustificativaBloqueado { get; set; }
        public bool ClienteSuspenso { get; set; }
        public string? JustificativaSuspenso { get; set; }
        public decimal? ComissaoRepresentante { get; set; }
        public bool? ClienteNaoFlutuante { get; set; }
        public bool? ExigeInspecaoAgucada { get; set; }
        public bool? NaoExigirNumeroPedido { get; set; }
    }
}
