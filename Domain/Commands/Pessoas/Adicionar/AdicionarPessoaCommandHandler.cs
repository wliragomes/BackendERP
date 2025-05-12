using Application.Interfaces.Auth;
using Domain.Entities.Contatos;
using Domain.Entities.Emails;
using Domain.Entities.Enderecos;
using Domain.Entities.Pessoas;
using Domain.Entities.Telefones;
using Domain.Entities.Usuarios;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;
using System.Text;

namespace Domain.Commands.Pessoas.Adicionar
{
    public class AdicionarPessoaCommandHandler : IRequestHandler<AdicionarPessoaCommand, FormularioResponse<AdicionarPessoaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AdicionarPessoaCommand> _validator;
        private readonly IUserService _userContext;
        private const int _indece = 0;

        public AdicionarPessoaCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarPessoaCommand> validator, IUserService userContext)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _userContext = userContext;
        }

        public async Task<FormularioResponse<AdicionarPessoaCommand>> Handle(AdicionarPessoaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarPessoaCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var usuarioLogadoId = _userContext.GetUserId();

            Pessoa pessoa = new
            (
                usuarioLogadoId,
                command.Ativo,
                command.Cliente,
                command.Fornecedor,
                command.Juridica,
                command.Estrangeiro,
                command.Nacional,
                command.Usuario,
                command.Vendedor,
                command.Motorista,
                command.CnpjCpf,
                command.RazaoSocial,
                command.Fantasia ?? string.Empty,
                command.IdRegiao,
                command.IdVendedor,
                command.InscricaoSuframa ?? string.Empty,
                command.EnviarEmail,
                command.EtiquetaUnit,
                command.ImprimeEtiqueta,
                command.EtiquetaPorLote,
                command.IdOrigem,
                command.IdSegmentoCliente,
                command.IdSegmentoEstrategico,
                command.InscricaoMunicipal ?? string.Empty,
                command.InscricaoEstadual ?? string.Empty,
                command.Cei ?? string.Empty,

                command.NaoContribuinte ?? false,
                command.EtiquetaEspecialGuardian ?? false,
                command.IdTipoConsumidor,
                command.IncideSubstituicaoIcms ?? false,
                command.ConsumidorFinal ?? false,
                command.Industria ?? false,
                command.DigitarIcms ?? false,

                command.ClienteEspecial,
                command.DescontoEspecial,
                command.PraticarLimiteCredito,
                command.LimiteCredito,
                command.PraticarInadimplencia,
                command.DiasTolerancia,
                command.ClienteBloqueado,
                command.JustificativaBloqueado ?? string.Empty,
                command.ClienteSuspenso,
                command.JustificativaSuspenso ?? string.Empty,
                command.ComissaoRepresentante,
                command.ClienteNaoFlutuante,
                command.ExigeInspecaoAgucada,
                command.NaoExigirNumeroPedido
            );

            var enderecos = CriarEnderecos(command.Enderecos!);
            var relacionaPessoaEnderecos = enderecos.Select(e => new RelacionaPessoaEndereco(pessoa.Id, e.Id)).ToList();

            var telefones = CriarTelefones(command.Telefones!);
            var relacionaPessoaTelefones = telefones.Select(e => new RelacionaPessoaTelefone(pessoa.Id, e.Id)).ToList();

            var emails = CriarEmails(command.Emails!);
            var relacionaPessoaEmails = emails.Select(e => new RelacionaPessoaEmail(pessoa.Id, e.Id)).ToList();

            //--------------------
            var emailsContato = CriarEmailsContato(command.Contatos!);
            emails.AddRange(emailsContato);

            var enderecosContato = CriarEnderecosContato(command.Contatos!);
            enderecos.AddRange(enderecosContato);

            var telefonesContato = CriarTelefonesContato(command.Contatos!);
            telefones.AddRange(telefonesContato);

            var contatos = CriarContatos(command.Contatos!, pessoa.Id, emailsContato);

            var relacionaContatoEnderecos = enderecosContato.Select(e => new RelacionaPessoaContatoEndereco(contatos[0].Id, e.Id)).ToList();
            var relacionaContatoTelefones = telefonesContato.Select(e => new RelacionaPessoaContatoTelefone(contatos[0].Id, e.Id)).ToList();

            //--------------------
            var enderecosDadosDaCobranca = CriarEnderecos(command.DadosCobranca!.SelectMany(c => c.Enderecos!).ToList());
            enderecos.AddRange(enderecosDadosDaCobranca);

            var telefonesDadosDaCobranca = CriarTelefones(command.DadosCobranca!.SelectMany(c => c.Telefones!).ToList());
            telefones.AddRange(telefonesDadosDaCobranca);

            var dadosCobranca = command.DadosCobranca!.Select(e => new DadosCobranca(pessoa.Id, e.Responsavel ?? string.Empty)).ToList();

            var relacionaEnderecosDadosDaCobranca = enderecosDadosDaCobranca.Select(e => new RelacionaDadosCobrancaEndereco(dadosCobranca[0].Id, e.Id)).ToList();
            var relacionaTelefonesDadosDaCobranca = telefonesDadosDaCobranca.Select(e => new RelacionaDadosCobrancaTelefone(dadosCobranca[0].Id, e.Id)).ToList();

            //--------------------
            var analiseCredito = command.AnaliseCredito!.Select(e => new AnaliseCredito(
                pessoa.Id, e.DataConsulta, e.OrgaoConsulta, e.IdResponsavelConsulta, e.Observacao)).ToList();

            //Criar usuario
            var userName = new Users(command.UserName!.Nome, Cifrar(command.UserName.Senha.ToUpper()), pessoa.Id);
            
            // Obter todas as funcionalidades e níveis de acesso
            var funcionalidades = command.Permissao!.Select(p => p.Funcionalidade.IdFuncionalidade).ToList();
            var niveisAcesso = command.Permissao!.SelectMany(p => p.Funcionalidade.NivelAcesso.Select(na => na.IdNivelAcesso)).ToList();

            // Criar a lista de relacionamentos
            var relacionaUsuarioFuncionalidadeNivelAcesso = funcionalidades
                .SelectMany(func => niveisAcesso, (func, nivel) => new RelacionaUsuarioFuncionalidadeNivelAcesso(userName.Id, func, nivel))
                .ToList();

            await Task.WhenAll(
                _unitOfWork.EnderecoRepository.AdicionarEmMassa(enderecos),
                _unitOfWork.RelacionaPessoaEnderecoRepository.AdicionarEmMassa(relacionaPessoaEnderecos),
                _unitOfWork.TelefoneRepository.AdicionarEmMassa(telefones),
                _unitOfWork.RelacionaPessoaTelefoneRepository.AdicionarEmMassa(relacionaPessoaTelefones),
                _unitOfWork.EmailRepository.AdicionarEmMassa(emails),
                _unitOfWork.RelacionaPessoaEmailRepository.AdicionarEmMassa(relacionaPessoaEmails),
                _unitOfWork.ContatoRepository.AdicionarEmMassa(contatos),
                _unitOfWork.RelacionaPessoaContatoEnderecoRepository.AdicionarEmMassa(relacionaContatoEnderecos),
                _unitOfWork.RelacionaPessoaContatoTelefoneRepository.AdicionarEmMassa(relacionaContatoTelefones),                
                _unitOfWork.DadosCobrancaRepository.AdicionarEmMassa(dadosCobranca),
                _unitOfWork.RelacionaDadosCobrancaEnderecoRepository.AdicionarEmMassa(relacionaEnderecosDadosDaCobranca),
                _unitOfWork.RelacionaDadosCobrancaTelefoneRepository.AdicionarEmMassa(relacionaTelefonesDadosDaCobranca),
                _unitOfWork.AnaliseCreditoRepository.AdicionarEmMassa(analiseCredito),
                _unitOfWork.UserRepository.Add(userName),
                _unitOfWork.RelacionaUsuarioFuncionalidadeNivelAcessoRepository.AdicionarEmMassa(relacionaUsuarioFuncionalidadeNivelAcesso)
            );

            await _unitOfWork.PessoaRepository.Adicionar(pessoa);

            response.Formulario!.SetId(pessoa.Id);

            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }

        private List<Endereco> CriarEnderecos(List<EnderecoCommand> enderecosCommand)
        {
            return enderecosCommand.Select(e => new Endereco(
                e.IdTipoEndereco, e.EnderecoDescricao, e.Numero, e.Complemento!,
                e.IdCidade, e.Bairro, e.IdUf, e.Cep)).ToList();
        }

        private List<Telefone> CriarTelefones(List<TelefoneCommand> telefonesCommand)
        {
            return telefonesCommand.Select(e => new Telefone(e.IdTipoTelefone, e.Numero)).ToList();
        }

        private List<Email> CriarEmails(List<EmailCommand> emailsCommand)
        {
            return emailsCommand.Select(e => new Email(e.IdTipoEmail, e.EnderecoEmail)).ToList();
        }

        private List<Email> CriarEmailsContato(List<ContatoCommand> contatosCommand)
        {
            return contatosCommand.Select(e => new Email(e.Email.IdTipoEmail, e.Email.EnderecoEmail)).ToList();
        }

        private List<Endereco> CriarEnderecosContato(List<ContatoCommand> contatosCommand)
        {
            return contatosCommand.SelectMany(c => c.Enderecos!
                .Select(e => new Endereco(
                    e.IdTipoEndereco, e.EnderecoDescricao, e.Numero, e.Complemento!,
                    e.IdCidade, e.Bairro, e.IdUf, e.Cep))
            ).ToList();
        }

        private List<Telefone> CriarTelefonesContato(List<ContatoCommand> contatosCommand)
        {
            return contatosCommand.SelectMany(c => c.Telefones!
                .Select(e => new Telefone(e.IdTipoTelefone, e.Numero))
            ).ToList();
        }

        private List<Contato> CriarContatos(List<ContatoCommand> contatosCommand, Guid idPessoa, List<Email> emailsContato)
        {
            return contatosCommand.Select((e, index) => new Contato(
                idPessoa, e.Nome, e.Apelido, e.IdDepartamento, e.IdCargo,
                e.Secretaria, e.DataAniversario, emailsContato[index].Id)).ToList();
        }

        private string Cifrar(string strTexto)
        {
            string strCifra = "";

            string strK1 = "2422512345987";
            int[] vntKey = new int[85] {233, 234, 235, 236, 237, 238, 239, 240, 241, 242,
                                        243, 244, 245, 246, 247, 248, 249, 250, 251, 252,
                                        253, 254, 255, 191, 190, 189, 188, 187, 186, 185,
                                        184, 183, 182, 181, 180, 179, 178, 177, 176, 175,
                                        174, 172, 171, 170, 169, 168, 167, 166, 165, 164,
                                        163, 162, 161, 033, 232, 035, 036, 037, 038, 039,
                                        040, 041, 042, 043, 044, 045, 046, 047, 126, 125,
                                        124, 123, 064, 063, 062, 061, 060, 059, 058, 096,
                                        095, 094, 093, 092, 091};

            for (int i = 1; i <= strTexto.Length; i++)
            {
                int j = i - (i / strK1.Length) * strK1.Length + 1;
                int m = Asc(strTexto.Substring(i - 1, 1)) - Convert.ToInt32(strK1.Substring(j - 1, 1));
                strCifra += Chr(vntKey[m - 38]);
            }

            return strCifra.Replace("'", "@@@");
        }

        static short Asc(string String)
        {
            // Utiliza a codificação Latin1 (ISO-8859-1)
            return Encoding.GetEncoding("ISO-8859-1").GetBytes(String)[0];
        }

        static string Chr(int CharCode)
        {
            if (CharCode > 255)
                throw new ArgumentOutOfRangeException(nameof(CharCode), CharCode, "CharCode deve estar entre 0 e 255.");
            // Utiliza a codificação Latin1 (ISO-8859-1)
            return Encoding.GetEncoding("ISO-8859-1").GetString(new[] { (byte)CharCode });
        }
    }
}
