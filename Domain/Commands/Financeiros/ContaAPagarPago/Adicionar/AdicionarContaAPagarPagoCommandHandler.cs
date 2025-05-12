using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasAPagarPago.Adicionar
{
    public class AdicionarContaAPagarPagoCommandHandler : IRequestHandler<AdicionarContaAPagarPagoCommand, FormularioResponse<AdicionarContaAPagarPagoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarContaAPagarPagoCommand> _validator;
        private const int _indece = 0;

        public AdicionarContaAPagarPagoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarContaAPagarPagoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarContaAPagarPagoCommand>> Handle(AdicionarContaAPagarPagoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarContaAPagarPagoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            ContaAPagarPago contaAPagarPago = new
            (
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
                //true
            );

            await _unitOfWork.ContaAPagarPagoRepository.Adicionar(contaAPagarPago);
            response.Formulario!.SetId(contaAPagarPago.Id);

            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }
    }
}
