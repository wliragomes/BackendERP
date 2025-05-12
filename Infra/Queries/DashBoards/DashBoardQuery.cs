using Infra.Context;
using Application.DTOs.DashBoards.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Queries;
using Application.DTOs.DashBoards;
using Application.DTOs.Vendas.Filtro;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.DashBoards
{
    public class DashBoardQuery : IDashBoardQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public DashBoardQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DashBoardFilterDto?> RetornarDashBoard()
        {
            var DashBoard = await _dbContext.DashBoard
            .AsNoTracking()
            .FirstOrDefaultAsync();

            if (DashBoard != null)
            {
                return new DashBoardFilterDto
                {                    
                    Pedidos = new PedidosDto
                    {
                        QuantidadePedido = DashBoard.QuantidadePedido,
                        QuantidadePedidoUltimaSemana = DashBoard.QuantidadePedidoUltimaSemana
                    },
                    Faturamento = new FaturamentoDto
                    {
                        QuantidadeFaturamento = DashBoard.QuantidadeFaturamento,
                        QuantidadeFaturamentoUltimaSemana = DashBoard.QuantidadeFaturamentoUltimaSemana
                    },
                    NotasEmitidas = new NotasEmitidasDto
                    {
                        QuantidadeNotasEmitidas = DashBoard.QuantidadeNotasEmitidas,
                        QuantidadeNotasEmitidasHoje = DashBoard.QuantidadeNotasEmitidasHoje

                    },
                    ToneladasAFabricar = new ToneladasAFabricarDto
                    {
                        QuantidadeToneladasAFabricar = DashBoard.QuantidadeToneladasAFabricar,
                        QuantidadeToneladasAFabricarHoje = DashBoard.QuantidadeToneladasAFabricarHoje
                    },
                    OfProducao = new OfProducaoDto
                    {
                        QuantidadeCorte = DashBoard.QuantidadeCorte,
                        PorcentagemCorte = DashBoard.PorcentagemCorte,
                        QuantidadeTempera = DashBoard.QuantidadeTempera,
                        PorcentagemTempera = DashBoard.PorcentagemTempera,
                        QuantidadeLapidacao = DashBoard.QuantidadeLapidacao,
                        PorcentagemLapidacao = DashBoard.PorcentagemLapidacao,
                        QuantidadeLaminacao = DashBoard.QuantidadeLaminacao,
                        PorcentagemLaminacao = DashBoard.PorcentagemLaminacao,
                        QuantidadeInsulado = DashBoard.QuantidadeInsulado,
                        PorcentagemInsulado = DashBoard.PorcentagemInsulado,
                        QuantidadeExpedicao = DashBoard.QuantidadeExpedicao,
                        PorcentagemExpedicao = DashBoard.PorcentagemExpedicao
                    }
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<PedidosGetDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = await _dbContext.Venda
                 .AsNoTracking()
                 .Include(p => p.Empresa)
                 .Include(s => s.Status)
                 .ToListAsync();

            var agrupado = query
                .GroupBy(x => new { x.CodigoVenda, x.AnoVenda })
                .Select(g => g
                    .OrderByDescending(x => x.Release)
                    .FirstOrDefault())
                .Where(x => x.Status.Id == Guid.Parse("917B2892-15F5-434C-881F-947177B941A5"))
                .Select(x => new PedidosGetDto
                {
                    Id = x.Id,
                    CodigoVenda = x.CodigoVenda,
                    AnoVenda = x.AnoVenda,
                    RazaoSocial = x.Empresa?.RazaoSocial,
                    ValorTotal = x.ValorTotal
                })
                .ToList();

            var response = await agrupado.RetonarFiltroCustomizado<PedidosGetDto, PedidosGetDto>(paginacaoRequest);
            return response;
        }
    }
}
