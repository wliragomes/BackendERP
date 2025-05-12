using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;
namespace Domain.Commands.FluxoCaixas.Adicionar
{
    public class AdicionarFluxoCaixaCommandHandler : IRequestHandler<AdicionarFluxoCaixaCommand, FormularioResponse<AdicionarFluxoCaixaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AdicionarFluxoCaixaCommand> _validator;
        private const int _indice = 0;
        public AdicionarFluxoCaixaCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarFluxoCaixaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }
        public async Task<FormularioResponse<AdicionarFluxoCaixaCommand>> Handle(AdicionarFluxoCaixaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarFluxoCaixaCommand>(_indice, command, validationResult);

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
            var ultimoValorSaldo = await _unitOfWork.FluxoCaixaRepository.ObterPorIdUltimoValor();
            decimal saldoAtual = ultimoValorSaldo ?? 0;
            command.ValorSaldo = saldoAtual - command.ValorLancamento;

            Guid centroCusto = Guid.Parse("1382039D-5BA5-4BD9-9495-0E0B35B666AB");
            Guid despesa = Guid.Empty;

            if (command.ChequeCartao == 1)
            {
                despesa = Guid.Parse("D788C199-C8B8-4802-B055-CED7EB09E8D1");
            }

            if (command.ChequeCartao == 2)
            {
                despesa = Guid.Parse("31A0C38E-F59F-4F62-A914-A13949781ED9");
            }

            var contaAReceber = new ContaAReceber
            (
                false,
                false,
                command.IdCliente,
                command.NChequeComprovanteCartao,
                command.Caixa,
                command.DataVencimento,
                command.ValorLancamento,
                1,
                1,
                1,
                centroCusto,
                despesa,
                command.IdBanco,
                null,
                command.Historico
            );

            await _unitOfWork.ContaAReceberRepository.Adicionar(contaAReceber);
            await _unitOfWork.CommitAsync(cancellationToken);

            var fluxoCaixa = new FluxoCaixa
            (
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
                command.Historico,
                contaAReceber.Id,
                null
            );

            await _unitOfWork.FluxoCaixaRepository.Adicionar(fluxoCaixa);
            response.Formulario!.SetId(fluxoCaixa.Id);
            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }
    }
}