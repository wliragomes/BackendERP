using Domain.Entities.Faturas;
using Domain.Entities.Vendas;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Faturas.Atualizar
{
    public class AtualizarFaturaCommandHandler : IRequestHandler<AtualizarFaturaCommand, FormularioResponse<AtualizarFaturaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarFaturaCommand> _validator;
        private const int _indice = 0;

        public AtualizarFaturaCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarFaturaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarFaturaCommand>> Handle(AtualizarFaturaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarFaturaCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            command.PagamentoParcelas!
                .Where(parcela => parcela.ValorParcela <= 0)
                .Select(parcela => new {
                    NomeCampo = "Valor da parcela " + parcela.SequenciaParcela,
                    Mensagem = "Nenhuma parcela pode ter valor menor ou igual a zero.",
                    Valor = parcela.ValorParcela
                })
                .ToList()
                .ForEach(erro => response.AddError(erro.NomeCampo, erro.Mensagem, erro.Valor));

            if (response.ExisteErro()) 
                return response;

            var faturaUpdate = await _unitOfWork.FaturaRepository.ObterPorId(command.Id);

            faturaUpdate!.Update(
                command.IdCliente,
                command.Totais.InformacoesAdicionais,
                null, //informacoesAdicionaisFisco
                command.RazaoSocial,
                command.Totais.NaturezaOperacao,
                command.EnderecoEntrega.Cep,
                command.EnderecoEntrega.EnderecoDescricao,
                command.EnderecoEntrega.Numero,
                command.EnderecoEntrega.Complemento,
                command.EnderecoEntrega.IdUf,
                command.EnderecoEntrega.IdCidade,
                command.EnderecoEntrega.Bairro,
                command.EnderecoCobranca.Cep,
                command.EnderecoCobranca.EnderecoDescricao,
                command.EnderecoCobranca.Numero,
                command.EnderecoCobranca.Complemento,
                command.EnderecoCobranca.IdUf,
                command.EnderecoCobranca.IdCidade,
                command.EnderecoCobranca.Bairro,
                command.Transporte != null ? command.Transporte.IdTipoFrete : null,
                command.Transporte != null ? command.Transporte.IdTransportadora : null,
                command.Transporte != null ? command.Transporte.PlacaVeiculo : null,
                command.Transporte != null ? command.Transporte.IdUFVeiculo : null,
                command.Totais.QuantidadeItens,
                command.Totais.Especie,
                command.NumeroPedido,
                command.NumeroPedidoCliente,
                command.Marca,
                command.Totais.PesoBruto,
                command.Totais.PesoLiquido,
                command.Totais.ValorFrete,
                command.Totais.ValorSeguro,
                command.Totais.ValorOutrasDespesas,
                command.Totais.ValorTotalProdutos,
                command.Totais.ValorBaseCalculoIcms,
                command.Totais.ValorIcms,
                null, //baseCalculoPisCofins
                command.Totais.ValorIpi, //valorIpi
                null, //valorPis
                null, //valorCofins
                command.Totais.BaseCalculoSt,
                command.Totais.ValorSt,
                null, //percentualDesconto
                null, //valorDesconto
                command.Totais.ValorTotal,
                null //valorDifal
            );

            // Atualizar Itens da Fatura
            var itens = CriarItens(command.Produtos!, faturaUpdate.Id);
            await _unitOfWork.FaturaItemRepository.RemoverPorFaturaId(faturaUpdate.Id);
            await _unitOfWork.FaturaItemRepository.AdicionarEmMassa(itens);

            // Atualizar o pagamento (VendaRecebimentoTipo)
            var pagamento = await _unitOfWork.VendaRecebimentoTipoRepository.ObterPorFaturaId(faturaUpdate.Id);
            if (pagamento != null)
            {
                pagamento.Update(
                    command.Pagamento.QuantidadeParcelas,
                    command.Pagamento.PagamentoAntecipado,
                    command.Pagamento.ParcelasPartirPedido ? 1 : 2,
                    command.Pagamento.PeriodoMensal ? 1 : command.Pagamento.PeriodoDigitada ? 2 : 3,
                    command.Pagamento.PeriodoQuantidadeDias
                );
            }
            else
            {
                pagamento = new VendaRecebimentoTipo(
                    command.Pagamento.QuantidadeParcelas,
                    command.Pagamento.PagamentoAntecipado,
                    command.Pagamento.ParcelasPartirPedido ? 1 : 2,
                    command.Pagamento.PeriodoMensal ? 1 : command.Pagamento.PeriodoDigitada ? 2 : 3,
                    command.Pagamento.PeriodoQuantidadeDias
                );
                await _unitOfWork.VendaRecebimentoTipoRepository.Adicionar(pagamento);
            }

            // Atualizar Relacionamento Fatura - VendaRecebimentoTipo
            var relacionamento = await _unitOfWork.RelacionaFaturaVendaRecebimentoTipoRepository.ObterPorFaturaId(faturaUpdate.Id);
            if (relacionamento == null)
            {
                relacionamento = new RelacionaFaturaVendaRecebimentoTipo(pagamento.Id, null, faturaUpdate.Id);
                await _unitOfWork.RelacionaFaturaVendaRecebimentoTipoRepository.Adicionar(relacionamento);
            }

            // Atualizar Parcelas do Pagamento
            var parcelas = CriarParcelas(command.PagamentoParcelas!, pagamento.Id);
            await _unitOfWork.VendaRecebimentoParcelaRepository.RemoverPorVendaRecebimentoId(pagamento.Id);
            await _unitOfWork.VendaRecebimentoParcelaRepository.AdicionarEmMassa(parcelas);

            await _unitOfWork.CommitAsync(cancellationToken);

            response.SetFormulario(command);
            return response;
        }

        private List<FaturaItem> CriarItens(List<FaturaProdutosCommand> itens, Guid idFatura)
        {
                return itens.Select(e => new FaturaItem(
                idFatura, e.SequenciaItem, e.DescricaoPedidoCliente, e.NumeroItemPedidoCliente, e.IdProduto, e.DescricaoProduto, e.IdUnidadeMedida,
                e.InformacoesAdicionais, e.NumeroFCI, e.ValorFCI, e.Quantidade, e.ValorUnitario, null,
                null, e.ValorTotal, e.IdCFOP, e.idNCM, e.AliquotaICMS, e.BaseCalculoICMS, e.ValorICMS,
                e.AliquotaIPI, e.ValorIPI, e.AliquotaST, e.BaseCalculoST, e.ValorST, null,
                null, null, null, null)).ToList();
        }

        private List<VendaRecebimentoParcela> CriarParcelas(List<FaturaPagamentoParcelasCommand> itens, Guid idVendaRecebimentoTipo)
        {
            return itens.Select(e => new VendaRecebimentoParcela(idVendaRecebimentoTipo, e.SequenciaParcela, e.NumeroDiasVencimento, e.DataVencimento, e.ValorParcela)).ToList();
        }
    }
}
