using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;
using Application.DTOs.Vendas.Filtro;
using Application.DTOs.Vendas.TiposFretes.Filtro;
using Application.DTOs.TiposFretes.Filtro;
using Application.DTOs.Faturas;
using Application.DTOs.Vendas;
using Application.DTOs.Pessoas;
using Application.DTOs.Vendas.Relatorios;
using Application.DTOs.Pessoas.Filtro;

namespace Infra.Queries.Vendas
{
    public class VendaQuery : IVendaQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public VendaQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<VendaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var data = await _dbContext.Venda
                .AsNoTracking()
                .GroupBy(x => new { x.CodigoVenda, x.AnoVenda })
                .Select(g => g
                    .OrderByDescending(x => x.Release) // ou .OrderByDescending(x => x.UpdateAt)
                    .Select(x => new
                    {
                        x.Id,
                        x.IdCliente,
                        RazaoSocial = x.Pessoa != null ? x.Pessoa.RazaoSocial : null,
                        Status = x.Status.Descricao,
                        x.CodigoVenda,
                        x.AnoVenda,
                        x.EmailContato,
                        x.SuprimiVendedor
                    })
                    .FirstOrDefault())
                .ToListAsync();

            var result = data.Select(x => new VendaFilterDto
            {
                Id = x.Id,
                IdCliente = x.IdCliente,
                RazaoSocial = x.RazaoSocial,
                Status = x.Status,
                Numero = FormatarCodigoAno(x.CodigoVenda, x.AnoVenda),
                EmailContato = x.EmailContato,
                SuprimirVendedor = x.SuprimiVendedor
            });

            var response = await result.RetonarFiltroCustomizado<VendaFilterDto, VendaFilterDto>(paginacaoRequest);
            return response;
        }

        private static string FormatarCodigoAno(int codigo, int? ano)
        {
            return $"{codigo:D5}/{ano}";
        }


        public async Task<VendaOrdemFabricacaoFilterDto?> RetornarOrdemFabricacao(string codigoAnoVenda)
        {
            var venda = await _dbContext.Venda
                .AsNoTracking()
                .Include(ee => ee.EnderecoEntrega.Cidade)
                .Include(ee => ee.VendaItem)
                    .ThenInclude(ee => ee.Produto)
                .Where(x => (x.CodigoVenda.ToString() + x.AnoVenda.ToString()) == codigoAnoVenda)
                .OrderByDescending(x => x.Release)
                .Select(x => new VendaOrdemFabricacaoFilterDto
                {
                    Id = x.Id,
                    CodigoVenda = x.CodigoVenda,
                    AnoVenda = x.AnoVenda,
                    Release = x.Release,
                    IdCliente = x.IdCliente,
                    NomeContato = x.NomeContato,
                    Endereco = x.EnderecoEntrega == null ? null : new EnderecoVendaOrdemDto
                    {
                        Id = x.EnderecoEntrega.Id,
                        IdTipoEndereco = x.EnderecoEntrega.IdTipoEndereco,
                        Cep = x.EnderecoEntrega.Cep,
                        Logradouro = x.EnderecoEntrega.EnderecoDescricao,
                        Numero = x.EnderecoEntrega.Numero,
                        Complemento = x.EnderecoEntrega.Complemento,
                        Bairro = x.EnderecoEntrega.Bairro,
                        IdCidade = x.EnderecoEntrega.IdCidade,
                        IdUf = x.EnderecoEntrega.IdUf
                    },
                    TelefoneContato = x.TelefoneContato,
                    DescricaoObra = x.DescricaoObra,
                    CodigoAnoVenda = x.CodigoVenda.ToString() + x.AnoVenda.ToString(),
                    IdProduto = x.VendaItem.Select(i => i.IdProduto).FirstOrDefault()
                })
                .FirstOrDefaultAsync();

            return venda;
        }


        public async Task<VendaByCodeDto?> RetornarPorId(Guid id)
        {
            var venda = await _dbContext.Venda
                .Include(s => s.Status)
                .Include(c => c.VendaItem)
                    .ThenInclude(p => p.Produto)
                .Include(c => c.VendaOrdem)
                    .ThenInclude(e => e.Endereco)
                .Include(c => c.RelacionaFaturaVendaRecebimentoTipo)
                    .ThenInclude(r => r.VendaRecebimentoTipo)
                    .ThenInclude(p => p.VendaRecebimentoParcela)
                .Include(rn => rn.RelacionaNormaAbntVenda)
                    .ThenInclude(n => n.NormaAbnt)
                .Include(ee => ee.EnderecoEntrega)
                .Include(ec => ec.EnderecoCobranca)
                .Include(i => i.ImpressaoEspecialTexto)
                .AsNoTracking()
                .Where(x => x.Id.Equals(id))
                .FirstOrDefaultAsync();

            if (venda != null)
            {
                var releases = await _dbContext.Venda
                     .Where(v => v.CodigoVenda == venda.CodigoVenda && v.AnoVenda == venda.AnoVenda)
                     .OrderByDescending(v => v.Release)
                     .Select(v => new { v.Id, v.Release, v.UpdateAt })
                     .ToListAsync();

                var releasesDto = releases
                    .Select((v, index) => new VendaReleaseDto
                    {
                        Id = v.Id,
                        Release = v.Release,
                        Data = v.UpdateAt,
                        UltimaRelease = index == 0 
                    })
                    .ToList();

                return new VendaByCodeDto
                {
                    Id = venda.Id,
                    IdStatus = venda.Status.Id,
                    Numero = FormatarCodigoAno(venda.CodigoVenda, venda.AnoVenda),
                    IdCliente = venda.IdCliente,                    
                    VendaOrdem = venda.VendaOrdem!.Select(item => new VendaOrdemDto
                    {
                        CaixilheiroObra = item.CaixilheiroObra,
                        IdCliente = item.IdCliente,
                        Endereco = new EnderecoVendaOrdemDto()
                        {
                            Id = item.Endereco!.Id,
                            IdTipoEndereco = item.Endereco.IdTipoEndereco,
                            Logradouro = item.Endereco.EnderecoDescricao,
                            Numero = item.Endereco.Numero,
                            Complemento = item.Endereco.Complemento,
                            IdCidade = item.Endereco.IdCidade,
                            Bairro = item.Endereco.Bairro,
                            IdUf = item.Endereco.IdUf,
                            Cep = item.Endereco.Cep
                        },
                        Observacao = item.Observacao
                    }).ToList(),
                    ImpressaoEspecial = venda.ImpressaoEspecial,
                    ImpressaoEspecialTexto = venda.ImpressaoEspecialTexto?.Texto,
                    FaturaManual = venda.FaturaManual,
                    OcutarVendedor = venda.SuprimiVendedor,
                    OcultarTotal = venda.SuprimirTotal,
                    ComIpi = venda.ComIpi,
                    VendaEntregaFutura = venda.VendaEntregaFutura,
                    UsoConsumo = venda.UsoConsumo,
                    PedidoCliente = venda.PedidoCliente,
                    PedidoGuardian = venda.PedidoGuardian,
                    EnvioMedidas = venda.EnvioMedidas,
                    IdResponsavelCompra = venda.IdResponsavelCompra,
                    IdConstrutora = venda.IdConstrutora,
                    IdVendedor = venda.IdVendedor,
                    NomeContato = venda.NomeContato,
                    EmailContato = venda.EmailContato,
                    TelefoneContato = venda.TelefoneContato,
                    DescricaoObra = venda.DescricaoObra,
                    NormaAbnt = venda.RelacionaNormaAbntVenda
                        .Select(n => n.NormaAbnt.Id)
                        .ToList(),
                    ValidadeOrcamentoDias = venda.ValidadeOrcamento.HasValue
                        ? (venda.ValidadeOrcamento.Value - DateTime.Now).Days
                        : 0,
                    ValidadePedidoDias = venda.ValidadePedido.HasValue
                        ? (venda.ValidadePedido.Value - DateTime.Now).Days
                        : 0,
                    ValidadeOrcamentoData = venda.ValidadeOrcamento,
                    ValidadePedidoData = venda.ValidadePedido,
                    Apfe = venda.Apfe,
                    Observacao = venda.Observacao,
                    EnderecoEntrega = venda.EnderecoEntrega == null ? null : new EnderecoDto
                    {
                        IdTipoEndereco = venda.EnderecoEntrega!.IdTipoEndereco,
                        Cep = venda.EnderecoEntrega.Cep,
                        EnderecoDescricao = venda.EnderecoEntrega.EnderecoDescricao,
                        Numero = venda.EnderecoEntrega.Numero,
                        Complemento = venda.EnderecoEntrega.Complemento,
                        Bairro = venda.EnderecoEntrega.Bairro,
                        IdCidade = venda.EnderecoEntrega.IdCidade,
                        IdUf = venda.EnderecoEntrega.IdUf,
                    },
                    EnderecoCobranca = venda.EnderecoCobranca == null ? null : new EnderecoDto
                    {
                        IdTipoEndereco = venda.EnderecoCobranca!.IdTipoEndereco,
                        Cep = venda.EnderecoCobranca.Cep,
                        EnderecoDescricao = venda.EnderecoCobranca.EnderecoDescricao,
                        Numero = venda.EnderecoCobranca.Numero,
                        Complemento = venda.EnderecoCobranca.Complemento,
                        Bairro = venda.EnderecoCobranca.Bairro,
                        IdCidade = venda.EnderecoCobranca.IdCidade,
                        IdUf = venda.EnderecoCobranca.IdUf
                    },
                    Produtos = venda.VendaItem!.Select(item => new FaturaProdutosDto
                    {
                        SequenciaItem = item.SequenciaItem,
                        IdProduto = item.IdProduto,
                        CodigoAmigavel = item.Produto.CodigoAmigavel,
                        DescricaoProduto = item.DescricaoProduto,
                        Jumbo = item.Jumbo,
                        InformacoesAdicionais = item.InformacoesAdicionais,
                        DescricaoPedidoCliente = item.DescricaoPedidoCliente,
                        NumeroItemPedidoCliente = item.NumeroItemPedidoCliente,
                        NumeroFCI = item.NumeroFci,
                        ValorFCI = item.ValorFci,
                        IdUnidadeMedida = item.IdUnidadeMedida,
                        Quantidade = item.Quantidade,
                        ValorUnitario = item.ValorUnitario,
                        PesoBruto = item.Produto.PesoBruto,
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
                        NaturezaOperacao = venda.NaturezaOperacao,
                        InformacoesAdicionais = venda.InformacoesAdicionais,
                        ValorFrete = venda.ValorFrete,
                        ValorSeguro = venda.ValorSeguro,
                        ValorOutrasDespesas = venda.ValorOutrasDespesas,
                        ValorTotalProdutos = venda.ValorTotalProdutos,
                        ValorBaseCalculoIcms = venda.ValorBaseCalculoIcms,
                        ValorIcms = venda.ValorIcms,
                        ValorIpi = venda.ValorIpi,
                        BaseCalculoSt = venda.BaseCalculoSt,
                        ValorSt = venda.ValorSt,
                        ValorTotal = venda.ValorTotal,
                        QuantidadeItens = venda.QuantidadeItens,
                        Especie = venda.Especie,
                        PesoBruto = venda.PesoBruto,
                        PesoLiquido = venda.PesoLiquido
                    },
                    Pagamento = new FaturaPagamentoDto
                    {
                        QuantidadeParcelas = venda.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo?.QuantidadeParcela ?? 0,
                        PagamentoAntecipado = venda.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo?.PagamentoAntecipado ?? false,
                        ParcelasPartirPedido = venda.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo?.ParcelaPartir == 1 ? true : false,
                        ParcelasPartirDiasDDL = venda.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo?.ParcelaPartir == 2 ? true : false,
                        PeriodoMensal = venda.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo?.Periodo == 1 ? true : false,
                        PeriodoDigitada = venda.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo?.Periodo == 2 ? true : false,
                        PeriodoDias = venda.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo?.Periodo == 3 ? true : false,
                        PeriodoQuantidadeDias = venda.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo?.QuantidadeDias ?? 0
                    },
                    PagamentoParcelas = venda.RelacionaFaturaVendaRecebimentoTipo?.VendaRecebimentoTipo.VendaRecebimentoParcela.Select(parcela => new FaturaPagamentoParcelasDto
                    {
                        SequenciaParcela = parcela.SequenciaParcela,
                        NumeroDiasVencimento = parcela.NumeroDiasVencimento,
                        DataVencimento = parcela.DataVencimento,
                        ValorParcela = parcela.ValorParcela
                    }).ToList(),
                    Transporte = new VendaTransporteDto
                    {
                        IdTransportadora = venda.IdTransportadora,
                        IdTipoFrete = venda.IdTipoFrete,
                        PlacaVeiculo = venda.PlacaVeiculoTransportadora,
                        IdUFVeiculo = venda.IdUfVeiculo,
                        Retira = venda.Retira,
                        Entrega = venda.Entrega,
                        InicioEntrega = venda.InicioEntrega,
                        TerminoEntrega = venda.TerminoEntrega,
                        FretesPrevistos = venda.FretesPrevistos,
                        ValorFrete = venda.PrecoCadaFrete,
                        ComFrete = venda.ComFrete,
                        DetalhesFrete = venda.MensagemFrete
                    },
                    Release = releasesDto,
                    IdTipoFechamento = venda.IdTipoFechamento,
                    Amostra = venda.Amostra
                };               
            }

            return null;
        }

        public async Task<PaginacaoResponse<TipoFreteFilterDto>> RetornarTipoFretePaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.TipoFrete.AsNoTracking();
            var data = query.Select(x => new TipoFreteFilterDto
            {
                Id = x.Id,
                NFrete = x.NFrete,
                Descricao = x.Descricao,
                DescricaoResumida = x.DescricaoResumida,
            });

            var response = await data.RetonarFiltroCustomizado<TipoFreteFilterDto, TipoFreteFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<TipoFreteByCodeDto?> RetornarTipoFretePorId(Guid id)
        {
            var tipoFrete = await _dbContext.TipoFrete
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (tipoFrete != null)
            {
                return new TipoFreteByCodeDto
                {
                    Id = tipoFrete.Id,
                    NFrete = tipoFrete.NFrete,
                    Descricao = tipoFrete.Descricao,    
                    DescricaoResumida = tipoFrete.DescricaoResumida
                };
            }

            return null;
        }

        public async Task<List<VendaOfRomaneioDto?>> RetornarVendaOfRomaneio(int sqOrdemFabricacaoCodigo, int sqOrdemFabricacaoAno)
        {
            string query = @"SELECT 
                                A.SQ_VENDA_CODIGO AS CodigoVenda, 
                                A.SQ_VENDA_ANO AS AnoVenda,
                                A.QT_FRETE as FretesPrevistos,
                                A.VL_PRECO_CADA_FRETE as PrecoCadaFrete,
                                SUM(E.QT_FRETE) AS QtdFretePorRomaneio
                            FROM TB_VENDA AS A
                                INNER JOIN TB_ORDEM_FABRICACAO AS B ON A.CD_VENDA = B.CD_VENDA
		                        INNER JOIN TB_ORDEM_FABRICACAO_ITEM AS C ON B.CD_ORDEM_FABRICACAO = C.CD_ORDEM_FABRICACAO
		                        INNER JOIN TB_ROMANEIO_ITEM AS D ON C.CD_ORDEM_FABRICACAO_ITEM = D.CD_ORDEM_FABRICACAO_ITEM
		                        INNER JOIN TB_ROMANEIO AS E ON D.CD_ROMANEIO = E.CD_ROMANEIO
                            WHERE 1 = 1 
                                AND A.BT_REMOVIDO = 0
                                AND B.BT_REMOVIDO = 0
                                AND C.BT_REMOVIDO = 0
                                AND D.BT_REMOVIDO = 0
                                AND E.BT_REMOVIDO = 0
                                AND B.SQ_ORDEM_FABRICACAO_CODIGO = @SqOrdemFabricacaoCodigo and 
                                b.SQ_ORDEM_FABRICACAO_ANO = @SqOrdemFabricacaoAno
                            Group by B.CD_ORDEM_FABRICACAO,
                                A.SQ_VENDA_CODIGO, 
                                A.SQ_VENDA_ANO,
                                A.QT_FRETE,
                                A.VL_PRECO_CADA_FRETE";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<VendaOfRomaneioDto?>(query, new { SqOrdemFabricacaoCodigo = sqOrdemFabricacaoCodigo, SqOrdemFabricacaoAno = sqOrdemFabricacaoAno });
            }
        }

        public async Task<List<OrcamentoPedidoImpressaoDto>> RetornarImpressao(Guid idVenda)
        {
            string query = @"select 
	                            '12345' AS pedido,
                                'Empresa Exemplo LTDA' AS empresa_razao_social,
                                'Rua Exemplo, 123' AS empresa_endereco,
                                '12345-678, Bairro Exemplo' AS empresa_cep_bairro,
                                'Cidade Exemplo, SP' AS empresa_cidade_uf,
                                '(11) 1234-5678' AS empresa_telefone,
                                'contato@empresa.com' AS empresa_e_mail,
                                'www.empresa.com' AS empresa_site,
                                'Cliente Exemplo' AS nome,
                                'Rua Cliente, 456' AS cob_cli_Ender,
                                'Bairro Cliente' AS cob_cli_bairro,
                                '12345-678, Cidade Cliente, SP' AS cob_cli_cep_cid_est,
                                '123.456.789.0001-00' AS ie,
                                'Rua Faturamento, 789' AS fat_cli_ender,
                                'Bairro Faturamento' AS fat_cli_bairro,
                                '12345-678, Cidade Faturamento, SP' AS fat_cli_cep_cid_est,
                                'Rua Entrega, 101' AS ent_cli_ender,
                                'Bairro Entrega' AS ent_cli_bairro,
                                '12345-678, Cidade Entrega, SP' AS ent_cli_cep_cid_est,
                                'cliente@email.com' AS cli_e_mail,
                                '123.456.789-00' AS cpf_cnpj,
                                'Contato Cliente' AS contato,
                                '(11) 98765-4321' AS telefone,
                                '(11) 99999-8888' AS celular,
                                'ABNT 12345' AS norma_abnt,
                                CONVERT(VARCHAR, GETDATE(), 103) AS data_criacao,
                                CONVERT(VARCHAR, GETDATE(), 108) AS hora_criacao,
                                CONVERT(VARCHAR, GETDATE(), 103) AS data_atualizacao,
                                CONVERT(VARCHAR, GETDATE(), 108) AS hora_atualizacao,
                                'Vendedor Exemplo' AS vendedor,
                                '(11) 91234-5678' AS celular_vendedor,
                                'vendedor@email.com' AS email_vendedor,
                                'Obra Exemplo' AS cli_obra,
                                'Aprovado' AS status,
                                '1.0' AS release,
                                '0' AS rascunho,
                                'Não' AS suprimir,
                                '1000.00' AS total_geral,
                                'Supervisor Exemplo' AS sup_vendedor,
                                '2' AS casas_decimais,
                                'ITEM001' AS cod_item,
                                '10' AS qtde,
                                'UN' AS um,
                                'Produto Exemplo' AS dsc_produto,
                                '100.00' AS vlr_unit,
                                '1000.00' AS vlr_tot,
                                'Texto de Cabeçalho Exemplo' AS texto_cabecalho,
                                'EMP001' AS cod_empresa,
                                'Mensagem de teste' AS mensagem,
                                -- Mock das linhas L001 a L045 com valores fictícios
                                'Linha 001' AS L001, 'Linha 002' AS L002, 'Linha 003' AS L003, 'Linha 004' AS L004, 
                                'Linha 005' AS L005, 'Linha 006' AS L006, 'Linha 007' AS L007, 'Linha 008' AS L008,
                                'Linha 009' AS L009, 'Linha 010' AS L010, 'Linha 011' AS L011, 'Linha 012' AS L012, 
                                'Linha 013' AS L013, 'Linha 014' AS L014, 'Linha 015' AS L015, 'Linha 016' AS L016, 
                                'Linha 017' AS L017, 'Linha 018' AS L018, 'Linha 019' AS L019, 'Linha 020' AS L020, 
                                'Linha 021' AS L021, 'Linha 022' AS L022, 'Linha 023' AS L023, 'Linha 024' AS L024, 
                                'Linha 025' AS L025, 'Linha 026' AS L026, 'Linha 027' AS L027, 'Linha 028' AS L028, 
                                'Linha 029' AS L029, 'Linha 030' AS L030, 'Linha 031' AS L031, 'Linha 032' AS L032, 
                                'Linha 033' AS L033, 'Linha 034' AS L034, 'Linha 035' AS L035, 'Linha 036' AS L036, 
                                'Linha 037' AS L037, 'Linha 038' AS L038, 'Linha 039' AS L039, 'Linha 040' AS L040, 
                                'Linha 041' AS L041, 'Linha 042' AS L042, 'Linha 043' AS L043, 'Linha 044' AS L044, 
                                'Linha 045' AS L045
                            from 
	                            Cratos.dbo.TB_VENDA as a 	                            
                            where
	                            a.CD_VENDA = @idVenda";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<OrcamentoPedidoImpressaoDto>(query, new
                {
                    idVenda = idVenda
                });
            }
        }

   
        public async Task<List<OrcamentoPedidoImpressaoDto>> RetornarImpressaoNew(Guid idVenda, bool especial, bool orcamento, Guid idCliente, bool suprimirVendedor)
        {
            string query = @"EXEC dbo.PR_RELATORIO_PEDIDO 
                                      @CD_VENDA = @idVenda, 
                                      @BT_ESPECIAL = @especial,
                                      @ORCAMENTO = @orcamento,
                                      @CD_EMPRESA = @idCliente,
                                      @BT_SUPRIMIR_VENDEDOR = @suprimirVendedor";

            using (var connection = _dbContext.Database.GetDbConnection())
            {
                return await connection.RetornarListDapper<OrcamentoPedidoImpressaoDto>(query, new
                {
                    idVenda = idVenda,
                    especial = especial,
                    orcamento = orcamento,
                    idCliente = idCliente,
                    suprimirVendedor = suprimirVendedor
                });
            }
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarTipoFechamentoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.TipoFechamento.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Nome
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }
    }
}