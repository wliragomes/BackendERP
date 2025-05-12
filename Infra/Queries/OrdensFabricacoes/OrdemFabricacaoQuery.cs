using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.OrdensFabricacoes.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.OrdensFabricacoes;
using SharedKernel.Configuration.Extensions;
using Domain.Entities;
using Application.DTOs.Vendas.Filtro;
using Application.DTOs.OrdensFabricacoes.Relatorios;
using Dapper;
using Application.DTOs.PlanejamentosProducoes;

namespace Infra.Queries.OrdensFabricacoes
{
    public class OrdemFabricacaoQuery : IOrdemFabricacaoQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public OrdemFabricacaoQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<OrdemFabricacaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.OrdemFabricacao.AsNoTracking();

            var data = query.Select(x => new OrdemFabricacaoFilterDto
            {
                Id = x.Id,
                SqOrdemFabricacaoCodigo = x.SqOrdemFabricacaoCodigo,
                SqOrdemFabricacaoAno = x.SqOrdemFabricacaoAno,
                IdVenda = x.IdVenda,
                IdPessoa = x.IdPessoa,
                NomeContato = x.NomeContato,
            });

            var response = await data.RetonarFiltroCustomizado<OrdemFabricacaoFilterDto, OrdemFabricacaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<OrdemFabricacaoByCodeDto?> RetornarPorId(Guid id)
        {
            string query = @"
                            SELECT 
                                a.CD_ORDEM_FABRICACAO as Id,
                                a.CD_VENDA as IdVenda,
                                a.SQ_ORDEM_FABRICACAO_CODIGO as SqOrdemFabricacaoCodigo,   
                                a.SQ_ORDEM_FABRICACAO_ANO as SqOrdemFabricacaoAno,  
                                a.CD_STATUS as IdStatus,
                                a.CD_PESSOA as IdPessoa,
                                a.PR_VIDRO_MODULADO as VidroModulado,
                                a.FL_CHAPA as Chapa,
                                a.DT_CRIACAO as DataCriacao,
                                a.DT_EFETIVACAO as DataEfetivacao,
                                a.NM_CONTATO as NomeContato,
                                a.NR_TEL_CONTATO as Telefone,
                                a.NR_TEL_CONTATO_CELULAR as Celular,
                                a.CD_ENDERECO_ENTREGA as IdEnderecoEntrega,
                                a.DS_OBRA as Obra,
                                a.NM_ENGENHEIRO_RESPONSAVEL as Engenheiro,
                                a.TX_OBSERVACAO as Observacao,
                                a.FL_ETIQUETA_GRANDE_TEMPERADO as EtiquetaGrandeTemperado,
                                a.FL_DESCARGA_CONTA_CLIENTE as DescargaCliente,
                                a.QT_DIAS_ENTREGA as DiasEntrega,
                                a.DT_ENTREGA as DataEntrega,

                                b.SQ_ITEM as SqItem,
                                b.SQ_VENDA_ITEM as SqVendaItem,
                                b.CD_PRODUTO as IdProduto,
                                b.NM_PRODUTO as NomeProduto,
                                b.DS_PRODUTO as DescricaoProduto,
                                b.VL_ESPESSURA as Espessura,
                                b.NR_ALTURA as Altura,
                                b.NR_LARGURA as Largura,
                                b.QT_PECA as Quantidade,
                                b.FL_ARAMADO as Aramado,
                                b.FL_MODELADO as Modelado,
                                b.VL_M2 as ValorM2,
                                b.VL_M_LINEAR as ValorM,
                                b.VL_PESO as ValorPeso,
                                b.VL_M2_REAL as ValorM2Real,
                                b.VL_M_LINEAR_REAL as ValorMReal,
                                b.VL_PESO_REAL as ValorPesoReal,
                                b.VL_AREA_MINIMA as ValorAreaMinima,
                                b.CD_SETOR_PRODUTO as IdSetorProduto,
                                b.CD_PROJETO as IdProjeto,
                                b.VL_LAPIDACAO_ALTURA as AlturaLapidacao,
                                b.VL_LAPIDACAO_ALTURA as AlturaLapidacao,
                                b.VL_LAPIDACAO_LARGURA as LarguraLapidacao,
                                b.FL_MANUAL as Manual,
                                b.FL_CORTADO as Cortado,
                                b.FL_FILETE_01 as Filete1,
                                b.FL_FILETE_02 as Filete2,
                                b.FL_FILETE_03 as Filete3,
                                b.FL_FILETE_04 as Filete4,
                                b.FL_INDUSTRIAL_01 as Industrial1,
                                b.FL_INDUSTRIAL_02 as Industrial2,
                                b.FL_INDUSTRIAL_03 as Industrial3,
                                b.FL_INDUSTRIAL_04 as Industrial4,
                                b.FL_POLIDA_01 as Polida1,
                                b.FL_POLIDA_02 as Polida2,
                                b.FL_POLIDA_03 as Polida3,
                                b.FL_POLIDA_04 as Polida4,
                                b.FL_QUEBRA_CANTO as QuebraCanto,
                                b.FL_REVENDA as Revenda,
                                b.FL_INSTACACAO as Instalacao,
                                b.FL_EDGE_DELETION as ManterEdgeDeletion,
                                b.FL_EDGE_DELETION_CANCELADO as CancelarEdgeDeletion,

                                c.SQ_ARQUIVO as SqArquivo,
                                c.DS_ARQUIVO as Descricao,
                                c.NM_ORIGINAL as NomeOriginal,
                                c.NM_DESTSINO as Destino,
                                c.DS_ENDERECO_ORIGINAL as EnderecoOriginal,
                                c.DS_ENDERECO_DESTINO as EnderecoDestino,
                                c.ARQUIVO as Arquivo           
                            FROM 
                                TB_ORDEM_FABRICACAO a
                                LEFT JOIN TB_ORDEM_FABRICACAO_ITEM b ON a.CD_ORDEM_FABRICACAO = b.CD_ORDEM_FABRICACAO
                                LEFT JOIN Cratos_arquivos.dbo.TB_ORDEM_FABRICACAO_ARQUIVO c ON a.CD_ORDEM_FABRICACAO = c.CD_ORDEM_FABRICACAO
                            WHERE 
                                a.CD_ORDEM_FABRICACAO = @id";

            using var connection = _dbContext.Database.GetDbConnection();

            var ordemFabricacaoDict = new Dictionary<Guid, OrdemFabricacaoByCodeDto>();

            var result = await connection.QueryAsync<OrdemFabricacaoByCodeDto, OrdemFabricacaoItemDto, OrdemFabricacaoArquivoFilterDto, OrdemFabricacaoByCodeDto>(
                query,
                (ordem, item, arquivo) =>
                {
                    if (!ordemFabricacaoDict.TryGetValue(ordem.Id, out var ordemEntry))
                    {
                        ordem.OrdemFabricacaoItem = new List<OrdemFabricacaoItemDto>();
                        ordem.OrdemFabricacaoArquivo = new List<OrdemFabricacaoArquivoFilterDto>();
                        ordemFabricacaoDict[ordem.Id] = ordem;
                        ordemEntry = ordem;
                    }

                    if (item?.SqItem > 0 && !ordemEntry.OrdemFabricacaoItem.Any(i => i.SqItem == item.SqItem))
                        ordemEntry.OrdemFabricacaoItem.Add(item);

                    if (arquivo?.SqArquivo > 0 && !ordemEntry.OrdemFabricacaoArquivo.Any(a => a.SqArquivo == arquivo.SqArquivo))
                        ordemEntry.OrdemFabricacaoArquivo.Add(arquivo);

                    return ordemEntry;
                },
                new { id },
                splitOn: "SqItem,SqArquivo" // Ajuste os nomes conforme os campos reais
            );

            return ordemFabricacaoDict.Values.FirstOrDefault();
        }

        public async Task<OrdemFabricacaoItemDimensaoCalculoDto?> GetCalculoDimensoesItem(OrdemFabricacaoItemDimensaoDto dimensao)
        {
            string query = @"SELECT 
                                metros_quadrados_r, metros_lineares_r, peso_kg_r, metros_quadrados_m, metros_lineares_m, peso_kg_m, area_minima
                            FROM FN_CALCULA_METRICAS
                            (@altura_mm, @largura_mm, @quantidade_pecas, @cod_vidro, @arredondamento, @vlr_modulado, @ds_projeto)";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarDapper<OrdemFabricacaoItemDimensaoCalculoDto?>(query, new
                {
                    altura_mm = dimensao.altura_mm,
                    largura_mm = dimensao.largura_mm,
                    quantidade_pecas = dimensao.quantidade_pecas,
                    cod_vidro = dimensao.cod_vidro,
                    arredondamento = dimensao.arredondamento,
                    vlr_modulado = dimensao.vlr_modulado,
                    ds_projeto = dimensao.ds_projeto
                });
            }
        }

        public async Task<OrdemFabricacaoCalculoLapidacaoDto?> GetCalculoLapidacaoItem(OrdemFabricacaoItemLapidacaoDto lapidacao)
        {
            string query = @"SELECT 
                                VL_ALTURA, VL_LARGURA 
                            FROM FN_TOLERANCIA_LAPIDADAO
                            (@CD_AMIGAVEL, @cortado_manual, @VAR_1, @VAR_2, @VAR_3, @VAR_4)";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarDapper<OrdemFabricacaoCalculoLapidacaoDto?>(query, new
                {
                    CD_AMIGAVEL = lapidacao.CD_AMIGAVEL,
                    cortado_manual = lapidacao.cortado_manual,
                    VAR_1 = lapidacao.VAR_1,
                    VAR_2 = lapidacao.VAR_2,
                    VAR_3 = lapidacao.VAR_3,
                    VAR_4 = lapidacao.VAR_4
                });
            }
        }

        public async Task<PaginacaoResponse<OrdemFabricacaoListaRomaneioDto>> RetornarOrdemFabricacaoRomaneioPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.OrdemFabricacaoItem
                .AsNoTracking()
                .Include(ee => ee.Produto)
                .Include(ee => ee.OrdemFabricacao)


                .Select(x => new OrdemFabricacaoListaRomaneioDto
                {
                    Id = x.Id,
                    SqOrdemFabricacaoCodigo = x.OrdemFabricacao.SqOrdemFabricacaoCodigo,
                    SqOrdemFabricacaoAno = x.OrdemFabricacao.SqOrdemFabricacaoAno,
                    IdProduto = x.IdProduto,
                    NomeProduto = x.NomeProduto,
                    DescricaoProduto = x.DescricaoProduto,
                    Quantidade = x.Quantidade,
                    Altura = x.Altura,
                    Largura = x.Largura,
                    CodigoAmigavel = x.Produto.CodigoAmigavel,
                    PesoBruto = x.Produto.PesoBruto
                });

            var response = await query.RetonarFiltroCustomizado<OrdemFabricacaoListaRomaneioDto, OrdemFabricacaoListaRomaneioDto>(paginacaoRequest);
            return response;
        }

        public async Task<PaginacaoResponse<OrdemFabricacaoGetDto>> RetornarOrdemFabricacaoGetPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.OrdemFabricacao
                .AsNoTracking()
                .Include(ee => ee.Pessoa)


                .Select(x => new OrdemFabricacaoGetDto
                {
                    Id = x.Id,
                    IdPessoa = x.IdPessoa,
                    RazaoSocial  = x.Pessoa.RazaoSocial,
                    SqOrdemFabricacaoCodigo = x.SqOrdemFabricacaoCodigo,
                    SqOrdemFabricacaoAno = x.SqOrdemFabricacaoAno,
                    Obra = x.Obra,
                });

            var response = await query.RetonarFiltroCustomizado<OrdemFabricacaoGetDto, OrdemFabricacaoGetDto>(paginacaoRequest);
            return response;
        }

        public async Task<List<ProformaClienteDto>> RetornarClienteProforma(Guid idOrdemFabricacao)
        {
            string query = @"select 
	                            a.NM_RAZAO_SOCIAL, 
	                            a.CD_CNPJ_CPF, 
                                (c.DS_ENDERECO + ', ' + c.NR_NUMERO + ' - ' + c.NM_BAIRRO) as Endereco, 
                                (c.NR_CEP + ' - ' + e.NM_CIDADE + ' - ' + d.SG_ESTADO) as EnderecoLinha2,
	                            c.NR_CEP, 
	                            e.NM_CIDADE, 
	                            d.SG_ESTADO, 
	                            f.DS_OBRA 
                            from 
	                            Cratos.dbo.TB_PESSOA as a 
	                            inner join Cratos.dbo.TB_RELACIONA_PESSOA_ENDERECO as b on 
		                            a.CD_PESSOA = b.CD_PESSOA
	                            inner join Cratos.dbo.TB_ENDERECO as c on
		                            b.CD_ENDERECO = c.CD_ENDERECO
	                            inner join Cratos.dbo.TB_ESTADO as d on
		                            c.CD_UF = d.CD_ESTADO
	                            inner join Cratos.dbo.TB_CIDADE as e on
		                            c.CD_CIDADE = e.CD_CIDADE
	                            inner join Cratos.dbo.TB_ORDEM_FABRICACAO as f on
		                            f.CD_PESSOA = a.CD_PESSOA
                            where
	                            f.CD_ORDEM_FABRICACAO = @idOrdemFabricacao";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<ProformaClienteDto>(query, new
                {
                    idOrdemFabricacao = idOrdemFabricacao
                });
            }
        }

        public async Task<ResultadoOrdemFabricacaoResumoDto?> GetOrdemFabricacaoResumo(Guid idOrdemTmp)
        {
            string query = @"EXEC dbo.PR_CALCULA_ORDEM_FABRICACAO_RESUMO 
                                      @CD_ORDEM_TMP = @IdOrdemTmp, 
                                      @APAGAR = 1";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarDapper<ResultadoOrdemFabricacaoResumoDto?>(query, new
                {
                    IdOrdemTmp = idOrdemTmp,
                });
            }
        }

        public async Task<PaginacaoResponse<GetTemporarioDto>> RetornarGetTemporarioPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.OrdemFabricacaoItemTemporaria
                .AsNoTracking();

            var data = query.Select(x => new GetTemporarioDto
            {
                Id = x.Id,
                IdVenda = x.IdVenda,
                SqVendaItem = x.SqVendaItem,
            });

            var response = await data.RetonarFiltroCustomizado<GetTemporarioDto, GetTemporarioDto>(paginacaoRequest);
            return response;
        }

        public async Task<List<GetTemporarioDto?>> RetornarGetTemporarioPaginacao(Guid idVenda)
        {
            string query = @"SELECT 
                                CD_ORDEM_TMP AS id,
		                        CD_VENDA as IdVenda,
		                        SQ_VENDA_ITEM as SqVendaItem
                            FROM TB_TMP_ORDEM_FABRICACAO_ITEM_RESUMO                                
                            WHERE 
                                CD_VENDA = @IdVenda AND
                                SQ_VENDA_ITEM = 1";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<GetTemporarioDto?>(query, new { IdVenda = idVenda });
            }
        } 

        public async Task<List<GetOrdemFabricacaoObterVendaDto?>> RetornarVendaPorOrdemFabricacao(int sqOrdemFabricacaoCodigo, int sqOrdemFabricacaoAno)
        {
            string query = @"SELECT 
                                A.SQ_VENDA_CODIGO AS CodigoVenda,
			                    A.SQ_VENDA_ANO AS AnoVenda
                            FROM TB_VENDA as A
                                INNER JOIN TB_ORDEM_FABRICACAO AS B ON A.CD_VENDA = B.CD_VENDA
                            WHERE 1 = 1
                                AND A.BT_REMOVIDO = 0
			                    AND B.BT_REMOVIDO = 0
			                    AND B.SQ_ORDEM_FABRICACAO_CODIGO = @SqOrdemFabricacaoCodigo	
			                    AND B.SQ_ORDEM_FABRICACAO_ANO = @SqOrdemFabricacaoAno";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<GetOrdemFabricacaoObterVendaDto?>(query, new { SqOrdemFabricacaoCodigo = sqOrdemFabricacaoCodigo, SqOrdemFabricacaoAno = sqOrdemFabricacaoAno });
            }
        }  

        public async Task<EnderecoOrdemFabricacaoDto?> RetornarEnderecoOrdemFabricacao(Guid id, Guid idEnderecoEntrega)
        {
            string query = @"SELECT 
                                a.CD_ORDEM_FABRICACAO as Id,
	                            a.CD_ENDERECO_ENTREGA AS IdEnderecoEntrega,
	                            b.NR_CEP as Cep,
	                            b.DS_ENDERECO as Logradouro,
	                            b.NR_NUMERO as Numero,
	                            b.DS_COMPLEMENTO as Complemento,
	                            b.CD_UF as IdEstado,
	                            b.CD_CIDADE as IdCidade,
	                            b.NM_BAIRRO as Bairro
                            FROM TB_ORDEM_FABRICACAO a
	                            INNER JOIN TB_ENDERECO b ON a.CD_ENDERECO_ENTREGA = b.CD_ENDERECO
                            WHERE 
                                a.CD_ORDEM_FABRICACAO = @Id
	                            and b.CD_ENDERECO = @IdEnderecoEntrega";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarDapper<EnderecoOrdemFabricacaoDto?>(query, new { Id = id, IdEnderecoEntrega = idEnderecoEntrega });
            }
        }
    }
}