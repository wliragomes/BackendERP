using Domain.Commands.Vendas.Atualizar;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.DashBoard.Atualizar
{
    public class AtualizarPedidoCommandHandler : IRequestHandler<AtualizarPedidoCommand, FormularioResponse<AtualizarPedidoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarPedidoCommand> _validator;
        private const int _indice = 0;

        public AtualizarPedidoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarPedidoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarPedidoCommand>> Handle(AtualizarPedidoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarPedidoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            
            var pedidoUpdate = await _unitOfWork.DashBoardRepository.ObterPorId(command.Id);

            pedidoUpdate!.Update(command.IdStatus);

            await _unitOfWork.CommitAsync(cancellationToken);

            response.SetFormulario(command);
            return response;
        }
    }
}
