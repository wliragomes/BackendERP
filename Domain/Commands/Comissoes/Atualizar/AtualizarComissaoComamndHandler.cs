using Domain.Entities.Faturas;
using Domain.Entities.Vendas;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Comissoes.Atualizar
{
    public class AtualizarComissaoCommandHandler : IRequestHandler<AtualizarComissaoCommand, FormularioResponse<AtualizarComissaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarComissaoCommand> _validator;
        private const int _indice = 0;

        public AtualizarComissaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarComissaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarComissaoCommand>> Handle(AtualizarComissaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarComissaoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var ComissaoUpdate = await _unitOfWork.ComissaoRepository.ObterPorId(command.Id);

            ComissaoUpdate!.Update(
                command.IdVendedor,
                command.Comissaoo,
                command.ValorComissao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarComissaoCommand(
                command.Id,
                command.IdVendaRecebimentoTipo,
                command.IdContaAReceber,
                command.IdFatura,
                command.IdVendedor,
                command.Comissaoo,
                command.ValorComissao,
                command.ValorPago,
                command.DataEmissao,
                command.DataVencimento,
                command.DataPagamento,
                command.IdStatus);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}