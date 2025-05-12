using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasAPagarPago.Atualizar
{
    public class AtualizarContaAPagarPagoCommandHandler : IRequestHandler<AtualizarContaAPagarPagoCommand, FormularioResponse<AtualizarContaAPagarPagoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarContaAPagarPagoCommand> _validator;
        private const int _indice = 0;

        public AtualizarContaAPagarPagoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarContaAPagarPagoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarContaAPagarPagoCommand>> Handle(AtualizarContaAPagarPagoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarContaAPagarPagoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var ContaAPagarPagoUpdate = await _unitOfWork.ContaAPagarPagoRepository.ObterPorId(command.Id);
            ContaAPagarPagoUpdate!.Update(
                command.IdContaAPagar,
                command.NItem,
                command.Baixa,
                command.IdBanco,
                command.Agencia,
                command.AgenciaDigito,
                command.Conta,
                command.ContaDigito,
                command.ValorPago,
                command.DataOperacao,
                command.Historico,
                command.NDocumentoPago
                //command.Status
                );

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarContaAPagarPagoCommand(
                command.Id,
                command.IdContaAPagar,
                command.NItem,
                command.Baixa,
                command.IdBanco,
                command.Agencia,
                command.AgenciaDigito,
                command.Conta,
                command.ContaDigito,
                command.ValorPago,
                command.DataOperacao,
                command.Historico,
                command.NDocumentoPago
                /*command.Status*/);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
