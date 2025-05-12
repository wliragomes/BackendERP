using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasAPagar.Atualizar
{
    public class AtualizarContaAPagarCommandHandler : IRequestHandler<AtualizarContaAPagarCommand, FormularioResponse<AtualizarContaAPagarCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarContaAPagarCommand> _validator;
        private const int _indice = 0;

        public AtualizarContaAPagarCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarContaAPagarCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarContaAPagarCommand>> Handle(AtualizarContaAPagarCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarContaAPagarCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            // Buscar a ContaAPagar existente
            var pagarClassificacaoUpdate = await _unitOfWork.PagarCentroCustoDespesaRepository.ObterPorId(command.Id);
            var ContaAPagarUpdate = await _unitOfWork.ContaAPagarRepository.ObterPorId(command.Id);
            if (ContaAPagarUpdate == null)
            {
                return response;
            }

            command.QtdParcela = 1;

            // Atualizar as informações da ContaAPagar
            ContaAPagarUpdate.Update(
                false,
                command.Rascunho,
                command.IdFornecedor,
                command.IdModalidade,
                command.NDocumento,
                command.DataDocumento,
                command.ValorDocumento,
                command.ValorSaldo,
                command.AntecipaDataPagamento,
                command.Resumo,
                command.UnitarioPeriodoMensal,
                command.LancadaDefinida,
                command.QtdParcela,
                command.QtdPeriodo,
                command.Reajuste,
                command.DataVencimento,
                command.IdBanco,
                command.Historico
            );

            var pagarCentroCustoDespesaParaRemover = await _unitOfWork.PagarCentroCustoDespesaRepository.ObterPorIdContaPagar(command.Id);
            if (pagarCentroCustoDespesaParaRemover.Any())
            {
                await _unitOfWork.PagarCentroCustoDespesaRepository.RemoverMassa(pagarCentroCustoDespesaParaRemover);
            }

            var pagarCentroCustoDespesas = CriarPagarCentroCustoDespesa(command.PagarCentroCustoDespesa!, command.Id);

            await _unitOfWork.PagarCentroCustoDespesaRepository.AdicionarEmMassa(pagarCentroCustoDespesas);

            // Commit das operações no banco
            await _unitOfWork.CommitAsync(cancellationToken);

            // Criar o comando atualizado para retornar na resposta
            var commandAtualizado = new AtualizarContaAPagarCommand(
                command.Id,
                command.Status,
                command.Rascunho,
                command.IdFornecedor,
                command.IdModalidade,
                command.NDocumento,
                command.DataDocumento,
                command.ValorDocumento,
                command.ValorSaldo,
                command.AntecipaDataPagamento,
                command.Resumo,
                command.UnitarioPeriodoMensal,
                command.LancadaDefinida,
                command.QtdParcela,
                command.QtdPeriodo,
                command.Reajuste,
                command.DataVencimento,
                command.IdBanco,
                command.Historico
            );

            response.SetFormulario(commandAtualizado);
            return response;
        }

        private List<PagarCentroCustoDespesa> CriarPagarCentroCustoDespesa(IEnumerable<PagarCentroCustoDespesaCommand> pagarCentroCustoDespesaCommands, Guid contaAPagarId)
        {
            return pagarCentroCustoDespesaCommands.Select(pagarCentroCustoDespesa => new PagarCentroCustoDespesa(
                contaAPagarId,
                pagarCentroCustoDespesa.NItem,
                pagarCentroCustoDespesa.IdDespesa,
                pagarCentroCustoDespesa.IdCentroDeCusto,
                pagarCentroCustoDespesa.ValorDespesa
            )).ToList();
        }
    }
}
