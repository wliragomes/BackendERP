using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasAPagar.Adicionar
{
    public class AdicionarContaAPagarCommandHandler : IRequestHandler<AdicionarContaAPagarCommand, FormularioResponse<AdicionarContaAPagarCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarContaAPagarCommand> _validator;
        private const int _indece = 0;

        public AdicionarContaAPagarCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarContaAPagarCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarContaAPagarCommand>> Handle(AdicionarContaAPagarCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarContaAPagarCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            ContaPagarLote contaPagarLote = new ContaPagarLote();

            command.QtdParcela = command.QtdParcela == 0 ? 1 : command.QtdParcela;   
            
            var totalParcela = command.ContaPagarLote?.Sum(x => x.ValorLote) ?? 0;
            

            if (command.LancadaDefinida == 3 && command.QtdParcela >= 1)
            {

                if (totalParcela != command.ValorDocumento)
                {
                    response.AddError("Valor da parcela", "A somatórias das parcelas não pode ser diferente do Valor do Documento.", "");
                    return response;
                }
            }

            command.ValorDocumento =  command.ValorDocumento / command.QtdParcela;

            for (int i = 0; i < command.QtdParcela; i++)
            {
                if (command.LancadaDefinida == 3)
                {
                    if (command.ContaPagarLote![i].ValorLote <= 0)
                    {
                        response.AddError("Valor da parcela", "Nenhuma parcela pode ter valor menor ou igual a zero.", command.ContaPagarLote![i].ValorLote);
                        return response;
                    }
                }

                ContaAPagar contaAPagar = new
                (
                    false,
                    command.Rascunho,
                    command.IdFornecedor,
                    command.IdModalidade,
                    command.NDocumento,
                    command.DataDocumento,
                    command.LancadaDefinida == 3 ? command.ContaPagarLote![i].ValorLote : command.ValorDocumento,
                    command.ValorSaldo,
                    command.AntecipaDataPagamento,
                    command.Resumo,
                    command.UnitarioPeriodoMensal,
                    command.LancadaDefinida,
                    command.QtdParcela,
                    command.QtdPeriodo,
                    command.Reajuste,
                    command.LancadaDefinida == 3 ? command.ContaPagarLote![i].DataVencimentoLote : command.DataVencimento,
                    command.IdBanco,
                    command.Historico
                );

                ContaPagarLoteItem contaPagarLoteItem = new ContaPagarLoteItem(contaPagarLote.Id, contaAPagar.Id);

                var pagarCentroCustoDespesas = CriarPagarCentroCustoDespesa(command.PagarCentroCustoDespesa!, contaAPagar.Id);


                await _unitOfWork.ContaAPagarRepository.Adicionar(contaAPagar);
                await _unitOfWork.PagarCentroCustoDespesaRepository.AdicionarEmMassa(pagarCentroCustoDespesas);
                await _unitOfWork.ContaPagarLoteRepository.Adicionar(contaPagarLote);
                await _unitOfWork.ContaPagarLoteItemRepository.Adicionar(contaPagarLoteItem);
            }            

            await _unitOfWork.CommitAsync(cancellationToken);
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
