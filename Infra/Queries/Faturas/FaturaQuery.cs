using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;
using Application.DTOs.Faturas.Filtro;
using Application.DTOs.Pessoas;
using Application.DTOs.Faturas;

namespace Infra.Queries.Faturas
{
    public class FaturaQuery : IFaturaQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public FaturaQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }        

        public async Task<PaginacaoResponse<FaturaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Fatura.AsNoTracking()
                        .AsQueryable();

            var data = query.Select(x => new FaturaFilterDto
            {
                Id = x.Id,
                IdCliente = x.IdCliente,
                RazaoSocial = x.RazaoSocial,
                NaturezaOperacao = x.NaturezaOperacao
            });

            var response = await data.RetonarFiltroCustomizado<FaturaFilterDto, FaturaFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<FaturaByCodeDto?> RetornarPorId(Guid id)
        {  
            var fatura = await _dbContext.Fatura
                .Include(c => c.FaturaItem)
                    .ThenInclude(p => p.Produto)
                .Include(c => c.RelacionaFaturaVendaRecebimentoTipo)
                    .ThenInclude(r => r.VendaRecebimentoTipo)
                    .ThenInclude(p => p.VendaRecebimentoParcela)
                .AsNoTracking()
                .Where(x => x.Id.Equals(id))
                .FirstOrDefaultAsync();

            if (fatura != null)
            {
                return new FaturaByCodeDto
                {
                    Id = fatura.Id,
                    IdCliente = fatura.IdCliente,
                    RazaoSocial = fatura.RazaoSocial,
                    NumeroPedido = fatura.NumeroPedido,
                    NumeroPedidoCliente = fatura.NumeroPedidoCliente,
                    Marca = fatura.Marca,
                    TemPedido = fatura.RelacionaFaturaVendaRecebimentoTipo.IdVenda != null ? true : false,
                    EnderecoCobranca = new EnderecoDto
                    {
                        IdTipoEndereco = new Guid(),
                        EnderecoDescricao = fatura.EnderecoCobranca,
                        Numero = fatura.NumeroCobranca,
                        Complemento = fatura.ComplementoCobranca,
                        IdCidade = fatura.IdCidadeCobranca,
                        Bairro = fatura.BairroCobranca,
                        IdUf = fatura.IdUfCobranca,
                        Cep = fatura.CepCobranca
                    },
                    EnderecoEntrega = new EnderecoDto
                    {
                        IdTipoEndereco = new Guid(),
                        EnderecoDescricao = fatura.EnderecoEntrega,
                        Numero = fatura.NumeroEntrega,
                        Complemento = fatura.ComplementoEntrega,
                        IdCidade = fatura.IdCidadeEntrega,
                        Bairro = fatura.BairroEntrega,
                        IdUf = fatura.IdUfEntrega,
                        Cep = fatura.CepEntrega
                    },
                    Produtos = fatura.FaturaItem!.Select(item => new FaturaProdutosDto
                    {
                        SequenciaItem = item.SequenciaItem,
                        IdProduto = item.IdProduto,
                        CodigoAmigavel = item.Produto.CodigoAmigavel,
                        DescricaoProduto = item.DescricaoProduto,
                        InformacoesAdicionais = item.InformacoesAdicionais,
                        DescricaoPedidoCliente = item.DescricaoPedidoCliente,
                        NumeroItemPedidoCliente = item.NumeroItemPedidoCliente,
                        NumeroFCI = item.NumeroFCI,
                        ValorFCI = item.ValorFCI,
                        IdUnidadeMedida = item.IdUnidadeMedida,
                        Quantidade = item.Quantidade,
                        ValorUnitario = item.ValorUnitario,
                        ValorTotal = item.ValorTotal,
                        idNCM = item.IdNCM,
                        IdCFOP = item.IdCFOP,
                        AliquotaICMS = item.AliquotaICMS,
                        BaseCalculoICMS = item.BaseCalculoICMS,
                        ValorICMS = item.ValorICMS,
                        AliquotaIPI = item.AliquotaIPI,
                        ValorIPI = item.ValorIPI,
                        BaseCalculoST = item.BaseCalculoST,
                        AliquotaST = item.AliquotaST,
                        ValorST = item.ValorST
                    }).ToList(),
                    Totais = new FaturaTotaisDto
                    {
                        NaturezaOperacao = fatura.NaturezaOperacao,
                        InformacoesAdicionais = fatura.InformacoesAdicionais,
                        ValorFrete = fatura.ValorFrete,
                        ValorSeguro = fatura.ValorSeguro,
                        ValorOutrasDespesas = fatura.ValorOutrasDespesas,
                        ValorTotalProdutos = fatura.ValorTotalProdutos,
                        ValorBaseCalculoIcms = fatura.ValorBaseCalculoIcms,
                        ValorIcms = fatura.ValorIcms,
                        ValorIpi = fatura.ValorIpi,
                        BaseCalculoSt = fatura.BaseCalculoSt,
                        ValorSt = fatura.ValorSt,
                        ValorTotal = fatura.ValorTotal,
                        QuantidadeItens = fatura.QuantidadeItens,
                        Especie = fatura.Especie,
                        PesoBruto = fatura.PesoBruto,
                        PesoLiquido = fatura.PesoLiquido

                    },
                    Pagamento = new FaturaPagamentoDto
                    {
                        QuantidadeParcelas = fatura.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo?.QuantidadeParcela ?? 0,
                        PagamentoAntecipado = fatura.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo?.PagamentoAntecipado ?? false,
                        ParcelasPartirPedido = fatura.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo?.ParcelaPartir == 1 ? true : false,
                        ParcelasPartirDiasDDL = fatura.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo?.ParcelaPartir == 2 ? true : false,
                        PeriodoMensal = fatura.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo?.Periodo == 1 ? true : false,
                        PeriodoDigitada = fatura.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo?.Periodo == 2 ? true : false,
                        PeriodoDias = fatura.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo?.Periodo == 3 ? true : false,
                        PeriodoQuantidadeDias = fatura.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo?.QuantidadeDias ?? 0
                    },
                    PagamentoParcelas = fatura.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo.VendaRecebimentoParcela.Select(parcela => new FaturaPagamentoParcelasDto
                    {
                        SequenciaParcela = parcela.SequenciaParcela,
                        NumeroDiasVencimento = parcela.NumeroDiasVencimento,
                        DataVencimento = parcela.DataVencimento,
                        ValorParcela = parcela.ValorParcela
                    }).ToList(),
                    Transporte = new FaturaTransporteDto
                    {
                        IdTransportadora = fatura.IdTransportadora,
                        IdTipoFrete = fatura.IdTipoFrete,
                        PlacaVeiculo = fatura.PlacaVeiculoTransportadora,
                        IdUFVeiculo = fatura.IdUfVeiculo
                    }
                };
            }

            return null;
        }
    }
}
