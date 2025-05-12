using Application.DTOs.Produtos.Filtro;
using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;
using Domain.Entities.Produtos;
using Application.DTOs.Pessoas.Filtro;
using Application.DTOs.Produtos.Ncms.Filtro;
using Application.DTOs.Produtos.SetorProduto.Filtro;
using Application.DTOs.Produtos.UnidadesMedidas.Filtro;
using Application.DTOs.Produtos.ClasseReajustes.Filtro;
using Application.DTOs.Produtos.DesgastePolimentos.Filtro;
using Application.DTOs.Produtos;
using Application.DTOs.OrdensFabricacoes;
using Application.DTOs.Produtos.SetoresDeProdutos.Filtro;

namespace Infra.Queries.Produtos
{
    public class ProdutoQuery : IProdutoQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public ProdutoQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<ProdutoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Produto.AsNoTracking()
                        .Include(s => s.SetorProduto)
                        .AsQueryable();

            var data = query.Select(x => new ProdutoFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
                CodigoAmigavel = x.CodigoAmigavel,
                UnidadeMedidaId = x.IdUnidadeMedida,
                PesoBruto = x.PesoBruto,
                PesoLiquido = x.PesoLiquido,
                CodigoBarras = x.CodigoBarras,
                Bloqueado = x.Bloqueado ?? false,
                Perfil = x.SetorProduto!.Perfil
            });

            var response = await data.RetonarFiltroCustomizado<ProdutoFilterDto, ProdutoFilterDto>(paginacaoRequest);
            return response;
        }

        //public async Task<PaginacaoResponse<ProdutoOrdemFabricacaoFilterDto>> RetornarProdutoOrdemFabricacaoPaginacao(PaginacaoRequest paginacaoRequest)
        //{
        //    var query = _dbContext.Produto.AsNoTracking()
        //                .Include(s => s.VendaItem)
        //                .Include(s => s.SetorProduto)
        //                .AsQueryable();

        //    var data = query.Select(x => new ProdutoOrdemFabricacaoFilterDto
        //    {
        //        IdProduto = x.Id,
        //        CodigoAmigavel = x.CodigoAmigavel,
        //        Nome = x.Nome,
        //        Espessura = x.Espessura,
        //        IdSetorProduto = x.IdSetorProduto,
        //        EdgeDeleton = x.EdgeDeleton,
        //        //DescricaoProdutoVenda = x.VendaItem.DescricaoProduto,
                
        //    });

        //    var response = await data.RetonarFiltroCustomizado<ProdutoOrdemFabricacaoFilterDto, ProdutoOrdemFabricacaoFilterDto>(paginacaoRequest);
        //    return response;
        //}

        public async Task<List<ProdutoOrdemFabricacaoFilterDto?>> RetornarProdutoPorVendaPaginacao(Guid idVenda)
        {
            string query = @"SELECT 
                                A.CD_PRODUTO as IdProduto,
		                        A.CD_AMIGAVEL as CodigoAmigavel,
		                        A.NR_ESPESSURA as Espessura,
		                        A.FL_EDGE_DELETION AS edgeDeleton,
		                        D.DS_SETOR_PRODUTO AS SetorProduto,
		                        D.CD_SETOR_PRODUTO AS IdSetorProduto,
                                B.DS_PRODUTO AS DescricaoProduto
                            FROM TB_PRODUTO AS A 
                                INNER JOIN TB_VENDA_ITEM AS B ON A.CD_PRODUTO = B.CD_PRODUTO
                                INNER JOIN TB_VENDA AS C ON C.CD_VENDA = B.CD_VENDA
                                INNER JOIN TB_SETOR_PRODUTO AS D ON A.CD_SETOR_PRODUTO = D.CD_SETOR_PRODUTO
                            WHERE 1 = 1
		                        AND A.BT_REMOVIDO = 0
		                        AND B.BT_REMOVIDO = 0
		                        AND C.BT_REMOVIDO = 0
		                        AND D.BT_REMOVIDO = 0		                        
                                AND C.CD_VENDA = @IdVenda";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<ProdutoOrdemFabricacaoFilterDto?>(query, new {IdVenda = idVenda });
            }
        }

        public async Task<ProdutoByIdDto?> RetornarPorId(Guid id)
        {
            var produto = await _dbContext.Produto
                .Include(pt => pt.PrecosTributacoes)
                .Include(c => c.Composicao)
                .Include(pf => pf.RelacionaProdutoFornecedor).ThenInclude(p => p.Pessoa)
                .Include(s => s.SetorProduto)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (produto == null)
                return null;

            // ⚠️ Carregar manualmente os dados dos produtos da composição  
            foreach (var item in produto.Composicao)
            {
                item.Produto = await _dbContext.Produto
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == item.IdComposicao);
            }

            // Fetch NomeMateriaPrima and CodigoAmigavelMateriaPrima  
            var materiaPrima = produto.IdMateriaPrima.HasValue
                ? await _dbContext.Produto.AsNoTracking().FirstOrDefaultAsync(p => p.Id == produto.IdMateriaPrima.Value)
                : null;

            return new ProdutoByIdDto
            {
                Id = produto.Id,
                CodigoAmigavel = produto.CodigoAmigavel,
                Nome = produto.Nome,
                IdUnidadeMedida = produto.IdUnidadeMedida,
                Espessura = produto.Espessura,
                PesoBruto = produto.PesoBruto,
                PesoLiquido = produto.PesoLiquido,
                IdSetorProduto = produto.IdSetorProduto,
                CodigoBarras = produto.CodigoBarras,
                EstoqueMinimo = produto.EstoqueMinimo,
                EstoqueMaximo = produto.EstoqueMaximo,

                IdMateriaPrima = produto.IdMateriaPrima,
                CodigoAmigavelMateriaPrima = materiaPrima?.CodigoAmigavel,
                NomeMateriaPrima = materiaPrima?.Nome,

                IdCodigoImportacao = produto.IdCodigoImportacao,
                CorteCerto = produto.CorteCerto,
                IdTipoProduto = produto.IdTipoProduto,
                IdGrupo = produto.IdGrupo,
                IdSubgrupo = produto.IdSubgrupo,
                IdFamilia = produto.IdFamilia,
                IdSetor = produto.IdSetor,
                Perfil = produto.SetorProduto?.Perfil ?? false,
                IdRua = produto.IdRua,
                IdPrateleira = produto.IdPrateleira,
                Posicao = produto.Posicao,
                InformacoesComplementares = produto.InformacoesComplementares,
                EdgeDeleton = produto.EdgeDeleton ?? false,
                Bloqueado = produto.Bloqueado ?? false,
                DataBloqueio = produto.DataBloqueio,

                PrecosTributacoes = produto.PrecosTributacoes.Select(pt => new PrecosTributacoesDto
                {
                    IdNcm = pt.IdNcm,
                    NrNcmCompleta = _dbContext.Ncm
                                      .Where(n => n.Id == pt.IdNcm)
                                      .Select(n => n.NrNcmCompleta)
                                      .FirstOrDefault(),
                    IdOrigemMaterial = pt.IdOrigemMaterial,
                    IdTipoPreco = pt.IdTipoPreco,
                    IdClasseReajuste = pt.IdClasseReajuste,
                    Ipi = _dbContext.Ncm
                                      .Where(n => n.Id == pt.IdNcm)
                                      .Select(n => n.Aliquota)
                                      .FirstOrDefault(),
                    PrecoCusto = pt.PrecoCusto,
                    PrecoVenda = pt.PrecoVenda,
                    Inativo = pt.Inativo
                }).ToList(),

                Composicao = produto.Composicao.Select(c => new ComposicaoDto
                {
                    IdProduto = c.IdComposicao,
                    codigoAmigavel = c.Produto?.CodigoAmigavel,
                    nome = c.Produto?.Nome,
                    SequenciaComposicao = c.SequenciaComposicao,
                    PerfilH = c.PerfilH,
                    PerfilL = c.PerfilL,
                    Etiqueta = c.Etiqueta
                }).ToList(),

                Fornecedor = produto.RelacionaProdutoFornecedor.Select(f => new RelacionaProdutoFornecedorDto
                {
                    IdFornecedor = f.IdFornecedor,
                    RazaoSocial = f.Pessoa.RazaoSocial,
                    CodigoProdutoFornecedor = f.CodigoProdutoFornecedor
                }).ToList()
            };
        }


        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarTipoProdutoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.TipoProduto.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarTipoProdutoPorId(Guid id)
        {
            var tipoproduto = await _dbContext.TipoProduto
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (tipoproduto != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = tipoproduto.Id,
                    Descricao = tipoproduto.Nome,
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarGrupoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Grupo.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarGrupoPorId(Guid id)
        {
            var Grupo = await _dbContext.Grupo
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Grupo != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = Grupo.Id,
                    Descricao = Grupo.Nome,
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarCodigoImportacaoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.CodigoImportacao.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarCodigoImportacaoPorId(Guid id)
        {
            var codigo = await _dbContext.CodigoImportacao
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (codigo != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = codigo.Id,
                    Descricao = codigo.Nome,
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarSubgrupoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Subgrupo.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarSubgrupoPorId(Guid id)
        {
            var subgrupo = await _dbContext.Subgrupo
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (subgrupo != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = subgrupo.Id,
                    Descricao = subgrupo.Nome,
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarFamiliaPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Familia.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarFamiliaPorId(Guid id)
        {
            var familia = await _dbContext.Familia
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (familia != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = familia.Id,
                    Descricao = familia.Nome
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarSetorPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Setor.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarSetorPorId(Guid id)
        {
            var setor = await _dbContext.Setor
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (setor != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = setor.Id,
                    Descricao = setor.Nome
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarPrateleiraPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Prateleira.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarPrateleiraPorId(Guid id)
        {
            var prateleira = await _dbContext.Prateleira
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (prateleira != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = prateleira.Id,
                    Descricao = prateleira.Nome,
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarRuaPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Rua.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarRuaPorId(Guid id)
        {
            var rua = await _dbContext.Rua
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (rua != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = rua.Id,
                    Descricao = rua.Nome,
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarTipoPrecoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.TipoPreco.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarTipoPrecoPorId(Guid id)
        {
            var tipopreco = await _dbContext.TipoPreco
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (tipopreco != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = tipopreco.Id,
                    Descricao = tipopreco.Nome,
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarOrigemMaterialPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.OrigemMaterial.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarOrigemMaterialPorId(Guid id)
        {
            var origemmaterial = await _dbContext.OrigemMaterial
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (origemmaterial != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = origemmaterial.Id,
                    Descricao = origemmaterial.Nome,
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<NcmByCodeDto>> RetornarNcmPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Ncm.AsNoTracking();

            var data = query.Select(x => new NcmByCodeDto
            {
                Id = x.Id,
                NrNcm01 = x.NrNcm01,
                NrNcm02 = x.NrNcm02,
                NrNcm03 = x.NrNcm03,
                NrNcmCompleta = x.NrNcmCompleta,
                Descricao = x.Descricao,
                Aliquota = x.Aliquota
            });

            var response = await data.RetonarFiltroCustomizado<NcmByCodeDto, NcmByCodeDto>(paginacaoRequest);
            return response;
        }

        public async Task<List<NcmByProdutoDto?>> RetornarNcmPorProduto(Guid idProduto)
        {
            string query = @"SELECT 
                                N.CD_NCM AS Id, 
                                N.NR_NCM_COMPLETA AS Descricao,
                                N.VL_ALIQUOTA as AliquotaIPI,
                                N.FL_INSITE_ST as InsideST,
                                N.VL_ALIQUOTA_ST as AliquotaST
                            FROM TB_NCM AS N
                            INNER JOIN TB_PRODUTO_PRECO_TRIBUTACAO AS PT ON N.CD_NCM = PT.CD_NCM
                            INNER JOIN TB_PRODUTO AS P ON PT.CD_PRODUTO = P.CD_PRODUTO
                            WHERE 
                                    N.BT_REMOVIDO = 0
                                AND PT.BT_REMOVIDO = 0
                                AND P.BT_REMOVIDO = 0
                                AND PT.FL_INATIVO = 0
                                AND P.CD_PRODUTO = @IdProduto";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<NcmByProdutoDto?>(query, new { IdProduto = idProduto });
            }
        }

        public async Task<NcmByCodeDto?> RetornarNcmPorId(Guid id)
        {
            var ncm = await _dbContext.Ncm
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (ncm != null)
            {
                return new NcmByCodeDto
                {
                    Id = ncm.Id,
                    NrNcm01 = ncm.NrNcm01,
                    NrNcm02 = ncm.NrNcm02,
                    NrNcm03 = ncm.NrNcm03,
                    NrNcmCompleta = ncm.NrNcmCompleta,
                    Descricao = ncm.Descricao,
                    Aliquota = ncm.Aliquota,
                    InsiteSt = ncm.InsiteSt,
                    AliquotaSt = ncm.AliquotaSt
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<SetorProdutoByCodeDto>> RetornarSetorProdutoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.SetorProduto.AsNoTracking();

            var data = query.Select(x => new SetorProdutoByCodeDto
            {
                Id = x.Id,
                CodigoSetor = x.CodigoSetor,
                Componente = x.Componente,
                Cmax = x.Cmax,
                Cmin = x.Cmin,
                Lmax = x.Lmax,
                Lmin = x.Lmin,
                Descricao = x.Descricao,
                Perfil = x.Perfil,
                CobrancaMinima = x.CobrancaMinima,
                SetorFabricação = x.SetorFabricacao,
                Pvb = x.Pvb,
                Argonio = x.Argonio,
                MostrarCadastro = x.MostrarCadastro
            });

            var response = await data.RetonarFiltroCustomizado<SetorProdutoByCodeDto, SetorProdutoByCodeDto>(paginacaoRequest);
            return response;
        }

        public async Task<List<SetorProdutoFilterDto?>> RetornarSetorProdutoPorCadastro(bool mostrarCadastro)
        {
            string query = @"SELECT 
                                CD_SETOR_PRODUTO as Id,
		                        DS_SETOR_PRODUTO as Descricao,
		                        FL_MOSTRAR_CADASTRO as MostrarCadastro
                            FROM TB_SETOR_PRODUTO                               
                            WHERE 
                                FL_MOSTRAR_CADASTRO = @MostrarCadastro
                                AND BT_REMOVIDO = 0";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<SetorProdutoFilterDto?>(query, new { MostrarCadastro = mostrarCadastro });
            }
        }

        public async Task<SetorProdutoByCodeDto?> RetornarSetorProdutoPorId(Guid id)
        {
            var setorproduto = await _dbContext.SetorProduto
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (setorproduto != null)
            {
                return new SetorProdutoByCodeDto
                {
                    Id = setorproduto.Id,
                    CodigoSetor = setorproduto.CodigoSetor,
                    Componente = setorproduto.Componente,
                    Cmax = setorproduto.Cmax,
                    Cmin = setorproduto.Cmin,
                    Lmax = setorproduto.Lmax,
                    Lmin = setorproduto.Lmin,
                    Descricao = setorproduto.Descricao,
                    Perfil = setorproduto.Perfil,
                    Pvb = setorproduto.Pvb,
                    Argonio = setorproduto.Argonio,
                    MostrarCadastro = setorproduto.MostrarCadastro,

                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<UnidadeMedidaByCodeDto>> RetornarUnidadeMedidaPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.UnidadeMedida.AsNoTracking();

            var data = query.Select(x => new UnidadeMedidaByCodeDto
            {
                Id = x.Id,
                Descricao = x.Nome,
                Sigla = x.Sigla,
                CasaDecimal = (int)x.CasasDecimais,

            });

            var response = await data.RetonarFiltroCustomizado<UnidadeMedidaByCodeDto, UnidadeMedidaByCodeDto>(paginacaoRequest);
            return response;
        }

        public async Task<UnidadeMedidaByCodeDto?> RetornarUnidadeMedidaPorId(Guid id)
        {
            var unidademedida = await _dbContext.UnidadeMedida
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (unidademedida != null)
            {
                return new UnidadeMedidaByCodeDto
                {
                    Id = unidademedida.Id,
                    Descricao = unidademedida.Nome,
                    Sigla = unidademedida.Sigla,
                    CasaDecimal = (int)unidademedida.CasasDecimais,
                };
            }

            return null;
        }        

        public async Task<PaginacaoResponse<DesgastePolimentoFilterDto>> RetornarDesgastePolimentoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.DesgastePolimento.AsNoTracking();

            var data = query.Select(x => new DesgastePolimentoFilterDto
            {
                Id = x.Id,
                EspessuraVidroMinimo = x.EspessuraVidroMinimo,
                EspessuraVidroMaximo = x.EspessuraVidroMaximo,
                QuantidadeDesgasteLado = x.QuantidadeDesgasteLado,
                QuantidadeDesgasteTotal = x.QuantidadeDesgasteTotal

            });

            var response = await data.RetonarFiltroCustomizado<DesgastePolimentoFilterDto, DesgastePolimentoFilterDto>(paginacaoRequest);
            return response;

        }

        public async Task<DesgastePolimentoByCodeDto?> RetornarDesgastePolimentoPorId(Guid id)
        {
            var desgastePolimento = await _dbContext.DesgastePolimento
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (desgastePolimento != null)
            {
                return new DesgastePolimentoByCodeDto
                {
                    Id = desgastePolimento.Id,
                    EspessuraVidroMinimo = desgastePolimento.EspessuraVidroMinimo,
                    EspessuraVidroMaximo = desgastePolimento.EspessuraVidroMaximo,
                    QuantidadeDesgasteLado = desgastePolimento.QuantidadeDesgasteLado,
                    QuantidadeDesgasteTotal = desgastePolimento.QuantidadeDesgasteTotal
                };
            }

            return null;
        }

        public async Task<PaginacaoResponse<ClasseReajusteByCodeDto>> RetornarClasseReajustePaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.ClasseReajuste.AsNoTracking();

            var data = query.Select(x => new ClasseReajusteByCodeDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Descricao = x.Descricao
            });

            var response = await data.RetonarFiltroCustomizado<ClasseReajusteByCodeDto, ClasseReajusteByCodeDto>(paginacaoRequest);
            return response;
        }

        public async Task<ClasseReajusteByCodeDto?> RetornarClasseReajustePorId(Guid id)
        {
            var classeReajuste = await _dbContext.ClasseReajuste
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (classeReajuste != null)
            {
                return new ClasseReajusteByCodeDto
                {
                    Id = classeReajuste.Id,
                    Nome = classeReajuste.Nome,
                    Descricao = classeReajuste.Descricao,

                };
            }
            return null;
        }
    }
}
