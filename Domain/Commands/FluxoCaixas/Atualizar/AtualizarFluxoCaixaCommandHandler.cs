using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.FluxoCaixas.Atualizar
{
    public class AtualizarFluxoCaixaCommandHandler : IRequestHandler<AtualizarFluxoCaixaCommand, FormularioResponse<AtualizarFluxoCaixaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarFluxoCaixaCommand> _validator;
        private const int _indice = 0;

        public AtualizarFluxoCaixaCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarFluxoCaixaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarFluxoCaixaCommand>> Handle(AtualizarFluxoCaixaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarFluxoCaixaCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            if (command.ChequeCartao == 1)
            {
                command.IdCartao = null;
            }
            else
            {
                command.IdBanco = null;
                command.Agencia = null;
                command.DigitoAgencia = null;
                command.Conta = null;
                command.DigitoConta = null;
                command.DataVencimento = DateTime.Now;
            }

            var fluxoCaixa = await _unitOfWork.FluxoCaixaRepository.ObterPorId(command.Id);
            var saldoAnterior = fluxoCaixa!.ValorSaldo;

            var ultimoValorSaldo = await _unitOfWork.FluxoCaixaRepository.ObterPorIdUltimoValor();

            command.ValorSaldo = ultimoValorSaldo ?? - command.ValorLancamento;

                

            fluxoCaixa.Update(
                command.Caixa,
                command.IdOperacao,
                command.IdCliente,
                command.CreditoDebito,
                command.ChequeCartao,
                command.IdBanco,
                command.IdCartao,
                command.Agencia,
                command.DigitoAgencia,
                command.Conta,
                command.DigitoConta,
                command.NChequeComprovanteCartao,
                command.DataVencimento,
                command.ValorLancamento * -1,
                command.ValorSaldo,
                command.Historico
            );

            var contaAReceberUpdate = await _unitOfWork.ContaAReceberRepository.BuscarContaAReceberId(fluxoCaixa.IdContaAReceber);
            contaAReceberUpdate!.Update(
                command.IdCliente,
                command.NChequeComprovanteCartao,
                command.DataVencimento,
                command.ValorLancamento,
                command.IdBanco,
                command.Historico
            );

            await _unitOfWork.CommitAsync(cancellationToken);

            var sql = $"EXEC [dbo].[PR_ATUALIZA_FLUXO_CAIXA] '{command.Id}'";
            await _unitOfWork.ExecuteSqlRawAsync(sql, cancellationToken);


            var commandAtualizado = new AtualizarFluxoCaixaCommand(
                command.Id,
                command.Caixa,
                command.IdOperacao,
                command.IdCliente,
                command.CreditoDebito,
                command.ChequeCartao,
                command.IdBanco,
                command.IdCartao,
                command.Agencia,
                command.DigitoAgencia,
                command.Conta,
                command.DigitoConta,
                command.NChequeComprovanteCartao,
                command.DataVencimento,
                command.ValorLancamento,
                command.ValorSaldo,
                command.Historico,
                command.IdContaAReceber,
                command.IdContaAReceberPago
            );

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
