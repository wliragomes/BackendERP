using Domain.Commands.FaturaTemporarias.Adicionar;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.OrdensFabricacoes.Adicionar
{
    public class AdicionarFaturaTemporariaCommandHandler : IRequestHandler<AdicionarFaturaTemporariaCommand, FormularioResponse<AdicionarFaturaTemporariaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AdicionarFaturaTemporariaCommand> _validator;
        private const int _indece = 0;

        public AdicionarFaturaTemporariaCommandHandler(IUnitOfWork unitOfWork, IUnitOfWorkArquivos unitOfWorkArquivos, IValidator<AdicionarFaturaTemporariaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarFaturaTemporariaCommand>> Handle(AdicionarFaturaTemporariaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarFaturaTemporariaCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            FaturaTemporaria faturaTemporaria = new
            (
                command.IdEmpresa,
                command.IdPessoa,
                command.ValorFrete,
                command.ValorSeguro,
                command.ValorOutrasDespesas,
                command.PrIcms,
                command.ValorIcms,
                command.ValorPis,
                command.ValorIpi,
                command.ValorCofins,
                command.BaseCalculoSt,
                command.ValorSt,
                command.ValorTotalProduto,
                command.ValorTotalNota
            );             

            var faturaTemporariaItens = command.FaturaTemporariaItem != null && command.FaturaTemporariaItem.Any()
                ? CriarFaturaTemporariaItem(command.FaturaTemporariaItem, faturaTemporaria.Id)
                : new List<FaturaTemporariaItem>();

            await _unitOfWork.FaturaTemporariaRepository.Adicionar(faturaTemporaria);            

            if (faturaTemporariaItens.Any())
            {
                await _unitOfWork.FaturaTemporariaItemRepository.AdicionarEmMassa(faturaTemporariaItens);
            }

            response.Formulario!.SetId(faturaTemporaria.Id);

            await _unitOfWork.CommitAsync(cancellationToken);

            ////-----------
            //var commandAtualizado = new AdicionarFaturaTemporariaCommand(
            //    command.Id,
            //    );

            // Executa a procedure e retorna os cálculos
            var resultadoImpostos = await _unitOfWork.FaturaTemporariaItemRepository.CalcularImpostosFaturaTemporariaAsync(faturaTemporaria.Id);

            // Alimenta o próprio objeto AdicionarFaturaTemporariaCommand com os valores da linha "TOTAL"
            var total = resultadoImpostos.FirstOrDefault(x => x.TABELA == "TOTAL");

            if (total != null)
            {
                command.ValorFrete = total.VL_FRETE ?? 0;
                command.ValorSeguro = total.VL_SEGURO ?? 0;
                command.ValorOutrasDespesas = total.VL_OUTRAS_DESPESAS ?? 0;
                command.PrIcms = total.PR_ICMS ?? 0;
                command.BaseCalculoIcms = total.VL_BASE_CALCULO_ICMS ?? 0;
                command.ValorIcms = total.VL_ICMS_PRODUTO ?? 0;
                command.ValorIpi = total.VL_IPI ?? 0;
                command.ValorPis = total.VL_PIS ?? 0;
                command.ValorCofins = total.VL_COFINS ?? 0;
                command.BaseCalculoSt = total.VL_BASE_CALCULO_ST ?? 0;
                command.ValorSt = total.VL_ST ?? 0;
                command.ValorTotalProduto = total.VL_TOTAL_PRODUTO ?? 0;
                command.ValorTotalNota = total.VL_TOTAL_PRODUTO + total.VL_FRETE + total.VL_SEGURO + total.VL_OUTRAS_DESPESAS ?? 0;
            }

            // Atualiza também os itens da fatura
            var itens = resultadoImpostos.Where(x => x.TABELA == "ITEM").ToList();
            foreach (var item in itens)
            {
                var itemCommand = command.FaturaTemporariaItem
                    .FirstOrDefault(x => x.SqItem == item.SQ_ITEM);

                if (itemCommand != null)
                {
                    itemCommand.QtdProduto = item.QT_PRODUTO ?? 0;
                    itemCommand.ValorUnitarioProduto = item.VL_UNITARIO_PRODUTO ?? 0;
                    itemCommand.ValorTotalProduto = item.VL_TOTAL_PRODUTO ?? 0;
                    itemCommand.PrIcms = item.PR_ICMS ?? 0;
                    itemCommand.BaseCalculoIcms = item.VL_BASE_CALCULO_ICMS ?? 0;
                    itemCommand.ValorIcms = item.VL_ICMS_PRODUTO ?? 0;
                    itemCommand.PrIpi = item.PR_IPI ?? 0;
                    itemCommand.ValorIpi = item.VL_IPI ?? 0;
                    itemCommand.PrPis = item.PR_PIS ?? 0;
                    itemCommand.ValorPis = item.VL_PIS ?? 0;
                    itemCommand.PrCofinss = item.PR_COFINS ?? 0;
                    itemCommand.ValorCofins = item.VL_COFINS ?? 0;
                    itemCommand.PrIva = item.PR_IVA ?? 0;
                    itemCommand.BaseCalculoSt = item.VL_BASE_CALCULO_ST ?? 0;
                    itemCommand.ValorSt = item.VL_ST ?? 0;
                }
            }

            response.SetFormulario(command);
            ////-----------

            return response;
        }

        private List<FaturaTemporariaItem> CriarFaturaTemporariaItem(IEnumerable<FaturaTemporariaItemCommand> FaturaTemporariaItemCommands, Guid faturaTemporariaId)
        {
            return FaturaTemporariaItemCommands.Select(faturaTemporariaItem => new FaturaTemporariaItem(
                faturaTemporariaId,
                faturaTemporariaItem.SqItem,
                faturaTemporariaItem.IdProduto,
                faturaTemporariaItem.QtdProduto,
                faturaTemporariaItem.ValorUnitarioProduto,
                faturaTemporariaItem.ValorTotalProduto,
                faturaTemporariaItem.IdCfop,
                faturaTemporariaItem.ValorFrete,
                faturaTemporariaItem.ValorSeguro,
                faturaTemporariaItem.ValorOutrasDespesas,
                faturaTemporariaItem.PrIcms,
                faturaTemporariaItem.ValorIcms,
                faturaTemporariaItem.PrIpi,
                faturaTemporariaItem.ValorIpi,
                faturaTemporariaItem.PrPis,
                faturaTemporariaItem.ValorPis,
                faturaTemporariaItem.PrCofinss,
                faturaTemporariaItem.ValorCofins,
                faturaTemporariaItem.PrIva,
                faturaTemporariaItem.BaseCalculoSt,
                faturaTemporariaItem.ValorSt,
                faturaTemporariaItem.ValorNetPrice,
                faturaTemporariaItem.ValorGrossPrice
            )).ToList();
        }
    }
}
