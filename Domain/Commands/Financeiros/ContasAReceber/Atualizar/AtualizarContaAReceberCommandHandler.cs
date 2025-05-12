using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasAReceber.Atualizar
{
    public class AtualizarContaAReceberCommandHandler : IRequestHandler<AtualizarContaAReceberCommand, FormularioResponse<AtualizarContaAReceberCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarContaAReceberCommand> _validator;
        private const int _indice = 0;

        public AtualizarContaAReceberCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarContaAReceberCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarContaAReceberCommand>> Handle(AtualizarContaAReceberCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarContaAReceberCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var ContaAReceberUpdate = await _unitOfWork.ContaAReceberRepository.ObterPorId(command.Id);
            ContaAReceberUpdate!.Update(
                command.Status,
                command.Rascunho,
                command.IdCliente,
                command.NDocumento,
                command.DataDocumento,
                command.DataVencimento,
                command.ValorDocumento,
                command.UnitarioPeriodoMensal,
                command.QtdParcela,
                command.QtdPeriodo,
                command.IdCentroDeCusto,
                command.IdDespesa,
                command.IdBanco,
                command.IdFatura,
                command.Historico);

            if (command.Status == true)
            {
                ContaAReceberPago contaAReceberPago = new
                (
                    command.Id,
                    1,
                    DateTime.Now,
                    command.ValorDocumento,
                    command.Historico,
                    command.NDocumento
                );

                await _unitOfWork.ContaAReceberPagoRepository.Adicionar(contaAReceberPago);

                var ultimoSaldo = await _unitOfWork.FluxoCaixaRepository.ObterPorIdUltimoValor();                    
                decimal valorSaldoAnterior = ultimoSaldo ?? 0;
                var novoSaldo = valorSaldoAnterior + command.ValorDocumento;

                FluxoCaixa fluxoCaixa = new
                (
                    DateTime.Now,
                    null,
                    command.IdCliente,
                    1,
                    2,
                    command.IdBanco,
                    null,
                    null,
                    null,
                    null,
                    null,
                    command.NDocumento,
                    command.DataVencimento,
                    command.ValorDocumento ?? 0,
                    novoSaldo ?? 0,
                    command.Historico!,
                    command.Id,
                    contaAReceberPago.Id
                );

                await _unitOfWork.FluxoCaixaRepository.Adicionar(fluxoCaixa);
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarContaAReceberCommand(
                command.Id,
                command.Status,
                command.Rascunho,
                command.IdCliente,
                command.NDocumento,
                command.DataDocumento,
                command.DataVencimento,
                command.ValorDocumento,
                command.UnitarioPeriodoMensal,
                command.QtdParcela,
                command.QtdPeriodo,
                command.IdCentroDeCusto,
                command.IdDespesa,
                command.IdBanco,
                command.IdFatura,
                command.Historico);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
