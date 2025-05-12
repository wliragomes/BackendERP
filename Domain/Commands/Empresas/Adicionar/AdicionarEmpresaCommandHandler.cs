using Domain.Commands.Pessoas;
using Domain.Entities;
using Domain.Entities.Emails;
using Domain.Entities.Empresas;
using Domain.Entities.Enderecos;
using Domain.Entities.Telefones;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Empresas.Adicionar
{
    public class AdicionarEmpresaCommandHandler : IRequestHandler<AdicionarEmpresaCommand, FormularioResponse<AdicionarEmpresaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AdicionarEmpresaCommand> _validator;
        private const int _indice = 0;

        public AdicionarEmpresaCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarEmpresaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarEmpresaCommand>> Handle(AdicionarEmpresaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarEmpresaCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var endereco = CriarEndereco(command.Endereco!);
            await _unitOfWork.EnderecoRepository.Adicionar(endereco);

            Guid idEndereco = endereco.Id;

            var email = CriarEmail(command.Email!);
            await _unitOfWork.EmailRepository.Adicionar(email);

            Guid idEmail = email.Id;

            var telefone = CriarTelefone(command.Telefone!);
            await _unitOfWork.TelefoneRepository.Adicionar(telefone);

            Guid idTelefone = telefone.Id;

            await _unitOfWork.CommitAsync(cancellationToken);

            Empresa empresa = new
            (
                command.CpfCnpj,
                command.InscricaoEstadual,
                command.InscricaoSuframa,
                command.RazaoSocial,
                command.NomeFantasia,
                command.IdRegimeTributario,
                idEndereco,
                idEmail,
                idTelefone
            );

            await _unitOfWork.EmpresaRepository.Adicionar(empresa);

            await _unitOfWork.CommitAsync(cancellationToken);

            var relacionaEmpresaSocios = command.Socios != null && command.Socios.Any()
                ? CriarEmpresaSocios(command.Socios, empresa.Id)
                : new List<RelacionaEmpresaSocio>();

            var relacionaEmpresaFaturaParametro = command.ParametroFatura != null && command.ParametroFatura.Any()
                ? CriarEmpresaFaturaParametro(command.ParametroFatura, empresa.Id)
                : new List<RelacionaEmpresaFaturaParametro>();            

            if (relacionaEmpresaSocios.Any())
            {
                await _unitOfWork.RelacionaEmpresaSocioRepository.AdicionarEmMassa(relacionaEmpresaSocios);
            }

            if (relacionaEmpresaFaturaParametro.Any())
            {
                await _unitOfWork.RelacionaEmpresaFaturaParametroRepository.AdicionarEmMassa(relacionaEmpresaFaturaParametro);
            }

            response.Formulario!.SetId(empresa.Id);

            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }

        private Endereco CriarEndereco(EnderecoCommand enderecoCommand)
        {
            return new Endereco(
                enderecoCommand.IdTipoEndereco,
                enderecoCommand.EnderecoDescricao,
                enderecoCommand.Numero,
                enderecoCommand.Complemento!,
                enderecoCommand.IdCidade,
                enderecoCommand.Bairro,
                enderecoCommand.IdUf,
                enderecoCommand.Cep);
        }

        private Email CriarEmail(EmailCommand emailCommand)
        {
            return new Email(
                emailCommand.IdTipoEmail,
                emailCommand.EnderecoEmail);
        }

        private Telefone CriarTelefone(TelefoneCommand telefoneCommand)
        {
            return new Telefone(
                telefoneCommand.IdTipoTelefone,
                telefoneCommand.Numero);
        }

        private List<RelacionaEmpresaSocio> CriarEmpresaSocios(IEnumerable<SocioCommand> sociosCommand, Guid empresaId)
        {
            return sociosCommand.Select(socio => new RelacionaEmpresaSocio(
                empresaId,
                socio.IdSocio
            )).ToList();
        }

        private List<RelacionaEmpresaFaturaParametro> CriarEmpresaFaturaParametro(IEnumerable<ParametroFaturaCommand> faturaParametroCommand, Guid empresaId)
        {
            return faturaParametroCommand.Select(socio => new RelacionaEmpresaFaturaParametro(
                empresaId,
                socio.IdFaturaParametro
            )).ToList();
        }
    }
}