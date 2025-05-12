using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.UnidadesMedidas.Atualizar
{
    public class AtualizarUnidadeMedidaCommandHandler : IRequestHandler<AtualizarUnidadeMedidaCommand, FormularioResponse<AtualizarUnidadeMedidaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarUnidadeMedidaCommand> _validator;
        private const int _indice = 0;

        public AtualizarUnidadeMedidaCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarUnidadeMedidaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarUnidadeMedidaCommand>> Handle(AtualizarUnidadeMedidaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarUnidadeMedidaCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var UnidadeMedidaUpdate = await _unitOfWork.UnidadeMedidaRepository.ObterPorId(command.Id);
            UnidadeMedidaUpdate!.Update(command.Id,command.Descricao, command.Sigla, command.CasaDecimal );

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarUnidadeMedidaCommand(
                command.Id,
                command.Descricao,
                command.Sigla,
                command.CasaDecimal);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
