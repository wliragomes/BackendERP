using Domain.Entities.Usuarios;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Funcionalidades.Atualizar
{
    public class AtualizarFuncionalidadeCommandHandler : IRequestHandler<AtualizarFuncionalidadeCommand, FormularioResponse<AtualizarFuncionalidadeCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarFuncionalidadeCommand> _validator;
        private const int _indice = 0;

        public AtualizarFuncionalidadeCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarFuncionalidadeCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarFuncionalidadeCommand>> Handle(AtualizarFuncionalidadeCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarFuncionalidadeCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var FuncionalidadeUpdate = await _unitOfWork.FuncionalidadeRepository.ObterPorId(command.Id);
            FuncionalidadeUpdate!.Update(command.Codigo, command.Nome);

            await RemoverRegistrosRelacionados(command.Id);

            var relacionaFuncionalidadeNivelAcesso = command.IdNivelAcesso
                .Select(item => new RelacionaFuncionalidadeNivelAcesso(command.Id, item))
                .ToList();

            await _unitOfWork.RelacionaFuncionalidadeNivelAcessoRepository.AdicionarEmMassa(relacionaFuncionalidadeNivelAcesso);
            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarFuncionalidadeCommand(
                command.Id,
                command.Codigo,
                command.Nome,
                command.IdNivelAcesso);

            response.SetFormulario(commandAtualizado);
            return response;
        }

        private async Task RemoverRegistrosRelacionados(Guid funcionalidadeId)
        {
            var enderecos = await _unitOfWork.RelacionaFuncionalidadeNivelAcessoRepository.ObterPorIdFuncionalidade(funcionalidadeId);
            if (enderecos.Any())
            {
                await _unitOfWork.RelacionaFuncionalidadeNivelAcessoRepository.RemoverEmMassa(enderecos!);
            }
        }
    }
}
