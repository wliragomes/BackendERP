using Application.DTOs.Vendas.Filtro;
using Application.Interfaces.Vendas;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using AutoMapper;
using SharedKernel.MediatR;
using Application.Interfaces.Queries;
using Domain.Commands.Vendas.Adicionar;
using Domain.Commands.Vendas.Atualizar;
using Application.DTOs.Venda.Adicionar;
using Application.DTOs.Venda.Atualizar;
using Application.DTOs.Venda.Excluir;
using Domain.Commands.Vendas.Excluir;
using Application.DTOs.TiposFretes.Adicionar;
using Application.DTOs.TiposFretes.Atualizar;
using Application.DTOs.TiposFretes.Filtro;
using Application.DTOs.Vendas.TiposFretes.Filtro;
using Application.DTOs.TiposFretes.Excluir;
using Domain.Commands.TipoFretes.Excluir;
using Domain.Commands.TipoFretes.Atualizar;
using Domain.Commands.TipoFretes.Adicionar;
using Microsoft.Reporting.NETCore;
using Application.DTOs.Pessoas.Filtro;

namespace Application.Services.Vendas
{
    public class VendaService : IVendaService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IVendaQuery _vendaQuery;

        public VendaService(IMapper mapper, IMediatrHandler mediatorHandler, IVendaQuery vendaQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _vendaQuery = vendaQuery;
        }

        public async Task<FormularioResponse<AdicionarVendaCommand>> Adicionar(AdicionarVendaRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarVendaCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarVendaCommand>> Atualizar(AtualizarVendaRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarVendaCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirVendaCommand>>> Excluir(ExcluirVendaDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirVendaCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirVendaCommand, ExcluirVendaCommand>(commands);
        }

        public async Task<PaginacaoResponse<VendaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _vendaQuery.RetornarPaginacao(paginacaoRequest);
        }

        //public async Task<PaginacaoResponse<VendaOrdemFabricacaoFilterDto>> RetornarOrdemFabricacaoPaginacao(PaginacaoRequest paginacaoRequest)
        //{
        //    return await _vendaQuery.RetornarOrdemFabricacaoPaginacao(paginacaoRequest);
        //}

        public async Task<List<VendaOfRomaneioDto?>> RetornarVendaOfRomaneio(int sqOrdemFabricacaoCodigo, int sqOrdemFabricacaoAno)
        {
            return await _vendaQuery.RetornarVendaOfRomaneio(sqOrdemFabricacaoCodigo, sqOrdemFabricacaoAno);
        }

        public async Task<VendaByCodeDto?> RetornarPorId(Guid id)
        {
            return await _vendaQuery.RetornarPorId(id);
        }   

        public async Task<VendaOrdemFabricacaoFilterDto?> RetornarOrdemFabricacao(string codigoAnoVenda)
        {
            return await _vendaQuery.RetornarOrdemFabricacao(codigoAnoVenda);
        }           

        public async Task<FormularioResponse<AdicionarTipoFreteCommand>> AdicionarTipoFrete(AdicionarTipoFreteRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarTipoFreteCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarTipoFreteCommand>> AtualizarTipoFrete(AtualizarTipoFreteRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarTipoFreteCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirTipoFreteCommand>>> ExcluirTipoFrete(ExcluirTipoFreteDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirTipoFreteCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirTipoFreteCommand, ExcluirTipoFreteCommand>(commands);
        }

        public async Task<PaginacaoResponse<TipoFreteFilterDto>> RetornarTipoFretePaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _vendaQuery.RetornarTipoFretePaginacao(paginacaoRequest);
        }

        public async Task<TipoFreteByCodeDto?> RetornarTipoFretePorId(Guid id)
        {
            return await _vendaQuery.RetornarTipoFretePorId(id);
        }

        public async Task<byte[]> RetornarImpressao(Guid idVenda, bool especial, bool orcamento, Guid idCliente, bool suprimirVendedor)
        {
            try
            {
                // Caminho do arquivo RDLC
                var nomeArquivo = "";

                if (orcamento)
                {
                    if (especial)
                    {
                        nomeArquivo = "relOrcamentoEspecial.rdlc";
                    }
                    else
                    {
                        nomeArquivo = "relOrcamento.rdlc";
                    }
                }
                else
                {
                    if (especial)
                    {
                        nomeArquivo = "relPedidoEspecial.rdlc";
                    }
                    else
                    {
                        nomeArquivo = "relPedido.rdlc";
                    }
                }
                
                var relatorioPath = Path.Combine(Directory.GetCurrentDirectory(), "Relatorios", nomeArquivo);

                if (!System.IO.File.Exists(relatorioPath))
                {
                    throw new FileNotFoundException("Arquivo RDLC não encontrado no caminho: " + relatorioPath);
                }

                // Configurar o ReportViewer
                using var localReport = new LocalReport();
                using var stream = new FileStream(relatorioPath, FileMode.Open, FileAccess.Read);
                localReport.LoadReportDefinition(stream);

                // Configurar o parâmetro
                localReport.SetParameters(new[] {
                    new ReportParameter("idVenda", idVenda.ToString())
                });

                // Configurar os dados
                var dadosFiltrados = await _vendaQuery.RetornarImpressaoNew(idVenda, especial, orcamento, idCliente, suprimirVendedor);

                localReport.DataSources.Add(new ReportDataSource("DataSetOrcamento", dadosFiltrados));

                // Renderizar o relatório como PDF
                var pdfBytes = localReport.Render("PDF");

                return pdfBytes;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao gerar o relatório: {ex.Message}");
            }
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarTipoFechamentoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _vendaQuery.RetornarTipoFechamentoPaginacao(paginacaoRequest);
        }
    }
}
