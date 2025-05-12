using Domain.Entities.Empresas;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Empresas.Atualizar
{
    public class AtualizarEmpresaCommandHandler : IRequestHandler<AtualizarEmpresaCommand, FormularioResponse<AtualizarEmpresaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarEmpresaCommand> _validator;
        private const int _indice = 0;

        public AtualizarEmpresaCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarEmpresaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarEmpresaCommand>> Handle(AtualizarEmpresaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarEmpresaCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var enderecoExistente = await _unitOfWork.EnderecoRepository.ObterPorId(command.IdEndereco);
            enderecoExistente!.Update(
                command.Endereco!.IdTipoEndereco,
                command.Endereco.EnderecoDescricao,
                command.Endereco.Numero,
                command.Endereco.Complemento!,
                command.Endereco.IdCidade,
                command.Endereco.Bairro,
                command.Endereco.IdUf,
                command.Endereco.Cep
            );

            var emailExistente = await _unitOfWork.EmailRepository.ObterPorId(command.IdEmail);
            emailExistente!.Update(
                command.Email!.IdTipoEmail,
                command.Email.EnderecoEmail
            );

            var telefoneExistente = await _unitOfWork.TelefoneRepository.ObterPorId(command.IdTelefone);
            telefoneExistente!.Update(
                command.Telefone!.IdTipoTelefone,
                command.Telefone.Numero
            );

            var empresaUpdate = await _unitOfWork.EmpresaRepository.ObterPorId(command.Id);
            empresaUpdate!.Update(
                command.CpfCnpj,
                command.InscricaoEstadual,
                command.InscricaoSuframa,
                command.RazaoSocial,
                command.NomeFantasia,
                command.IdRegimeTributario,
                command.IdEndereco,
                command.IdEmail,
                command.IdTelefone
            );

            var sociosExistentes = await _unitOfWork.RelacionaEmpresaSocioRepository.ObterPorIdEmpresa(command.Id);
            if (sociosExistentes.Any())
            {
                await _unitOfWork.RelacionaEmpresaSocioRepository.RemoverEmMassa(sociosExistentes);
            }
            var socios = CriarEmpresaSocios(command.Socios!, command.Id);


            var faturaParametroExistentes = await _unitOfWork.RelacionaEmpresaFaturaParametroRepository.ObterPorIdEmpresa(command.Id);
            if (faturaParametroExistentes.Any())
            {
                await _unitOfWork.RelacionaEmpresaFaturaParametroRepository.RemoverEmMassa(faturaParametroExistentes);
            }
            var faturasParametro = CriarEmpresaFaturaParametro(command.ParametroFatura!, command.Id);

            await _unitOfWork.RelacionaEmpresaSocioRepository.AdicionarEmMassa(socios);     
            await _unitOfWork.RelacionaEmpresaFaturaParametroRepository.AdicionarEmMassa(faturasParametro);     
            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarEmpresaCommand(
                command.Id,
                command.CpfCnpj,
                command.InscricaoEstadual,
                command.InscricaoSuframa,
                command.RazaoSocial,
                command.NomeFantasia,
                command.IdRegimeTributario,
                command.IdEndereco,
                command.IdEmail,
                command.IdTelefone
            );

            response.SetFormulario(commandAtualizado);
            return response;
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