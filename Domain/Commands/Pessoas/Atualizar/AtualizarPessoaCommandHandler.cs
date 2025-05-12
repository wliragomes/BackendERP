using Domain.Entities.Enderecos;
using Domain.Entities.Pessoas;
using Domain.Entities.Emails;
using Domain.Entities.Telefones;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;
using Domain.Entities.Contatos;
using System.Text;
using Domain.Entities.Usuarios;
using SharedKernel.Configuration.Cache;
using APIs.Security.JWT;
using Application.Interfaces.Auth;

namespace Domain.Commands.Pessoas.Atualizar
{
    public class AtualizarPessoaCommandHandler : IRequestHandler<AtualizarPessoaCommand, FormularioResponse<AtualizarPessoaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarPessoaCommand> _validator;
        private readonly ICacheProvider _cacheProvider;
        private readonly IUserService _userContext;
        private Users? _novoUser;
        private const int _indice = 0;

        public AtualizarPessoaCommandHandler(IUnitOfWork unitOfWork, 
            IValidator<AtualizarPessoaCommand> validator, 
            ICacheProvider cacheProvider,
            IUserService userContext)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _cacheProvider = cacheProvider;
            _userContext = userContext;
        }

        public async Task<FormularioResponse<AtualizarPessoaCommand>> Handle(AtualizarPessoaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarPessoaCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var pessoa = await _unitOfWork.PessoaRepository.ObterPorId(command.Id);

            var usuarioLogadoId = _userContext.GetUserId();

            pessoa!.Update(
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

            await AtualizarTabelasRalacionadasPessoa(command, pessoa.Id);

            await _unitOfWork.CommitAsync(cancellationToken);

            await AtualizaPermissoes(_novoUser);

            var commandAtualizado = new AtualizarPessoaCommand(
                pessoa.Id,
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
                command.Fantasia,
                command.IdRegiao,
                command.IdVendedor,
                command.InscricaoSuframa,
                command.EnviarEmail,
                command.EtiquetaUnit,
                command.ImprimeEtiqueta,
                command.EtiquetaPorLote,
                command.IdOrigem,
                command.IdSegmentoCliente,
                command.IdSegmentoEstrategico,
                command.InscricaoMunicipal,
                command.InscricaoEstadual,
                command.Cei,

                command.Enderecos,
                command.Telefones,
                command.Emails,

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
                command.JustificativaBloqueado,
                command.ClienteSuspenso,
                command.JustificativaSuspenso,
                command.ComissaoRepresentante,
                command.ClienteNaoFlutuante,
                command.ExigeInspecaoAgucada,
                command.NaoExigirNumeroPedido
            );

            response.SetFormulario(commandAtualizado);
            return response;
        }

        private async Task AtualizaPermissoes(Users? user)
        {
            if (user != null)
            {
                var credentials = await _unitOfWork.FunctionUserRepository.GetCredential(user.Id);
                TimeSpan _credentialsCacheExpiry = new TimeSpan(25, 0, 0);

                var redisIdToken = user.Id;

                if (await _cacheProvider.KeyExists<Token>(redisIdToken.ToString()))
                {
                    await _cacheProvider.DeleteKeyAsync<Token>(redisIdToken.ToString());
                    await _cacheProvider.SetAsync(redisIdToken.ToString(), credentials, _credentialsCacheExpiry);
                }
            }
        }

        private async Task AtualizarTabelasRalacionadasPessoa(AtualizarPessoaCommand command, Guid pessoaId)
        {
            // Primeiro remover todos os registros relacionados à pessoa
            await RemoverRegistrosRelacionados(pessoaId);

            // Após a remoção, criar os novos registros
            var enderecos = CriarEnderecos(command.Enderecos!);
            var relacionaPessoaEnderecos = enderecos.Select(e => new RelacionaPessoaEndereco(pessoaId, e.Id)).ToList();

            var telefones = CriarTelefones(command.Telefones!);
            var relacionaPessoaTelefones = telefones.Select(e => new RelacionaPessoaTelefone(pessoaId, e.Id)).ToList();

            var emails = CriarEmails(command.Emails!);
            var relacionaPessoaEmails = emails.Select(e => new RelacionaPessoaEmail(pessoaId, e.Id)).ToList();

            //--------------------
            if (command.Cliente || command.Fornecedor)
            {
                var emailsContato = CriarEmailsContato(command.Contatos!);
                emails.AddRange(emailsContato);

                var enderecosContato = CriarEnderecosContato(command.Contatos!);
                enderecos.AddRange(enderecosContato);

                var telefonesContato = CriarTelefonesContato(command.Contatos!);
                telefones.AddRange(telefonesContato);
                
                var contatos = await _unitOfWork.ContatoRepository.ObterPorIdPessoa(pessoaId);
                if (!contatos.Any())
                {
                    contatos = CriarContatos(command.Contatos!, pessoaId, emailsContato);
                    await _unitOfWork.ContatoRepository.AdicionarEmMassa(contatos);
                }
                else
                {
                    contatos[0]!.Update(pessoaId, command.Contatos[0].Nome, command.Contatos[0].Apelido, command.Contatos[0].IdDepartamento, command.Contatos[0].IdCargo, command.Contatos[0].Secretaria, command.Contatos[0].DataAniversario, emailsContato[0].Id);
                }

                var relacionaContatoEnderecos = enderecosContato.Select(e => new RelacionaPessoaContatoEndereco(contatos[0].Id, e.Id)).ToList();
                var relacionaContatoTelefones = telefonesContato.Select(e => new RelacionaPessoaContatoTelefone(contatos[0].Id, e.Id)).ToList();

                await _unitOfWork.RelacionaPessoaContatoEnderecoRepository.AdicionarEmMassa(relacionaContatoEnderecos);
                await _unitOfWork.RelacionaPessoaContatoTelefoneRepository.AdicionarEmMassa(relacionaContatoTelefones); 
            }
            else
            {
                var contatos = await _unitOfWork.ContatoRepository.ObterPorIdPessoa(pessoaId);
                if (contatos.Any())
                {
                    await _unitOfWork.ContatoRepository.RemoverEmMassa(contatos!);
                }
            }
            //--------------------
            var enderecosDadosDaCobranca = CriarEnderecos(command.DadosCobranca!.SelectMany(c => c.Enderecos!).ToList());
            enderecos.AddRange(enderecosDadosDaCobranca);

            var telefonesDadosDaCobranca = CriarTelefones(command.DadosCobranca!.SelectMany(c => c.Telefones!).ToList());
            telefones.AddRange(telefonesDadosDaCobranca);

            var dadosCobranca = command.DadosCobranca!.Select(e => new DadosCobranca(pessoaId, e.Responsavel ?? string.Empty)).ToList();

            var relacionaEnderecosDadosDaCobranca = enderecosDadosDaCobranca.Select(e => new RelacionaDadosCobrancaEndereco(dadosCobranca[0].Id, e.Id)).ToList();
            var relacionaTelefonesDadosDaCobranca = telefonesDadosDaCobranca.Select(e => new RelacionaDadosCobrancaTelefone(dadosCobranca[0].Id, e.Id)).ToList();

            //--------------------
            var analiseCredito = command.AnaliseCredito!.Select(e => new AnaliseCredito(
                pessoaId, e.DataConsulta, e.OrgaoConsulta, e.IdResponsavelConsulta, e.Observacao)).ToList();

            //--------------------
            if (command.Usuario)
            {
                _novoUser = await _unitOfWork.UserRepository.ObterPorIdPessoa(pessoaId);
                if (_novoUser == null)
                {
                    _novoUser = new Users(command.UserName!.Nome, Cifrar(command.UserName.Senha.ToUpper()), pessoaId);
                    await _unitOfWork.UserRepository.Add(_novoUser);
                }

                // Adicionar permissões (funcionalidade e níveis de acesso)
                var relacionaUsuarioPermissoes = new List<RelacionaUsuarioFuncionalidadeNivelAcesso>();

                foreach (var permissao in command.Permissao!)
                {
                    var funcionalidadeId = permissao.Funcionalidade.IdFuncionalidade;
                    foreach (var nivelAcesso in permissao.Funcionalidade.NivelAcesso)
                    {
                        relacionaUsuarioPermissoes.Add(new RelacionaUsuarioFuncionalidadeNivelAcesso(_novoUser.Id, funcionalidadeId, nivelAcesso.IdNivelAcesso));
                    }
                }

                await Removerpermissoes(_novoUser.Id);

                await _unitOfWork.RelacionaUsuarioFuncionalidadeNivelAcessoRepository.AdicionarEmMassa(relacionaUsuarioPermissoes);
            }
            else
            {
                var usuario = await _unitOfWork.UserRepository.ObterPorIdPessoa(pessoaId);
                if (usuario != null)
                {
                    await _unitOfWork.UserRepository.Remover(usuario!);

                    await Removerpermissoes(usuario.Id);

                    if (await _cacheProvider.KeyExists<Token>(usuario.Id.ToString()))
                    {
                        await _cacheProvider.DeleteKeyAsync<Token>(usuario.Id.ToString());
                    }
                }
            }
            //--------------------

            // Agora adicionar os novos registros
            await Task.WhenAll(
                _unitOfWork.EnderecoRepository.AdicionarEmMassa(enderecos),
                _unitOfWork.RelacionaPessoaEnderecoRepository.AdicionarEmMassa(relacionaPessoaEnderecos),
                _unitOfWork.TelefoneRepository.AdicionarEmMassa(telefones),
                _unitOfWork.RelacionaPessoaTelefoneRepository.AdicionarEmMassa(relacionaPessoaTelefones),
                _unitOfWork.EmailRepository.AdicionarEmMassa(emails),
                _unitOfWork.RelacionaPessoaEmailRepository.AdicionarEmMassa(relacionaPessoaEmails),
                //_unitOfWork.ContatoRepository.AdicionarEmMassa(contatos),
                //_unitOfWork.RelacionaPessoaContatoEnderecoRepository.AdicionarEmMassa(relacionaContatoEnderecos),
                //_unitOfWork.RelacionaPessoaContatoTelefoneRepository.AdicionarEmMassa(relacionaContatoTelefones),                
                _unitOfWork.DadosCobrancaRepository.AdicionarEmMassa(dadosCobranca),
                _unitOfWork.RelacionaDadosCobrancaEnderecoRepository.AdicionarEmMassa(relacionaEnderecosDadosDaCobranca),
                _unitOfWork.RelacionaDadosCobrancaTelefoneRepository.AdicionarEmMassa(relacionaTelefonesDadosDaCobranca),
                _unitOfWork.AnaliseCreditoRepository.AdicionarEmMassa(analiseCredito)
            );
        }

        private async Task Removerpermissoes(Guid usuarioId)
        {
            var permissoes = await _unitOfWork.RelacionaUsuarioFuncionalidadeNivelAcessoRepository.ObterPorIdUsuario(usuarioId);
            if (permissoes.Any())
            {
                await _unitOfWork.RelacionaUsuarioFuncionalidadeNivelAcessoRepository.RemoverEmMassa(permissoes);
            }
        }

        private async Task RemoverRegistrosRelacionados(Guid pessoaId)
        {
            var enderecos = await _unitOfWork.EnderecoRepository.ObterPorIdPessoa(pessoaId);
            if (enderecos.Any())
            {
                await _unitOfWork.EnderecoRepository.RemoverEmMassa(enderecos!);
            }

            var telefones = await _unitOfWork.TelefoneRepository.ObterPorIdPessoa(pessoaId);
            if (telefones.Any())
            {
                await _unitOfWork.TelefoneRepository.RemoverEmMassa(telefones!);
            }

            var emails = await _unitOfWork.EmailRepository.ObterPorIdPessoa(pessoaId);
            if (emails.Any())
            {
                await _unitOfWork.EmailRepository.RemoverEmMassa(emails!);
            }

            var enderecosRelacionados = await _unitOfWork.RelacionaPessoaEnderecoRepository.ObterPorIdPessoa(pessoaId);
            if (enderecosRelacionados.Any())
            {
                await _unitOfWork.RelacionaPessoaEnderecoRepository.RemoverEmMassa(enderecosRelacionados!);
            }

            var telefonesRelacionados = await _unitOfWork.RelacionaPessoaTelefoneRepository.ObterPorIdPessoa(pessoaId);
            if (telefonesRelacionados.Any())
            {
                await _unitOfWork.RelacionaPessoaTelefoneRepository.RemoverEmMassa(telefonesRelacionados!);
            }

            var emailsRelacionados = await _unitOfWork.RelacionaPessoaEmailRepository.ObterPorIdPessoa(pessoaId);
            if (emailsRelacionados.Any())
            {
                await _unitOfWork.RelacionaPessoaEmailRepository.RemoverEmMassa(emailsRelacionados!);
            }

            // ---
            var telefonesRelacionadosContato = await _unitOfWork.RelacionaPessoaContatoTelefoneRepository.ObterPorIdPessoa(pessoaId);
            if (telefonesRelacionadosContato.Any())
            {
                await _unitOfWork.RelacionaPessoaContatoTelefoneRepository.RemoverEmMassa(telefonesRelacionadosContato!);
            }

            var enderecosRelacionadosContato = await _unitOfWork.RelacionaPessoaContatoEnderecoRepository.ObterPorIdPessoa(pessoaId);
            if (enderecosRelacionadosContato.Any())
            {
                await _unitOfWork.RelacionaPessoaContatoEnderecoRepository.RemoverEmMassa(enderecosRelacionadosContato!);
            }

            //var contatosRelacionadosContato = await _unitOfWork.ContatoRepository.ObterPorIdPessoa(pessoaId);
            //if (contatosRelacionadosContato.Any())
            //{
            //    await _unitOfWork.ContatoRepository.RemoverEmMassa(contatosRelacionadosContato!);
            //}

            // --
            var telefonesRelacionadosDadosCobranca = await _unitOfWork.RelacionaDadosCobrancaTelefoneRepository.ObterPorIdPessoa(pessoaId);
            if (telefonesRelacionadosDadosCobranca.Any())
            {
                await _unitOfWork.RelacionaDadosCobrancaTelefoneRepository.RemoverEmMassa(telefonesRelacionadosDadosCobranca!);
            }

            var enderecosRelacionadosDadosCobranca = await _unitOfWork.RelacionaDadosCobrancaEnderecoRepository.ObterPorIdPessoa(pessoaId);
            if (enderecosRelacionadosDadosCobranca.Any())
            {
                await _unitOfWork.RelacionaDadosCobrancaEnderecoRepository.RemoverEmMassa(enderecosRelacionadosDadosCobranca!);
            }

            var dadosCobrancaRelacionados = await _unitOfWork.DadosCobrancaRepository.ObterPorIdPessoa(pessoaId);
            if (dadosCobrancaRelacionados.Any())
            {
                await _unitOfWork.DadosCobrancaRepository.RemoverEmMassa(dadosCobrancaRelacionados!);
            }

            // --
            var analisesCreditoRelacionadas = await _unitOfWork.AnaliseCreditoRepository.ObterPorIdPessoa(pessoaId);
            if (analisesCreditoRelacionadas.Any())
            {
                await _unitOfWork.AnaliseCreditoRepository.RemoverEmMassa(analisesCreditoRelacionadas!);
            }

            //var relacionaUsuarioFuncionalidadeNivelAcessoRepository = await _unitOfWork.RelacionaUsuarioFuncionalidadeNivelAcessoRepository.ObterPorIdPessoa(pessoaId);
            //if (relacionaUsuarioFuncionalidadeNivelAcessoRepository.Any())
            //{
            //    await _unitOfWork.RelacionaUsuarioFuncionalidadeNivelAcessoRepository.RemoverEmMassa(relacionaUsuarioFuncionalidadeNivelAcessoRepository!);
            //}
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