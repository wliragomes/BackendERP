using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.MotivoCancelamentos.Atualizar
{
    public class AtualizarMotivoCancelamentoCommandHandler : IRequestHandler<AtualizarMotivoCancelamentoCommand, FormularioResponse<AtualizarMotivoCancelamentoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarMotivoCancelamentoCommand> _validator;
        private const int _indice = 0;

        public AtualizarMotivoCancelamentoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarMotivoCancelamentoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarMotivoCancelamentoCommand>> Handle(AtualizarMotivoCancelamentoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarMotivoCancelamentoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var MotivoCancelamentoUpdate = await _unitOfWork.MotivoCancelamentoRepository.ObterPorId(command.Id);
            MotivoCancelamentoUpdate!.Update(command.Nome, command.Descricao, command.Pedido, command.Orcamento, command.PedidoInativo, command.OrcamentoInativo);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarMotivoCancelamentoCommand(
                command.Id,
                command.Nome,
                command.Descricao,
                command.Pedido,
                command.Orcamento,
                command.PedidoInativo,
                command.OrcamentoInativo);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
