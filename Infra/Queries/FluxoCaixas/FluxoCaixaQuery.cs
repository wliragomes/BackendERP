using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.FluxoCaixas.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.FluxoCaixas;
using SharedKernel.Configuration.Extensions;
using Domain.Entities;
using Application.DTOs.Comissoes;

namespace Infra.Queries.FluxoCaixas
{
    public class FluxoCaixaQuery : IFluxoCaixaQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public FluxoCaixaQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<FluxoCaixaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.FluxoCaixa.AsNoTracking()
                            .Include(ee => ee.Pessoa)
                            .Include(ee => ee.Banco);

            var data = query.Select(x => new FluxoCaixaFilterDto
            {
                Id = x.Id,
                DataCaixa = x.Caixa,
                NomeCliente = x.Pessoa.RazaoSocial,
                NomeBanco = x.Banco != null ? x.Banco.Nome ?? "" : "",
                ValorLancamento = x.ValorLancamento,
                ValorSaldo = x.ValorSaldo
    });
            

        var response = await data.RetonarFiltroCustomizado<FluxoCaixaFilterDto, FluxoCaixaFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<FluxoCaixaByCodeDto?> RetornarPorId(Guid id)
        {
            var FluxoCaixa = await _dbContext.FluxoCaixa
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (FluxoCaixa != null)
            {
                return new FluxoCaixaByCodeDto
                {
                    Id = FluxoCaixa.Id,
                    Caixa = FluxoCaixa.Caixa,
                    IdOperacao = FluxoCaixa.IdOperacao,
                    IdCliente = FluxoCaixa.IdCliente,
                    CreditoDebito = FluxoCaixa.CreditoDebito,
                    ChequeCartao = FluxoCaixa.ChequeCartao,
                    IdBanco = FluxoCaixa.IdBanco,
                    IdCartao = FluxoCaixa.IdCartao,
                    Agencia = FluxoCaixa.Agencia,
                    DigitoAgencia = FluxoCaixa.DigitoAgencia,
                    Conta = FluxoCaixa.Conta,
                    DigitoConta = FluxoCaixa.DigitoConta,
                    NChequeComprovanteCartao = FluxoCaixa.NChequeComprovanteCartao,
                    DataVencimento = FluxoCaixa.DataVencimento,
                    ValorLancamento = FluxoCaixa.ValorLancamento,
                    ValorSaldo = FluxoCaixa.ValorSaldo,
                    Historico = FluxoCaixa.Historico,
                    IdContaAReceber = FluxoCaixa.IdContaAReceber,
                    IdContaAReceberPago = FluxoCaixa.IdContaAReceberPago,
                };
            }

            return null;
        }

        public async Task<List<FluxoCaixaGetDto?>> RetornarFluxoCaixaGet(DateTime? dataCaixaInicial, DateTime? dataCaixaFinal)
        {
            string query = @"SELECT 
                                a.CD_FLUXO_CAIXA as Id,
                                a.DT_CAIXA as DataCaixa,
                                b.NM_RAZAO_SOCIAL as NomeCliente,
                                ISNULL(c.NM_BANCO, '') as NomeBanco,
                                a.VL_LANCAMENTO as ValorLancamento,
                                a.VL_SALDO as ValorSaldo
                            FROM TB_FLUXO_CAIXA as a
                                INNER JOIN TB_PESSOA as b ON b.CD_PESSOA = a.CD_CLIENTE
                                LEFT JOIN TB_BANCO as c ON c.CD_BANCO = a.CD_BANCO
                            WHERE 1 = 1
                                AND A.BT_REMOVIDO = 0
                                AND B.BT_REMOVIDO = 0";

            if (dataCaixaInicial != null)
            {
                dataCaixaInicial = dataCaixaInicial.Value.Date; // Inicio do dia
                query += " AND A.DT_CAIXA >= @DataCaixaInicial ";
            }

            if (dataCaixaFinal != null)
            {
                dataCaixaFinal = dataCaixaFinal.Value.Date.AddDays(1).AddTicks(-1); // Final do dia
                query += " AND A.DT_CAIXA <= @DataCaixaFinal ";
            }

            query += " ORDER BY a.DT_CAIXA ASC";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<FluxoCaixaGetDto?>(query, new
                {
                    DataCaixaInicial = dataCaixaInicial,
                    DataCaixaFinal = dataCaixaFinal,
                });
            }
        }
    }
}
