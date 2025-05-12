using Domain.Entities.Contatos;
using Domain.Entities.Empresas;
using Domain.Entities.Produtos;
using Domain.Entities.Usuarios;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Pessoas
{
    public class Pessoa : EntityId
    {
        public Guid IdUsuario { get; private set; }
        public bool? Ativo { get; private set; }
        public bool? Cliente { get; private set; }
        public bool? Fornecedor { get; private set; }
        public bool? Juridica { get; private set; }
        public bool? Vendedor { get; private set; }
        public bool? Estrangeiro { get; private set; }
        public bool? Nacional { get; private set; }
        public bool? Usuario { get; private set; }
        public bool? Motorista { get; private set; }
        public string? CnpjCpf { get; private set; }
        public string RazaoSocial { get; private set; }
        public string? Fantasia { get; private set; }
        public Guid? IdRegiao { get; private set; }
        public Guid? IdVendedor { get; private set; }
        public string? InscricaoSuframa { get; private set; }
        public bool? EnviarEmail { get; private set; }
        public bool? EtiquetaUnit { get; private set; }
        public bool? ImprimeEtiqueta { get; private set; }
        public bool? EtiquetaPorLote { get; private set; }
        public Guid? IdOrigem { get; private set; }
        public Guid? IdSegmentoCliente { get; private set; }
        public Guid? IdSegmentoEstrategico { get; private set; }
        public string? InscricaoMunicipal { get; private set; }
        public string? InscricaoEstadual { get; private set; }
        public string? Cei { get; private set; }

        public bool? NaoContribuinte { get; private set; }
        public bool? EtiquetaEspecialGuardian { get; private set; }
        public Guid? IdTipoConsumidor { get; private set; }
        public bool? IncideSubstituicaoIcms { get; private set; }
        public bool? ConsumidorFinal { get; private set; }
        public bool? Industria { get; private set; }
        public bool? DigitarIcms { get; private set; }

        //--Credito comissao
        public bool? ClienteEspecial { get; private set; }
        public decimal? DescontoEspecial { get; private set; }
        public bool? PraticarLimiteCredito { get; private set; }
        public decimal? LimiteCredito { get; private set; }
        public bool? PraticarInadimplencia { get; private set; }
        public int? DiasTolerancia { get; private set; }
        public bool? ClienteBloqueado { get; private set; }
        public string? JustificativaBloqueado { get; private set; }
        public bool? ClienteSuspenso { get; private set; }
        public string? JustificativaSuspenso { get; private set; }
        public decimal? ComissaoRepresentante { get; private set; }
        public bool? ClienteNaoFlutuante { get; private set; }
        public bool? ExigeInspecaoAgucada { get; private set; }
        public bool? NaoExigirNumeroPedido { get; private set; }

        public Regiao? Regiao { get; private set; }
        public Origem? Origem { get; private set; }
        public SegmentoCliente? SegmentoCliente { get; private set; }
        public SegmentoEstrategico? SegmentoEstrategico { get; private set; }
        public Pessoa? Vendedores { get; private set; }
        public virtual Users? Usuarios { get; private set; }
        public virtual Users? UsuarioCadastro { get; private set; }
        
        public ICollection<RelacionaPessoaEndereco>? RelacionaPessoaEnderecos { get; private set; }
        public ICollection<RelacionaPessoaTelefone>? RelacionaPessoaTelefones { get; private set; }
        public ICollection<RelacionaPessoaEmail>? RelacionaPessoaEmails { get; private set; }
        public ICollection<RelacionaEmpresaSocio>? RelacionaEmpresaSocio { get; private set; }
        public ICollection<Contato>? Contatos { get; private set; }
        public ICollection<DadosCobranca>? DadosCobrancas { get; private set; }
        public ICollection<AnaliseCredito>? AnaliseCreditos { get; private set; }
        public ICollection<RelacionaProdutoFornecedor>? RelacionaProdutoFornecedor { get; set; }
        public virtual ContaAReceber ContaAReceber { get; private set; }
        public virtual ContaAPagar ContaAPagar { get; private set; }
        public virtual OrdemFabricacao OrdemFabricacao { get; private set; }
        public virtual FluxoCaixa FluxoCaixa { get; private set; }
        public virtual Duplicata? Duplicata { get; set; }


        public Pessoa() { }        

        public Pessoa(Guid idUsuario, bool ativo, bool cliente, bool fornecedor, bool juridica, bool estrangeiro, bool nacional, bool usuario, bool? vendedor, bool motorista, string cnpjCpf, string razaoSocial, string fantasia,
                      Guid? idRegiao, Guid? idVendedor, string inscricaoSuframa, bool enviarEmail, bool etiquetaUnit, bool imprimeEtiqueta, bool etiquetaPorLote,
                      Guid? idOrigem, Guid? idSegmentoCliente, Guid? idSegmentoEstrategico, string inscricaoMunicipal, string inscricaoEstadual, string cei,
                      bool naoContribuinte, bool etiquetaEspecialGuardian, Guid? idTipoConsumidor, bool incideSubstituicaoIcms, bool consumidorFinal, bool industria, bool digitarIcms,
                      bool clienteEspecial, decimal descontoEspecial, bool praticarLimiteCredito, decimal limiteCredito, bool praticarInadimplencia, int diasTolerancia,
                      bool clienteBloqueado, string justificativaBloqueado, bool clienteSuspenso, string justificativaSuspenso, decimal comissaoRepresentante, 
                      bool clienteNaoFlutuante, bool exigeInspecaoAgucada, bool naoExigirNumeroPedido)
        {
            SetId(Guid.NewGuid());
            IdUsuario = idUsuario;
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

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(bool? ativo)
        {
            Ativo = ativo;

            ChangeUpdateAtToDateTimeNow();
        }

        public void Update(Guid idUsuario, bool ativo, bool cliente, bool fornecedor, bool juridica, bool estrangeiro, bool nacional, bool usuario,  bool? vendedor, bool motorista, string cnpjCpf, string razaoSocial, string fantasia,
                      Guid? idRegiao, Guid? idVendedor, string inscricaoSuframa, bool enviarEmail, bool etiquetaUnit, bool imprimeEtiqueta, bool etiquetaPorLote,
                      Guid? idOrigem, Guid? idSegmentoCliente, Guid? idSegmentoEstrategico, string inscricaoMunicipal, string inscricaoEstadual, string cei,
                      bool naoContribuinte, bool etiquetaEspecialGuardian, Guid? idTipoConsumidor, bool incideSubstituicaoIcms, bool consumidorFinal, bool industria, bool digitarIcms,
                      bool clienteEspecial, decimal descontoEspecial, bool praticarLimiteCredito, decimal limiteCredito, bool praticarInadimplencia, int diasTolerancia,
                      bool clienteBloqueado, string justificativaBloqueado, bool clienteSuspenso, string justificativaSuspenso, decimal comissaoRepresentante,
                      bool clienteNaoFlutuante, bool exigeInspecaoAgucada, bool naoExigirNumeroPedido)
        {
            IdUsuario = idUsuario;
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

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
