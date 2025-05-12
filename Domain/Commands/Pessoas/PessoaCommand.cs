using Application.DTOs.Funcionalidades;
using SharedKernel.MediatR;

namespace Domain.Commands.Pessoas
{
    public abstract class PessoaCommand<T> : CommandBase<T>
    {
        public Guid Id { get; protected set; }
        public bool Ativo { get; protected set; }
        public bool Cliente { get; protected set; }
        public bool Fornecedor { get; protected set; }
        public bool Juridica { get; protected set; }
        public bool Estrangeiro { get; protected set; }
        public bool Nacional { get; protected set; }
        public bool Usuario { get; protected set; }
        public bool? Vendedor { get; protected set; }
        public bool Motorista { get; protected set; }
        public string CnpjCpf { get; protected set; }
        public string RazaoSocial { get; protected set; }
        public string? Fantasia { get; protected set; }
        public Guid? IdRegiao { get; protected set; }
        public Guid? IdVendedor { get; protected set; }
        public string? InscricaoSuframa { get; protected set; }
        public bool EnviarEmail { get; protected set; }
        public bool EtiquetaUnit { get; protected set; }
        public bool ImprimeEtiqueta { get; protected set; }
        public bool EtiquetaPorLote { get; protected set; }
        public Guid? IdOrigem { get; protected set; }
        public Guid? IdSegmentoCliente { get; protected set; }
        public Guid? IdSegmentoEstrategico { get; protected set; }
        public string? InscricaoMunicipal { get; protected set; }
        public string? InscricaoEstadual { get; protected set; }
        public string? Cei { get; protected set; }

        public List<EnderecoCommand>? Enderecos { get; set; }
        public List<TelefoneCommand>? Telefones { get; set; }
        public List<EmailCommand>? Emails { get; set; }

        public List<ContatoCommand>? Contatos {get; set; }
        public List<DadosCobrancaCommand>? DadosCobranca { get; set; }
        public List<AnaliseCreditoCommand>? AnaliseCredito { get; set; }
        public UsuarioPessoaCommand? UserName { get; set; }
        public List<PermissaoCommand>? Permissao { get; set; }        

        public bool? NaoContribuinte { get; protected set; }
        public bool? EtiquetaEspecialGuardian { get; protected set; }
        public Guid? IdTipoConsumidor { get; protected set; }
        public bool? IncideSubstituicaoIcms { get; protected set; }
        public bool? ConsumidorFinal { get; protected set; }
        public bool? Industria { get; protected set; }
        public bool? DigitarIcms { get; protected set; }

        public bool ClienteEspecial { get; set; }
        public decimal DescontoEspecial { get; set; }
        public bool PraticarLimiteCredito { get; set; }
        public decimal LimiteCredito { get; set; }
        public bool PraticarInadimplencia { get; set; }
        public int DiasTolerancia { get; set; }
        public bool ClienteBloqueado { get; set; }
        public string? JustificativaBloqueado { get; set; }
        public bool ClienteSuspenso { get; set; }
        public string? JustificativaSuspenso { get; set; }
        public decimal ComissaoRepresentante { get; set; }
        public bool ClienteNaoFlutuante { get; set; }
        public bool ExigeInspecaoAgucada { get; set; }
        public bool NaoExigirNumeroPedido { get; set; }

        public PessoaCommand()
        {

        }

        public PessoaCommand(Guid id, bool ativo, bool cliente, bool fornecedor, bool juridica, bool estrangeiro, bool nacional, bool usuario, bool? vendedor, bool motorista, string cnpjCpf, string razaoSocial,
                             string? fantasia, Guid? idRegiao, Guid? idVendedor, string? inscricaoSuframa, bool enviarEmail, bool etiquetaUnit, bool imprimeEtiqueta,
                             bool etiquetaPorLote, Guid? idOrigem, Guid? idSegmentoCliente, Guid? idSegmentoEstrategico, string? inscricaoMunicipal,
                             string? inscricaoEstadual, string? cei, 
                             List<EnderecoCommand>? enderecos, List<TelefoneCommand>? telefones, List<EmailCommand>? emails,
                             bool naoContribuinte, bool etiquetaEspecialGuardian, Guid? idTipoConsumidor, bool incideSubstituicaoIcms, bool consumidorFinal, bool industria, bool digitarIcms,
                             bool clienteEspecial, decimal descontoEspecial, bool praticarLimiteCredito, decimal limiteCredito, bool praticarInadimplencia, 
                             int diasTolerancia, bool clienteBloqueado, string? justificativaBloqueado, bool clienteSuspenso, string? justificativaSuspenso, 
                             decimal comissaoRepresentante, bool clienteNaoFlutuante, bool exigeInspecaoAgucada, bool naoExigirNumeroPedido)
        {
            Id = id;
            Ativo = ativo;
            Cliente = cliente;
            Fornecedor = fornecedor;
            Juridica = juridica;
            Estrangeiro = estrangeiro;
            Nacional = nacional;
            Usuario = usuario;
            Vendedor = vendedor;
            Motorista = motorista;
            CnpjCpf = cnpjCpf;
            RazaoSocial = razaoSocial;
            Fantasia = fantasia;
            IdRegiao = idRegiao;
            IdVendedor = idVendedor;
            InscricaoSuframa = inscricaoSuframa;
            EnviarEmail = enviarEmail;
            EtiquetaUnit = etiquetaUnit;
            ImprimeEtiqueta = imprimeEtiqueta;
            EtiquetaPorLote = etiquetaPorLote;
            IdOrigem = idOrigem;
            IdSegmentoCliente = idSegmentoCliente;
            IdSegmentoEstrategico = idSegmentoEstrategico;
            InscricaoMunicipal = inscricaoMunicipal;
            InscricaoEstadual = inscricaoEstadual;
            Cei = cei;

            Enderecos = enderecos;
            Telefones = telefones;
            Emails = emails;

            NaoContribuinte = naoContribuinte;
            EtiquetaEspecialGuardian = etiquetaEspecialGuardian;
            IdTipoConsumidor = idTipoConsumidor;
            IncideSubstituicaoIcms = incideSubstituicaoIcms;
            ConsumidorFinal = consumidorFinal;
            Industria = industria;
            DigitarIcms = digitarIcms;

            ClienteEspecial = clienteEspecial;
            DescontoEspecial = descontoEspecial;
            PraticarLimiteCredito = praticarLimiteCredito;
            LimiteCredito = limiteCredito;
            PraticarInadimplencia = praticarInadimplencia;
            DiasTolerancia = diasTolerancia;
            ClienteBloqueado = clienteBloqueado;
            JustificativaBloqueado = justificativaBloqueado;
            ClienteSuspenso = clienteSuspenso;
            JustificativaSuspenso = justificativaSuspenso;
            ComissaoRepresentante = comissaoRepresentante;
            ClienteNaoFlutuante = clienteNaoFlutuante;
            ExigeInspecaoAgucada = exigeInspecaoAgucada;
            NaoExigirNumeroPedido = naoExigirNumeroPedido;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
