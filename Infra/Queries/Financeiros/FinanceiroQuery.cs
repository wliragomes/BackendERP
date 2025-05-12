using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;
using Application.Interfaces.Queries;
using Application.DTOs.Classificacoes.Filtro;
using Application.DTOs.Classificacoes;
using Application.DTOs.Operacoes.Filtro;
using Application.DTOs.Operacoes;
using Application.DTOs.ContasAPagar.Filtro;
using Application.DTOs.ContasAPagar;
using Domain.Entities;
using Application.DTOs.Cartoes.Filtro;
using Application.DTOs.ContasAPagarPago.Filtro;
using Application.DTOs.ContasAPagarPago;
using Application.DTOs.ContasAReceber.Filtro;
using Application.DTOs.ContasAReceber;
using Application.DTOs.Financeiros;
using Application.DTOs.PlanosDeContas.Filtro;
using Application.DTOs.PlanosDeContas;
using Application.DTOs.Comissoes;
using Application.DTOs.Financeiros.ContasAReceber.Filtro;
using System.Net.NetworkInformation;

namespace Infra.Queries.Financeiros
{
    public class FinanceiroQuery : IFinanceiroQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public FinanceiroQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<CentroCustoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = await _dbContext.CentroCusto
                .AsNoTracking()
                .Select(x => new CentroCustoFilterDto
                {
                    Id = x.Id,
                    SequenciaPlanoDeContas = x.SequenciaPlanoDeContas,
                    Descricao = x.Descricao,
                })
                .ToListAsync();     

                    var response = await query.RetonarFiltroCustomizado<CentroCustoFilterDto, CentroCustoFilterDto>(paginacaoRequest);
                    return response;
        }

        public async Task<List<DespesaByCodeDto?>> RetornarDespesaCentroCusto(Guid idCentroCusto)
        {
            string query = @"SELECT
                                A.CD_PLANO_CONTAS AS IdCentroDeCusto,            
                                B.CD_TIPO_DESPESA AS IdTipoDespesa,
			                    B.DS_TIPO_DESPESA AS DescricaoDepesa
                    FROM		VW_CENTRO_CUSTO_CONTA_PAGAR AS A
			                    INNER JOIN VW_TIPO_DESPESA_CONTA_PAGAR AS B ON A.CD_PLANO_CONTAS = B.CD_CENTRO_CUSTO
                    WHERE		1 = 1
                                AND A.BT_REMOVIDO = 0 AND B.BT_REMOVIDO = 0
			                    AND A.CD_PLANO_CONTAS = @IdCentroCusto";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<DespesaByCodeDto?>(query, new { idCentroCusto = idCentroCusto });
            }
        }

        public async Task<PaginacaoResponse<CentroCustoFilterDto>> RetornarCentroCustoContaAReceberPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = await _dbContext.CentroCustoContaAReceber
                .AsNoTracking()
                .Select(x => new CentroCustoFilterDto
                {
                    Id = x.Id,
                    SequenciaPlanoDeContas = x.SequenciaPlanoDeContas,
                    Descricao = x.Descricao,
                })
                .ToListAsync();

            var response = await query.RetonarFiltroCustomizado<CentroCustoFilterDto, CentroCustoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<List<DespesaByCodeDto?>> RetornarDespesaCentroCustoContaAReceber(Guid idCentroCustoContaAReceber)
        {
            string query = @"SELECT
                                A.CD_CENTRO_CUSTO AS IdCentroDeCusto,            
                                B.CD_TIPO_DESPESA AS IdTipoDespesa,
			                    B.DS_TIPO_DESPESA AS DescricaoDepesa
                    FROM		VW_CENTRO_CUSTO_CONTA_RECEBER AS A
			                    INNER JOIN VW_TIPO_DESPESA_CONTA_RECEBER AS B ON A.CD_CENTRO_CUSTO = B.CD_CENTRO_CUSTO
                    WHERE		1 = 1
                                AND A.BT_REMOVIDO = 0 AND B.BT_REMOVIDO = 0
			                    AND A.CD_CENTRO_CUSTO = @IdCentroDeCusto";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<DespesaByCodeDto?>(query, new { IdCentroDeCusto = idCentroCustoContaAReceber });
            }
        }

        public async Task<PaginacaoResponse<ClassificacaoFilterDto>> RetornarClassificacaoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Classificacao.AsNoTracking();

            var data = query.Select(x => new ClassificacaoFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
            });

            var response = await data.RetonarFiltroCustomizado<ClassificacaoFilterDto, ClassificacaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<ClassificacaoByCodeDto?> RetornarClassificacaoPorId(Guid id)
        {
            var Classificacao = await _dbContext.Classificacao
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Classificacao != null)
            {
                return new ClassificacaoByCodeDto
                {
                    Id = Classificacao.Id,
                    Nome = Classificacao.Nome,
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<OperacaoFilterDto>> RetornarOperacaoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Operacao.AsNoTracking();

            var data = query.Select(x => new OperacaoFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
            });

            var response = await data.RetonarFiltroCustomizado<OperacaoFilterDto, OperacaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<OperacaoByCodeDto?> RetornarOperacaoPorId(Guid id)
        {
            var Operacao = await _dbContext.Operacao
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Operacao != null)
            {
                return new OperacaoByCodeDto
                {
                    Id = Operacao.Id,
                    Nome = Operacao.Nome,
                    DescontaFinanceiro = Operacao.DescontaFinanceiro,
                    LancaComissao = Operacao.LancaComissao,
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<ContaAPagarFilterDto>> RetornarContaAPagarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.ContaAPagar.AsNoTracking()
                                              .Include(s => s.Pessoa); ;

            var data = query.Select(x => new ContaAPagarFilterDto
            {
                Id = x.Id,
                IdFornecedor = x.IdFornecedor,
                NomeFornecedor = x.Pessoa.RazaoSocial,
                NDocumento = x.NDocumento,
                ValorDocumento = x.ValorDocumento,
                DataDocumento = x.DataDocumento,
                DataVencimento = x.DataVencimento,
            });

            var response = await data.RetonarFiltroCustomizado<ContaAPagarFilterDto, ContaAPagarFilterDto>(paginacaoRequest);
            return response;
        }        

        public async Task<ContaAPagarByCodeDto?> RetornarContaAPagarPorId(Guid id)
        {
            var ContaAPagar = await _dbContext.ContaAPagar
                .Include(p => p.PagarCentroCustoDespesa)
                .AsNoTracking()
                .Where(x => x.Id.Equals(id))
                .FirstOrDefaultAsync();

            if (ContaAPagar != null)
            {
                return new ContaAPagarByCodeDto
                {
                    Id = ContaAPagar.Id,
                    Status = ContaAPagar.Status,
                    Rascunho = ContaAPagar.Rascunho,
                    IdFornecedor = ContaAPagar.IdFornecedor,
                    IdModalidade = ContaAPagar.IdModalidade,
                    NDocumento = ContaAPagar.NDocumento,
                    DataDocumento = ContaAPagar.DataDocumento,
                    ValorDocumento = ContaAPagar.ValorDocumento,
                    ValorSaldo = ContaAPagar.ValorSaldo,
                    AntecipaDataPagamento = ContaAPagar.AntecipaDataPagamento,
                    Resumo = ContaAPagar.Resumo,
                    UnitarioPeriodoMensal = ContaAPagar.UnitarioPeriodoMensal,
                    LancadaDefinida = ContaAPagar.LancadaDefinida,
                    QtdParcela = ContaAPagar.QtdParcela,
                    QtdPeriodo = ContaAPagar.QtdPeriodo,
                    Reajuste = ContaAPagar.Reajuste,
                    DataVencimento = ContaAPagar.DataVencimento,
                    IdBanco = ContaAPagar.IdBanco,
                    Historico = ContaAPagar.Historico,
                    PagarCentroCustoDespesa = ContaAPagar.PagarCentroCustoDespesa.Select(p => new PagarCentroCustoDespesaDto
                    {
                        NItem = p.NItem,
                        IdDespesa = p.IdDespesa,
                        IdCentroDeCusto = p.IdCentroDeCusto,
                        ValorDespesa = p.ValorDespesa
                    }).ToList(),

                };
            }
            return null;
        }

        public async Task<PaginacaoResponse<CartaoFilterDto>> RetornarCartaoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Cartao.AsNoTracking();

            var data = query.Select(x => new CartaoFilterDto
            {
                Id = x.Id,
                Nome = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<CartaoFilterDto, CartaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<CartaoByCodeDto?> RetornarCartaoPorId(Guid id)
        {
            var Cartao = await _dbContext.Cartao
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Cartao != null)
            {
                return new CartaoByCodeDto
                {
                    Id = Cartao.Id,
                    Nome = Cartao.Nome
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<ContaAPagarPagoFilterDto>> RetornarContaAPagarPagoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.ContaAPagarPago.AsNoTracking();

            var data = query.Select(x => new ContaAPagarPagoFilterDto
            {
                Id = x.Id,
                IdContaAPagar = x.IdContaAPagar,
                NItem= x.NItem,
                NDocumentoPago = x.NDocumentoPago
            });

            var response = await data.RetonarFiltroCustomizado<ContaAPagarPagoFilterDto, ContaAPagarPagoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<ContaAPagarPagoByCodeDto?> RetornarContaAPagarPagoPorId(Guid id)
        {
            var ContaAPagarPago = await _dbContext.ContaAPagarPago
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (ContaAPagarPago != null)
            {
                return new ContaAPagarPagoByCodeDto
                {
                    Id = ContaAPagarPago.Id,
                    IdContaAPagar = ContaAPagarPago.IdContaAPagar,
                    NItem = ContaAPagarPago.NItem,
                    Baixa = ContaAPagarPago.Baixa,
                    IdBanco = ContaAPagarPago.IdBanco,
                    Agencia = ContaAPagarPago.Agencia,
                    AgenciaDigito = ContaAPagarPago.AgenciaDigito,
                    Conta = ContaAPagarPago.Conta,
                    ContaDigito = ContaAPagarPago.ContaDigito,
                    ValorPago = ContaAPagarPago.ValorPago,
                    DataOperacao = ContaAPagarPago.DataOperacao,
                    Historico = ContaAPagarPago.Historico,
                    NDocumentoPago = ContaAPagarPago.NDocumentoPago,
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<ContaAReceberFilterDto>> RetornarContaAReceberPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.ContaAReceber.AsNoTracking()
                .Include(s => s.Pessoa);

            var data = query.Select(x => new ContaAReceberFilterDto
            {
                Id = x.Id,
                IdCliente = x.IdCliente,
                NomeCliente = x.Pessoa.RazaoSocial,
                NDocumento = x.NDocumento,
                ValorDocumento = x.ValorDocumento,
                DataDocumento = x.DataDocumento,
                DataVencimento = x.DataVencimento,
                Status = x.Status,
                Historico = x.Historico,
                IdBanco = x.IdBanco,
                IdCentroDeCusto = x.IdCentroDeCusto,
                IdDespesa = x.IdDespesa,
            });

            var response = await data.RetonarFiltroCustomizado<ContaAReceberFilterDto, ContaAReceberFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<ContaAReceberByCodeDto?> RetornarContaAReceberPorId(Guid id)
        {
            var ContaAReceber = await _dbContext.ContaAReceber
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (ContaAReceber != null)
            {
                return new ContaAReceberByCodeDto
                {
                    Id = ContaAReceber.Id,
                    Status = ContaAReceber.Status,
                    Rascunho = ContaAReceber.Rascunho,
                    IdCliente = ContaAReceber.IdCliente,
                    NDocumento = ContaAReceber.NDocumento,
                    DataDocumento = ContaAReceber.DataDocumento,
                    DataVencimento = ContaAReceber.DataVencimento,
                    ValorDocumento = ContaAReceber.ValorDocumento,
                    UnitarioPeriodoMensal = ContaAReceber.UnitarioPeriodoMensal,
                    QtdParcela = ContaAReceber.QtdParcela,
                    QtdPeriodo = ContaAReceber.QtdPeriodo,
                    IdCentroDeCusto = ContaAReceber.IdCentroDeCusto,
                    IdDespesa = ContaAReceber.IdDespesa,
                    IdBanco = ContaAReceber.IdBanco,
                    IdFatura = ContaAReceber.IdFatura,
                    Historico = ContaAReceber.Historico,
                };
            }

            return null;
        }


        /* -------------------------------------------------------------------------------- */
        public async Task<List<ContaAReceberGetDto?>> RetornarContaAReceber(string? status, DateTime? dataInicial, DateTime? dataFinal)
        {
            string query = @"SELECT 
                                        A.CD_CONTA_RECEBER AS Id,
                                        A.DT_CADASTRO AS DataCadastro,
				                        B.CD_PESSOA AS IdCliente,
				                        A.NR_DOCUMENTO AS NDocumento,
				                        A.VL_DOCUMENTO AS ValorDocumento,
				                        A.DT_DOCUMENTO AS DataDocumento,
				                        A.DT_VENCIMENTO AS DataVencimento,
				                        B.NM_RAZAO_SOCIAL AS NomeCliente,
				                        A.FL_STATUS AS Status,
				                        A.TX_HISTORICO AS Historico,
                                        A.CD_BANCO AS IdBanco,
				                        A.CD_CENTRO_CUSTO AS IdCentroDeCusto,
				                        A.CD_TIPO_DESPESA AS IdDespesa
                            FROM        TB_CONTA_RECEBER AS A
                                        INNER JOIN TB_PESSOA AS B ON B.CD_PESSOA = A.CD_PESSOA
                            WHERE       1 = 1 AND
				                        A.BT_REMOVIDO = 0 AND
				                        B.BT_REMOVIDO = 0";

            if (status != null)
            {
                query += @" AND A.FL_STATUS = @status ";
            }

            if (dataInicial != null)
            {
                dataInicial = dataInicial.Value.Date.AddMilliseconds(1);
                query += " AND A.DT_CADASTRO >= @dataInicial";
            }

            if (dataFinal != null)
            {
                dataFinal = dataFinal.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(599);
                query += " AND A.DT_CADASTRO <= @dataFinal ";
            }

            query += " ORDER BY A.DT_CADASTRO ASC";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<ContaAReceberGetDto?>(query, new
                {
                    Status = status,
                    DataInicial = dataInicial,
                    DataFinal = dataFinal
                });
            }
        }


   /* -------------------------------------- */

    public async Task<PaginacaoResponse<PlanoDeContasFilterDto>> RetornarPlanoDeContasPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.PlanoDeContas.AsNoTracking();

            var data = query.Select(x => new PlanoDeContasFilterDto
            {
                Id = x.Id,
                PlanoDeContasCompleto = x.PlanoDeContasCompleto,
                Conta = x.Conta,
                Natureza = x.Natureza
            });
           
        var response = await data.RetonarFiltroCustomizado<PlanoDeContasFilterDto, PlanoDeContasFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PlanoDeContasByCodeDto?> RetornarPlanoDeContasPorId(Guid id)
        {
            var PlanoDeContas = await _dbContext.PlanoDeContas
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (PlanoDeContas != null)
            {
                return new PlanoDeContasByCodeDto
                {
                    Id = PlanoDeContas.Id,
                    PlanoDeContasCompleto = PlanoDeContas.PlanoDeContasCompleto,
                    ContaPrincipal = PlanoDeContas.ContaPrincipal,
                    SubGrupo = PlanoDeContas.SubGrupo,
                    Analitico = PlanoDeContas.Analitico,
                    AnaliticoDetalhado = PlanoDeContas.AnaliticoDetalhado,
                    Especifico = PlanoDeContas.Especifico,
                    PositivoNegativo = PlanoDeContas.PositivoNegativo,
                    Conta = PlanoDeContas.Conta,
                    Natureza = PlanoDeContas.Natureza,
                    Nivel = PlanoDeContas.Nivel,
                };
            }

            return null;
        }
    }
}
